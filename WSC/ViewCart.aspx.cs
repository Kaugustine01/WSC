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
            if(!this.IsPostBack)
            {
                if (Session["Cart"] != null)
                {
                    CartGridView.DataSource = Session["Cart"];
                    CartGridView.DataBind();
                }
                else
                {
                    lblError.Visible = true;
                    btnRemoveFromCart.Visible = false;
                    btnConfirmPurchase.Visible = false;
                }
            }
            
        }

        protected void RemoveFromCart_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Contents.Remove("Cart");

                List<CatalogItem> lCatItems = new List<CatalogItem>();

                foreach (GridViewRow row in CartGridView.Rows)
                {
                    CatalogItem objCatItem = new CatalogItem();

                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {
                            
                        }
                        else
                        {
                            objCatItem.CatalogItemId = int.Parse(row.Cells[1].Text);
                            objCatItem.CatalogItemName = row.Cells[2].Text;
                            objCatItem.CatalogItemDescr = row.Cells[3].Text;
                            objCatItem.Price = decimal.Parse(row.Cells[4].Text);
                            objCatItem.CatalogImagePath = row.Cells[5].Text;

                            lCatItems.Add(objCatItem);
                        }
                    }
                }

                Session["Cart"] = lCatItems;

                Response.Redirect("ViewCart.aspx");
            }
            catch (Exception)
            {

                lblError.Visible = true;
            }
        }

        protected void ConfirmPurchase_Click(object sender, EventArgs e)
        {
            if (Session["Cart"] != null)
            {
                Response.Redirect("~/CheckOut.aspx");
            }
            else
            {
                lblError.Visible = true;
            }
        }
    }
}