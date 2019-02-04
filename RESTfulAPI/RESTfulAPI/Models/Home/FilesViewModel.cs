
using System.Collections.Generic;

// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

namespace RESTfulAPI.Models.Home
{

    /// <summary>
    /// 
    /// 
    /// </summary>
    public class FileDetails
    {

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Path { get; set; }

    }

    /// <summary>
    /// 
    /// File download
    /// </summary>
    public class FilesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<FileDetails> Files { get; set; } = new List<FileDetails>();

    }



}
