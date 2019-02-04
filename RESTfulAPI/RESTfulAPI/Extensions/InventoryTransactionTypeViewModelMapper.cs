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
    public static class InventoryTransactionTypeViewModelMapper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static InventoryTransactionTypeViewModel ToViewModel(this InventoryTransactionType entity)
        {

            return entity == null ? null : new InventoryTransactionTypeViewModel
            {

                Id = entity.Id,
                Type_Name = entity.Type_Name



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
        public static InventoryTransactionType ToEntity(this InventoryTransactionTypeViewModel viewModel)
        {
            return viewModel == null ? null : new InventoryTransactionType
            {
                Id = viewModel.Id,
                Type_Name = viewModel.Type_Name
               

                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}
