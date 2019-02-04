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
    public static class UserViewModelMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static UserViewModel ToViewModel(this User entity)
        {

            return entity == null ? null : new UserViewModel
            {

                Id = entity.Id,
                UserName = entity.UserName,
                Password = entity.Password




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
        public static User ToEntity(this UserViewModel viewModel)
        {
            return viewModel == null ? null : new User
            {
                Id = viewModel.Id,

                UserName = viewModel.UserName,
                Password = viewModel.Password


                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}


