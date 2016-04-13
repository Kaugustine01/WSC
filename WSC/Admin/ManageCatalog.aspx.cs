using System;
using System.Collections.Generic;
using System.Linq;
using BAL;

/*
    Programmer: Daniel Bays
    Date:       04/05/2016
    Purpose:    Manage Catalog Process
    Details:    This program is used to Populate and Edit Catalog.
 */

namespace WSC.Admin
{
    public partial class ManageCatalog : System.Web.UI.Page
    {
        // Creates a Business Layer Obeject to Call Functions
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SecurityLevel"] == "M")
            {
                try
                {
                    // Populates the GridView with Catalog Information from the Database
                    if (!this.IsPostBack)
                    {
                        // Displays the Catalog if the user is an Operations Manager

                        List<CatalogItem> lCatItems = null;

                        //Retrieve Catalog Items
                        lCatItems = objBAL.GetCatalogItems();

                        CatalogGridView.DataSource = lCatItems;
                        CatalogGridView.DataBind();

                    }
                }
                catch (Exception)
                {
                    lblError.Visible = true;
                }
            }
            else
            {
                Response.Redirect("~/NoAccess.aspx");
            }
        }

        protected void AddCatalogItem_Click(object sender, EventArgs e)
        {
            // Redirect to Add Catalog Item
            Response.Redirect("~/Admin/AddCatalogItem.aspx");
        }

        protected void DeleteChkRow_Click(object sender, EventArgs e)
        {

        }

        protected void OnSelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                CatalogItem updateItem = new CatalogItem();

                // creates order items session variable
                if (Session["CatalogItem"] == null)
                {
                    Session["CatalogItem"] = new CatalogItem();
                }

                // Get Catalog out of session          
                var catalogItem = Session["CatalogItem"] as CatalogItem;

                // identifies the order to be displayed in the order details form
                string catalogId = CatalogGridView.SelectedRow.Cells[0].Text;

                // creates Business Layer object
                BusinessLayer objBAL = new BusinessLayer();

                // pulls a list of the customers orders
                List<CatalogItem> lCatItems = null;
                lCatItems = objBAL.GetCatalogItems();

                // used to index the orders
                int lIndex = 0;

                // added the order information to the Order Items Session Variable
                foreach (CatalogItem catalog in lCatItems)
                {
                    if (catalog.CatalogItemId == Convert.ToInt32(catalogId))
                    {
                        CatalogItem selectedCatalogId = new CatalogItem();

                        selectedCatalogId = lCatItems.ElementAt(lIndex);
                        catalogItem = selectedCatalogId;

                        Session["CatalogItem"] = catalogItem;
                    }

                    lIndex = lIndex + 1;
                }

                if (Session["CatalogItem"] != null)
                {
                    Response.Redirect("~/Admin/UpdateCatalogItem.aspx");
                }
            }
            catch (Exception)
            {
                lblError.Visible = true;
            }

        }
    }
}