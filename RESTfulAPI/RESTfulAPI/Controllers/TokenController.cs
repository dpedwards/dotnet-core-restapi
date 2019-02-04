// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.Extensions.Options;
using RESTfulAPI.Core.AppSettingsLayer;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices;
using System.IO;
using RESTfulAPI.Core;


namespace RESTfulAPI.Controllers
{


   /// <summary>
   /// 
   /// </summary>
    [Route("api/1.0/webservice/[controller]")]    
    public class TokenController : Controller
    {

        private readonly TokenAuthOptions _tokenOption;
        private readonly IOptions<DatabaseSettings> _databaseSettings;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IOptions<LinuxSettings> _linuxSettings;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="databaseSettings"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="linuxSettings"></param>
        public TokenController(TokenAuthOptions t, IOptions<DatabaseSettings> databaseSettings, IHostingEnvironment hostingEnvironment, IOptions<LinuxSettings> linuxSettings)
        {
            this._tokenOption = t;
            _databaseSettings = databaseSettings;
            _hostingEnvironment = hostingEnvironment;
            _linuxSettings = linuxSettings;
        }



        public string UserName { get; set; }
        public string PasswordHash { get; set; }
       


        /// <summary>
        /// 
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseCache(Duration = 30)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public IActionResult Post([FromBody]Core.EntityLayer.User auth)
        {

            try
            {

              
                Pomelo.Data.MySql.MySqlConnection sqlAccess_dboUserAccount = new Pomelo.Data.MySql.MySqlConnection(_databaseSettings.Value.ConnectionString);
                Pomelo.Data.MySql.MySqlCommand dboUserAccountCmd = new Pomelo.Data.MySql.MySqlCommand { };
                dboUserAccountCmd.Connection = sqlAccess_dboUserAccount;
                sqlAccess_dboUserAccount.Open();


                dboUserAccountCmd.CommandText = @"SELECT username, password_hash  
                                                  FROM useraccounts
                                                  WHERE username = '" + auth.UserName + "' AND password_hash = '" + auth.Password + "' ";

            using (Pomelo.Data.MySql.MySqlDataReader dboUserAccountData = dboUserAccountCmd.ExecuteReader())
            {
                while (dboUserAccountData.Read())
                {
                        //HttpContext.Session.SetString("UserName_T", dboUserAccountData["username"].ToString().Trim());
                        //HttpContext.Session.SetString("Password_T", dboUserAccountData["password_hash"].ToString().Trim());

                        //ViewBag.UserName_T = HttpContext.Session.GetString("UserName_T");
                        //ViewBag.Password_T = HttpContext.Session.GetString("Password_T");

                        //if (auth.UserName == ViewBag.UserName_T && auth.Password == ViewBag.Password_T)

                        UserName = dboUserAccountData["username"].ToString().Trim();
                        PasswordHash = dboUserAccountData["password_hash"].ToString().Trim();

                        if (auth.UserName == UserName && auth.Password == PasswordHash)
                    {
                        DateTime? expire = DateTime.Now.AddMinutes(10); 
                        var tokenString = GetToken(auth.UserName, expire);

                        return Json(new { auth = true, timestamp = DateTime.Now, status = HttpStatusCode.OK, client = HttpContext.Connection.RemoteIpAddress.ToString(), session = HttpContext.Session.Id.ToString(), token = tokenString, tokenExpires = expire });
                    }
                }
                return this.Json(new { auth = false, timestamp = DateTime.Now, status = HttpStatusCode.Unauthorized, info = "JWT auth fail! Please check username and password." });

            }

        }
            catch (Exception ex)
            {
                string errorGuid = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                HttpContext.Session.SetString("ErrorGuid", errorGuid);
                ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, ViewBag.ErrorGuid);
                        return this.Json(new { timestamp = DateTime.Now, errorGuid = ViewBag.ErrorGuid, status = HttpStatusCode.InternalServerError, info = "Something went wrong!" });
                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, ViewBag.ErrorGuid);
                        return this.Json(new { timestamp = DateTime.Now, errorGuid = ViewBag.ErrorGuid, status = HttpStatusCode.InternalServerError, info = "Something went wrong!" });
                    }
                }

              
            }

            return View();
        }



    private string GetToken(string UserName, DateTime? expire)
{
    var handler = new JwtSecurityTokenHandler();
    ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(UserName, "TokenAuth"), new[] { new Claim("EntityID", HttpContext.Session.Id.ToString(), ClaimValueTypes.Integer) });

    var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor()
    {
        Issuer = this._tokenOption.Issuer,
        Audience = _tokenOption.Audience,
        SigningCredentials = _tokenOption.SigningCredentials,
        Subject = identity,
        Expires = expire
    });
    return handler.WriteToken(securityToken);
     }
        
    }
}
