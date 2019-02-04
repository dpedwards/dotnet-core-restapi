// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using System.Runtime.Serialization;

namespace RESTfulAPI.Core.EntityLayer
{
    public class User
    {

        [IgnoreDataMember]
        public Int32? Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }

    }
}
