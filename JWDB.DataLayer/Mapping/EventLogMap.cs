﻿using JWDB.EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWDB.DataLayer.Mapping
{
    public class EventLogMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<EventLog>();

            entity.ToTable("EventLog", "dbo");

            entity.HasKey(p => p.EventLogID);

            entity.Property(p => p.EventLogID).UseSqlServerIdentityColumn();
        }
    }
}
