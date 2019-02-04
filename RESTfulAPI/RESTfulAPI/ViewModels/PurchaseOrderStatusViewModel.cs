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
    public class PurchaseOrderStatusViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? Id { get; set; } // ~ MySql INT datatype 

        /// <summary>
        /// 
        /// </summary>
        public String Status { get; set; } // ~ MySql VARCHAR datatype

    }
}
