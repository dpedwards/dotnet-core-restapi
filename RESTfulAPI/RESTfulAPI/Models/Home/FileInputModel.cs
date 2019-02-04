// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using Microsoft.AspNetCore.Http;

namespace RESTfulAPI.Model.Home
{
    /// <summary>
    /// 
    /// </summary>
    public class FileInputModel
    {
        /// <summary>
        /// 
        /// </summary>
        public IFormFile FileToUpload { get; set; }

    }
}
