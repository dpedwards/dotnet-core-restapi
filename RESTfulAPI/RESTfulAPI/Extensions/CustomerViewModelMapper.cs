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
    public static class CustomerViewModelMapper
    { 

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static CustomerViewModel ToViewModel(this Customer entity)
    {

        return entity == null ? null : new CustomerViewModel
        {

            //Id = entity.Id,
            Company = entity.Company,
            //TransactionId = entity.TransactionId,
            Last_Name = entity.Last_Name,
            First_Name = entity.First_Name,
            Email_Address = entity.Email_Address,
            Job_Title = entity.Job_Title,
            Business_Phone = entity.Business_Phone,
            Home_Phone = entity.Home_Phone,
            Mobile_Phone = entity.Mobile_Phone,
            Fax_Number = entity.Fax_Number,
            Address = entity.Address,
            City = entity.City,
            State_Province = entity.State_Province,
            Zip_Postal_Code = entity.Zip_Postal_Code,
            Country_Region = entity.Country_Region,
            Web_Page = entity.Web_Page,
            Notes = entity.Notes,
            Attachments = entity.Attachments
           


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
    public static Customer ToEntity(this CustomerViewModel viewModel)
    {
        return viewModel == null ? null : new Customer
        {
            //Id = viewModel.Id,
            Company = viewModel.Company,
            //TransactionId = entity.TransactionId,
            Last_Name = viewModel.Last_Name,
            First_Name = viewModel.First_Name,
            Email_Address = viewModel.Email_Address,
            Job_Title = viewModel.Job_Title,
            Business_Phone = viewModel.Business_Phone,
            Home_Phone = viewModel.Home_Phone,
            Mobile_Phone = viewModel.Mobile_Phone,
            Fax_Number = viewModel.Fax_Number,
            Address = viewModel.Address,
            City = viewModel.City,
            State_Province = viewModel.State_Province,
            Zip_Postal_Code = viewModel.Zip_Postal_Code,
            Country_Region = viewModel.Country_Region,
            Web_Page = viewModel.Web_Page,
            Notes = viewModel.Notes,
            Attachments = viewModel.Attachments

            //
            //RowGuid = viewModel.RowGuid,
            //ModifiedDate = viewModel.ModifiedDate

        };
    }
}
}

