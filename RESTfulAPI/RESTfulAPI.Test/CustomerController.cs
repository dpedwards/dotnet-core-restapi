// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System.Threading.Tasks;
using RESTfulAPI.Controllers;
using RESTfulAPI.Core.DataLayer;
using RESTfulAPI.Responses;
using RESTfulAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Xunit;
using RESTfulAPI.Core.AppSettingsLayer;
using Microsoft.AspNetCore.Hosting;
//using NUnit.Framework;


namespace RESTfulAPI.Tests
{
    public class CustomerControllerTest
    {
        public CustomerControllerTest()
        {

        }

        
        private readonly IOptions<DatabaseSettings> _databaseSettings;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IOptions<LinuxSettings> _linuxSettings;


        private IRESTfulAPI_Repository _RESTfulAPI_Repository
        {
            get
            {

                var databaseSettings = Options.Create(new DatabaseSettings
                {
                    ConnectionString = "server=localhost;userid=[CHANGE_ROOT];password=[CHANGE_PASSWORD];database=northwind;"
                });

                var entityMapper = new RESTfulAPI_EntityMapper() as IEntityMapper;

                return new RESTfulAPI_Repository(new RESTfulAPI_DbContext(databaseSettings, entityMapper)) as IRESTfulAPI_Repository;
            }
        }


        #region Create Test
        [Xunit.Fact]
        public async Task Customer_CreateAsync()
        {

            var controller = new CustomerController(_RESTfulAPI_Repository, _databaseSettings,_hostingEnvironment, _linuxSettings);

            bool testData01 = true; // #1 |


            #region Test Daten 01
            if (testData01 == true)
            {

                var viewModel = new CustomerViewModel
                {
           
                    Company = "Company Test",
                    Last_Name = "Last Name Test",
                    First_Name = "First Name Test",
                    Email_Address = "Email Address Test",
                    Job_Title = "Job Title Test",
                    Business_Phone = "Business Phone Test",
                    Home_Phone = "Home Phone Test",
                    Mobile_Phone = "Mobile Phoe Test",
                    Fax_Number = "Fax Number Test",
                    Address = "Address Test",
                    City = "City Test",
                    State_Province = "State Province Test",
                    Zip_Postal_Code = "Zip Postal Code Test",
                    Country_Region = "Country Region Test",
                    Web_Page = "Web Page Test",
                    Notes = "Notes Test",
                    Attachments = null

                };

                // Act
                var response = await controller.CreateCustomerAsync(viewModel) as ObjectResult;

                // Assert
                var value = response.Value as ISingleModelResponse<CustomerViewModel>;

                Xunit.Assert.False(value.DidError);


            }
            #endregion 
        }
        #endregion 



        //[Fact]
        //public async Task Customer_UpdateAsync()
        //{
        //    // Arrange
        //    var controller = new CustomerController(RESTfulAPI_Repository);

        //    var id = 29;

        //    var viewModel = new CustomerViewModel
        //    {
        //        Company = "",
        //        Last_Name = "",
        //        First_Name = "",
        //        Email_Address = "",
        //        Job_Title = "",
        //        Business_Phone = "",
        //        Home_Phone = "",
        //        Mobile_Phone = "",
        //        Fax_Number = "",
        //        Address = "",
        //        City = "",
        //        State_Province = "",
        //        Zip_Postal_Code = "",
        //        Country_Region = "",
        //        Web_Page = "",
        //        Notes = ""
        //    };

        //    // Act
        //    var response = await controller.UpdateCustomerAsync(id, viewModel) as ObjectResult;

        //    // Assert
        //    var value = response.Value as ISingleModelResponse<CustomerViewModel>;

        //    Assert.False(value.DidError);
        //}


        //[Fact]
        //public async Task Customer_DeleteCustomerAsync()
        //{
        //    // Arrange
        //    var controller = new CustomerController(RESTfulAPI_Repository);
        //    var id = 1;

        //    // Act
        //    var response = await controller.DeleteCustomerAsync(id) as ObjectResult;

        //    // Assert
        //    var value = response.Value as ISingleModelResponse<CustomerViewModel>;

        //    Assert.False(value.DidError);
        //}

    }
}

