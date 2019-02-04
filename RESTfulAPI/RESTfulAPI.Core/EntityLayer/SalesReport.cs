// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;

namespace RESTfulAPI.Core.EntityLayer
{

    // MySql Northdinw db sales_reports table 
    public class SalesReport
    {
      
        public Int32? Id { get; set; } // ~ MySql INT datatype 

        public String Group_By { get; set; } // ~ MySql VARCHAR datatype
        public String Display { get; set; } 
        public String Title { get; set; } 
        public String Filter_Row_Source { get; set; } // ~ MySql LONGTEXT datatype 
        public Boolean Default { get; set; } // ~ MySql TINYINT 1 datatype  

    }
}
