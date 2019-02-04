// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using RESTfulAPI.Core.EntityLayer;
using Microsoft.EntityFrameworkCore;


namespace RESTfulAPI.Core.DataLayer
{
    public class CustomerMap : IEntityMap
    {

        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Customer>();
            entity.ToTable("customers"); 
            entity.HasKey(p => new {p.Id});
            entity.Property(p => p.Id).UseMySqlIdentityColumn();
            entity.Property(p => p.Id ).UseSqlServerIdentityColumn();
        }


    }
}


