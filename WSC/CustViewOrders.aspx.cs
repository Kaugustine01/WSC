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
    }
}