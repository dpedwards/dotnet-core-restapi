// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RESTfulAPI.Core.EntityLayer;
using RESTfulAPI.ViewModels;

namespace RESTfulAPI.Extensions
{

    /// <summary>
    /// 
    /// </summary>
    public static class EmployeePrivilegeViewModelMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static EmployeePrivilegeViewModel ToViewModel(this EmployeePrivilege entity)
        {

            return entity == null ? null : new EmployeePrivilegeViewModel
            {

                Employee_Id = entity.Employee_Id,
                Privilege_Id = entity.Privilege_Id
               



                //
                //RowGuid = entity.RowGuid,
                //ModifiedDate = entity.ModifiedDate

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static EmployeePrivilege ToEntity(this EmployeePrivilegeViewModel viewModel)
        {
            return viewModel == null ? null : new EmployeePrivilege
            {

                Employee_Id = viewModel.Employee_Id,
                Privilege_Id = viewModel.Privilege_Id

                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}

