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
    public class InvoiceViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Int32? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Order_Id { get; set; } // ~ MySql INT datatype

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Invoice_Date { get; set; } // ~ MySql DATETIME datatype

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Due_Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? Tax { get; set; } // ~ MySql DECIMAL datatype

        /// <summary>
        /// 
        /// </summary>
        public Decimal? Shipping { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? Amount_Due { get; set; }
    }
}
