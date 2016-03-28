using System;
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
                OrderTest();
                //GetLookupsTest();


            }
            catch (Exception ex)
            {
                lblException.Text = ex.Message;
            }

        }

        public void UserAccountTest()
        {
            try
            {
                //Check existing
                objBAL.GetUserAccount("KAugustine", "test");

                //Insert User, will check if already exists.
                //If already exists will throw exception
                UserAccount objUA = new UserAccount(0, "KAugustine", "test", UserAccount.UserRole.Customer);
                objUA = objBAL.InsertUser(objUA);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CustomerTest()
        {
            Customer objCustomer = null;

            try
            {

                //Get Customer by Search Filters
                objCustomer = objBAL.GetCustomerByFilter(Customer.SearchFilter.LastName, "Augustine");

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

            //Retrieve Catalog Items
            lCatItems = objBAL.GetCatalogItems();
        }

        public void OrderTest()
        {

            //Initiate new order with items,must have items or will throw exception
            //New Order
            bool bOrderSuccessful = false;
            OrderItem objOrderItem = null;
            Order objOrder = new Order(0,false,0,2,1,DateTime.Now);

            //Add items to the collection
            objOrderItem = new OrderItem(0,1,1,2.00m,OrderItem.ContentType.Engraved,"Test");
            objOrder.OrderItems.Add(objOrderItem);

            objOrderItem = new OrderItem(0, 1, 1, 2.00m, OrderItem.ContentType.Engraved, "Test 2");
            objOrder.OrderItems.Add(objOrderItem);

            bOrderSuccessful = objBAL.InsertOrder(objOrder, 1);

            //Get Orders
            List<Order> objOrders = null;
            objOrders = objBAL.GetOrdersByCustomerId(1);

            //Update order, must have items or will throw exception
            objOrders[0].StatusId = 4; //Cancel Order
            bOrderSuccessful = objBAL.UpdateOrder(objOrders[0], 1);
        }

        public void GetLookupsTest()
        {
            //Get Statuses.
            Statuses objStatuses = new Statuses();

            //Get PaymentTypes
            PaymentTypes objPaymentTypes = new PaymentTypes();
        }

        //TODO       
        //If Orderitems fail to insert, Roll all items back (Delete) and delete Order        

        //Daniel, For insert order I am just returning a bool.  Do you need anything else?  
    }
}