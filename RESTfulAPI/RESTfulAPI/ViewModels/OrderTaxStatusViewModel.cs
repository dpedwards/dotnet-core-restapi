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
    public class OrderTaxStatusViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? Id { get; set; }  // ~ MySql INT datatype


        /// <summary>
        /// 
        /// </summary>
        public String Tax_Status_Name { get; set; } // ~ MySql VARCHAR datatype

    }
}
