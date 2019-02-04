// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;


namespace RESTfulAPI.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// 
        /// </summary>
        String Info { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Boolean DidError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        String ErrorMessage { get; set; }
    }
}