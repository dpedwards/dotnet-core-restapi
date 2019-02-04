// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================


using Microsoft.Extensions.Options;
using System;
using Microsoft.EntityFrameworkCore;
using RESTfulAPI.Core.AppSettingsLayer;

namespace RESTfulAPI.Core.DataLayer
{

    public class RESTfulAPI_DbContext : DbContext
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appSettings"></param>
        /// <param name="entityMapper"></param>
        public RESTfulAPI_DbContext(IOptions<DatabaseSettings> appSettings, IEntityMapper entityMapper)
        {
            ConnectionString = appSettings.Value.ConnectionString;
            EntityMapper = entityMapper;
        }

        public String ConnectionString { get; } // MySql
       

        public IEntityMapper EntityMapper { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseMySql(ConnectionString);
            //optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityMapper.MapEntities(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
