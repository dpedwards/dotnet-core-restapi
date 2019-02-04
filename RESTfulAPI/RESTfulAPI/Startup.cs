// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using RESTfulAPI.Core.DataLayer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Swashbuckle.AspNetCore.Swagger;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Options;
using RESTfulAPI.Core.AppSettingsLayer;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.IO;
using Swashbuckle.AspNetCore.Examples;
using Microsoft.Extensions.FileProviders;
using RESTfulAPI.Models;

namespace RESTfulAPI
{

    /// <summary>
    /// 
    /// </summary>
    public class TokenAuthOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SigningCredentials SigningCredentials { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class Startup
    {

        private RsaSecurityKey _key;

        /// <summary>
        /// 
        /// </summary>
        public TokenAuthOptions _tokenAuth { get; set; }

        private readonly IOptions<DatabaseSettings> _databaseSettings;
        private readonly IOptions<SwaggerSettings> _swaggerSettings;
        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="databaseSettings"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="swaggerSettings"></param>
        public Startup(IConfiguration configuration, IOptions<DatabaseSettings> databaseSettings, IHostingEnvironment hostingEnvironment, IOptions<SwaggerSettings> swaggerSettings)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();


            //Configuration = configuration;

            _databaseSettings = databaseSettings;
            _hostingEnvironment = hostingEnvironment;
            _swaggerSettings = swaggerSettings;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            services
             .AddMvc()
             .AddJsonOptions(a => a.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())

             .AddRazorPagesOptions(options =>
             {
                    #region Razor-Convention Feature
                    //options.Conventions.Add(new GlobalTemplatePageRouteModelConvention()); // Swagger etc.
                    //options.Conventions.Add(new GlobalHeaderPageApplicationModelConvention()); // Swagger etc.
                    //options.Conventions.ConfigureFilter(new AddHeaderWithFactory());
                    #endregion
                });



            services.AddSession(options =>
            {
                //options.Cookie.HttpOnly = false;
                //options.Cookie.Name = ".ASPNetCoreSession";
                //options.IdleTimeout = TimeSpan.FromMinutes(40);
                //options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                //options.Cookie.Path = "/";

            });

            services.AddDistributedMemoryCache();


            #region appsettings.json

            services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));


            #endregion

         
            #region file location
            

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {

                string webRootPath = _hostingEnvironment.WebRootPath;

                services.AddSingleton<IFileProvider>(
                   new PhysicalFileProvider(
                       Path.Combine(Directory.GetCurrentDirectory(), webRootPath + "\\documents")));
            }



            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                string webRootPath = _hostingEnvironment.WebRootPath;

                services.AddSingleton<IFileProvider>(
                   new PhysicalFileProvider(
                       Path.Combine(Directory.GetCurrentDirectory(), webRootPath + "/documents")));
            }
            #endregion


            #region Razor Page Indexing

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizePage("/Files");
                    //options.Conventions.AllowAnonymousToPage("/Private/PublicPage");
                    //options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion

        
            #region HTTPS!

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });

            #endregion


            #region Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = ".NET Core 2.1 RESTful API Template with swagger Doc",
                    Description = "This Template is based on the Northwind database, an excellent tutorial schema for a small-business ERP, with customers, orders, inventory, purchasing, suppliers, shipping, employees, and single-entry accounting.",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Davain Pablo Edwards",
                        Email = "core8@gmx.net",
                        Url = ""
                    }
                });

                //c.SwaggerDoc("v2", new Info
                //{
                //    Version = "v2",
                //    Title = "SE B2B REST API",
                //    Description = "ASP .NET Core 2.0 Web API",
                //    TermsOfService = "None",
                //    Contact = new Contact() { Name = "SE Vertrieb", Email = "support@se-vertrieb.de", Url = "www.se-vertrieb.de" }
                //});
                //c.IncludeXmlComments(GetXmlCommentsPath());
                //options.IncludeXmlComments(GetXmlCommentsPath());
                options.OperationFilter<AddFileParamTypesOperationFilter>();
                options.DescribeAllEnumsAsStrings();



                // 2018-06-18
                // Kommentar-Pfad für swagger JSON und UI
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);


            });

            services.AddSwaggerDocumentation();
            #endregion


            #region Token auth

            // Windows os support
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                RSACryptoServiceProvider rSA = new RSACryptoServiceProvider(2048);

                RSAParameters keyParam = rSA.ExportParameters(true);
                _key = new RsaSecurityKey(keyParam);
                _tokenAuth = new TokenAuthOptions
                {
                    Audience = "TokenAudience",
                    Issuer = "Issuer",
                    SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.RsaSha256Signature)
                };
            }

            // Linux os support
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                RSAOpenSsl rSA = new RSAOpenSsl(2048);

                RSAParameters keyParam = rSA.ExportParameters(true);
                _key = new RsaSecurityKey(keyParam);
                _tokenAuth = new TokenAuthOptions
                {
                    Audience = "TokenAudience",
                    Issuer = "Issuer",
                    SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.RsaSha256Signature)
                };
            }


            services.AddSingleton<TokenAuthOptions>(_tokenAuth);

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                .RequireAuthenticatedUser().Build());
            });

            services.AddAuthentication()
                    .AddCookie(auth => auth.SlidingExpiration = true)
                    .AddJwtBearer(auth =>
                    {
                        auth.RequireHttpsMetadata = false;
                        auth.SaveToken = true;

                        auth.TokenValidationParameters = new TokenValidationParameters
                        {
                            IssuerSigningKey = _key,
                            ValidAudience = _tokenAuth.Audience,
                            ValidIssuer = _tokenAuth.Issuer,

                            ValidateLifetime = true,

                            ClockSkew = TimeSpan.FromMinutes(0)
                        };


                    });
            #endregion


            services
                .AddMvc()
                .AddJsonOptions(a => a.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());


            services.AddEntityFrameworkMySql().AddDbContext<RESTfulAPI_DbContext>();

            services.AddScoped<IEntityMapper, RESTfulAPI_EntityMapper>();

            services.AddScoped<IRESTfulAPI_Repository, RESTfulAPI_Repository>();

            services.AddOptions();
            services.AddSingleton(Configuration);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {


            // Debugging
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            #region HTTPS!

            var options = new RewriteOptions()
            .AddRedirectToHttps();
            app.UseRewriter(options);

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            #endregion


            // HOME
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            if (env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }



            // Error handling
            app.UseStatusCodePagesWithReExecute("/statuscode{0}");

            app.UseAuthentication();  // TokenAuth
                                      // IMPORTANT: session vor UseMvc() aufrufen!
            app.UseStaticFiles();
            app.UseSession(); // session vor MVC
            app.UseMvcWithDefaultRoute();

            //app.UseMvc();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            #region Swagger

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle(".NET Core 2.1 RESTful API");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            #endregion 


        }


        #region Swagger 

        /*
         * Property -> Build -> Output -> 
         * XML documentation file: 'bin\Debug\netcoreapp2.1\RESTfulAPI.xml'
         * 
         */
        //private string GetXmlCommentsPath()
        //{
        //    var app = PlatformServices.Default.Application;
        //    return System.IO.Path.Combine(app.ApplicationBasePath, "RESTfulAPI.xml");
        //}

        #endregion


    }


    #region Swagger
    /// <summary>
    /// 
    /// </summary>
    public static class SwaggerServiceExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info { Title = "Main API v1.0", Version = "v1.0" });

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
            });
            return services;
        }
    }
    #endregion 

}
