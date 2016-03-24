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
        string sConnString = ConfigurationManager.ConnectionStrings["WSCDatabaseConnectionString"].ConnectionString;

        public DataAccessLayer()
        {       
                      
        }

        /// <summary>
        /// Get User Info returned in a DataTable
        /// </summary>
        /// <param name="sUserName">UserName</param>
        /// <param name="sPassword">Password</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserId(string sUserName, string sPassword)
        {
            DataTable dtUser = null;

            //Query to return User Info
            string queryString = "SELECT UserID, UserName, Password, Role FROM UserT where UserName = @username and Password = @password";
        
            //establish connection parameters
            using (OleDbConnection connection = new OleDbConnection(sConnString))
            {
                // Insert the SQL statement into the command                
                OleDbCommand command = new OleDbCommand(queryString);

                // Parameters to prevent injection  
                command.Parameters.Add(new OleDbParameter("@username", sUserName));
                command.Parameters.Add(new OleDbParameter("@password", sPassword));

                // Set the Connection to the new OleDbConnection.
                command.Connection = connection;
                
                try
                {
                    // Open the connection and execute the SQL command.
                    connection.Open();

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

    }
}
