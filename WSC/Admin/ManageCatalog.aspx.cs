using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            try
            {
                // Populates the GridView with Catalog Information from the Database
                if (!this.IsPostBack)
                {
                    // Displays the Catalog if the user is an Operations Manager
                    if (Session["SecurityLevel"] == "M")
                    {
                        List<CatalogItem> lCatItems = null;

                        //Retrieve Catalog Items
                        lCatItems = objBAL.GetCatalogItems();

                        CatalogGridView.DataSource = lCatItems;
                        CatalogGridView.DataBind();
                    }
                    else
                    {
                        Response.Redirect("~/NoAccess.aspx");
                    }       
                }
            }
            catch (Exception)
            {
                lblError.Visible = true;
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

        protected void UpdateCatalogItem_Click(object sender, EventArgs e)
        {

        }
    }
}