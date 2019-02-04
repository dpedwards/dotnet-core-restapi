// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using System.Collections.Generic;
using RESTfulAPI.Core.EntityLayer;

namespace RESTfulAPI.Core.DataLayer
{
    public interface IRESTfulAPI_Repository : IDisposable
    {

        #region User

        IEnumerable<User> GetUsers(Int32 pageSize, Int32 pageNumber, String name);

        User GetUser(Int32? id);
        User AddUser(User entity);
        User UpdateUser(Int32? id, User changes);
        User DeleteUser(Int32? id);

        #endregion

        #region Customer 

        IEnumerable<Customer> GetCustomers(Int32 pageSize, Int32 pageNumber, String name);

        Customer GetCustomer(Int32? id);
        Customer AddCustomer(Customer entity);
        Customer UpdateCustomer(Int32? id, Customer changes);
        Customer DeleteCustomer(Int32? id);

        #endregion

        #region Employee

        IEnumerable<Employee> GetEmployees(Int32 pageSize, Int32 pageNumber, String name);

        Employee GetEmployee(Int32? id);
        Employee AddEmployee(Employee entity);
        Employee UpdateEmployee(Int32? id, Employee changes);
        Employee DeleteEmployee(Int32? id);

        #endregion

        #region Employee Privilege

        IEnumerable<EmployeePrivilege> GetEmployeePrivileges(Int32 pageSize, Int32 pageNumber, String name);

        EmployeePrivilege GetEmployeePrivilege(Int32? id);
        EmployeePrivilege AddEmployeePrivilege(EmployeePrivilege entity);
        EmployeePrivilege UpdateEmployeePrivilege(Int32? id, EmployeePrivilege changes);
        EmployeePrivilege DeleteEmployeePrivilege(Int32? id);

        #endregion

        #region Inventory Transactions

        IEnumerable<InventoryTransaction> GetInventoryTransactions(Int32 pageSize, Int32 pageNumber, String name);

        InventoryTransaction GetInventoryTransaction(Int32? id);
        InventoryTransaction AddInventoryTransaction(InventoryTransaction entity);
        InventoryTransaction UpdateInventoryTransaction(Int32? id, InventoryTransaction changes);
        InventoryTransaction DeleteInventoryTransaction(Int32? id);

        #endregion

        #region Inventory Transaction Types

        IEnumerable<InventoryTransactionType> GetInventoryTransactionTypes(Int32 pageSize, Int32 pageNumber, String name);

        InventoryTransactionType GetInventoryTransactionType(Int32? id);
        InventoryTransactionType AddInventoryTransactionType(InventoryTransactionType entity);
        InventoryTransactionType UpdateInventoryTransactionType(Int32? id, InventoryTransactionType changes);
        InventoryTransactionType DeleteInventoryTransactionType(Int32? id);

        #endregion

        #region Invoice

        IEnumerable<Invoice> GetInvoices(Int32 pageSize, Int32 pageNumber, String name);

        Invoice GetInvoice(Int32? id);
        Invoice AddInvoice(Invoice entity);
        Invoice UpdateInvoice(Int32? id, Invoice changes);
        Invoice DeleteInvoice(Int32? id);

        #endregion

        #region Order

        IEnumerable<Order> GetOrders(Int32 pageSize, Int32 pageNumber, String name);
        Order GetOrder(Int32? id);
        Order AddOrder(Order entity);
        Order UpdateOrder(Int32? id, Order changes);
        Order DeleteOrder(Int32? id);

        #endregion

        #region Order Status

        IEnumerable<OrderStatus> GetOrderStatuus(Int32 pageSize, Int32 pageNumber, String name);

        OrderStatus GetOrderStatus(Int32? id);
        OrderStatus AddOrderStatus(OrderStatus entity);
        OrderStatus UpdateOrderStatus(Int32? id, OrderStatus changes);
        OrderStatus DeleteOrderStatus(Int32? id);

        #endregion

        #region Order Tax Status

        IEnumerable<OrderTaxStatus> GetOrderTaxStatuses(Int32 pageSize, Int32 pageNumber, String name);

        OrderTaxStatus GetOrderTaxStatus(Int32? id);
        OrderTaxStatus AddOrderTaxStatus(OrderTaxStatus entity);
        OrderTaxStatus UpdateOrderTaxStatus(Int32? id, OrderTaxStatus changes);
        OrderTaxStatus DeleteOrderTaxStatus(Int32? id);

        #endregion

        #region Order Detail

        IEnumerable<OrderDetail> GetOrderDetails(Int32 pageSize, Int32 pageNumber, String name);

        OrderDetail GetOrderDetail(Int32? id);
        OrderDetail AddOrderDetail(OrderDetail entity);
        OrderDetail UpdateOrderDetail(Int32? id, OrderDetail changes);
        OrderDetail DeleteOrderDetail(Int32? id);

        #endregion

        #region Order Detail Status

        IEnumerable<OrderDetailStatus> GetOrderDetailStatuses(Int32 pageSize, Int32 pageNumber, String name);

        OrderDetailStatus GetOrderDetailStatus(Int32? id);
        OrderDetailStatus AddOrderDetailStatus(OrderDetailStatus entity);
        OrderDetailStatus UpdateOrderDetailStatus(Int32? id, OrderDetailStatus changes);
        OrderDetailStatus DeleteOrderDetailStatus(Int32? id);

        #endregion

        #region Privilege

        IEnumerable<Privilege> GetPrivileges(Int32 pageSize, Int32 pageNumber, String name);

        Privilege GetPrivilege(Int32? id);
        Privilege AddPrivilege(Privilege entity);
        Privilege UpdatePrivilege(Int32? id, Privilege changes);
        Privilege DeletePrivilege(Int32? id);

        #endregion

        #region Product

        IEnumerable<Product> GetProducts(Int32 pageSize, Int32 pageNumber, String name);

        Product GetProduct(Int32? id);
        Product AddProduct(Product entity);
        Product UpdateProduct(Int32? id, Product changes);
        Product DeleteProduct(Int32? id);

        #endregion

        #region Purchase Order 

        IEnumerable<PurchaseOrder> GetPurchaseOrders(Int32 pageSize, Int32 pageNumber, String name);

        PurchaseOrder GetPurchaseOrder(Int32? id);
        PurchaseOrder AddPurchaseOrder(PurchaseOrder entity);
        PurchaseOrder UpdatePurchaseOrder(Int32? id, PurchaseOrder changes);
        PurchaseOrder DeletePurchaseOrder(Int32? id);

        #endregion

        #region Purchase Order Detail

        IEnumerable<PurchaseOrderDetail> GetPurchaseOrderDetails(Int32 pageSize, Int32 pageNumber, String name);

        PurchaseOrderDetail GetPurchaseOrderDetail(Int32? id);
        PurchaseOrderDetail AddPurchaseOrderDetail(PurchaseOrderDetail entity);
        PurchaseOrderDetail UpdatePurchaseOrderDetail(Int32? id, PurchaseOrderDetail changes);
        PurchaseOrderDetail DeletePurchaseOrderDetail(Int32? id);

        #endregion

        #region Purchase Order Status

        IEnumerable<PurchaseOrderStatus> GetPurchaseOrderStatuses(Int32 pageSize, Int32 pageNumber, String name);

        PurchaseOrderStatus GetPurchaseOrderStatus(Int32? id);
        PurchaseOrderStatus AddPurchaseOrderStatus(PurchaseOrderStatus entity);
        PurchaseOrderStatus UpdatePurchaseOrderStatus(Int32? id, PurchaseOrderStatus changes);
        PurchaseOrderStatus DeletePurchaseOrderStatus(Int32? id);

        #endregion

        #region Sales Report

        IEnumerable<SalesReport> GetSalesReports(Int32 pageSize, Int32 pageNumber, String name);

        //SalesReport GetSalesReport(Int32? id);
        SalesReport AddSalesReport(SalesReport entity);
        //SalesReport UpdateSalesReport(Int32? id, SalesReport changes);
        //SalesReport DeleteSalesReport(Int32? id);

        #endregion

        #region Shipper

        IEnumerable<Shipper> GetShippers(Int32 pageSize, Int32 pageNumber, String name);

        Shipper GetShipper(Int32? id);
        Shipper AddShipper(Shipper entity);
        Shipper UpdateShipper(Int32? id, Shipper changes);
        Shipper DeleteShipper(Int32? id);

        #endregion

        #region Strings

        IEnumerable<Strings> GetStringss(Int32 pageSize, Int32 pageNumber, String name);

        Strings GetStrings(Int32? id);
        Strings AddStrings(Strings entity);
        Strings UpdateStrings(Int32? id, Strings changes);
        Strings DeleteStrings(Int32? id);

        #endregion

        #region Supplier

        IEnumerable<Supplier> GetSuppliers(Int32 pageSize, Int32 pageNumber, String name);

        Supplier GetSupplier(Int32? id);
        Supplier AddSupplier(Supplier entity);
        Supplier UpdateSupplier(Int32? id, Supplier changes);
        Supplier DeleteSupplier(Int32? id);

        #endregion
    }

}
