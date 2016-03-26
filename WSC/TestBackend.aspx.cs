using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                CustomerTest();
                //CatalogTest();
                //OrderTest();
                
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
            //Get Orders
            List<Order> objOrders = null;
            objOrders = objBAL.GetOrdersByCustomerId(1);

            //Initiate new order with items,must have items or will throw exception

            //Update order, must have items or will throw exception

        }

        public void GetLookupsTest()
        {
            //Get Statuses, PaymentTypes
        }

        //TODO       
        //Create Order Methods
        //Update Order Methods
        //LookUp Tables       

        //Double check Error Handling. Ensure bubbles up to UI.
    }
}