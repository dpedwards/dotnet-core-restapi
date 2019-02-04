// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace RESTfulAPI.Core.DataLayer
{
    public class EntityMapper : IEntityMapper
    {

        public IEnumerable<IEntityMap> Mappings { get; protected set; }


        public void MapEntities(ModelBuilder modelBuilder)
        {
            foreach (var item in Mappings)
            {
                item.Map(modelBuilder);
            }
        }

    }
}