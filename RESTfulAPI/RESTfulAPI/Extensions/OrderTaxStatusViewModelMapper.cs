// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RESTfulAPI.Core.EntityLayer;
using RESTfulAPI.ViewModels;

namespace RESTfulAPI.Extensions
{

    /// <summary>
    /// 
    /// </summary>
    public static class OrderTaxStatusTaxStatusViewModelMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static OrderTaxStatusViewModel ToViewModel(this OrderTaxStatus entity)
        {

            return entity == null ? null : new OrderTaxStatusViewModel
            {

                Id = entity.Id,

                Tax_Status_Name = entity.Tax_Status_Name



                //
                //RowGuid = entity.RowGuid,
                //ModifiedDate = entity.ModifiedDate

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static OrderTaxStatus ToEntity(this OrderTaxStatusViewModel viewModel)
        {
            return viewModel == null ? null : new OrderTaxStatus
            {
                Id = viewModel.Id,
                
                Tax_Status_Name = viewModel.Tax_Status_Name

                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}

