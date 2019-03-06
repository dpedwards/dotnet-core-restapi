# [.NET Core RESTful API with swagger API Doc based on Northwind MySQL database template](https://github.com/dpedwards/dotnet-core-restapi)

[![LICENSE](https://img.shields.io/badge/license-MIT-lightgrey.svg)](https://raw.githubusercontent.com/dpedwards/dotnet-core-restapi/master/LICENSE)
[![.NET Core](https://img.shields.io/badge/dotnet%20core-%3E%3D%202.0-blue.svg)](https://dotnet.microsoft.com/download)
[![swagger](https://img.shields.io/badge/swagger-%3E%3D%201.2.0-blue.svg)](https://rubygems.org/gems/minimal-mistakes-jekyll)
[![Tip Me via PayPal](https://img.shields.io/badge/PayPal-tip%20me-green.svg?logo=paypal)](https://www.paypal.me/dare2101)

This Template is based on the Northwind MySQl database, an excellent tutorial schema for a small-business ERP, with customers, orders, inventory, purchasing, suppliers, shipping, employees, and single-entry accounting.

:sparkles: See what`s new in the [CHANGELOG](CHANGELOG.md).

**If you enjoy this template, please consider [supporting me](https://www.paypal.me/dare2101) for developing and maintaining it.**

[![Support via PayPal](https://cdn.rawgit.com/twolfson/paypal-github-button/1.0.0/dist/button.svg)](https://www.paypal.me/dare2101)


## Pictures 



Index:
<img src="RESTfulAPI/images/NET%20Core%20RESTful%20API_Index.png" >


Swagger API Doc Overview:
<img src="RESTfulAPI/images/NET%20Core%20RESTful%20API_Swagger.png" >


JWT WebService (Swagger API Doc):
<img src="RESTfulAPI/images/NET%20Core%20RESTful%20API_Swagger2.png" >


JWT Bearer (Swagger API Doc):
<img src="RESTfulAPI/images/NET%20Core%20RESTful%20API_Swagger3.png" >


API key authorization (Swagger API Doc):
<img src="RESTfulAPI/images/NET%20Core%20RESTful%20API_Swagger4.png" >


WebService call (Swagger API Doc):
<img src="RESTfulAPI/images/NET%20Core%20RESTful%20API_Swagger5.png" >


## Notable features

- OAuth 2.0 JWT bearer authentication
- .pfx certificate support
- swagger API Doc 
- CRUD operations
- File up-/download
- Windows & Linux platform support
- MySQL / MS SQL support 
- Razor Page support
- Unit Test
- Error logging


## Installation

For this project you need to install .NET Core 2.1 Framework and MySQL/MariaDB on your local machine!

### 



1. Execute the `northwind.sql` file in MySQL/MariaDB and create the northwind db:

   ```yaml
   path: RESTfulAPI/RESTfulAPI/wwwroot/documents/northwind.sql
   ```
   

2. Execute the `nothwind-data.sql` file in MySQL/MariaDB and fill the previously created northwind db with test datasets:

    ```yaml
   path: RESTfulAPI/RESTfulAPI/wwwroot/documents/northwind-data.sql
   ```

3. Change the MySQL/MariaDB connection string in `appsettings.json` file:

   ```yaml
   path: RESTfulAPI/RESTfulAPI/application.json
   ```

4. Run the project inside the Visual Studio IDE/Visual Sudio Code Editor or navigate to project root path `RESTfulAPI\RESTfulAPI` with Windows cmd or linux terminal console and enter the following dotnet core commands:

   ```yaml
   cmd: dotnet restore
   ```
   
   ```yaml
   cmd: dotnet run
   ```
   
## Development

5. If all is fine the project will run on port 5001 you can access with https://localhost:5001.

6. For testing REST CRUD operations you can access the swagger API Doc https://localhost:5001/swagger. 

7. Before you can start CRUD operations on any implemented WebService you have to authenticate with the Token WebService:

8. Paste in the following JSON structure and press the `Try it out!` button.

 ```yaml
               {
                 "userName": "TestUser",
                 "password": "P455w0rd"
               }
   ```

9. Next copy the Bearer token string inside from the response body element like in this example in the square brackets --> `"token:""[eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6I...]"`.

10. Now navigate to the top of the swagger API Doc page view and push the green space button with white text `Authorize` on the right side.

11. After a new window poped up, paste the Bearer token string in the `value:` field with following convention shown in square brackets --> `[Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6I...]`.

12. Finally authenticate with pushing the grey `Auhtorize` button.

If you need some more help please feel free to message me. Happy coding! 


## Usage

For detailed instructions on how to configure, customize, add/migrate content, and more read the [template`s documentation](https://github.com/dpedwards/dotnet-core-restapidocs/quick-start-guide/).

---

## Contributing

Having trouble working with the template? Found a typo in the documentation? Interested in adding a feature or [fixing a bug](https://github.com/dpedwards/dotnet-core-restapi/issues)? Then by all means [submit an issue](https://github.com/dpedwards/dotnet-core-restapi/issues/new) or [pull request](https://help.github.com/articles/using-pull-requests/). If this is your first pull request, it may be helpful to read up on the [GitHub Flow](https://guides.github.com/introduction/flow/) first.

### Pull Requests

When submitting a pull request:

1. Clone the repo.
2. Create a branch off of `master` and give it a meaningful name (e.g. `my-awesome-new-feature`).
3. Open a pull request on GitHub and describe the feature or fix.

Template documentation and demo pages can be found in the [`/docs`](docs) if submitting improvements, typo corrections, etc.

---

## Credits

### Creator

**Davain Pablo Edwards**

- <https://soon.com>
- <https://twitter.com/soon>
- <https://github.com/dpedwards>


### Other:

- [Couchbase.Extensions.Session](https://github.com/couchbaselabs/Couchbase.Extensions)
- [Microsoft.ApplicationInsights.AspNetCore](https://docs.microsoft.com/de-de/azure/azure-monitor/app/app-insights-overview)
- [Microsoft.AspNetCore.All](https://www.asp.net/)
- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.asp.net/)
- [Microsoft.AspNetCore.Hosting](https://www.asp.net/)
- [Microsoft.AspNetCore.Identity](https://www.asp.net/)
- [Microsoft.AspNetCore.Mvc](https://www.asp.net/)
- [Microsoft.AspNetCore.Mvc.WebApiCompatShim](https://www.asp.net/)
- [Microsoft.AspNetCore.Routing](https://www.asp.net/)
- [Microsoft.AspNetCore.Server.IISIntegration](https://www.asp.net/)
- [Microsoft.AspNetCore.Server.Kestrel.Https](https://www.asp.net/)
- [Microsoft.AspNetCore.Session](https://www.asp.net/)
- [Microsoft.AspNetCore.StaticFiles](https://www.asp.net/)
- [Microsoft.Composition](https://blogs.msdn.microsoft.com/bclteam/p/composition/)
- [Microsoft.EntityFrameworkCore.Design](https://www.asp.net/)
- [Microsoft.EntityFrameworkCore.SqlServer](https://www.asp.net/)
- [Microsoft.EntityFrameworkCore.Tools](https://www.asp.net/)
- [Microsoft.Extensions.Logging.Debug](https://www.asp.net/)
- [Microsoft.Extensions.PlatformAbstractions](https://www.asp.net/)
- [Microsoft.IdentityModel.Tokens](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet)
- [Microsoft.NET.Sdk.Razor](https://www.asp.net/)
- [Microsoft.NETCore.App](https://dotnet.microsoft.com/)
- [Microsoft.VisualStudio.Web.CodeGeneration.Design](https://www.asp.net/)
- [MySql.Data.EntityFrameworkCore](https://dev.mysql.com/downloads/)
- [ReflectionIT.Mvc.Paging](https://github.com/sonnemaf/ReflectionIT.Mvc.Paging)
- [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [Swashbuckle.AspNetCore.Examples](https://github.com/mattfrear/Swashbuckle.AspNetCore.Filters)
- [System.IdentityModel.Tokens.Jwt](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet)
- [System.Linq.Dynamic.Core](https://github.com/StefH/System.Linq.Dynamic.Core)
- [System.Security.Cryptography.OpenSsl](https://dotnet.microsoft.com/)
- [Pomelo.Data.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql) 
- [Pomelo.EntityFrameworkCore.MySQL](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)
- [Microsoft.NET.Test.Sdk](https://github.com/microsoft/vstest/)
- [xunit](https://github.com/xunit/xunit)
- [xunit.runner.visualstudio](https://github.com/xunit/xunit)

---

## License

MIT License

Copyright (c) 2019 Davain Pablo Edwards

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
