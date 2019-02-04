// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using RESTfulAPI.Core.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace RESTfulAPI.Core.DataLayer
{
    public class SalesReportMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<SalesReport>();
            entity.ToTable("sales_reports");
            entity.HasKey(p => new { p.Group_By });
            //entity.Property(p => p.Group_By).UseMySqlIdentityColumn();
        }
    }
}
