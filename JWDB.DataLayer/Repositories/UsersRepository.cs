using JWDB.DataLayer.Contracts;
using JWDB.EntityLayer;
using JWDB.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWDB.DataLayer.Repositories
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public UsersRepository(IUserInfo userInfo, JWDbContext dbContext) : base(userInfo, dbContext)
        { 
        }
        public void AddUser(TaUser user)
        {
            throw new NotImplementedException();
        }

        public TaUser GetUSer(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaUser> GetUsers(int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(TaUser user)
        {
            throw new NotImplementedException();
        }
    }
}
