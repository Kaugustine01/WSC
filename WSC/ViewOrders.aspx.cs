using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using BAL;

/*
    Programmer: Daniel Bays
    Date:       04/05/2016
    Purpose:    View Orders Process
    Details:    This program is used to Populate and the Customers view of past orders.
 */

namespace WSC
{
    public partial class CustManageOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // creates object for Business Layer
            BusinessLayer objBAL = new BusinessLayer();

            if (!this.IsPostBack)
            {
                // Creates list of customers past orders
                List<Order> objOrders = null;
                objOrders = objBAL.GetOrdersByCustomerId(Convert.ToInt32(Session["CustomerId"]));

                // adds customer orders to the gridview
                ManageOrdersGridView.DataSource = objOrders;
                ManageOrdersGridView.DataBind();

                // edits the values of the status field
                foreach (GridViewRow row in ManageOrdersGridView.Rows)
                {
                    // Status
                    if (row.Cells[3].Text == "4")
                    {
                        row.Cells[3].Text = "Cancelled";
                    }
                    else if (row.Cells[3].Text == "3")
                    {
                        row.Cells[3].Text = "Complete";
                    }
                    else if (row.Cells[3].Text == "2")
                    {
                        row.Cells[3].Text = "Validated";
                    }
                    else
                    {
                        row.Cells[3].Text = "Processing";
                    }
                }
            }
        }

        protected void OnSelectedIndexChange(object sender, EventArgs e)
        {
            // creates order items session variable
            if (Session["OrderItems"] == null)
            {
                Session["OrderItems"] = new Order(0, false, 0.00m, 2, 1, DateTime.Now);
            }

            // Get Order out of session          
            var objOrder = Session["OrderItems"] as Order;

            // identifies the order to be displayed in the order details form
            string orderId = ManageOrdersGridView.SelectedRow.Cells[1].Text;

            // creates Business Layer object
            BusinessLayer objBAL = new BusinessLayer();

            // pulls a list of the customers orders
            List<Order> objOrders = null;
            objOrders = objBAL.GetOrdersByCustomerId(Convert.ToInt32(Session["CustomerId"]));

            // used to index the orders
            int lIndex = 0;

            // added the order information to the Order Items Session Variable
            foreach (Order order in objOrders)
            {
                if (order.OrderId == int.Parse(orderId))
                {
                    Order selectedOrder = new Order();

                    selectedOrder = objOrders.ElementAt(lIndex);
                    objOrder = selectedOrder;

                    Session["OrderItems"] = objOrder;
                }

                lIndex = lIndex + 1;
            }

            // Redirects user to Order Details page.
            if (Session["OrderItems"] != null)
            {
                Response.Redirect("~/OrderDetails.aspx");
            }
        }
    }
}