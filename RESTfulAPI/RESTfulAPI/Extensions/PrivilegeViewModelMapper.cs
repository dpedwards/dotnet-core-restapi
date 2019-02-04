// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using RESTfulAPI.Core.EntityLayer;
using RESTfulAPI.ViewModels;

namespace RESTfulAPI.Extensions
{

    /// <summary>
    /// 
    /// </summary>
    public static class PrivilegeViewModelMapper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PrivilegeViewModel ToViewModel(this Privilege entity)
        {

            return entity == null ? null : new PrivilegeViewModel
            {

                Id = entity.Id,
                Privilege_Name = entity.Privilege_Name


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
        public static Privilege ToEntity(this PrivilegeViewModel viewModel)
        {
            return viewModel == null ? null : new Privilege
            {
                Id = viewModel.Id,
                Privilege_Name = viewModel.Privilege_Name

                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}
