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
    public class SalesReportViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? Id { get; set; } // ~ MySql INT datatype 

        /// <summary>
        /// 
        /// </summary>
        public String Group_By { get; set; } // ~ MySql VARCHAR datatype

        /// <summary>
        /// 
        /// </summary>
        public String Display { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Filter_Row_Source { get; set; } // ~ MySql LONGTEXT datatype 

        /// <summary>
        /// 
        /// </summary>
        public Boolean Default { get; set; } // ~ MySql TINYINT 1 datatype  

    }
}
