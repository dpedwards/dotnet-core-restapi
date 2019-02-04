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
    public static class PurchaseOrderDetailViewModelMapper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseOrderDetailViewModel ToViewModel(this PurchaseOrderDetail entity)
        {

            return entity == null ? null : new PurchaseOrderDetailViewModel
            {

                Id = entity.Id,
                Purchase_Order_Id = entity.Purchase_Order_Id,
                Product_Id = entity.Product_Id,
                Quantity = entity.Quantity,
                Unit_Cost = entity.Unit_Cost,
                Date_Received = entity.Date_Received,
                Posted_To_Inventory = entity.Posted_To_Inventory,
                Inventory_Id = entity.Inventory_Id



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
        public static PurchaseOrderDetail ToEntity(this PurchaseOrderDetailViewModel viewModel)
        {
            return viewModel == null ? null : new PurchaseOrderDetail
            {
                Id = viewModel.Id,
               
                Purchase_Order_Id = viewModel.Purchase_Order_Id,
                Product_Id = viewModel.Product_Id,
                Quantity = viewModel.Quantity,
                Unit_Cost = viewModel.Unit_Cost,
                Date_Received = viewModel.Date_Received,
                Posted_To_Inventory = viewModel.Posted_To_Inventory,
                Inventory_Id = viewModel.Inventory_Id


                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}
