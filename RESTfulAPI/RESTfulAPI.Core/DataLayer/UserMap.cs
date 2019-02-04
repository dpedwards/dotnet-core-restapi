// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using RESTfulAPI.Core.EntityLayer;

namespace RESTfulAPI.Core.DataLayer
{
    public class UserMap : IEntityMap
    {

        public void Map(ModelBuilder modelBuilder)
        {
          
                var entity = modelBuilder.Entity<User>();
                entity.ToTable("user");
                entity.HasKey(p => new { p.Id });
                entity.Property(p => p.Id).UseMySqlIdentityColumn();
                //entity.Property(p => p.Id ).UseSqlServerIdentityColumn();
           
        }


    }
}
