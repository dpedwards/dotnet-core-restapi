// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================


using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace RESTfulAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            BuildWebHostDev(args).Run();
        }

        private static IWebHost BuildWebHostDev(string[] args)
        {


            var cert = new X509Certificate2("dev_certificate.pfx", "bck37weCert");
            var w = WebHost
                .CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 5000);
                    options.Listen(IPAddress.Any, 5001, listenOptions =>
                    {
                        listenOptions.UseHttps(cert);
                    });
                })
                .UseEnvironment("Development")
                //.UseUrls("https://localhost:5000")
                .UseApplicationInsights()
                .UseStartup<Startup>()
                .Build();

            return w;

        }
    }
}
