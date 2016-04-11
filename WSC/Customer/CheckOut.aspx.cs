using System;
using System.Web.UI.WebControls;
using BAL;

/*
    Programmer: Daniel Bays
    Date:       3/30/2016
    Purpose:    Check Out Process
    Details:    This form is used to populate the customers order into the Business Layer.
*/

namespace WSC
{
    public partial class CheckOut : System.Web.UI.Page
    {
        // Creates decimal variable for the grand total
        decimal grdTotal = 0;

        // Creates business layer object
        BusinessLayer objBAL = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            decimal deposit = 0;
            objBAL = new BusinessLayer();

            // Populates the GridView with Session Cart information or displays the error that the cart is empty
            if (!this.IsPostBack)
            {
                if (Session["Cart"] != null)
                {
                    Order oCart = new Order();
                    oCart = Session["Cart"] as Order;

                    CartGridView.DataSource = oCart.OrderItems;
                    CartGridView.DataBind();
                }
                else
                {
                    lblError.Visible = true;
                }

                // Calculates the Deposit Amount and Populates txtDeposit
                foreach (GridViewRow row in CartGridView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        deposit = deposit + decimal.Parse(row.Cells[5].Text);
                    }
                }

                deposit = deposit * 10 / 100;
                txtDeposit.Text = deposit.ToString("c");

                // Populates the Label (lblTotal) with the Total Amount of the Order
                foreach (GridViewRow row in CartGridView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        grdTotal = grdTotal + decimal.Parse(row.Cells[5].Text);
                    }
                }

                lblTotal.Text = "Total: " + grdTotal.ToString("c");
            }
        }


        protected void Checkout_Click(object sender, EventArgs e)
        {
            try
            {
                // Creates Bool to see if order was succesful
                bool bOrderSuccessful = false;

                // Creates Bool input value for Payment at Pickup
                bool depositBool = false;

                if (ddlPaymentOnDelivery.Text == "Yes")
                {
                    depositBool = true;
                }

                int paymentType = 0;

                if (ddlPaymentType.Text == "COD")
                {
                    paymentType = 1;
                }
                else if (ddlPaymentType.Text == "Credit Card")
                {
                    paymentType = 2;
                }
                else if (ddlPaymentType.Text == "Check")
                {
                    paymentType = 3;
                }
                else if (ddlPaymentType.Text == "PayPal")
                {
                    paymentType = 4;
                }
                else if (ddlPaymentType.Text == "BitCoin")
                {
                    paymentType = 5;
                }

                // Create New Order
                Order objOrder = new Order(0, depositBool, decimal.Parse(txtDeposit.Text, System.Globalization.NumberStyles.Currency), paymentType, 1, DateTime.Now);


                // Populate Items and Add to Order
                foreach (GridViewRow row in CartGridView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        OrderItem newOrderItem = new OrderItem();
                        newOrderItem.CatalogItemName = row.Cells[1].Text;
                        newOrderItem.CatalogItemDescr = row.Cells[2].Text;
                        newOrderItem.CatalogImagePath = row.Cells[3].Text;
                        newOrderItem.CatalogItemId = int.Parse(row.Cells[0].Text);
                        newOrderItem.Qty = int.Parse(row.Cells[4].Text);
                        newOrderItem.ItemPrice = decimal.Parse(row.Cells[5].Text);
                        newOrderItem.ItemContentType = OrderItem.ContentType.Engraved;
                        newOrderItem.Content = row.Cells[6].Text;
                        newOrderItem.Price = 100;
                        objOrder.OrderItems.Add(newOrderItem);
                    }
                }

                // Send Order to Business Layer for insert into Database
                bOrderSuccessful = objBAL.InsertOrder(objOrder, Convert.ToInt32(Session["CustomerId"]));

                // Removes Contents of the Cart
                Session.Contents.Remove("Cart");

                // Displays Purchase Confirmation and Removed Purchase Button
                lblComplete.Visible = true;
                btnCheckOut.Visible = false;
            }
            catch (Exception)
            {
                lblError2.Visible = true;
            }  
        }
    }
}