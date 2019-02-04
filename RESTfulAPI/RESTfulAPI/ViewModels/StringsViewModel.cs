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
    public class StringsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? String_Id { get; set; } // ~ MySql INT datatype

        /// <summary>
        /// 
        /// </summary>
        public String String_Data { get; set; } // ~ MySql VARCHAR datatype 

    }
}
