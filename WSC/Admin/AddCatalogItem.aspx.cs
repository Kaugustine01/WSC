using System;
using System.Collections.Generic;
using BAL;

/*
    Programmer: Daniel Bays
    Date:       04/05/2016
    Purpose:    Add Catalog Item Process
    Details:    This program is used to Add a new Item to the Catalog.
 */

namespace WSC.Admin
{
    public partial class AddCatalogItem : System.Web.UI.Page
    {
        // Creates a Business Layer Obeject to Call Functions
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            // allows user to display page if they are a Operations Manager
            if (Session["SecurityLevel"] == "M")
            {

            }
            else
            {
                Response.Redirect("~/NoAccess.aspx");
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                // creates a catalog item list to add a new item.
                List<CatalogItem> lCatItems = null;

                // creates string to update the image path
                string sImagePath = "";

                // updates sImagePath to add to Database
                if (ddlCatalogImage.Text == "Plaque")
                {
                    sImagePath = @"Images\CatalogItems\Plaque.jpg";
                }
                else if (ddlCatalogImage.Text == "Trophy")
                {
                    sImagePath = @"Images\CatalogItems\Trophy.jpg";
                }
                else if (ddlCatalogImage.Text == "Mug")
                {
                    sImagePath = @"Images\CatalogItems\RedMug.jpg";
                }
                else if (ddlCatalogImage.Text == "Shirt")
                {
                    sImagePath = @"Images\CatalogItems\Shirt.jpg";
                }

                //Insert New Item
                lCatItems = objBAL.InsertCatalogItem(new CatalogItem(0, txtCatalogItem.Text, txtCatalogDescr.Text, Convert.ToDecimal(txtPrice.Text), sImagePath));

                // display the completion of the adding an item to the catalog
                lblComplete.Visible = true;
                btnSubmit.Visible = false;
            }
            catch (Exception)
            {
                // Displays error if there is an issue
                lblError.Visible = true;
            }
        }
    }
}