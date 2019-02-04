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
    public class EmployeeViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Company { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Last_Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String First_Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Email_Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Job_Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Business_Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Home_Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Mobile_Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Fax_Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String State_Province { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Zip_Postal_Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Country_Region { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Web_Page { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Notes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Byte[] Attachments { get; set; } // ~ MySql LONGBLOB datatype

    }
}
