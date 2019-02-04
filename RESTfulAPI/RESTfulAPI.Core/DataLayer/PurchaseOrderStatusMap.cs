// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using RESTfulAPI.Core.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace RESTfulAPI.Core.DataLayer
{
    public class PurchaseOrderStatusMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<PurchaseOrderStatus>();
            entity.ToTable("purchase_order_status");
            entity.HasKey(p => new { p.Id });
            entity.Property(p => p.Id).UseMySqlIdentityColumn();
        }
    }
}
