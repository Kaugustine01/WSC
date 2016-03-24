﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //Check to ensure all fields are present
            if(objUserAccount != null)
            {
                if(string.IsNullOrEmpty(objUserAccount.UserName))
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

            try
            {
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
        /// Return Customer Object By UserId
        /// </summary>
        /// <param name="nUserId">userid</param>
        /// <returns>Customer Object</returns>
        public Customer GetCustomerByUserId(int nUserId)
        {
            DataTable dtCus = null;
            Customer objCus = new Customer();
            string sUserType = string.Empty;

            //Fill DataTable with Customer Info By UserId
            dtCus = objDAL.GetCustomerByUserId(nUserId);

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
                    return GetCustomerByUserId(objCustomer.UserId);
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

        public Customer UpdateCustomer(Customer objCustomer)
        {
            //Check to ensure all fields are present
            CheckRequiredFields(objCustomer);

            try
            {
                //Insert New Customer
                if (objDAL.UpdateCustomer(objCustomer.UserId, objCustomer.FirstName, objCustomer.LastName, objCustomer.Address, objCustomer.Address2,
                    objCustomer.City, objCustomer.State, objCustomer.ZipCode, objCustomer.PhoneNo))
                {
                    //Rehydrate Customer to ensure inserted correctly       
                    return GetCustomerByUserId(objCustomer.UserId);
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

        /// <summary>
        /// Check required fields, if error an exception is thrown
        /// </summary>
        /// <param name="objCustomer"></param>
        private void CheckRequiredFields(Customer objCustomer)
        {
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

            //Return Catalog List of catalog Items objects
            return lCatItems;
        }

        #endregion
    }
}
