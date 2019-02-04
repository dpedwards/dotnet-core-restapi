// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RESTfulAPI.Core.DataLayer
{
    public interface IEntityMapper
    {

        IEnumerable<IEntityMap> Mappings { get; }

        void MapEntities(ModelBuilder modelBuilder);

    }
}
