﻿using System;
using System.Collections.Generic;
using BAL;

namespace WSC
{
    public partial class TestBackend : System.Web.UI.Page
    {
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //UserAccountTest();
                //CustomerTest();
                //CatalogTest();
                //OrderTest();
                //GetLookupsTest();
                //SampleCartSession();
                //CrytoTest();
                //SendEmailTest();

                //Bind Drop Down List
                if (!IsPostBack)
                {
                    PaymentTypes objPaymentTypes = new PaymentTypes();                    

                    ddlPmtTypes.DataTextField = "OrderPaymentType";
                    ddlPmtTypes.DataValueField = "PaymentId";
                    ddlPmtTypes.DataSource = objPaymentTypes.lOrderPaymentTypes;
                    ddlPmtTypes.DataBind();
                }

            }
            catch (Exception ex)
            {
                lblException.Text = ex.Message;
            }

        }

        public void UserAccountTest()
        {
            UserAccount objUA = null;
            UserAccount objMgrUA = null;

            try
            {
                //Retrieve UserAcct existing
                objMgrUA = objBAL.GetUserAccount("dbays", "NoRe@son28v");

                //Retrieve User By ID
                objUA = objBAL.GetUserAccount(objMgrUA, 3);                

                //Insert User, will check if already exists.
                //If already exists will throw exception
                objUA = objBAL.InsertUser(new UserAccount(0, "KAugustine", "test", UserAccount.UserRole.Customer,"test@test.com"));

                //Update User
                objUA = objBAL.UpdateUser(new UserAccount(3, "KAugustine", "test", UserAccount.UserRole.Customer,"test2@test.com"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CustomerTest()
        {
            Customer objCustomer = null;
            List<Customer> lCustomers = null; 

            try
            {

                
                lCustomers = objBAL.GetCustomerListByFilter(Customer.SearchFilter.LastName, "Bays");

                //Get Customer by Search Filters
                objCustomer = objBAL.GetCustomerByFilter(Customer.SearchFilter.LastName, "Bays");

                objCustomer = objBAL.GetCustomerByFilter(Customer.SearchFilter.UserId, "3");

                //Update Customer Record 
                objCustomer = new Customer(1, 3, "Ken", "Augustine", "1234 Test St", "Suite 111", "TestVille", "FL", "12345", "5555515554");
                objCustomer = objBAL.UpdateCustomer(objCustomer);

                //Insert New Customer, will check if already exists
                //If already exists will throw exception
                objCustomer = new Customer(0, 3, "Ken", "Augustine", "123 Test St", "", "TestVille", "FL", "12345", "5555515554");
                objCustomer = objBAL.InsertCustomer(objCustomer);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CatalogTest()
        {
            List<CatalogItem> lCatItems = null;

            //Insert New Item
            lCatItems = objBAL.InsertCatalogItem(new CatalogItem(0, "Test New", "Test Description", 12m, @"c:\",true));

            //Update Existing Item
            lCatItems = objBAL.UpdateCatalogItem(new CatalogItem(5, "Test Update", "Test Description Update", 3m, @"Test",true));

            //Retrieve All Catalog Items
            lCatItems = objBAL.GetCatalogItems();

            //Retrieve Active Catalog Items
            lCatItems = objBAL.GetCatalogItems(true);
        }

        public void OrderTest()
        {
            List<Order> objOrders = null;


            //Get All Open Orders         
            objOrders = objBAL.GetAllOpenOrders();

            //Initiate new order with items,must have items or will throw exception
            //New Order
            bool bOrderSuccessful = false;
            OrderItem objOrderItem = null;
            Order objOrder = new Order(0, false, 0, 2, 1, DateTime.Now);

            //Add items to the collection
            objOrderItem = new OrderItem(0, 1, 1, 2.00m, OrderItem.ContentType.Engraved, "Test");
            objOrder.OrderItems.Add(objOrderItem);

            objOrderItem = new OrderItem(0, 1, 1, 2.00m, OrderItem.ContentType.Engraved, "Test 2");
            objOrder.OrderItems.Add(objOrderItem);

            bOrderSuccessful = objBAL.InsertOrder(objOrder, 1);

            //Get Orders            
            objOrders = objBAL.GetOrdersByCustomerId(1);

            //Update order, must have items or will throw exception
            objOrders[0].StatusId = 4; //Cancel Order
            bOrderSuccessful = objBAL.UpdateOrder(objOrders[0]);
        }

        public void GetLookupsTest()
        {
            //Get Statuses.
            Statuses objStatuses = new Statuses();

            //Get PaymentTypes
            PaymentTypes objPaymentTypes = new PaymentTypes();
        }

        public void SampleCartSession()
        {
            //Get a list of the catalog items
            List<CatalogItem> lCatalogItems = null;
            lCatalogItems = objBAL.GetCatalogItems();

            //Customer likes catalog item 1
            int nCatalogItemCstLoves = lCatalogItems[0].CatalogItemId;

            //Check to see if the order has already bee started
            //By checking the session, if not in session initite new order
            if (Session["Cart"] == null)
                Session["Cart"] = new Order(0, false, 0.00m, 2, 1, DateTime.Now);

            //Get Order out of session          
            var objOrder = Session["Cart"] as Order;

            //Customer decides to purchase Item 1 from the catalog.
            OrderItem objOrderItem = new OrderItem(0, nCatalogItemCstLoves, 1, 25.00m, OrderItem.ContentType.Engraved, "Test");

            //Add OrderItem to the order item List collection
            objOrder.OrderItems.Add(objOrderItem);

            //Customer is done, Load the order back into session until he click the Buy Button later
            Session["Cart"] = objOrder;

            //If Customer clicks buy later and you need to save to database. Grab
            //out of session, see above "Get Order out of session", then call the Insert from the 
            //Business layer.
            int nCustomerId = 3; 
            objBAL.InsertOrder(Session["Cart"] as Order, nCustomerId);
        }

        public void SendEmailTest()
        {        
            Email.SendIt("kennethpaugustine@gmail.com", "This is only a test", "This is a test of the body");           
        }

        public void CrytoTest()
        {
            string sEncryptedString = Crypto.Encrypt("This is a test");
            string sDecryptedString = Crypto.Decrypt(sEncryptedString);
        }

        //TODO       
        //If Orderitems fail to insert, Roll all items back (Delete) and delete Order    
    }
}
    