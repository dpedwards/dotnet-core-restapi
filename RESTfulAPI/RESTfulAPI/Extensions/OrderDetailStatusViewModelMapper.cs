// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using RESTfulAPI.Core.EntityLayer;
using RESTfulAPI.ViewModels;

namespace RESTfulAPI.Extensions
{

    /// <summary>
    /// 
    /// </summary>
    public static class OrderDetailStatusViewModelMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static OrderDetailStatusViewModel ToViewModel(this OrderDetailStatus entity)
        {

            return entity == null ? null : new OrderDetailStatusViewModel
            {

                Id = entity.Id,

                Status_Name = entity.Status_Name



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
        public static OrderDetailStatus ToEntity(this OrderDetailStatusViewModel viewModel)
        {
            return viewModel == null ? null : new OrderDetailStatus
            {
                Id = viewModel.Id,
               
                Status_Name = viewModel.Status_Name

                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}

