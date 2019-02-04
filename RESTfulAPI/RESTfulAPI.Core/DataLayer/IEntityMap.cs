// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using Microsoft.EntityFrameworkCore;

namespace RESTfulAPI.Core.DataLayer
{
    public interface IEntityMap
    {
        void Map(ModelBuilder modelBuilder);
    }
}
