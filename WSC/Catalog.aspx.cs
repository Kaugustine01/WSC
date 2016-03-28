using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace WSC
{
    public partial class Catalog : System.Web.UI.Page
    {
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {

            List<CatalogItem> lCatItems = null;

            //Retrieve Catalog Items
            lCatItems = objBAL.GetCatalogItems();

            CatalogGridView.DataSource = lCatItems;
            CatalogGridView.DataBind();
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            var selectedProducts = CatalogGridView.Rows.Cast<GridViewRow>()
                .Where(row => ((CheckBox)row.FindControl("SelectedProducts")).Checked)
                .Select(row => CatalogGridView.DataKeys[row.RowIndex].Value.ToString()).ToList();

            if (Session["Cart"] == null)
            {
                Session["Cart"] = selectedProducts;
            }
            else
            {
                var cart = (List<string>)Session["Cart"];
                foreach (var product in selectedProducts)
                {
                    cart.Add(product);
                    Session["Cart"] = cart;
                }
            }
            foreach (GridViewRow row in CatalogGridView.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("SelectedProducts");
                if (cb.Checked)
                {
                    cb.Checked = false;
                }
            }
        }

        protected void Checkout_Click(object sender, EventArgs e)
        {
            if (Session["Cart"] != null)
            {
                Response.Redirect("CheckOut.aspx");
            }
            else
            {
                lblError.Visible = true;
            }
        }
    }
}