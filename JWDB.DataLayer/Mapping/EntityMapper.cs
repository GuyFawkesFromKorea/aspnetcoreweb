using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWDB.DataLayer.Mapping
{
    public class EntityMapper : IEntityMapper
    {
        public EntityMapper()
        {
        }

        public IEnumerable<IEntityMap> Mappings { get; set; }

        public void MapEntities(ModelBuilder modelBuilder)
        {
            foreach (var item in Mappings) { item.Map(modelBuilder); }
        }
    }
}
