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
    public static class PurchaseOrderViewModelMapper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PurchaseOrderViewModel ToViewModel(this PurchaseOrder entity)
        {

            return entity == null ? null : new PurchaseOrderViewModel
            {

                Id = entity.Id,
                Supplier_Id = entity.Supplier_Id,
                Created_By = entity.Created_By,
                Submitted_Date = entity.Submitted_Date,
                Creation_Date = entity.Creation_Date,
                Status_Id = entity.Status_Id,
                Expected_Date = entity.Expected_Date,
                Shipping_Fee = entity.Shipping_Fee,
                Taxes = entity.Taxes,
                Payment_Date = entity.Payment_Date,
                Payment_Amount = entity.Payment_Amount,
                Payment_Method = entity.Payment_Method,
                Notes = entity.Notes,
                Approved_By = entity.Approved_By,
                Approved_Date = entity.Approved_Date,
                Submitted_By = entity.Submitted_By



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
        public static PurchaseOrder ToEntity(this PurchaseOrderViewModel viewModel)
        {
            return viewModel == null ? null : new PurchaseOrder
            {
                Id = viewModel.Id,

                Supplier_Id = viewModel.Supplier_Id,
                Created_By = viewModel.Created_By,
                Submitted_Date = viewModel.Submitted_Date,
                Creation_Date = viewModel.Creation_Date,
                Status_Id = viewModel.Status_Id,
                Expected_Date = viewModel.Expected_Date,
                Shipping_Fee = viewModel.Shipping_Fee,
                Taxes = viewModel.Taxes,
                Payment_Date = viewModel.Payment_Date,
                Payment_Amount = viewModel.Payment_Amount,
                Payment_Method = viewModel.Payment_Method,
                Notes = viewModel.Notes,
                Approved_By = viewModel.Approved_By,
                Approved_Date = viewModel.Approved_Date,
                Submitted_By = viewModel.Submitted_By


                
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}
