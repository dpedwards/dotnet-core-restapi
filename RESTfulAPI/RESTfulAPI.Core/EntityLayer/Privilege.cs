// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;


namespace RESTfulAPI.Core.EntityLayer
{
    // MySql Northwind db privilege_name table
    public class Privilege
    {

        public Int32? Id { get; set; }

        public String Privilege_Name { get; set; } // ~ MySql VARCHAR datatype

    }
}
