// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using RESTfulAPI.Core.AppSettingsLayer;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using RESTfulAPI.Models.Home;
using System.Threading.Tasks;
using RESTfulAPI.Model.Home;

namespace RESTfulAPI.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IOptions<LinuxSettings> _linuxSettings;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileProvider"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="linuxSettings"></param>
        public HomeController(IFileProvider fileProvider, IHostingEnvironment hostingEnvironment, IOptions<LinuxSettings> linuxSettings)
        {
            this._fileProvider = fileProvider;
            _hostingEnvironment = hostingEnvironment;
            _linuxSettings = linuxSettings;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            if (file == null || file.Length == 0)
                return Content("file not selected");

            #region Windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {


                string standardFolder = webRootPath + "\\documents";

                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), standardFolder,
                            file.GetFilename());


                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            #endregion

            #region Linux
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {


                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), webRootPath + "/documents",
                            file.GetFilename());


                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            #endregion

            return RedirectToAction("Files");
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadFilesAsync(List<IFormFile> files)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            #region Windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {

                string standardFolder = webRootPath + "\\documents";

                if (files == null || files.Count == 0)
                    return Content("files not selected");

                foreach (var file in files)
                {
                    var path = Path.Combine(
                            Directory.GetCurrentDirectory(), standardFolder,
                            file.GetFilename());

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            #endregion

            #region Linux
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (files == null || files.Count == 0)
                    return Content("files not selected");

                foreach (var file in files)
                {
                    var path = Path.Combine(
                            Directory.GetCurrentDirectory(), webRootPath + "/documents",
                            file.GetFilename());

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            #endregion

            return RedirectToAction("Files");
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadFileViaModelAsync(FileInputModel model)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            #region Windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {

                string standardFolder = webRootPath + "\\documents";


                if (model == null ||
                    model.FileToUpload == null || model.FileToUpload.Length == 0)
                    return Content("file not selected");

                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), standardFolder,
                            model.FileToUpload.GetFilename());

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.FileToUpload.CopyToAsync(stream);
                }
            }
            #endregion

            #region Linux
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (model == null ||
                    model.FileToUpload == null || model.FileToUpload.Length == 0)
                    return Content("file not selected");

                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), webRootPath + "/documents",
                            model.FileToUpload.GetFilename());

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.FileToUpload.CopyToAsync(stream);
                }
            }
            #endregion


            return RedirectToAction("Files");
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Files()
        {
            var model = new FilesViewModel();
            foreach (var item in this._fileProvider.GetDirectoryContents(""))
            {
                model.Files.Add(
                    new FileDetails { Name = item.Name, Path = item.PhysicalPath });
            }
            return View(model);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public async Task<IActionResult> DownloadAsync(string filename)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            #region Windows 
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                if (filename == null)
                    return Content("filename not present");

            string standardFolder = webRootPath + "\\documents";

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           standardFolder, filename);
            // @"/www_dotnetcore/restapi/documents", filename);


            var memory = new MemoryStream();


            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            #endregion

            #region Linux
            //if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            //    if (filename == null)
            //        return Content("filename not present");

            //    var path = Path.Combine(
            //                   Directory.GetCurrentDirectory(),
            //                   _linuxSettings.Value.DocumentDir + "/documents", filename);


            //    var memory = new MemoryStream();


            //    using (var stream = new FileStream(path, FileMode.Open))
            //    {
            //        await stream.CopyToAsync(memory);
            //    }
            //    memory.Position = 0;

            #endregion


            //if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            //return File(memoryLinux, GetContentType(pathLinux), Path.GetFileName(pathLinux));

            return File(memory, GetContentType(path), Path.GetFileName(path));
        }



        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }



        /// <summary>
        /// https://wiki.selfhtml.org/wiki/MIME-Type/%C3%9Cbersicht
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".json", "application/json" },
                {"", "application/datei"},
                {".md", "application/md"},
                {".mwb", "application/mwb"},
                {".sql", "application/sql"},
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult ErrorPage()
        {
            ViewData["Message"] = "404 Page";

            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            ViewData["Message"] = "About";

            return View();
        }

      

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult CustomerView()
        {
            

            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
