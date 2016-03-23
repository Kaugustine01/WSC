using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OleDb;

namespace DAL
{
    public class DataAccessLayer
    {
        //string sConnString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"Data Source = C:\Users\ftlki\Documents\Visual Studio 2015\Projects\GitHub\WSC\WSC\App_Data\WSCDatabase.accdb";
        string sConnString = ConfigurationManager.ConnectionStrings["WSCDatabaseConnectionString"].ConnectionString;

        public DataAccessLayer()
        {       
                      
        }

        public int GetUserId(string sUserName, string sPassword)
        {
            int nUserId = 0;

            string queryString = string.Format("SELECT CustID, UserName FROM dbo.CustomerLoginT where '{0}'", sUserName);
        
            using (OleDbConnection connection = new OleDbConnection(sConnString))
            {
                // The SQL statement                 
                OleDbCommand command = new OleDbCommand(queryString);

                // Set the Connection to the new OleDbConnection.
                command.Connection = connection;

                // Open the connection and execute the SQL command.
                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                
                    while (reader.Read())
                    {
                        nUserId = int.Parse(reader[0].ToString());
                    }
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }


            return nUserId;
        }

    }
}
