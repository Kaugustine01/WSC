using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

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
                
                try
                {
                    // Open the connection and execute the SQL command.
                    dbConnection.Open();

                    //Fill DataTable with the User Info
                    dtUser = new DataTable();
                    OleDbDataAdapter DataAdapter = new OleDbDataAdapter(command);
                    DataAdapter.Fill(dtUser);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // The connection is automatically closed when the
                // code exits the using block.
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

            //New Database connection
            using (dbConnection = new OleDbConnection(sConnString))
            {
                try
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
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
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

            //Check to make sure User doesnt already Exist
            nUserId = GetUserIdByUserName(sUserName);
            if (nUserId > 0)
                throw new Exception("User already exists");

            //New Database connection
            using (dbConnection = new OleDbConnection(sConnString))
            {
                try
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
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
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

            //Check to make sure Customer doesnt already Exist
            dtCustomer = GetCustomerByUserId(nUserId);
            if (dtCustomer != null)
            {
                if (dtCustomer.Rows.Count > 0)
                    throw new Exception("Customer already exists");
            }

            //New Database connection
            using (dbConnection = new OleDbConnection(sConnString))
            {
                try
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
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return false;
        }

        /// <summary>
        /// Get Customer Info returned in a DataTable
        /// </summary>
        /// <param name="nUserId">userid</param>
        /// <returns>datatable</returns>
        public DataTable GetCustomerByUserId(int nUserId)
        {
            DataTable dtCustomer = null;

            //Query to return Customer Info
            string queryString = "SELECT CustomerId, UserId,CustomerFirstName,CustomerLastName,CustomerAddress,CustomerAddress2,CustomerCity,CustomerState,CustomerZip,CustomerPhoneNo FROM CustomerT WHERE UserID = @userid";

            //establish connection parameters
            using (dbConnection = new OleDbConnection(sConnString))
            {
                // Insert the SQL statement into the command                
                OleDbCommand command = new OleDbCommand(queryString);

                // Parameters to prevent injection  
                command.Parameters.Add(new OleDbParameter("@userid", nUserId));

                // Set the Connection to the new OleDbConnection.
                command.Connection = dbConnection;

                try
                {
                    // Open the connection and execute the SQL command.
                    dbConnection.Open();

                    //Fill DataTable with the Customer Info
                    dtCustomer = new DataTable();
                    OleDbDataAdapter DataAdapter = new OleDbDataAdapter(command);
                    DataAdapter.Fill(dtCustomer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // The connection is automatically closed when the
                // code exits the using block.
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
        public DataTable GetCatalogItems()
        {
            DataTable dtCatItems = null;

            //Query to return Catalog Items
            string queryString = "SELECT CatalogID, ItemPrice, CatalogImagePath, ItemDescription, CatalogItemName FROM CatalogT";

            //establish connection parameters
            using (dbConnection = new OleDbConnection(sConnString))
            {
                // Insert the SQL statement into the command                
                OleDbCommand command = new OleDbCommand(queryString);         

                // Set the Connection to the new OleDbConnection.
                command.Connection = dbConnection;

                try
                {
                    // Open the connection and execute the SQL command.
                    dbConnection.Open();

                    //Fill DataTable with the Catalog Items
                    dtCatItems = new DataTable();
                    OleDbDataAdapter DataAdapter = new OleDbDataAdapter(command);
                    DataAdapter.Fill(dtCatItems);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
            //Return the datatable filled with CatalogItems
            return dtCatItems;
        }

        #endregion
    }
}
