using System;
using System.Collections.Generic;
using DAL;
using System.Data;

namespace BAL
{
    public class BusinessLayer
    {
        DataAccessLayer objDAL = new DataAccessLayer();

        public BusinessLayer()
        {

        }

        #region User Account
        /// <summary>
        /// Return UserAccount Object by Username and Password
        /// </summary>
        /// <param name="sUserName">Username</param>
        /// <param name="sPassword">Password</param>
        /// <returns>UserSAccount Object</returns>
        public UserAccount GetUserAccount(string sUserName, string sPassword)
        {
            DataTable dtUser = null;
            UserAccount objUA = new UserAccount();
            string sUserType = string.Empty;

            try
            {
                //Fill Datatable with User Info By Username and Password
                dtUser = objDAL.GetUserAccount(sUserName, sPassword);

                //Check to make sure datatable has rows
                if (dtUser != null)
                {
                    if (dtUser.Rows.Count > 0)
                    {
                        //Hydrate Object from datatable
                        objUA.UserId = int.Parse(dtUser.Rows[0]["UserID"].ToString());
                        objUA.UserName = dtUser.Rows[0]["UserName"].ToString();
                        objUA.Password = dtUser.Rows[0]["Password"].ToString();
                        sUserType = dtUser.Rows[0]["Role"].ToString();

                        //Transform Datatable value to Enum
                        switch (sUserType)
                        {
                            case "C":
                                objUA.UserType = UserAccount.UserRole.Customer;
                                break;
                            case "M":
                                objUA.UserType = UserAccount.UserRole.OperationManager;
                                break;
                            case "S":
                                objUA.UserType = UserAccount.UserRole.Sales;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //Return UserAccount Object
            return objUA;
        }

        /// <summary>
        /// Inserts new user into the database if its not already present
        /// </summary>
        /// <param name="objUserAccount">UserAccount Object</param>
        /// <returns>New UserAccount Object</returns>
        public UserAccount InsertUser(UserAccount objUserAccount)
        {
            string sUserType = string.Empty;

            try
            {
                //Check to ensure all fields are present
                if (objUserAccount != null)
                {
                    if (string.IsNullOrEmpty(objUserAccount.UserName))
                        throw new Exception("UserName can not be null or empty");

                    if (string.IsNullOrEmpty(objUserAccount.Password))
                        throw new Exception("Password can not be null or empty");
                }
                else
                {
                    throw new Exception("UserAccount is NULL");
                }

                //Deserialize role for insertion
                switch (objUserAccount.UserType)
                {
                    case UserAccount.UserRole.Customer:
                        sUserType = "C";
                        break;
                    case UserAccount.UserRole.OperationManager:
                        sUserType = "M";
                        break;
                    case UserAccount.UserRole.Sales:
                        sUserType = "S";
                        break;
                }


                //Insert New User
                if (objDAL.InsertUser(objUserAccount.UserName, objUserAccount.Password, sUserType))
                {
                    //Rehydrate UserAccount to ensure inserted correctly
                    return GetUserAccount(objUserAccount.UserName, objUserAccount.Password);
                }
                else
                {
                    throw new Exception("User Failed to be inserted");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        #endregion

        #region Customer
        /// <summary>
        /// /Return Customer Object By SearchFilter
        /// </summary>
        /// <param name="objSearchFilter">Customer.SearchFilter Enum</param>
        /// <param name="sValue">Value</param>
        /// <returns></returns>
        public Customer GetCustomerByFilter(Customer.SearchFilter objSearchFilter, string sValue)
        {
            DataTable dtCus = null;
            Customer objCus = new Customer();
            string sUserType = string.Empty, sClause = string.Empty;

            try
            {
                //Options to Filter By
                switch (objSearchFilter)
                {
                    case Customer.SearchFilter.CustomerID:
                        sClause = "CustomerID";
                        break;
                    case Customer.SearchFilter.LastName:
                        sClause = "CustomerLastName";
                        break;
                    case Customer.SearchFilter.UserId:
                        sClause = "UserID";
                        break;
                }

                //Fill DataTable with Customer Info By Search Filter
                dtCus = objDAL.GetCustomerBySearchFilter(sClause, sValue);

                //Ensure DataTable has Rows
                if (dtCus != null)
                {
                    if (dtCus.Rows.Count > 0)
                    {
                        objCus.CustomerId = int.Parse(dtCus.Rows[0]["CustomerID"].ToString());
                        objCus.UserId = int.Parse(dtCus.Rows[0]["UserID"].ToString());
                        objCus.FirstName = dtCus.Rows[0]["CustomerFirstName"].ToString();
                        objCus.LastName = dtCus.Rows[0]["CustomerLastName"].ToString();
                        objCus.Address = dtCus.Rows[0]["CustomerAddress"].ToString();
                        objCus.Address2 = dtCus.Rows[0]["CustomerAddress2"].ToString();
                        objCus.City = dtCus.Rows[0]["CustomerCity"].ToString();
                        objCus.State = dtCus.Rows[0]["CustomerState"].ToString();
                        objCus.ZipCode = dtCus.Rows[0]["CustomerZip"].ToString();
                        objCus.PhoneNo = dtCus.Rows[0]["CustomerPhoneNo"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //Return Customer Object
            return objCus;
        }

        /// <summary>
        /// Inserts new Customer into the database if its no already present
        /// </summary>
        /// <param name="objCustomer"></param>
        /// <returns>Customer Object</returns>
        public Customer InsertCustomer(Customer objCustomer)
        {
            //Check to ensure all fields are present
            CheckRequiredFields(objCustomer);

            try
            {
                //Insert New Customer
                if (objDAL.InsertCustomer(objCustomer.UserId, objCustomer.FirstName, objCustomer.LastName, objCustomer.Address, objCustomer.Address2,
                    objCustomer.City, objCustomer.State, objCustomer.ZipCode, objCustomer.PhoneNo))
                {
                    //Rehydrate Customer to ensure inserted correctly       
                    return GetCustomerByFilter(Customer.SearchFilter.UserId, objCustomer.UserId.ToString());
                }
                else
                {
                    throw new Exception("Customer failed to be inserted");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }    

        public Customer UpdateCustomer(Customer objCustomer)
        {
            //Check to ensure all fields are present
            CheckRequiredFields(objCustomer);

            try
            {
                //Update New Customer
                if (objDAL.UpdateCustomer(objCustomer.CustomerId, objCustomer.FirstName, objCustomer.LastName, objCustomer.Address, objCustomer.Address2,
                    objCustomer.City, objCustomer.State, objCustomer.ZipCode, objCustomer.PhoneNo))
                {
                    //Rehydrate Customer to ensure inserted correctly       
                    return GetCustomerByFilter(Customer.SearchFilter.UserId, objCustomer.UserId.ToString());
                }
                else
                {
                    throw new Exception("Customer failed to update");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Check required fields, if error an exception is thrown
        /// </summary>
        /// <param name="objCustomer"></param>
        private void CheckRequiredFields(Customer objCustomer)
        {
            try {
                //Check to ensure all fields are present
                if (objCustomer != null)
                {
                    if (objCustomer.UserId == 0)
                        throw new Exception("UserId can not be zero");

                    if (string.IsNullOrEmpty(objCustomer.FirstName))
                        throw new Exception("First Name can not be null or empty");

                    if (string.IsNullOrEmpty(objCustomer.LastName))
                        throw new Exception("Last Name can not be null or empty");

                    if (string.IsNullOrEmpty(objCustomer.Address))
                        throw new Exception("Address can not be null or empty");

                    if (string.IsNullOrEmpty(objCustomer.City))
                        throw new Exception("City can not be null or empty");

                    if (string.IsNullOrEmpty(objCustomer.State))
                        throw new Exception("State can not be null or empty");

                    if (string.IsNullOrEmpty(objCustomer.ZipCode))
                        throw new Exception("Zip Code can not be null or empty");

                    if (string.IsNullOrEmpty(objCustomer.PhoneNo))
                        throw new Exception("Phone Number can not be null or empty");
                }
                else
                {
                    throw new Exception("Customer is NULL");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region Catalog
        /// <summary>
        /// Get a list of catalog items
        /// </summary>
        /// <returns>List collection of Catalog Objects</returns>
        public List<CatalogItem> GetCatalogItems()
        {
            DataTable dtCatItems = null;

            //Create a List of Catalog Onjects
            List<CatalogItem> lCatItems = new List<CatalogItem>();

            try
            {

                //Fill Datatable with User Info By Username and Password
                dtCatItems = objDAL.GetCatalogItems();

                //Check to make sure datatable has rows
                if (dtCatItems != null)
                {
                    if (dtCatItems.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtCatItems.Rows)
                        {
                            //New instance of Catalog Object
                            CatalogItem objCatItem = new CatalogItem();

                            //Hydrate Object from datatable
                            objCatItem.CatalogItemId = int.Parse(row["CatalogID"].ToString());
                            objCatItem.Price = decimal.Parse(row["ItemPrice"].ToString());
                            objCatItem.CatalogImagePath = row["CatalogImagePath"].ToString();
                            objCatItem.CatalogItemDescr = row["ItemDescription"].ToString();
                            objCatItem.CatalogItemName = row["CatalogItemName"].ToString();

                            //Add to list collection
                            lCatItems.Add(objCatItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //Return Catalog List of catalog Items objects
            return lCatItems;
        }
        #endregion

        #region Orders
        /// <summary>
        /// Get a List of Orders by CustomerId. Orders also contain the OrderItems
        /// </summary>
        /// <param name="nCustomerId">CustomerID</param>
        /// <returns>List of Orders</returns>
        public List<Order> GetOrdersByCustomerId (int nCustomerId)
        {
            DataTable dtOrders = null;            

            List<Order> lOrders = new List<Order>();

            try {

                //Fill DataTable with Customer Info By UserId
                dtOrders = objDAL.GetOrdersByCustomerId(nCustomerId);

                //Ensure DataTable has Rows
                if (dtOrders != null)
                {
                    if (dtOrders.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtOrders.Rows)
                        {
                            //Order Object
                            Order objOrder = new Order();

                            objOrder.OrderId = int.Parse(row["OrderID"].ToString());
                            objOrder.IsPaymentOnDelivery = (bool)row["IsPaymentOnDelivery"];
                            objOrder.DepositAmt = decimal.Parse(row["DepositAmt"].ToString());
                            objOrder.StatusId = int.Parse(row["StatusID"].ToString());
                            objOrder.OrderDate = DateTime.Parse(row["OrderDate"].ToString());
                            objOrder.PaymentId = int.Parse(row["PaymentID"].ToString());

                            //Append the order items to the ItemsList in the order Object
                            AppendOrderItemsToOrder(ref objOrder);

                            //Append Order to order List
                            lOrders.Add(objOrder);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //Return Orders List
            return lOrders;
        }

        /// <summary>
        /// Reference Order, append the Items to the orderItems List
        /// </summary>
        /// <param name="objOrder">referenced Order Object</param>
        private void AppendOrderItemsToOrder(ref Order objOrder)
        {
            DataTable dtOrderItems = null;

            try
            {
                //Get Order Items
                dtOrderItems = objDAL.GetOrderItemsByOrderId(objOrder.OrderId);

                //Check to ensure the DataTable has rows and isn't Null
                if (dtOrderItems != null)
                {
                    if (dtOrderItems.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtOrderItems.Rows)
                        {
                            string sContentType = string.Empty;

                            //Create an Item Object
                            OrderItem OrderItem = new OrderItem();
                            OrderItem.OrderItemId = int.Parse(row["OrderItemID"].ToString());
                            OrderItem.CatalogItemId = int.Parse(row["CatalogID"].ToString());
                            OrderItem.Qty = int.Parse(row["Qty"].ToString());
                            OrderItem.Content = row["Content"].ToString();
                            OrderItem.Price = decimal.Parse(row["Price"].ToString());
                            sContentType = row["ContentType"].ToString();

                            //Enum Content Type
                            switch (sContentType)
                            {
                                case "E":
                                    OrderItem.ItemContentType = OrderItem.ContentType.Engraved;
                                    break;
                                case "P":
                                    OrderItem.ItemContentType = OrderItem.ContentType.Printed;
                                    break;
                            }

                            //Append to item list in the Order object
                            objOrder.OrderItems.Add(OrderItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
