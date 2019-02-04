// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;


namespace RESTfulAPI.Core.EntityLayer
{
    // MySql Northwind db employee table
    public class Employee
    {

        public Int32? Id { get; set; } // ~ MySql INT datatype

        public String Company { get; set; }
        public String Last_Name { get; set; }
        public String First_Name { get; set; }
        public String Email_Address { get; set; }
        public String Job_Title { get; set; }
        public String Business_Phone { get; set; }
        public String Home_Phone { get; set; }
        public String Mobile_Phone { get; set; }
        public String Fax_Number { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String State_Province { get; set; }
        public String Zip_Postal_Code { get; set; }
        public String Country_Region { get; set; }
        public String Web_Page { get; set; }
        public String Notes { get; set; }
        public Byte[] Attachments { get; set; } // ~ MySql LONGBLOB datatype

    }
}
