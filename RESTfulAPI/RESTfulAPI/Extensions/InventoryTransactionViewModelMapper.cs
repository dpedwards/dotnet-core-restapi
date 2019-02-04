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
    public static class InventoryTransactionViewModelMapper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryTransactionViewModel ToViewModel(this InventoryTransaction entity)
        {

            return entity == null ? null : new InventoryTransactionViewModel
            {

                Id = entity.Id,
                Transaction_Type = entity.Transaction_Type,
                Transaction_Created_Date = entity.Transaction_Created_Date,
                Transaction_Modified_Date = entity.Transaction_Modified_Date,
                Product_Id = entity.Product_Id,
                Quantity = entity.Quantity,
                Purchase_Order_Id = entity.Purchase_Order_Id,
                Customer_Order_Id = entity.Customer_Order_Id,
                Comments = entity.Comments



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
        public static InventoryTransaction ToEntity(this InventoryTransactionViewModel viewModel)
        {
            return viewModel == null ? null : new InventoryTransaction
            {
                Id = viewModel.Id,
                Transaction_Type = viewModel.Transaction_Type,
                Transaction_Created_Date = viewModel.Transaction_Created_Date,
                Transaction_Modified_Date = viewModel.Transaction_Modified_Date,
                Product_Id = viewModel.Product_Id,
                Quantity = viewModel.Quantity,
                Purchase_Order_Id = viewModel.Purchase_Order_Id,
                Customer_Order_Id = viewModel.Customer_Order_Id,
                Comments = viewModel.Comments

                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}
