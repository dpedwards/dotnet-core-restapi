// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using RESTfulAPI.Core.EntityLayer;
using Microsoft.AspNetCore.Hosting;

namespace RESTfulAPI.Core.DataLayer
{
    public class RESTfulAPI_Repository : IRESTfulAPI_Repository
    {

        private readonly RESTfulAPI_DbContext DbContext;
        private Boolean Disposed;
        private RESTfulAPI_DbContext rESTfulAPI_DbContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public RESTfulAPI_Repository(RESTfulAPI_DbContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            DbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public RESTfulAPI_Repository(RESTfulAPI_DbContext rESTfulAPI_DbContext)
        {
            this.rESTfulAPI_DbContext = rESTfulAPI_DbContext;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                    Disposed = true;
                }
            }
        }



        #region Customer

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<Customer> GetCustomers(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<Customer>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);//Last_Name.ToLower().Contains(name.ToLower()));
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public Customer GetCustomer(Int32? id)
        {
            return DbContext.Set<Customer>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public Customer AddCustomer(Customer entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<Customer>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);
                       
                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);
                       
                    }
                }
            }

            return entity;

        }

        public Customer UpdateCustomer(Int32? id, Customer changes)
        {

            var entity = GetCustomer(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public Customer DeleteCustomer(int? id)
        {
            var entity = GetCustomer(id);

            if (entity != null)
            {
                DbContext.Set<Customer>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }

        #endregion

        #region Employee

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<Employee> GetEmployees(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<Employee>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);//Last_Name.ToLower().Contains(name.ToLower()));
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public Employee GetEmployee(Int32? id)
        {
            return DbContext.Set<Employee>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public Employee AddEmployee(Employee entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<Employee>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public Employee UpdateEmployee(Int32? id, Employee changes)
        {

            var entity = GetEmployee(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public Employee DeleteEmployee(int? id)
        {
            var entity = GetEmployee(id);

            if (entity != null)
            {
                DbContext.Set<Employee>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }

        #endregion

        #region Employee Privilege

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<EmployeePrivilege> GetEmployeePrivileges(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<EmployeePrivilege>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Employee_Id.HasValue);//Last_Name.ToLower().Contains(name.ToLower()));
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public EmployeePrivilege GetEmployeePrivilege(Int32? id)
        {
            return DbContext.Set<EmployeePrivilege>().FirstOrDefault(item => item.Employee_Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public EmployeePrivilege AddEmployeePrivilege(EmployeePrivilege entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<EmployeePrivilege>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public EmployeePrivilege UpdateEmployeePrivilege(Int32? id, EmployeePrivilege changes)
        {

            var entity = GetEmployeePrivilege(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public EmployeePrivilege DeleteEmployeePrivilege(int? id)
        {
            var entity = GetEmployeePrivilege(id);

            if (entity != null)
            {
                DbContext.Set<EmployeePrivilege>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }

        #endregion

        #region Inventory Transaction

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<InventoryTransaction> GetInventoryTransactions(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<InventoryTransaction>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);//ToLower().Contains(name.ToLower()));
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public InventoryTransaction GetInventoryTransaction(Int32? id)
        {
            return DbContext.Set<InventoryTransaction>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public InventoryTransaction AddInventoryTransaction(InventoryTransaction entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<InventoryTransaction>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public InventoryTransaction UpdateInventoryTransaction(Int32? id, InventoryTransaction changes)
        {

            var entity = GetInventoryTransaction(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public InventoryTransaction DeleteInventoryTransaction(int? id)
        {
            var entity = GetInventoryTransaction(id);

            if (entity != null)
            {
                DbContext.Set<InventoryTransaction>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }

        #endregion

        #region Inventory Transaction Type

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<InventoryTransactionType> GetInventoryTransactionTypes(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<InventoryTransactionType>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);//ToLower().Contains(name.ToLower()));
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public InventoryTransactionType GetInventoryTransactionType(Int32? id)
        {
            return DbContext.Set<InventoryTransactionType>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public InventoryTransactionType AddInventoryTransactionType(InventoryTransactionType entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<InventoryTransactionType>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public InventoryTransactionType UpdateInventoryTransactionType(Int32? id, InventoryTransactionType changes)
        {

            var entity = GetInventoryTransactionType(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public InventoryTransactionType DeleteInventoryTransactionType(int? id)
        {
            var entity = GetInventoryTransactionType(id);

            if (entity != null)
            {
                DbContext.Set<InventoryTransactionType>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }

        #endregion

        #region Invoice

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<Invoice> GetInvoices(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<Invoice>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);//ToLower().Contains(name.ToLower()));
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public Invoice GetInvoice(Int32? id)
        {
            return DbContext.Set<Invoice>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public Invoice AddInvoice(Invoice entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<Invoice>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public Invoice UpdateInvoice(Int32? id, Invoice changes)
        {

            var entity = GetInvoice(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public Invoice DeleteInvoice(int? id)
        {
            var entity = GetInvoice(id);

            if (entity != null)
            {
                DbContext.Set<Invoice>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }

        #endregion

        #region Order

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<Order> GetOrders(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<Order>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public Order GetOrder(Int32? id)
        {
            return DbContext.Set<Order>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public Order AddOrder(Order entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<Order>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public Order UpdateOrder(Int32? id, Order changes)
        {

            var entity = GetOrder(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public Order DeleteOrder(int? id)
        {
            var entity = GetOrder(id);

            if (entity != null)
            {
                DbContext.Set<Order>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }



        #endregion

        #region Order Status

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<OrderStatus> GetOrderStatuus(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<OrderStatus>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public OrderStatus GetOrderStatus(Int32? id)
        {
            return DbContext.Set<OrderStatus>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public OrderStatus AddOrderStatus(OrderStatus entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<OrderStatus>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public OrderStatus UpdateOrderStatus(Int32? id, OrderStatus changes)
        {

            var entity = GetOrderStatus(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public OrderStatus DeleteOrderStatus(int? id)
        {
            var entity = GetOrderStatus(id);

            if (entity != null)
            {
                DbContext.Set<OrderStatus>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }



        #endregion

        #region Order Tax Status

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<OrderTaxStatus> GetOrderTaxStatuses(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<OrderTaxStatus>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public OrderTaxStatus GetOrderTaxStatus(Int32? id)
        {
            return DbContext.Set<OrderTaxStatus>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public OrderTaxStatus AddOrderTaxStatus(OrderTaxStatus entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<OrderTaxStatus>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public OrderTaxStatus UpdateOrderTaxStatus(Int32? id, OrderTaxStatus changes)
        {

            var entity = GetOrderTaxStatus(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public OrderTaxStatus DeleteOrderTaxStatus(int? id)
        {
            var entity = GetOrderTaxStatus(id);

            if (entity != null)
            {
                DbContext.Set<OrderTaxStatus>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }



        #endregion

        #region Order Detail

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<OrderDetail> GetOrderDetails(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<OrderDetail>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public OrderDetail GetOrderDetail(Int32? id)
        {
            return DbContext.Set<OrderDetail>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public OrderDetail AddOrderDetail(OrderDetail entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<OrderDetail>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public OrderDetail UpdateOrderDetail(Int32? id, OrderDetail changes)
        {

            var entity = GetOrderDetail(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public OrderDetail DeleteOrderDetail(int? id)
        {
            var entity = GetOrderDetail(id);

            if (entity != null)
            {
                DbContext.Set<OrderDetail>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }



        #endregion

        #region Order Detail Status 

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<OrderDetailStatus> GetOrderDetailStatuses(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<OrderDetailStatus>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public OrderDetailStatus GetOrderDetailStatus(Int32? id)
        {
            return DbContext.Set<OrderDetailStatus>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public OrderDetailStatus AddOrderDetailStatus(OrderDetailStatus entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<OrderDetailStatus>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public OrderDetailStatus UpdateOrderDetailStatus(Int32? id, OrderDetailStatus changes)
        {

            var entity = GetOrderDetailStatus(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public OrderDetailStatus DeleteOrderDetailStatus(int? id)
        {
            var entity = GetOrderDetailStatus(id);

            if (entity != null)
            {
                DbContext.Set<OrderDetailStatus>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }



        #endregion

        #region Privilege

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<Privilege> GetPrivileges(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<Privilege>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public Privilege GetPrivilege(Int32? id)
        {
            return DbContext.Set<Privilege>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public Privilege AddPrivilege(Privilege entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<Privilege>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public Privilege UpdatePrivilege(Int32? id, Privilege changes)
        {

            var entity = GetPrivilege(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public Privilege DeletePrivilege(int? id)
        {
            var entity = GetPrivilege(id);

            if (entity != null)
            {
                DbContext.Set<Privilege>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }



        #endregion

        #region Product

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<Product> GetProducts(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<Product>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public Product GetProduct(Int32? id)
        {
            return DbContext.Set<Product>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public Product AddProduct(Product entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<Product>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public Product UpdateProduct(Int32? id, Product changes)
        {

            var entity = GetProduct(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public Product DeleteProduct(int? id)
        {
            var entity = GetProduct(id);

            if (entity != null)
            {
                DbContext.Set<Product>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }



        #endregion

        #region Purchase Orders

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<PurchaseOrder> GetPurchaseOrders(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<PurchaseOrder>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public PurchaseOrder GetPurchaseOrder(Int32? id)
        {
            return DbContext.Set<PurchaseOrder>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public PurchaseOrder AddPurchaseOrder(PurchaseOrder entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<PurchaseOrder>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public PurchaseOrder UpdatePurchaseOrder(Int32? id, PurchaseOrder changes)
        {

            var entity = GetPurchaseOrder(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public PurchaseOrder DeletePurchaseOrder(int? id)
        {
            var entity = GetPurchaseOrder(id);

            if (entity != null)
            {
                DbContext.Set<PurchaseOrder>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }



        #endregion

        #region Purchase Orders Detail

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<PurchaseOrderDetail> GetPurchaseOrderDetails(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<PurchaseOrderDetail>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public PurchaseOrderDetail GetPurchaseOrderDetail(Int32? id)
        {
            return DbContext.Set<PurchaseOrderDetail>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public PurchaseOrderDetail AddPurchaseOrderDetail(PurchaseOrderDetail entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<PurchaseOrderDetail>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public PurchaseOrderDetail UpdatePurchaseOrderDetail(Int32? id, PurchaseOrderDetail changes)
        {

            var entity = GetPurchaseOrderDetail(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public PurchaseOrderDetail DeletePurchaseOrderDetail(int? id)
        {
            var entity = GetPurchaseOrderDetail(id);

            if (entity != null)
            {
                DbContext.Set<PurchaseOrderDetail>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }



        #endregion

        #region Purchase Order Status

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<PurchaseOrderStatus> GetPurchaseOrderStatuses(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<PurchaseOrderStatus>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public PurchaseOrderStatus GetPurchaseOrderStatus(Int32? id)
        {
            return DbContext.Set<PurchaseOrderStatus>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public PurchaseOrderStatus AddPurchaseOrderStatus(PurchaseOrderStatus entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<PurchaseOrderStatus>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public PurchaseOrderStatus UpdatePurchaseOrderStatus(Int32? id, PurchaseOrderStatus changes)
        {

            var entity = GetPurchaseOrderStatus(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public PurchaseOrderStatus DeletePurchaseOrderStatus(int? id)
        {
            var entity = GetPurchaseOrderStatus(id);

            if (entity != null)
            {
                DbContext.Set<PurchaseOrderStatus>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }



        #endregion

        #region Sales Report

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<SalesReport> GetSalesReports(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<SalesReport>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Title.ToLower().Contains(name.ToLower()));
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="default"></param>
        public SalesReport GetSalesReport(Boolean _default)
        {
            return DbContext.Set<SalesReport>().FirstOrDefault(item => item.Default == _default);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public SalesReport AddSalesReport(SalesReport entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<SalesReport>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        //public SalesReport UpdateSalesReport(Int32? id, SalesReport changes)
        //{

        //    var entity = GetSalesReport(id);

        //    if (entity != null)
        //    {
        //        //

        //        DbContext.SaveChanges();
        //    }
        //    return entity;
        //}

        //public SalesReport DeleteSalesReport(int? id)
        //{
        //    var entity = GetSalesReport(id);

        //    if (entity != null)
        //    {
        //        DbContext.Set<SalesReport>().Remove(entity);

        //        DbContext.SaveChanges();
        //    }

        //    return entity;
        //}



        #endregion

        #region Shipper

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<Shipper> GetShippers(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<Shipper>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);//Last_Name.ToLower().Contains(name.ToLower()));
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public Shipper GetShipper(Int32? id)
        {
            return DbContext.Set<Shipper>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public Shipper AddShipper(Shipper entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<Shipper>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public Shipper UpdateShipper(Int32? id, Shipper changes)
        {

            var entity = GetShipper(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public Shipper DeleteShipper(int? id)
        {
            var entity = GetShipper(id);

            if (entity != null)
            {
                DbContext.Set<Shipper>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }

        #endregion

        #region Strings

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<Strings> GetStringss(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<Strings>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.String_Id.HasValue);
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public Strings GetStrings(Int32? id)
        {
            return DbContext.Set<Strings>().FirstOrDefault(item => item.String_Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public Strings AddStrings(Strings entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<Strings>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public Strings UpdateStrings(Int32? id, Strings changes)
        {

            var entity = GetStrings(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public Strings DeleteStrings(int? id)
        {
            var entity = GetStrings(id);

            if (entity != null)
            {
                DbContext.Set<Strings>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }

        #endregion

        #region Supplier

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<Supplier> GetSuppliers(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<Supplier>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public Supplier GetSupplier(Int32? id)
        {
            return DbContext.Set<Supplier>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public Supplier AddSupplier(Supplier entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<Supplier>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public Supplier UpdateSupplier(Int32? id, Supplier changes)
        {

            var entity = GetSupplier(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public Supplier DeleteSupplier(int? id)
        {
            var entity = GetSupplier(id);

            if (entity != null)
            {
                DbContext.Set<Supplier>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }

        #endregion

        #region User

        /// <summary>
        ///
        ///<summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        public IEnumerable<User> GetUsers(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<User>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Id.HasValue);//Last_Name.ToLower().Contains(name.ToLower()));
            }
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public User GetUser(Int32? id)
        {
            return DbContext.Set<User>().FirstOrDefault(item => item.Id == id);
        }


        /// <summar>
        ///
        /// </summary>
        /// <param name="entity"></param>
        public User AddUser(User entity)
        {
            try
            {
                //entity.TransactionId = String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond) + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
                //entity.RowGuid = Guid.NewGuid();
                //entity.ModifiedDate = DateTime.Now;


                DbContext.Set<User>().Add(entity);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorGuidString = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

                //HttpContext.Session.SetString("ErrorGuid", errorGuid);
                //ViewBag.ErrorGuid = HttpContext.Session.GetString("ErrorGuid");

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {

                    string webRootPath = _hostingEnvironment.WebRootPath;


                    using (StreamWriter w = new StreamWriter(webRootPath + "\\log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;

                    using (StreamWriter w = new StreamWriter(webRootPath + "/log.txt", append: true))
                    {

                        Log.Logging(ex.ToString(), w, errorGuidString);

                    }
                }
            }

            return entity;

        }

        public User UpdateUser(Int32? id, User changes)
        {

            var entity = GetUser(id);

            if (entity != null)
            {
                //

                DbContext.SaveChanges();
            }
            return entity;
        }

        public User DeleteUser(int? id)
        {
            var entity = GetUser(id);

            if (entity != null)
            {
                DbContext.Set<User>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }

        #endregion

    }


}
