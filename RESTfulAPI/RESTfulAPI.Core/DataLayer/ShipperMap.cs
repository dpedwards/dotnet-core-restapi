// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using RESTfulAPI.Core.EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTfulAPI.Core.DataLayer
{
    public class ShipperMap : IEntityMap
    {

        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Shipper>();
            entity.ToTable("shippers");
            entity.HasKey(p => new { p.Id });
            entity.Property(p => p.Id).UseMySqlIdentityColumn();
            //entity.Property(p => p.Id ).UseSqlServerIdentityColumn();
        }


    }
}
