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
    public static class StringsViewModelMapper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static StringsViewModel ToViewModel(this Strings entity)
        {

            return entity == null ? null : new StringsViewModel
            {

              String_Id = entity.String_Id,
              String_Data = entity.String_Data



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
        public static Strings ToEntity(this StringsViewModel viewModel)
        {
            return viewModel == null ? null : new Strings
            {
               

                String_Id = viewModel.String_Id,
                String_Data = viewModel.String_Data

                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}
