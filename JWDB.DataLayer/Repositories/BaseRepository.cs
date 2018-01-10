using JWDB.EntityLayer;
using JWDB.EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JWDB.DataLayer.Repositories
{
    public abstract class BaseRepository
    {
        protected IUserInfo UserInfo;
        protected JWDbContext DbContext;

        public BaseRepository(IUserInfo userInfo, JWDbContext dbContext)
        {
            UserInfo = userInfo;
            DbContext = dbContext;
        }

        protected virtual void Add(IEntity entity)
        {
            var cast = entity as IAuditEntity;

            if (cast != null)
            {
                cast.RegId = UserInfo.Name;
                cast.RegDtm = DateTime.Now;
            }
        }

        protected virtual void Update(IEntity entity)
        {
            var cast = entity as IAuditEntity;

            if (cast != null)
            {
                cast.UpdId = UserInfo.Name;

                if (!cast.UpdDtm.HasValue)
                {
                    cast.UpdDtm = DateTime.Now;
                }
            }
        }

        protected virtual IEnumerable<ChangeLog> GetChanges()
        {
            foreach (var entry in DbContext.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Modified)
                {
                    var entityType = entry.Entity.GetType();

                    foreach (var property in entityType.GetTypeInfo().DeclaredProperties)
                    {
                        var originalValue = entry.Property(property.Name).OriginalValue;
                        var currentValue = entry.Property(property.Name).CurrentValue;

                        if (String.Concat(originalValue) != String.Concat(currentValue))
                        {
                            yield return new ChangeLog
                            {
                                ClassNm = entityType.Name,
                                PropertyNm = property.Name,
                                OriginalValue = originalValue == null ? String.Empty : originalValue.ToString(),
                                CurrentValue = currentValue == null ? String.Empty : currentValue.ToString(),
                                UserNm = UserInfo.Name,
                                ChangeDtm = DateTime.Now
                            };
                        }
                    }
                }
            }
        }

        protected void CommitChanges()
        {
            var dbSet = DbContext.Set<ChangeLog>();

            foreach (var change in GetChanges().ToList())
            {
                dbSet.Add(change);
            }

            DbContext.SaveChanges();
        }
    }
}
