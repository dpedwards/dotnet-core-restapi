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
    public static class OrderDetailViewModelMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static OrderDetailViewModel ToViewModel(this OrderDetail entity)
        {

            return entity == null ? null : new OrderDetailViewModel
            {

                Id = entity.Id,
                Order_Id = entity.Order_Id,
                Product_Id = entity.Product_Id,
                Quantity = entity.Quantity,
                Unit_Price = entity.Unit_Price,
                Discount = entity.Discount,
                Status_Id = entity.Status_Id,
                Date_Allocated = entity.Date_Allocated,
                Purchase_Order_Id = entity.Purchase_Order_Id,
                Inventory_Id = entity.Inventory_Id

                //RowGuid = entity.RowGuid,
                //ModifiedDate = entity.ModifiedDate

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static OrderDetail ToEntity(this OrderDetailViewModel viewModel)
        {
            return viewModel == null ? null : new OrderDetail
            {
                Id = viewModel.Id,

                Order_Id = viewModel.Order_Id,
                Product_Id = viewModel.Product_Id,
                Quantity = viewModel.Quantity,
                Unit_Price = viewModel.Unit_Price,
                Discount = viewModel.Discount,
                Status_Id = viewModel.Status_Id,
                Date_Allocated = viewModel.Date_Allocated,
                Purchase_Order_Id = viewModel.Purchase_Order_Id,
                Inventory_Id = viewModel.Inventory_Id

                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}

