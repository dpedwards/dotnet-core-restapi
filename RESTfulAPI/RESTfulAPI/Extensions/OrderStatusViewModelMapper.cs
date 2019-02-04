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
    public static class OrderStatusViewModelMapper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static OrderStatusViewModel ToViewModel(this OrderStatus entity)
        {

            return entity == null ? null : new OrderStatusViewModel
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
        public static OrderStatus ToEntity(this OrderStatusViewModel viewModel)
        {
            return viewModel == null ? null : new OrderStatus
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
