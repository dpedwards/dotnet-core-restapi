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
    public static class OrderViewModelMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static OrderViewModel ToViewModel(this Order entity)
        {

            return entity == null ? null : new OrderViewModel
            {

                Id = entity.Id,
                
                //TransactionId = entity.TransactionId,
                Employee_Id = entity.Employee_Id,
                Customer_Id = entity.Customer_Id,
                Order_Date = entity.Order_Date,
                Shipped_Date = entity.Shipped_Date,
                Shipper_Id = entity.Shipper_Id,
                Ship_Name = entity.Ship_Name,
                Ship_Address = entity.Ship_Address,
                Ship_City = entity.Ship_City,
                Ship_State_Province = entity.Ship_State_Province,
                Ship_Zip_Postal_Code = entity.Ship_Zip_Postal_Code,
                Ship_Country_Region = entity.Ship_Country_Region,
                Shipping_Fee = entity.Shipping_Fee,
                Taxes = entity.Taxes,
                Payment_Type = entity.Payment_Type,
                Paid_Date = entity.Paid_Date,
                Notes = entity.Notes,
                Tax_Rate = entity.Tax_Rate,
                Tax_Status_Id = entity.Tax_Status_Id,
                Status_Id = entity.Status_Id
               
              



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
        public static Order ToEntity(this OrderViewModel viewModel)
        {
            return viewModel == null ? null : new Order
            {
                Id = viewModel.Id,
                //TransactionId = entity.TransactionId,
                Employee_Id = viewModel.Employee_Id,
                Customer_Id = viewModel.Customer_Id,
                Order_Date = viewModel.Order_Date,
                Shipped_Date = viewModel.Shipped_Date,
                Shipper_Id = viewModel.Shipper_Id,
                Ship_Name = viewModel.Ship_Name,
                Ship_Address = viewModel.Ship_Address,
                Ship_City = viewModel.Ship_City,
                Ship_State_Province = viewModel.Ship_State_Province,
                Ship_Zip_Postal_Code = viewModel.Ship_Zip_Postal_Code,
                Ship_Country_Region = viewModel.Ship_Country_Region,
                Shipping_Fee = viewModel.Shipping_Fee,
                Taxes = viewModel.Taxes,
                Payment_Type = viewModel.Payment_Type,
                Paid_Date = viewModel.Paid_Date,
                Notes = viewModel.Notes,
                Tax_Rate = viewModel.Tax_Rate,
                Tax_Status_Id = viewModel.Tax_Status_Id,
                Status_Id = viewModel.Status_Id

              

                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}

