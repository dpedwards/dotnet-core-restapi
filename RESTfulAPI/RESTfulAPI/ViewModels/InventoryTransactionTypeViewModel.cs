// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using System.Runtime.Serialization;

namespace RESTfulAPI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class InventoryTransactionTypeViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? Id { get; set; } // ~ MySql TINYINT datatype 

        /// <summary>
        /// 
        /// </summary>
        public String Type_Name { get; set; } // ~ MySql VARCHAR datatype 
    }
}
