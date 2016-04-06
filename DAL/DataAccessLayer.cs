using System;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;

namespace DAL
{
    public class DataAccessLayer
    {
        OleDbConnection dbConnection;
        string sConnString = ConfigurationManager.ConnectionStrings["WSCDatabaseConnectionString"].ConnectionString;

        public DataAccessLayer() { }

        #region User Account
        /// <summary>
        /// Get User Info returned in a DataTable
        /// </summary>
        /// <param name="sUserName">UserName</param>
        /// <param name="sPassword">Password</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserAccount(string sUserName, string sPassword)
        {
            DataTable dtUser = null;

            try
            {
                //Query to return User Info
                string queryString = "SELECT UserID, UserName, Password, Role FROM UserT WHERE UserName = @username and Password = @password";

                //establish connection parameters
                using (dbConnection = new OleDbConnection(sConnString))
                {
                    // Insert the SQL statement into the command                
                    OleDbCommand command = new OleDbCommand(queryString);

                    // Parameters to prevent injection  
                    command.Parameters.Add(new OleDbParameter("@username", sUserName));
                    command.Parameters.Add(new OleDbParameter("@password", sPassword));

                    // Set the Connection to the new OleDbConnection.
                    command.Connection = dbConnection;


                    // Open the connection and execute the SQL command.
                    dbConnection.Open();

                    //Fill DataTable with the User Info
                    dtUser = new DataTable();
                    OleDbDataAdapter DataAdapter = new OleDbDataAdapter(command);
                    DataAdapter.Fill(dtUser);

                    // The connection is automatically closed when the
                    // code exits the using block.
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //Return the datatable filled with User Data
            return dtUser;
        }

        /// <summary>
        /// Get UserId by Username
        /// </summary>
        /// <param name="sUserName">username</param>
        /// <returns>UserId</returns>
        public int GetUserIdByUserName(string sUserName)
        {
            OleDbCommand dbCommand;
            int nUserId = 0;

            try
            {
                //New Database connection
                using (dbConnection = new OleDbConnection(sConnString))
                {

                    // Open database connection
                    dbConnection.Open();

                    // SQL statement 
                    string queryString = "SELECT UserID FROM UserT WHERE UserName = @username";

                    // New command passing sql statement and the connection to the database
                    dbCommand = new OleDbCommand(queryString, dbConnection);

                    // Parameters   
                    dbCommand.Parameters.Add(new OleDbParameter("@username", sUserName));

                    //Get query Results
                    object result = dbCommand.ExecuteScalar();

                    if (result != null)
                    {
                        nUserId = (int)result;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return nUserId;
        }

        /// <summary>
        /// Inserts User into the database
        /// </summary>
        /// <param name="sUserName">Username</param>
        /// <param name="sPassword">password</param>
        /// <param name="sRole">role</param>
        /// <returns>boolean</returns>
        public bool InsertUser(string sUserName, string sPassword, string sRole)
        {  
            OleDbCommand dbCommand;
            int nUserId = 0;

            try
            {
                //Check to make sure User doesnt already Exist
                nUserId = GetUserIdByUserName(sUserName);
                if (nUserId > 0)
                    throw new Exception("User already exists");

                //New Database connection
                using (dbConnection = new OleDbConnection(sConnString))
                {

                    // Open database connection
                    dbConnection.Open();

                    // SQL statement insert the customer
                    string sqlStmt = "INSERT INTO UserT([UserName],[Password],[Role]) " +
                                     "VALUES (@username,@password,@role)";

                    // New command passing sql statement and the connection to the database
                    dbCommand = new OleDbCommand(sqlStmt, dbConnection);

                    // Parameters   
                    dbCommand.Parameters.Add(new OleDbParameter("@username", sUserName));
                    dbCommand.Parameters.Add(new OleDbParameter("@password", sPassword));
                    dbCommand.Parameters.Add(new OleDbParameter("@role", sRole));

                    //Execute query
                    if (dbCommand.ExecuteNonQuery() > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="nUserID">UserId</param>
        /// <param name="sUserName">Username</param>
        /// <param name="sPassword">Password</param>
        /// <param name="sRole">Role [M,C,S]</param>
        /// <returns></returns>
        public bool UpdateUser(int nUserID, string sUserName, string sPassword, string sRole)
        {
            OleDbCommand dbCommand;            

            try
            {      
                //New Database connection
                using (dbConnection = new OleDbConnection(sConnString))
                {

                    // Open database connection
                    dbConnection.Open();

                    // SQL statement insert the customer
                    string sqlStmt = @"Update UserT SET 
                                        [UserName] = @username,
                                        [Password] = @password,
                                        [Role] = @role
                                     WHERE [UserID] = @userid";

                    // New command passing sql statement and the connection to the database
                    dbCommand = new OleDbCommand(sqlStmt, dbConnection);

                    // Parameters   
                    dbCommand.Parameters.Add(new OleDbParameter("@username", sUserName));
                    dbCommand.Parameters.Add(new OleDbParameter("@password", sPassword));
                    dbCommand.Parameters.Add(new OleDbParameter("@role", sRole));
                    dbCommand.Parameters.Add(new OleDbParameter("@userid", nUserID));

                    //Execute query
                    if (dbCommand.ExecuteNonQuery() > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }
        #endregion

        #region Customer
        /// <summary>
        /// Inserts Customer into the database
        /// </summary>
        /// <param name="nUserId">userid</param>
        /// <param name="sFirstName">first name</param>
        /// <param name="sLastName">last name</param>
        /// <param name="sAddress">address</param>
        /// <param name="sAddress2">address 2 (optional)</param>
        /// <param name="sCity">city</param>
        /// <param name="sState">state</param>
        /// <param name="sZip">zip code</param>
        /// <param name="sPhoneNo">phone number xxxxxxxxxx</param>
        /// <returns>boolean</returns>
        public bool InsertCustomer(int nUserId, string sFirstName, string sLastName, string sAddress, string sAddress2, string sCity, string sState,
            string sZip, string sPhoneNo)
        {
            OleDbCommand dbCommand;
            DataTable dtCustomer = null;

            try
            {
                //Check to make sure Customer doesnt already Exist
                dtCustomer = GetCustomerBySearchFilter("UserID", nUserId.ToString());
                if (dtCustomer != null)
                {
                    if (dtCustomer.Rows.Count > 0)
                        throw new Exception("Customer already exists");
                }

                //New Database connection
                using (dbConnection = new OleDbConnection(sConnString))
                {

                    // Open database connection
                    dbConnection.Open();

                    // SQL statement insert the customer
                    string sqlStmt = "INSERT INTO CustomerT([UserId],[CustomerFirstName],[CustomerLastName],[CustomerAddress],[CustomerAddress2],[CustomerCity],[CustomerState],[CustomerZip],[CustomerPhoneNo]) " +
                                     "VALUES (@userid,@firstname,@lastname,@address,@address2,@city,@state,@zip,@phoneno)";

                    // New command passing sql statement and the connection to the database
                    dbCommand = new OleDbCommand(sqlStmt, dbConnection);

                    // Parameters   
                    dbCommand.Parameters.Add(new OleDbParameter("@userid", nUserId));
                    dbCommand.Parameters.Add(new OleDbParameter("@firstname", sFirstName));
                    dbCommand.Parameters.Add(new OleDbParameter("@lastname", sLastName));
                    dbCommand.Parameters.Add(new OleDbParameter("@address", sAddress));
                    dbCommand.Parameters.Add(new OleDbParameter("@address2", sAddress2));
                    dbCommand.Parameters.Add(new OleDbParameter("@city", sCity));
                    dbCommand.Parameters.Add(new OleDbParameter("@state", sState));
                    dbCommand.Parameters.Add(new OleDbParameter("@zip", sZip));
                    dbCommand.Parameters.Add(new OleDbParameter("@phoneno", sPhoneNo));

                    //Execute query
                    if (dbCommand.ExecuteNonQuery() > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }                

        /// <summary>
        /// Get Customer Info returned in a DataTable
        /// </summary>
        /// <param name="nUserId">userid</param>
        /// <returns>datatable</returns>
        public DataTable GetCustomerBySearchFilter(string sClause, string sValue)
        {
            DataTable dtCustomer = null;

            try
            {
                //Query to return Customer Info
                string queryString = "SELECT CustomerId, UserId,CustomerFirstName,CustomerLastName,CustomerAddress,CustomerAddress2,CustomerCity,CustomerState,CustomerZip,CustomerPhoneNo FROM CustomerT WHERE " + sClause + " = @value";

                //establish connection parameters
                using (dbConnection = new OleDbConnection(sConnString))
                {
                    // Insert the SQL statement into the command                
                    OleDbCommand command = new OleDbCommand(queryString);

                    // Parameters to prevent injection  
                    command.Parameters.Add(new OleDbParameter("@value", sValue));

                    // Set the Connection to the new OleDbConnection.
                    command.Connection = dbConnection;


                    // Open the connection and execute the SQL command.
                    dbConnection.Open();

                    //Fill DataTable with the Customer Info
                    dtCustomer = new DataTable();
                    OleDbDataAdapter DataAdapter = new OleDbDataAdapter(command);
                    DataAdapter.Fill(dtCustomer);

                    // The connection is automatically closed when the
                    // code exits the using block.
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //Return the datatable filled with Customer Data
            return dtCustomer;
        }

        /// <summary>
        /// Updates Customer By Customer ID
        /// </summary>
        /// <param name="nCustomerId">customer</param>
        /// <param name="sFirstName">first name</param>
        /// <param name="sLastName">last name</param>
        /// <param name="sAddress">address</param>
        /// <param name="sAddress2">address 2 (optional)</param>
        /// <param name="sCity">city</param>
        /// <param name="sState">state</param>
        /// <param name="sZip">zip code</param>
        /// <param name="sPhoneNo">phone number xxxxxxxxxx</param>
        /// <returns>boolean</returns>
        public bool UpdateCustomer(int nCustomerId, string sFirstName, string sLastName, string sAddress, string sAddress2, string sCity, string sState,
            string sZip, string sPhoneNo)
        {
            OleDbCommand dbCommand;
        
            //New Database connection
            using (dbConnection = new OleDbConnection(sConnString))
            {
                try
                {
                    // Open database connection
                    dbConnection.Open();

                    //string sqlStmt = "UPDATE CustomerT(CustomerFirstName,CustomerLastName,CustomerAddress,CustomerAddress2,CustomerCity,CustomerState,CustomerZip,CustomerPhoneNo) " +
                    //                  "VALUES (@firstname,@lastname,@address,@address2,@city,@state,@zip,@phoneno)" +
                    //                  "WHERE (CustomerID = @customerid)";

                    // SQL statement insert the customer
                    string sqlStmt = @"UPDATE CustomerT SET 
                                        [CustomerFirstName] = @firstname,
                                        [CustomerLastName] = @lastname,
                                        [CustomerAddress] = @address,
                                        [CustomerAddress2] = @address2,
                                        [CustomerCity] = @city,
                                        [CustomerState] = @state,
                                        [CustomerZip] = @zip,
                                        [CustomerPhoneNo] = @phoneno 
                                     WHERE CustomerID = @customerid";

                    // New command passing sql statement and the connection to the database
                    dbCommand = new OleDbCommand(sqlStmt, dbConnection);

                    // Parameters                       
                    dbCommand.Parameters.Add(new OleDbParameter("@firstname", sFirstName));
                    dbCommand.Parameters.Add(new OleDbParameter("@lastname", sLastName));
                    dbCommand.Parameters.Add(new OleDbParameter("@address", sAddress));
                    dbCommand.Parameters.Add(new OleDbParameter("@address2", sAddress2));
                    dbCommand.Parameters.Add(new OleDbParameter("@city", sCity));
                    dbCommand.Parameters.Add(new OleDbParameter("@state", sState));
                    dbCommand.Parameters.Add(new OleDbParameter("@zip", sZip));
                    dbCommand.Parameters.Add(new OleDbParameter("@phoneno", sPhoneNo));
                    dbCommand.Parameters.Add(new OleDbParameter("@customerid", nCustomerId));

                    //Execute query
                    if (dbCommand.ExecuteNonQuery() > 0)
                        return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return false;
        }
        #endregion

        #region Catalog
        /// <summary>
        /// Get Catalog Items returned in a Data Table
        /// </summary>
        /// <returns>Datatable</returns>
        public DataTable GetCatalogItems(bool? bActive)
        {
            DataTable dtCatItems = null;

            try
            {
                //Query to return Catalog Items
                string queryString = string.Format("SELECT CatalogID, ItemPrice, CatalogImagePath, ItemDescription, CatalogItemName, Active FROM CatalogT WHERE {0}",
                    (bActive == null) ? "1 = 1" : string.Format("Active = {0}",bActive)) ;

                //establish connection parameters
                using (dbConnection = new OleDbConnection(sConnString))
                {
                    // Insert the SQL statement into the command                
                    OleDbCommand command = new OleDbCommand(queryString);

                    // Set the Connection to the new OleDbConnection.
                    command.Connection = dbConnection;

                    // Open the connection and execute the SQL command.
                    dbConnection.Open();

                    //Fill DataTable with the Catalog Items
                    dtCatItems = new DataTable();
                    OleDbDataAdapter DataAdapter = new OleDbDataAdapter(command);
                    DataAdapter.Fill(dtCatItems);

                    // The connection is automatically closed when the
                    // code exits the using block.
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //Return the datatable filled with CatalogItems
            return dtCatItems;
        }

        /// <summary>
        /// Insert New Catalog Item
        /// </summary>
        /// <param name="dItemPrice">Price</param>
        /// <param name="sCatalogImagePath">Image path on server</param>
        /// <param name="sItemDescription">Descr of item</param>
        /// <param name="sCatalogItemName">Item Name</param>
        /// <returns></returns>
        public bool InsertCatalogItem(decimal dItemPrice, string sCatalogImagePath, string sItemDescription, string sCatalogItemName)
        {
            OleDbCommand dbCommand;

            try
            {
                //New Database connection
                using (dbConnection = new OleDbConnection(sConnString))
                {

                    // Open database connection
                    dbConnection.Open();

                    // SQL statement insert the customer
                    string sqlStmt = "INSERT INTO CatalogT([ItemPrice], [CatalogImagePath], [ItemDescription], [CatalogItemName],[Active]) " +
                                     "VALUES (@itemprice,@catalogimagepath,@itemdescription,@catalogitemname,'1')";

                    // New command passing sql statement and the connection to the database
                    dbCommand = new OleDbCommand(sqlStmt, dbConnection);

                    // Parameters   
                    dbCommand.Parameters.Add(new OleDbParameter("@itemprice", dItemPrice));
                    dbCommand.Parameters.Add(new OleDbParameter("@catalogimagepath", sCatalogImagePath));
                    dbCommand.Parameters.Add(new OleDbParameter("@itemdescription", sItemDescription));
                    dbCommand.Parameters.Add(new OleDbParameter("@CatalogItemName", sCatalogItemName));

                    //Execute query
                    if (dbCommand.ExecuteNonQuery() > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Update Catalog Item
        /// </summary>
        /// <param name="nCatalogID">Catalog ID</param>
        /// <param name="dItemPrice">Price</param>
        /// <param name="sCatalogImagePath">Image path on server</param>
        /// <param name="sItemDescription">Descr of item</param>
        /// <param name="sCatalogItemName">Item Name</param>
        /// <returns></returns>
        public bool UpdateCatalogItem(int nCatalogID, decimal dItemPrice, string sCatalogImagePath, string sItemDescription, string sCatalogItemName, bool? bActive)
        {
            OleDbCommand dbCommand;

            try
            {
                //New Database connection
                using (dbConnection = new OleDbConnection(sConnString))
                {

                    // Open database connection
                    dbConnection.Open();

                    // SQL statement insert the customer
                    string sqlStmt = @"Update CatalogT SET
                                        [ItemPrice] = @itemprice, 
                                        [CatalogImagePath] = @catalogimagepath, 
                                        [ItemDescription] = @itemdescription, 
                                        [CatalogItemName] =  @catalogitemname,
                                        [Active] = @active
                                      WHERE CatalogID = @catalogid";

                    // New command passing sql statement and the connection to the database
                    dbCommand = new OleDbCommand(sqlStmt, dbConnection);

                    // Parameters   
                    dbCommand.Parameters.Add(new OleDbParameter("@itemprice", dItemPrice));
                    dbCommand.Parameters.Add(new OleDbParameter("@catalogimagepath", sCatalogImagePath));
                    dbCommand.Parameters.Add(new OleDbParameter("@itemdescription", sItemDescription));
                    dbCommand.Parameters.Add(new OleDbParameter("@catalogitemname", sCatalogItemName));
                    dbCommand.Parameters.Add(new OleDbParameter("@active", bActive));
                    dbCommand.Parameters.Add(new OleDbParameter("@catalogid", nCatalogID));
                   

                    //Execute query
                    if (dbCommand.ExecuteNonQuery() > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }
        #endregion

        #region Order
        /// <summary>
        /// Get All Open Orders
        /// </summary>
        /// <returns>Data Table</returns>
        public DataTable GetAllOpenOrders()
        {
            DataTable dtOrders = null;

            try
            {
                //Query to return Orders 
                string queryString = @"
                    SELECT 
                        OrderID,
                        CustomerId,
                        IsPaymentOnDelivery,
                        DepositAmt,
                        StatusID,
                        OrderDate,
                        PaymentID
                    FROM OrderT
                    WHERE StatusID in (1,2)";

                //establish connection parameters
                using (dbConnection = new OleDbConnection(sConnString))
                {
                    // Insert the SQL statement into the command                
                    OleDbCommand command = new OleDbCommand(queryString);                  

                    // Set the Connection to the new OleDbConnection.
                    command.Connection = dbConnection;

                    // Open the connection and execute the SQL command.
                    dbConnection.Open();

                    //Fill DataTable with the Orders
                    dtOrders = new DataTable();
                    OleDbDataAdapter DataAdapter = new OleDbDataAdapter(command);
                    DataAdapter.Fill(dtOrders);

                    // The connection is automatically closed when the
                    // code exits the using block.
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //Return the datatable filled with Orders 
            return dtOrders;
        }
        /// <summary>
        /// Get Orders by CustomerId
        /// </summary>
        /// <param name="nCustomerId"></param>
        /// <returns>Data Table</returns>
        public DataTable GetOrdersByCustomerId(int nCustomerId)
        {
            DataTable dtOrders = null;

            try
            {
                //Query to return Orders 
                string queryString = @"
                    SELECT 
                        OrderID,
                        CustomerId,
                        IsPaymentOnDelivery,
                        DepositAmt,
                        StatusID,
                        OrderDate,
                        PaymentID
                    FROM OrderT
                    WHERE CustomerId = @customerid";

                //establish connection parameters
                using (dbConnection = new OleDbConnection(sConnString))
                {
                    // Insert the SQL statement into the command                
                    OleDbCommand command = new OleDbCommand(queryString);

                    // Parameters to prevent injection  
                    command.Parameters.Add(new OleDbParameter("@customerid", nCustomerId));

                    // Set the Connection to the new OleDbConnection.
                    command.Connection = dbConnection;


                    // Open the connection and execute the SQL command.
                    dbConnection.Open();

                    //Fill DataTable with the Orders
                    dtOrders = new DataTable();
                    OleDbDataAdapter DataAdapter = new OleDbDataAdapter(command);
                    DataAdapter.Fill(dtOrders);

                    // The connection is automatically closed when the
                    // code exits the using block.
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //Return the datatable filled with Orders 
            return dtOrders;
        }

        /// <summary>
        /// Get Order Items by OrderId
        /// </summary>
        /// <param name="nOrderId"></param>
        /// <returns>datatable</returns>
        public DataTable GetOrderItemsByOrderId(int nOrderId)
        {
            DataTable dtOrderItems = null;

            try
            {
                //Query to return OrderItems
                string queryString = @"
                    SELECT 
                        o.OrderID,        
                        i.OrderItemID,
                        i.CatalogID,
                        i.Qty,
                        i.ContentType,
                        i.Content,
                        i.Price
                    FROM OrderT o
                    INNER JOIN OrderItemsT i on i.OrderID = o.OrderID 
                    WHERE o.OrderID = @orderid";

                //establish connection parameters
                using (dbConnection = new OleDbConnection(sConnString))
                {
                    // Insert the SQL statement into the command                
                    OleDbCommand command = new OleDbCommand(queryString);

                    // Parameters to prevent injection  
                    command.Parameters.Add(new OleDbParameter("@orderid", nOrderId));

                    // Set the Connection to the new OleDbConnection.
                    command.Connection = dbConnection;

                    // Open the connection and execute the SQL command.
                    dbConnection.Open();

                    //Fill DataTable with the Orders and OrderItems
                    dtOrderItems = new DataTable();
                    OleDbDataAdapter DataAdapter = new OleDbDataAdapter(command);
                    DataAdapter.Fill(dtOrderItems);

                    // The connection is automatically closed when the
                    // code exits the using block.
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //Return the datatable filled with OrderItems
            return dtOrderItems;
        }

        /// <summary>
        /// Insert Order and Order Items
        /// </summary>
        /// <param name="nCustomerId">customer id</param>
        /// <param name="bIsPaymentOnDelivery">is payment on delivery</param>
        /// <param name="dDepositAmt">deposit amount</param>
        /// <param name="nStatusId">status id</param>
        /// <param name="nPaymentId">payment id</param>
        /// <param name="dtOrderItems">Data table of order items</param>
        /// <returns></returns>
        public bool InsertOrder(int nCustomerId, bool bIsPaymentOnDelivery, decimal dDepositAmt, int nStatusId, int nPaymentId, DataTable dtOrderItems)
        {
            OleDbCommand dbCommand;            
            int nOrderId = 0;
            bool bSuccess = false;

            try
            {
                //New Database connection
                using (dbConnection = new OleDbConnection(sConnString))
                {

                    // Open database connection
                    dbConnection.Open();

                    // SQL statement insert the customer
                    string sqlStmt = "INSERT INTO OrderT([CustomerID],[IsPaymentOnDelivery],[DepositAmt],[StatusID],[OrderDate],[PaymentID]) " +
                                     "VALUES (@customerid,@ispaymentondelivery,@depositamt,@statusid,@orderdate,@paymentid)";

                    // New command passing sql statement and the connection to the database
                    dbCommand = new OleDbCommand(sqlStmt, dbConnection);

                    // Parameters   
                    dbCommand.Parameters.Add(new OleDbParameter("@customerid", nCustomerId));
                    dbCommand.Parameters.Add(new OleDbParameter("@ispaymentondelivery", bIsPaymentOnDelivery));
                    dbCommand.Parameters.Add(new OleDbParameter("@depositamt", dDepositAmt));
                    dbCommand.Parameters.Add(new OleDbParameter("@statusid", nStatusId));

                    //Order Date
                    OleDbParameter parm = new OleDbParameter("@orderdate", OleDbType.Date);
                    parm.Value = DateTime.Now;
                    dbCommand.Parameters.Add(parm);
                                        
                    dbCommand.Parameters.Add(new OleDbParameter("@paymentid", nPaymentId));

                    //Execute query
                    if (dbCommand.ExecuteNonQuery() > 0)
                    {
                        //Get OrderId (Autonumber from database)
                        dbCommand.CommandText = "SELECT @@IDENTITY";
                        nOrderId = (int)dbCommand.ExecuteScalar();

                        if (nOrderId > 0)
                            bSuccess = true;
                    }
                }
                
                if (bSuccess)
                {
                    //Insert Items
                    if (InsertOrderItems(nOrderId, dtOrderItems))
                        return true;
                }
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bSuccess;
        }

        /// <summary>
        /// Insert order items
        /// </summary>
        /// <param name="nOrderId">order id</param>
        /// <param name="dtOrderItems">datatable of order items</param>
        /// <returns>bool</returns>
        public bool InsertOrderItems(int nOrderId, DataTable dtOrderItems)
        {
            OleDbCommand dbCommand;
            bool bSuccess = false;

            try
            {
                //Check to make sure Order Exists.
                if (CheckIfOrderExists(nOrderId))
                {
                    //New Database connection
                    using (dbConnection = new OleDbConnection(sConnString))
                    {

                        // Open database connection
                        dbConnection.Open();


                        //Loop to insert all items
                        foreach (DataRow row in dtOrderItems.Rows)
                        {
                            //Reset to False
                            bSuccess = false;

                            // SQL statement insert the customer
                            string sqlStmt = "INSERT INTO OrderItemsT([OrderID],[CatalogID],[Qty],[ContentType],[Content],[price]) " +
                                         "VALUES (@orderid,@catalogid, @qty, @contenttype, @content, @price)";

                            // New command passing sql statement and the connection to the database
                            dbCommand = new OleDbCommand(sqlStmt, dbConnection);

                            // Parameters   
                            dbCommand.Parameters.Add(new OleDbParameter("@orderid", nOrderId));
                            dbCommand.Parameters.Add(new OleDbParameter("@catalogid", int.Parse(row["CatalogItemID"].ToString())));
                            dbCommand.Parameters.Add(new OleDbParameter("@qty", int.Parse(row["Qty"].ToString())));
                            dbCommand.Parameters.Add(new OleDbParameter("@contenttype", row["ItemContentType"].ToString()));
                            dbCommand.Parameters.Add(new OleDbParameter("@content", row["ItemContent"].ToString()));
                            dbCommand.Parameters.Add(new OleDbParameter("@price", decimal.Parse(row["Price"].ToString())));

                            //Execute query
                            if (dbCommand.ExecuteNonQuery() > 0)
                                bSuccess = true;

                            //If failed to insert, abort and delete orderitems and order
                            if (!bSuccess)
                                break;

                        }

                        //Items successfully inserted return true
                        if (bSuccess)
                        {
                            return true;
                        }
                        else
                        {
                            //Delete OrderItems
                            DeleteOrderItems(nOrderId);

                            //Delete Order
                            DeleteOrder(nOrderId);

                            throw new Exception("Failed to insert order.");
                        }
                    }
                }
                else
                {
                    //Order Does not exist
                    throw new Exception("Order does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update Order
        /// </summary>
        /// <param name="nCustomerId">customerid</param>
        /// <param name="nOrderId">orderid</param>
        /// <param name="bIsPaymentOnDelivery">is payment on delivery</param>
        /// <param name="dDepositAmt">deposit amt</param>
        /// <param name="nStatusId">status id</param>
        /// <param name="nPaymentId">paymentid</param>
        /// <param name="dtOrderItems">datatable of order items</param>
        /// <returns>bool</returns>
        public bool UpdateOrder(int nOrderId, bool bIsPaymentOnDelivery, decimal dDepositAmt, int nStatusId, int nPaymentId, DataTable dtOrderItems)
        {
            OleDbCommand dbCommand;             

            try
            {
                //New Database connection
                using (dbConnection = new OleDbConnection(sConnString))
                {

                    // Open database connection
                    dbConnection.Open();

                    // SQL statement insert the customer
                    string sqlStmt = @"UPDATE OrderT SET
                                        [IsPaymentOnDelivery] = @ispaymentondelivery,
                                        [DepositAmt] = @depositamt,
                                        [StatusID] = @statusid,
                                        [PaymentID] = @paymentid
                                       WHERE OrderID = @orderid";

                    // New command passing sql statement and the connection to the database
                    dbCommand = new OleDbCommand(sqlStmt, dbConnection);

                    // Parameters                       
                    dbCommand.Parameters.Add(new OleDbParameter("@ispaymentondelivery", bIsPaymentOnDelivery));
                    dbCommand.Parameters.Add(new OleDbParameter("@depositamt", dDepositAmt));
                    dbCommand.Parameters.Add(new OleDbParameter("@statusid", nStatusId));
                    dbCommand.Parameters.Add(new OleDbParameter("@paymentid", nPaymentId));                    
                    dbCommand.Parameters.Add(new OleDbParameter("@orderid", nOrderId));

                    //Execute query
                    if (dbCommand.ExecuteNonQuery() > 0)
                    {
                        if (UpdateOrderItems(nOrderId, dtOrderItems))
                            return true;                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Update order items
        /// </summary>
        /// <param name="nOrderId">order id</param>
        /// <param name="dtOrderItems">datatable of order items</param>
        /// <returns>bool</returns>
        public bool UpdateOrderItems(int nOrderId, DataTable dtOrderItems)
        {
            OleDbCommand dbCommand;
            bool bSuccess = false;

            try
            {

                //New Database connection
                using (dbConnection = new OleDbConnection(sConnString))
                {

                    // Open database connection
                    dbConnection.Open();


                    //Loop to insert all items
                    foreach (DataRow row in dtOrderItems.Rows)
                    {
                        //Reset to False
                        bSuccess = false;

                        // SQL statement insert the customer
                        string sqlStmt = @"UPDATE OrderItemsT SET
                                                [CatalogID] = @catalogid,
                                                [Qty] = @qty,
                                                [ContentType] = @contenttype,
                                                [Content] = @content,
                                                [price] =  @price
                                         WHERE OrderItemID = @orderitemid";

                        // New command passing sql statement and the connection to the database
                        dbCommand = new OleDbCommand(sqlStmt, dbConnection);

                        // Parameters                           
                        dbCommand.Parameters.Add(new OleDbParameter("@catalogid", int.Parse(row["CatalogItemID"].ToString())));
                        dbCommand.Parameters.Add(new OleDbParameter("@qty", int.Parse(row["Qty"].ToString())));
                        dbCommand.Parameters.Add(new OleDbParameter("@contenttype", row["ItemContentType"].ToString()));
                        dbCommand.Parameters.Add(new OleDbParameter("@content", row["ItemContent"].ToString()));
                        dbCommand.Parameters.Add(new OleDbParameter("@price", decimal.Parse(row["Price"].ToString())));
                        dbCommand.Parameters.Add(new OleDbParameter("@orderitemid", int.Parse(row["OrderItemID"].ToString())));

                        //Execute query
                        if (dbCommand.ExecuteNonQuery() > 0)
                            bSuccess = true;

                        //If failed to insert, abort and delete orderitems and order
                        if (!bSuccess)
                            break;

                    }

                    //Items successfully inserted return true
                    if (bSuccess)
                    {
                        return true;
                    }
                    else
                    {                        
                        throw new Exception("Failed to Update order.");
                    }
                }
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        /// <summary>
        /// Check if order exists
        /// </summary>
        /// <param name="nOrderId">Order Id</param>
        /// <returns>bool</returns>
        private bool CheckIfOrderExists(int nOrderId)
        {
            DataTable dtOrder = null;

            try
            {
                //Query 
                string queryString = "SELECT OrderId FROM OrderT WHERE OrderId = @orderid";

                //establish connection parameters
                using (dbConnection = new OleDbConnection(sConnString))
                {
                    // Insert the SQL statement into the command                
                    OleDbCommand command = new OleDbCommand(queryString);

                    // Parameters to prevent injection  
                    command.Parameters.Add(new OleDbParameter("@orderid", nOrderId));                    

                    // Set the Connection to the new OleDbConnection.
                    command.Connection = dbConnection;


                    // Open the connection and execute the SQL command.
                    dbConnection.Open();

                    //Fill DataTable with Order Info
                    dtOrder = new DataTable();
                    OleDbDataAdapter DataAdapter = new OleDbDataAdapter(command);
                    DataAdapter.Fill(dtOrder);

                    // The connection is automatically closed when the
                    // code exits the using block.


                    //Return true if order exists.
                    if(dtOrder != null)
                    {
                        if (dtOrder.Rows.Count > 0)
                            return true;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //Return false
            return false;
        }

        /// <summary>
        /// Delete order items
        /// </summary>
        /// <param name="nOrderId">order id</param>
        /// <returns>bool</returns>
        private bool DeleteOrderItems(int nOrderId)
        {
            return true;
        }

        /// <summary>
        /// delete order
        /// </summary>
        /// <param name="nOrderId">order id</param>
        /// <returns>bool</returns>
        private bool DeleteOrder(int nOrderId)
        {
            return true;
        }
        #endregion

        #region LookUps
        /// <summary>
        /// Get Payment types
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable GetPaymentTypes()
        {
            DataTable dtPaymentTypes = null;

            try
            {
                //Query to return Payment Types
                string queryString = "SELECT PaymentID, PaymentType FROM PaymentT";

                //establish connection parameters
                using (dbConnection = new OleDbConnection(sConnString))
                {
                    // Insert the SQL statement into the command                
                    OleDbCommand command = new OleDbCommand(queryString);

                    // Set the Connection to the new OleDbConnection.
                    command.Connection = dbConnection;

                    // Open the connection and execute the SQL command.
                    dbConnection.Open();

                    //Fill DataTable with the User Info
                    dtPaymentTypes = new DataTable();
                    OleDbDataAdapter DataAdapter = new OleDbDataAdapter(command);
                    DataAdapter.Fill(dtPaymentTypes);

                    // The connection is automatically closed when the
                    // code exits the using block.
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //Return DataTable filled with PaymentTypes
            return dtPaymentTypes;
        }

        /// <summary>
        /// Get statuses
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable GetStatuses()
        {
            DataTable dtStatuses = null;

            try
            {
                //Query to return Statuses
                string queryString = "SELECT StatusID, Status FROM StatusT";

                //establish connection parameters
                using (dbConnection = new OleDbConnection(sConnString))
                {
                    // Insert the SQL statement into the command                
                    OleDbCommand command = new OleDbCommand(queryString);

                    // Set the Connection to the new OleDbConnection.
                    command.Connection = dbConnection;

                    // Open the connection and execute the SQL command.
                    dbConnection.Open();

                    //Fill DataTable with the User Info
                    dtStatuses = new DataTable();
                    OleDbDataAdapter DataAdapter = new OleDbDataAdapter(command);
                    DataAdapter.Fill(dtStatuses);

                    // The connection is automatically closed when the
                    // code exits the using block.
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //Return datatable with Statuses
            return dtStatuses;
        }
        #endregion
    }
}
