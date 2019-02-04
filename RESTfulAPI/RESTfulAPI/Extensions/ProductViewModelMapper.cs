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
    public static class ProductViewModelMapper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ProductViewModel ToViewModel(this Product entity)
        {

            return entity == null ? null : new ProductViewModel
            {

                Id = entity.Id,
                Supplier_Ids = entity.Supplier_Ids,
                Product_Code = entity.Product_Code,
                Product_Name = entity.Product_Name,
                Description = entity.Description,
                Standard_Cost = entity.Standard_Cost,
                List_Price = entity.List_Price,
                Reorder_Level = entity.Reorder_Level,
                Target_Level = entity.Target_Level,
                Quantity_Per_Unit = entity.Quantity_Per_Unit,
                Discontinued = entity.Discontinued,
                Minimum_Reorder_Quantity = entity.Minimum_Reorder_Quantity,
                Category = entity.Category,
                Attachments = entity.Attachments




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
        public static Product ToEntity(this ProductViewModel viewModel)
        {
            return viewModel == null ? null : new Product
            {
              
                Id = viewModel.Id,
                Supplier_Ids = viewModel.Supplier_Ids,
                Product_Code = viewModel.Product_Code,
                Product_Name = viewModel.Product_Name,
                Description = viewModel.Description,
                Standard_Cost = viewModel.Standard_Cost,
                List_Price = viewModel.List_Price,
                Reorder_Level = viewModel.Reorder_Level,
                Target_Level = viewModel.Target_Level,
                Quantity_Per_Unit = viewModel.Quantity_Per_Unit,
                Discontinued = viewModel.Discontinued,
                Minimum_Reorder_Quantity = viewModel.Minimum_Reorder_Quantity,
                Category = viewModel.Category,
                Attachments = viewModel.Attachments


                //
                //RowGuid = viewModel.RowGuid,
                //ModifiedDate = viewModel.ModifiedDate

            };
        }
    }
}
