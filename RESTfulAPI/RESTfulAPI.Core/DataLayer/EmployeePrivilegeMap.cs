// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using RESTfulAPI.Core.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace RESTfulAPI.Core.DataLayer
{
    public class EmployeePrivilegeMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<EmployeePrivilege>();
            entity.ToTable("employee_privileges");
            entity.HasKey(p => new { p.Employee_Id });
            //entity.Property(p => p.Id).UseMySqlIdentityColumn();
        }
    }
}