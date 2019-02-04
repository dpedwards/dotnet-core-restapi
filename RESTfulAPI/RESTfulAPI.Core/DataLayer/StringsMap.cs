// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using RESTfulAPI.Core.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace RESTfulAPI.Core.DataLayer
{
    public class StringsMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Strings>();
            entity.ToTable("strings");
            entity.HasKey(p => new { p.String_Id });
            entity.Property(p => p.String_Id).UseMySqlIdentityColumn();
        }
    }
}
