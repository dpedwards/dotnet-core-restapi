// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System.Collections.Generic;

namespace RESTfulAPI.Core.DataLayer
{

    public class RESTfulAPI_EntityMapper : EntityMapper
    {

        public RESTfulAPI_EntityMapper()
        {
            Mappings = new List<IEntityMap>()
            {
             
                new CustomerMap() as IEntityMap,
                new EmployeeMap() as IEntityMap,
                new InventoryTransactionMap() as IEntityMap,
                new InventoryTransactionTypeMap() as IEntityMap,
                new InvoiceMap() as IEntityMap,
                new OrderMap() as IEntityMap,
                new OrderStatusMap() as IEntityMap,
                new OrderTaxStatusMap() as IEntityMap,
                new OrderDetailMap() as IEntityMap,
                new OrderDetailStatusMap() as IEntityMap,
                new PrivilegeMap() as IEntityMap,
                new ProductMap() as IEntityMap,
                new PurchaseOrderMap() as IEntityMap,
                new PurchaseOrderDetailMap() as IEntityMap,
                new PurchaseOrderStatusMap() as IEntityMap,
                new SalesReportMap() as IEntityMap,
                new ShipperMap() as IEntityMap,
                new StringsMap() as IEntityMap,
                new SupplierMap() as IEntityMap
            };
        }
    }
}
