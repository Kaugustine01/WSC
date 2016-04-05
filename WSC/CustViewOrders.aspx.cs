using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace WSC
{
    public partial class CustManageOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessLayer objBAL = new BusinessLayer();

            if (!this.IsPostBack)
            {
                List<Order> objOrders = null;
                objOrders = objBAL.GetOrdersByCustomerId(Convert.ToInt32(Session["CustomerId"]));

                ManageOrdersGridView.DataSource = objOrders;
                ManageOrdersGridView.DataBind();

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

            if (Session["OrderItems"] == null)
            {
                Session["OrderItems"] = new Order(0, false, 0.00m, 2, 1, DateTime.Now);
            }

            //Get Order out of session          
            var objOrder = Session["OrderItems"] as Order;

            string orderId = ManageOrdersGridView.SelectedRow.Cells[1].Text;

            BusinessLayer objBAL = new BusinessLayer();

            List<Order> objOrders = null;
            objOrders = objBAL.GetOrdersByCustomerId(Convert.ToInt32(Session["CustomerId"]));

            int lIndex = 0;

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

            if (Session["OrderItems"] != null)
            {
                Response.Redirect("~/CustViewOrderItems.aspx");
            }
        }
    }
}