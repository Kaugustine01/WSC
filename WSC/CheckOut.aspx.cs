using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace WSC
{
    public partial class CheckOut : System.Web.UI.Page
    {
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            decimal deposit = 0;

            if (!this.IsPostBack)
            {
                if (Session["Cart"] != null)
                {
                    CartGridView.DataSource = Session["Cart"];
                    CartGridView.DataBind();
                }

                // Inputs rows that ARE checked into lCatItems list
                foreach (GridViewRow row in CartGridView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        decimal rowTotal = decimal.Parse(row.Cells[3].Text);

                        deposit = deposit + rowTotal;
                    }
                }

                deposit = deposit * 10 / 100;
                txtDeposit.Text = "Deposit Amount: " + deposit.ToString("c");
            }

            
        }


        protected void Checkout_Click(object sender, EventArgs e)
        {
            bool depositBool = false;

            if (ddlPaymentOnDelivery.Text == "Yes")
            {
                depositBool = true;
            }

            //Initiate new order with items,must have items or will throw exception
            //New Order
            bool bOrderSuccessful = false;

            // Create New Order
            Order objOrder = new Order(0, depositBool, decimal.Parse(txtDeposit.Text), 2, 1, DateTime.Now);

            

            foreach (GridViewRow row in CartGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    OrderItem objOrderItem = new OrderItem();

                    //Add items to the collection
                    objOrderItem = new OrderItem(0, 1, 1, 2.00m, OrderItem.ContentType.Engraved, "Test");
                    objOrder.OrderItems.Add(objOrderItem);

                }
            }

            bOrderSuccessful = objBAL.InsertOrder(objOrder, 1);
        }
        
    }
}