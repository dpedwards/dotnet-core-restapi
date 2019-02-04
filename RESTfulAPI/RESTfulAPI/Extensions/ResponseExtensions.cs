// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTfulAPI.Responses;
using System.Net;

namespace RESTfulAPI.Extensions
{

    /// <summary>
    /// 
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public static IActionResult ToHttpResponse<TModel>(this IListModelResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Model == null)
            {
                status = HttpStatusCode.NoContent;
            }

            return new ObjectResult(response) { StatusCode = (Int32)status };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public static IActionResult ToHttpResponse<TModel>(this ISingleModelResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Model == null)
            {
                status = HttpStatusCode.NotFound;
            }

            return new ObjectResult(response) { StatusCode = (Int32)status };
        }


        /// <summary>
        /// TEST
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        //public static IActionResult ToHttpResponseTest<TModel>(this ISingleModelResponse<TModel> response2)
        //{


        //    // return new ObjectResult(response2) { Value = response2.ToHttpResponse() };
        //    //return new ObjectResult(response2) { Value = RemoteStatements.GlobalMessageProcessText01 + "\n" +
        //    //                                             RemoteStatements.GlobalMessageProcessText01_1 + "\n" };
        //}

    }
}
