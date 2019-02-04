// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using System.Collections.Generic;

namespace RESTfulAPI.Responses
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IListModelResponse<TModel> : IResponse
    {
        /// <summary>
        /// 
        /// </summary>
        Int32 PageSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Int32 PageNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<TModel> Model { get; set; }
    }
}
