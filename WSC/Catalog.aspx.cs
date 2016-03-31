﻿using System;
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
                // Creates the list to store the Cart information
                List<OrderItem> lOrderItems = new List<OrderItem>();

                // Inputs rows that ARE checked into lCatItems list
                foreach (GridViewRow row in CatalogGridView.Rows)
                {
                    OrderItem objCatItem = new OrderItem();

                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {
                            objCatItem.CatalogItemId = int.Parse(row.Cells[1].Text);

                            objCatItem.Qty = int.Parse(row.Cells[7].Text);

                            objCatItem.Price = (decimal.Parse(row.Cells[4].Text) * objCatItem.Qty);

                            objCatItem.ItemContentType = BAL.OrderItem.ContentType.Engraved;

                            objCatItem.Content = row.Cells[8].Text;

                            lOrderItems.Add(objCatItem);
                        }
                    }
                }

                // Inserts the Cart information into Session[Cart], then Reloads the page
                Session["Cart"] = lOrderItems;

                Response.Redirect("Catalog.aspx");
            }
            catch (Exception)
            {
                // Displays lblError if there is a problem with the transaction
                lblError.Visible = true;
            }
            
        }

        protected void Checkout_Click(object sender, EventArgs e)
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