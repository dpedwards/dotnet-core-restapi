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
    public class UserViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Password { get; set; }
    }
}
