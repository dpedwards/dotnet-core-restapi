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
    /// <typeparam name="TModel"></typeparam>
    public interface ISingleModelResponse<TModel> : IResponse
    {
        /// <summary>
        /// 
        /// </summary>
        TModel Model { get; set; }

    }
}
