using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RESTfulAPI.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public class AboutModel : PageModel
    {

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string RouteDataText { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public void OnGet()
        {
            Message = "Your application description page.";
        }
    }
}
