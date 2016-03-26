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
    }
}