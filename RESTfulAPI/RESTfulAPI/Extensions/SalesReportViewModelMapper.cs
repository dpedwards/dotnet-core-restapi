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
    public static class SalesReportViewModelMapper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SalesReportViewModel ToViewModel(this SalesReport entity)
        {

            return entity == null ? null : new SalesReportViewModel
            {

                //Id = entity.Id,

                Group_By = entity.Group_By,
                Display = entity.Display,
                Title = entity.Title,
                Filter_Row_Source = entity.Filter_Row_Source,
                Default = entity.Default



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
        public static SalesReport ToEntity(this SalesReportViewModel viewModel)
        {
            return viewModel == null ? null : new SalesReport
            {
                //Id = viewModel.Id,

                Group_By = viewModel.Group_By,
                Display = viewModel.Display,
                Title = viewModel.Title,
                Filter_Row_Source = viewModel.Filter_Row_Source,
                Default = viewModel.Default


                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}
