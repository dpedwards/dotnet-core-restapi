﻿// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using RESTfulAPI.Extensions;
using RESTfulAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.Responses;
using Microsoft.AspNetCore.Authorization;
using RESTfulAPI.Core.DataLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using RESTfulAPI.Core.AppSettingsLayer;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.IO;
using RESTfulAPI.Core;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTfulAPI.Controllers
{
   
    /// <summary>
    /// 
    /// </summary>
    [Route("api/1.0/webservice/[controller]")]
    public class InvoiceController : Controller
    {

        private IRESTfulAPI_Repository _RESTfulAPI_Repository;
        private readonly IOptions<DatabaseSettings> _databaseSettings;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IOptions<LinuxSettings> _linuxSettings;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="databaseSettings"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="linuxSettings"></param>
        public InvoiceController(IRESTfulAPI_Repository repository, IOptions<DatabaseSettings> databaseSettings, IHostingEnvironment hostingEnvironment, IOptions<LinuxSettings> linuxSettings)
        {
            _RESTfulAPI_Repository = repository;
            _databaseSettings = databaseSettings;
            _hostingEnvironment = hostingEnvironment;
            _linuxSettings = linuxSettings;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(Boolean disposing)
        {
            if (_RESTfulAPI_Repository != null)
            {
                _RESTfulAPI_Repository.Dispose();
            }

            base.Dispose(disposing);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseCache(Duration = 30)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> GetInvoicesAsync(Int32? pageSize = 10, Int32? pageNumber = 1, String name = null)
        {
            var response = new ListModelResponse<InvoiceViewModel>() as IListModelResponse<InvoiceViewModel>;

            try
            {
                response.PageSize = (Int32)pageSize;
                response.PageNumber = (Int32)pageNumber;

                response.Model = await Task.Run(() =>
                {
                    return _RESTfulAPI_Repository
                        .GetInvoices(response.PageSize, response.PageNumber, name)
                        .Select(item => item.ToViewModel())
                        .ToList();
                });

                response.Info = String.Format("Total of records: {0}", response.Model.Count());
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ResponseCache(Duration = 30)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> GetInvoiceAsync(Int32 id)
        {
            var response = new SingleModelResponse<InvoiceViewModel>() as ISingleModelResponse<InvoiceViewModel>;

            try
            {
                response.Model = await Task.Run(() =>
                {
                    return _RESTfulAPI_Repository.GetInvoice(id).ToViewModel();
                });
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseCache(Duration = 30)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> CreateInvoiceAsync([FromBody]InvoiceViewModel value)
        {

            var response = new SingleModelResponse<InvoiceViewModel>() as ISingleModelResponse<InvoiceViewModel>;

            try
            {


                var entity = await Task.Run(() =>
                {
                    return _RESTfulAPI_Repository.AddInvoice(value.ToEntity());
                });


              
                if (response.DidError == false)
                {
                
                    response.Model = entity.ToViewModel();
                }

               
            }
            catch (Exception ex)
            {
                string webRoot = _hostingEnvironment.WebRootPath;
                string errorGuid = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                HttpContext.Session.SetString("ErrorGuid", errorGuid);
                ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    using (StreamWriter w = new StreamWriter(webRoot + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, ViewBag.ErrorGuid);
                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {

                    using (StreamWriter w = new StreamWriter(webRoot + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, ViewBag.ErrorGuid);
                    }
                }


                response.DidError = true;
                //response.ErrorMessage = ex.ToString();


                return this.Json(new { timestamp = DateTime.Now, errorGuid = ViewBag.ErrorGuid, status = HttpStatusCode.InternalServerError, info = "Error logged in log file." });
            }

            
            
            response.Info = "Client " + " " + HttpContext.Connection.RemoteIpAddress.ToString();

            return response.ToHttpResponse();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ResponseCache(Duration = 30)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> UpdateInvoiceAsync(Int32 id, [FromBody]InvoiceViewModel value)
        {
            var response = new SingleModelResponse<InvoiceViewModel>() as ISingleModelResponse<InvoiceViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return _RESTfulAPI_Repository.UpdateInvoice(id, value.ToEntity());
                });



                response.Model = entity.ToViewModel();
                response.Info = "The record was updated successfully";


            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ResponseCache(Duration = 30)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> DeleteInvoiceAsync(Int32 id)
        {
            var response = new SingleModelResponse<InvoiceViewModel>() as ISingleModelResponse<InvoiceViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return _RESTfulAPI_Repository.DeleteInvoice(id);
                });

                response.Model = entity.ToViewModel();
                response.Info = "The record was deleted successfully";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }



    }
}
