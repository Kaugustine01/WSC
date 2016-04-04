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
            }
        }

        protected void OnSelectedIndexChange(object sender, EventArgs e)
        {
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
                    Session["OrderItems"] = selectedOrder.OrderItems;
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