using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BAL;

/*
    Programmer: Daniel Bays
    Date:       03/30/2016
    Purpose:    View Cart
    Details:    This program is used to Populate and Edit the Sessions Cart Information.
 */

namespace WSC
{
    public partial class ViewCart : System.Web.UI.Page
    {
        // Creates decimal variable for the grand total
        decimal grdTotal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Populates the GridView with Session Cart information or displays the error that the cart is empty
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

            // Populates the Label (lblTotal) with the Total Amount of the Order
            foreach (GridViewRow row in CartGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    decimal rowTotal = decimal.Parse(row.Cells[4].Text);

                    grdTotal = grdTotal + rowTotal;
                }
            }

            lblTotal.Text = "Total: " + grdTotal.ToString("c");

        }

        protected void RemoveFromCart_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Contents.Remove("Cart");

                // Creates the list to store the Cart information
                List<CatalogItem> lCatItems = new List<CatalogItem>();

                // Inputs rows that are NOT checked into lCatItems list
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

                // Inserts the Cart information into Session[Cart], then Reloads the page
                Session["Cart"] = lCatItems;

                Response.Redirect("ViewCart.aspx");
            }
            catch (Exception)
            {
                // Displays lblError if there is a problem with the transaction
                lblError.Visible = true;
            }
        }

        protected void ConfirmPurchase_Click(object sender, EventArgs e)
        {

            // Sends the user to the Check Out page or if the cart is empty displays the error. 
            if (Session["Cart"] != null)
            {
                Response.Redirect("~/CheckOut.aspx");
            }
            else
            {
                // Displays lblError if there is a problem with the transaction
                lblError.Visible = true;
            }
        }
    }
}