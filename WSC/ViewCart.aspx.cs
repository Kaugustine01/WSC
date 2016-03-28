using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace WSC
{
    public partial class ViewCart : System.Web.UI.Page
    {

        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Cart"] != null)
            {
                CartGridView.DataSource = Session["Cart"];
                CartGridView.DataBind();
            }
        }

        protected void RemoveFromCart_Click(object sender, EventArgs e)
        {

        }

        protected void ConfirmPurchase_Click(object sender, EventArgs e)
        {

        }
    }
}