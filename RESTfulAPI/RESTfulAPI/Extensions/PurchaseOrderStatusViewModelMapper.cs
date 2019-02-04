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
    public static class PurchaseOrderStatusViewModelMapper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseOrderStatusViewModel ToViewModel(this PurchaseOrderStatus entity)
        {

            return entity == null ? null : new PurchaseOrderStatusViewModel
            {

                Id = entity.Id,
                Status = entity.Status



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
        public static PurchaseOrderStatus ToEntity(this PurchaseOrderStatusViewModel viewModel)
        {
            return viewModel == null ? null : new PurchaseOrderStatus
            {
                Id = viewModel.Id,
                Status = viewModel.Status


                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}
