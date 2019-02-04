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
    public static class InvoiceViewModelMapper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InvoiceViewModel ToViewModel(this Invoice entity)
        {

            return entity == null ? null : new InvoiceViewModel
            {

                Id = entity.Id,
                Order_Id = entity.Order_Id,
                Invoice_Date = entity.Invoice_Date,
                Due_Date = entity.Due_Date,
                Tax = entity.Tax,
                Shipping = entity.Shipping,
                Amount_Due = entity.Shipping
                



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
        public static Invoice ToEntity(this InvoiceViewModel viewModel)
        {
            return viewModel == null ? null : new Invoice
            {
                Id = viewModel.Id,
                Order_Id = viewModel.Order_Id,
                Invoice_Date = viewModel.Invoice_Date,
                Due_Date = viewModel.Due_Date,
                Tax = viewModel.Tax,
                Shipping = viewModel.Shipping,
                Amount_Due = viewModel.Shipping
                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}
