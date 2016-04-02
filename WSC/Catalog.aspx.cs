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
    public partial class Catalog : System.Web.UI.Page
    {
        // Creates a Business Layer Obeject to Call Functions
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Populates the GridView with Catalog Information from the Database
            if (!this.IsPostBack)
            {
                // Removes display of column to add items to cart and asks the user to login
                if (Session["UserID"] == null)
                {
                    CatalogGridView.Columns.RemoveAt(7);
                    CatalogGridView.Columns.RemoveAt(6);
                    CatalogGridView.Columns.RemoveAt(0);

                    lblLogin.Visible = true;
                    btnLogin.Visible = true;
                    btnAddToCart.Visible = false;
                    btnViewCart.Visible = false;
                    
                }

                List<CatalogItem> lCatItems = null;

                //Retrieve Catalog Items
                lCatItems = objBAL.GetCatalogItems();

                CatalogGridView.DataSource = lCatItems;
                CatalogGridView.DataBind();
            }
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                //Check to see if the order has already bee started
                //By checking the session, if not in session initite new order
                if (Session["Cart"] == null)
                {
                    Session["Cart"] = new Order(0, false, 0.00m, 2, 1, DateTime.Now);
                }


                //Get Order out of session          
                var objOrder = Session["Cart"] as Order;

                foreach (GridViewRow row in CatalogGridView.Rows)
                {
                    OrderItem objOrderItem = new OrderItem();

                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {
                            objOrderItem.CatalogItemId = int.Parse(row.Cells[1].Text);

                            objOrderItem.Qty = int.Parse((row.FindControl("txtQty") as TextBox).Text);

                            objOrderItem.ItemPrice = (decimal.Parse(row.Cells[4].Text) * objOrderItem.Qty);

                            objOrderItem.ItemContentType = OrderItem.ContentType.Engraved;

                            objOrderItem.Content = (row.FindControl("txtContent") as TextBox).Text;

                            objOrder.OrderItems.Add(objOrderItem);
                        }
                    }
                }

                // Inserts the Cart information into Session[Cart], then Reloads the page
                Session["Cart"] = objOrder;


                // Zero out textboxs and checkboxs after order submission
                foreach (GridViewRow row in CatalogGridView.Rows)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked == true)
                    {
                        chkRow.Checked = false; 
                    }

                    TextBox qtyRow = (row.Cells[6].FindControl("txtQty") as TextBox);
                    if (qtyRow.Text == "")
                    {
                        
                    }
                    else
                    {
                        qtyRow.Text = "";
                    }

                    TextBox contentRow = (row.Cells[7].FindControl("txtContent") as TextBox);
                    if (contentRow.Text == "")
                    {

                    }
                    else
                    {
                        contentRow.Text = "";
                    }
                }

                lblItemsAdded.Visible = true;
            }
            catch (Exception)
            {
                // Displays lblError if there is a problem with the transaction
                lblError.Visible = true;
            }
            

        }

        protected void ViewCart_Click(object sender, EventArgs e)
        {
            // Sends the user to the Check Out page or if the cart is empty displays the error.
            if (Session["Cart"] != null)
            {
                Response.Redirect("~/ViewCart.aspx");
            }
            else
            {
                // Displays lblError if there is a problem with the transaction
                lblError.Visible = true;
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}