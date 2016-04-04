using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace WSC
{
    public partial class ManageAccount : System.Web.UI.Page
    {
        BusinessLayer objBAL = new BusinessLayer();
        int custid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["SecurityLevel"] == "C")
                {

                    Customer objCus = new Customer();
                    objCus = objBAL.GetCustomerByFilter(Customer.SearchFilter.UserId, Convert.ToInt32(Session["UserID"]).ToString());

                    txtUserName.Text = Convert.ToString(Session["UserName"]);
                    txtFirstName.Text = objCus.FirstName;
                    txtLastName.Text = objCus.LastName;
                    txtAddress.Text = objCus.Address;
                    txtAddressTwo.Text = objCus.Address2;
                    txtCity.Text = objCus.City;
                    txtState.Text = objCus.State;
                    txtZipCode.Text = objCus.ZipCode;
                    txtPhone.Text = objCus.PhoneNo;

                    custid = objCus.CustomerId;
                }
                else
                {
                    Response.Redirect("NoAccess.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Customer objCus = new Customer();

            //Update Customer Record 
            objCus = new Customer(custid, Convert.ToInt32(Session["UserId"]), txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtAddressTwo.Text, txtCity.Text, txtState.Text, txtZipCode.Text, txtPhone.Text);
            objCus = objBAL.UpdateCustomer(objCus);
        }
    }
}
