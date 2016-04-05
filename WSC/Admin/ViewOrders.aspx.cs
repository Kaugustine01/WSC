using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace WSC.Admin
{
    public partial class ViewOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SecurityLevel"] == "M")
            {
                try
                {
                    BusinessLayer objBAL = new BusinessLayer();

                    if (!this.IsPostBack)
                    {
                        List<Order> objOrders = null;
                        objOrders = objBAL.GetAllOpenOrders();

                        ManageOrdersGridView.DataSource = objOrders;
                        ManageOrdersGridView.DataBind();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            else
            {
                Response.Redirect("NoAccess.aspx");
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
                Response.Redirect("~/Admin/ViewOrders.aspx");
            }
        }
    }
}