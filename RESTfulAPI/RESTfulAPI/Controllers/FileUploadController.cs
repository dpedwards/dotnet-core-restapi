// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using RESTfulAPI.Core.AppSettingsLayer;
using RESTfulAPI.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace RESTfulAPI.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Route("api/1.0/webservice/[controller]")]
    public class FileUploadController : Controller
    {


        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IOptions<FtpSettings> _ftpSettings;
        private readonly IOptions<LinuxSettings> _linuxSettings;
        private readonly IOptions<WindowsSettings> _windowsSettings;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        /// <param name="ftpSettings"></param>
        /// <param name="linuxSettings"></param>
        /// <param name="windowsSettings"></param>
        public FileUploadController(IHostingEnvironment hostingEnvironment, IOptions<FtpSettings> ftpSettings, IOptions<LinuxSettings> linuxSettings, IOptions<WindowsSettings> windowsSettings)
        {
            _hostingEnvironment = hostingEnvironment;
            _ftpSettings = ftpSettings;
            _linuxSettings = linuxSettings;
            _windowsSettings = windowsSettings;
        }



        #region FTP Mulitupload

        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost("multi")]
        [AddSwaggerFileUploadButton]
        [ResponseCache(Duration = 30)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<dynamic> UploadFilesAsync(List<IFormFile> files)
        {

            string ext = null;

            string transactionId = null;

            try
            {

                Stopwatch stopWatch = new Stopwatch();


                ViewBag.ClientNumber_T = HttpContext.Session.GetString("ClientNumber_T");
                ViewBag.UserNumber_T = HttpContext.Session.GetString("UserNumber_T");


                int clientNumber = Convert.ToInt32(ViewBag.ClientNumber_T);
                int userNumber = Convert.ToInt32(ViewBag.UserNumber_T);

                string ftpPath = "/" + clientNumber + "/" + userNumber + "/" + _ftpSettings.Value.UploadPath;

                #region Windows Platform
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    stopWatch.Start();



                    string ftpFullAddress = _ftpSettings.Value.Url + ftpPath;


                    if (files != null && files.Count > 0)
                    {

                        #region Dateiordner Verwaltung

                        string webRootPath = _hostingEnvironment.WebRootPath;
                        // string contentRootPath = _hostingEnvironment.ContentRootPath;

                        string uploadFolder = webRootPath + "\\Uploads";

                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }


                        string standardDataPath = Path.Combine(webRootPath, uploadFolder);

                        //string uploads = Path.Combine(_windowsSettings.Value.DocumentDir);

                        #endregion

                        transactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);


                        foreach (var item in files)
                        {



                            if (item.Length > 0)
                            {
                                string fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');


                                ext = Path.GetExtension(fileName);

                                if (ext.ToLower() == ".pdf")// || ext.ToLower() == ".csv")// || ext.ToLower() == ".xlsx") //|| Path.GetExtension(file.FileName).ToLower() == ".csv")
                                {

                                    string fullPath = Path.Combine(standardDataPath, transactionId + "_" + fileName);
                                    using (var stream = new FileStream(fullPath, FileMode.Create))
                                    {
                                        await item.CopyToAsync(stream);
                                    }

                                    #region FTP Upload




                                    //Create FTP request
                                    FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ftpFullAddress + "/" + Path.GetFileName(fileName));


                                    request.Method = WebRequestMethods.Ftp.UploadFile;
                                    request.Credentials = new NetworkCredential(_ftpSettings.Value.UserName, _ftpSettings.Value.Password);
                                    request.UsePassive = true;
                                    request.UseBinary = true;
                                    request.KeepAlive = false;

                                    //Load the file
                                    FileStream stream2 = new FileStream(fullPath, FileMode.Open, FileAccess.Read);



                                    byte[] buffer = new byte[stream2.Length];
                                    await stream2.ReadAsync(buffer, 0, buffer.Length);
                                    stream2.Close();

                                    //Upload file
                                    Stream reqStream = await request.GetRequestStreamAsync();
                                    await reqStream.WriteAsync(buffer, 0, buffer.Length);
                                    //
                                    await closeRequestStreamAsync(reqStream);


                                    reqStream.Close();
                                    #endregion
                                }
                                else
                                {
                                    return new { timestamp = DateTime.Now, status = HttpStatusCode.UnsupportedMediaType, info = " " + ">>" + "Es sind nur" + " " + "application/pdf" + " " + "bzw. ZUGFeRD Dateien erlaubt!<<" };// + " " + "und" + " " + "text/csv" + " " + "Dateien erlaubt!" + "<<" };
                                }

                            }
                        }
                        stopWatch.Stop();

                        TimeSpan ts = stopWatch.Elapsed;

                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                        Console.WriteLine("##############################" + "\n" +
                                          "TimeStamp: " + DateTime.Now + "\n" +
                                          "RunTime: " + elapsedTime + "\n" +
                                          "Controller: FileUpload" + "\n" +
                                          "Method: UploadFilesAsync" + "\n" +
                                          "Platform: Windows" + "\n" +
                                          "##############################");


                        return new { timestamp = DateTime.Now, status = HttpStatusCode.OK, info = "[File Uploads] Client " + " " + HttpContext.Connection.RemoteIpAddress.ToString() + " " + " Request Ticket:" + " " + transactionId + " " + "@" + " " + DateTime.Now, upload = "Upload erfolgreich!", extension = ext };


                    }

                    //}
                    //else
                    //{
                    //    return new { info = "Wählen Sie für den Upload nur 100 Elemente gleichzeitig aus!", extension = ext };
                    //}
                }
                #endregion


                #region Linux Platform 

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {

                    stopWatch.Start();


                    if (files != null && files.Count > 0)
                    {

                        #region Dateiordner Verwaltung

                        string uploads = Path.Combine(_linuxSettings.Value.DocumentDir + ftpPath);

                        if (!Directory.Exists(uploads))
                        {
                            Directory.CreateDirectory(uploads);
                        }

                        #endregion 

                        transactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);


                        foreach (var item in files)
                        {



                            if (item.Length > 0)
                            {
                                string fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');


                                ext = Path.GetExtension(fileName);

                                if (ext.ToLower() == ".pdf")// || ext.ToLower() == ".csv")// || ext.ToLower() == ".xlsx") //|| Path.GetExtension(file.FileName).ToLower() == ".csv")
                                {

                                    string fullPath = Path.Combine(uploads, transactionId + "_" + fileName);
                                    using (var stream = new FileStream(fullPath, FileMode.Create))
                                    {
                                        await item.CopyToAsync(stream);
                                    }

                                }
                                else
                                {
                                    return new { timestamp = DateTime.Now, status = HttpStatusCode.UnsupportedMediaType, info = " " + ">>" + "Es sind nur" + " " + "application/pdf" + " " + "bzw. ZUGFeRD Dateien erlaubt!<<" };// + " " + "und" + " " + "text/csv" + " " + "Dateien erlaubt!" + "<<" };
                                }

                            }
                        }
                        stopWatch.Stop();

                        TimeSpan ts = stopWatch.Elapsed;

                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                        Console.WriteLine("##############################" + "\n" +
                                         "TimeStamp: " + DateTime.Now + "\n" +
                                         "RunTime: " + elapsedTime + "\n" +
                                         "Controller: FileUpload" + "\n" +
                                         "Method: UploadFilesAsync" + "\n" +
                                         "Platform: Linux" + "\n" +
                                         "##############################");

                        return new { timestamp = DateTime.Now, status = HttpStatusCode.OK, info = "[File Uploads] Client " + " " + HttpContext.Connection.RemoteIpAddress.ToString() + " " + " Request Ticket:" + " " + transactionId + " " + "@" + " " + DateTime.Now, upload = "Upload erfolgreich!", extension = ext };

                    }
                }

                #endregion


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

                return new { timestamp = DateTime.Now, errorGuid = ViewBag.ErrorGuid, status = HttpStatusCode.InternalServerError, info = "Something went wrong!" };
            }

            return new { timestamp = DateTime.Now, status = HttpStatusCode.OK, info = "[File Uploads] Client " + " " + HttpContext.Connection.RemoteIpAddress.ToString() + " " + " Request Ticket:" + " " + transactionId + " " + "@" + " " + DateTime.Now, upload = "Upload erfolgreich!", extension = ext };
        }

        /// <summary>
        /// Background worker for closing request stream
        /// </summary>
        /// <param name="requestStream"></param>
        /// <remarks>This is the method that actually triggers the writing to the server
        /// of the data in the FTP stream.  This blocks the UI thread when called synchronously.
        /// </remarks>
        private Task closeRequestStreamAsync(Stream requestStream)
        {
            return Task.Run(() =>
            {
                requestStream.Close();
            }
                );
        }



        #endregion



        #region FTP Singleupload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("single")]
        [AddSwaggerFileUploadButton]
        [ResponseCache(Duration = 30)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<dynamic> UploadFileAsync(IFormFile file)
        {


            string ext = null;

            string transactionId = null;


            try
            {

                Stopwatch stopWatch = new Stopwatch();



                ViewBag.ClientNumber_T = HttpContext.Session.GetString("ClientNumber_T");
                ViewBag.UserNumber_T = HttpContext.Session.GetString("UserNumber_T");


                int clientNumber = Convert.ToInt32(ViewBag.ClientNumber_T);
                int userNumber = Convert.ToInt32(ViewBag.UserNumber_T);

                string ftpPath = @"/" + clientNumber + "/" + userNumber + "/" + _ftpSettings.Value.UploadPath;



                #region Windows 
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {


                    stopWatch.Start();


                    string ftpFullAddress = _ftpSettings.Value.Url + ftpPath;

                    if (file != null)
                    {

                        #region Dateiordner Verwaltung

                        string webRootPath = _hostingEnvironment.WebRootPath;
                        // string contentRootPath = _hostingEnvironment.ContentRootPath;

                        string uploadFolder = webRootPath + "\\Uploads";

                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        string standardDataPath = Path.Combine(webRootPath, uploadFolder);

                        //string uploads = Path.Combine(_windowsSettings.Value.DocumentDir);

                        #endregion

                        transactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);



                        if (file.Length > 0)
                        {


                            string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');


                            ext = Path.GetExtension(fileName);


                            if (ext.ToLower() == ".pdf")// || ext.ToLower() == ".csv")// || ext.ToLower() == ".xlsx") //|| Path.GetExtension(file.FileName).ToLower() == ".csv")
                            {

                                string fullPath = Path.Combine(standardDataPath, transactionId + "_" + fileName);
                                using (var stream = new FileStream(fullPath, FileMode.Create))
                                {
                                    await file.CopyToAsync(stream);
                                }

                                #region FTP Upload



                                //Create FTP request
                                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ftpFullAddress + "/" + Path.GetFileName(fileName));

                                request.Method = WebRequestMethods.Ftp.UploadFile;
                                request.Credentials = new NetworkCredential(_ftpSettings.Value.UserName, _ftpSettings.Value.Password);
                                request.UsePassive = true;
                                request.UseBinary = true;
                                request.KeepAlive = false;

                                //Load the file
                                FileStream stream2 = new FileStream(fullPath, FileMode.Open, FileAccess.Read);



                                byte[] buffer = new byte[stream2.Length];
                                await stream2.ReadAsync(buffer, 0, buffer.Length);
                                stream2.Close();

                                //Upload file
                                Stream reqStream = await request.GetRequestStreamAsync();
                                await reqStream.WriteAsync(buffer, 0, buffer.Length);
                                //
                                await closeRequestStreamAsync(reqStream);


                                reqStream.Close();
                                #endregion
                            }
                            else
                            {
                                return new { timestamp = DateTime.Now, status = HttpStatusCode.UnsupportedMediaType, info = " " + ">>" + "Es sind nur" + " " + "application/pdf" + " " + "bzw. ZUGFeRD Dateien erlaubt!<<" };// + " " + "und" + " " + "text/csv" + " " + "Dateien erlaubt!" + "<<" };
                            }

                        }
                    }
                    stopWatch.Stop();

                    TimeSpan ts = stopWatch.Elapsed;

                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                    Console.WriteLine("##############################" + "\n" +
                                      "TimeStamp: " + DateTime.Now + "\n" +
                                      "RunTime: " + elapsedTime + "\n" +
                                      "Controller: FileUpload" + "\n" +
                                      "Method: UploadFileAsync" + "\n" +
                                      "Platform: Windows" + "\n" +
                                      "##############################");

                    return new { timestamp = DateTime.Now, status = HttpStatusCode.OK, info = "Client " + " " + HttpContext.Connection.RemoteIpAddress.ToString() + " " + " Request Ticket:" + " " + transactionId + " " + "@" + " " + DateTime.Now, upload = "Upload erfolgreich!", extension = ext };

                }

                //}
                //else
                //{
                //    return new { info = "Wählen Sie für den Upload nur 100 Elemente gleichzeitig aus!", extension = ext };
                //}

                #endregion


                #region Linux Platform 

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    stopWatch.Start();


                    if (file != null && file.Length > 0)
                    {

                        #region Dateiordner Verwaltung

                        string uploads = Path.Combine(_linuxSettings.Value.DocumentDir + ftpPath);

                        if (!Directory.Exists(uploads))
                        {
                            Directory.CreateDirectory(uploads);
                        }

                        #endregion

                        transactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);



                        if (file.Length > 0)
                        {
                            string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');


                            ext = Path.GetExtension(fileName);

                            if (ext.ToLower() == ".pdf")// || ext.ToLower() == ".csv")// || ext.ToLower() == ".xlsx") //|| Path.GetExtension(file.FileName).ToLower() == ".csv")
                            {

                                string fullPath = Path.Combine(uploads, transactionId + "_" + fileName);
                                using (var stream = new FileStream(fullPath, FileMode.Create))
                                {
                                    await file.CopyToAsync(stream);
                                }

                            }
                            else
                            {
                                return new { timestamp = DateTime.Now, status = HttpStatusCode.UnsupportedMediaType, info = " " + ">>" + "Es sind nur" + " " + "application/pdf" + " " + "bzw. ZUGFeRD Dateien erlaubt!<<" };// + " " + "und" + " " + "text/csv" + " " + "Dateien erlaubt!" + "<<" };
                            }

                        }
                    }
                    stopWatch.Stop();

                    TimeSpan ts = stopWatch.Elapsed;

                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                    Console.WriteLine("##############################" + "\n" +
                                     "TimeStamp: " + DateTime.Now + "\n" +
                                     "RunTime: " + elapsedTime + "\n" +
                                     "Controller: FileUpload" + "\n" +
                                     "Method: UploadFileAsync" + "\n" +
                                     "Platform: Linux" + "\n" +
                                     "##############################");

                    return new { timestamp = DateTime.Now, status = HttpStatusCode.OK, info = "Client " + " " + " Request Ticket:" + " " + transactionId + " " + "@" + " " + DateTime.Now, upload = "Upload erfolgreich!", extension = ext };

                }

                #endregion
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

                return new { timestamp = DateTime.Now, errorGuid = ViewBag.ErrorGuid, status = HttpStatusCode.InternalServerError, info = "Error logged in log file." };

            }

            return new { timestamp = DateTime.Now, status = HttpStatusCode.OK, info = "Client " + " " + HttpContext.Connection.RemoteIpAddress.ToString() + " "   ,extension = ext };
        }


    }
}



#endregion
