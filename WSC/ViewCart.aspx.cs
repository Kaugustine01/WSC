using System;
using System.Linq;
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
        BusinessLayer objBAL = null;
        List<CatalogItem> lCatalogItem = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Populates the GridView with Session Cart information or displays the error that the cart is empty
            if(!this.IsPostBack)
            {
                objBAL = new BusinessLayer();
                
                //Get CatalogItems
                lCatalogItem = objBAL.GetCatalogItems();



                if (Session["Cart"] != null)
                {
                    Order oCart = new Order();
                    oCart = Session["Cart"] as Order;

                    //Bind Catalog Info to the OrderItems
                    AddCatalogInfoToOrderItems(ref lCatalogItem, ref oCart);

                    CartGridView.DataSource = oCart.OrderItems;
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
                    
                }
            }

            lblTotal.Text = "Total: " + grdTotal.ToString("c");

        }

        protected void RemoveFromCart_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Contents.Remove("Cart");

                //Check to see if the order has already bee started
                //By checking the session, if not in session initite new order
                Session["Cart"] = new Order(0, false, 0.00m, 2, 1, DateTime.Now);

                var objOrder = Session["Cart"] as Order;

                // Inputs rows that are NOT checked into lCatItems list
                foreach (GridViewRow row in CartGridView.Rows)
                {
                    OrderItem objOrderItem = new OrderItem();

                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {
                            
                        }
                        else
                        {
                            objOrderItem.CatalogItemId = int.Parse(row.Cells[2].Text);

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

        private static void AddCatalogInfoToOrderItems(ref List<CatalogItem> lCatalogItem, ref Order objOrder)
        {
           foreach(OrderItem objOrderItem in objOrder.OrderItems)
            {
                var ObjCatalogItem = lCatalogItem.FirstOrDefault(i => i.CatalogItemId == objOrderItem.CatalogItemId);
                objOrderItem.CatalogItemName = ObjCatalogItem.CatalogItemName;
                objOrderItem.CatalogItemDescr = ObjCatalogItem.CatalogItemDescr;
                objOrderItem.CatalogImagePath = ObjCatalogItem.CatalogImagePath;
            }
        }
    }
}