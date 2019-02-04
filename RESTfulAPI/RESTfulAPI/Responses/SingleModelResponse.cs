// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulAPI.Responses
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class SingleModelResponse<TModel> : ISingleModelResponse<TModel>
    {

        /// <summary>
        /// 
        /// </summary>
        public Boolean DidError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String ErrorMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Info { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TModel Model { get; set; }
     
    }
}
