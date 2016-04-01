using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace WSC
{
    public partial class CheckOut : System.Web.UI.Page
    {
        // Creates decimal variable for the grand total
        decimal grdTotal = 0;
        BusinessLayer objBAL = null;
        List<CatalogItem> lCatalogItem = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            decimal deposit = 0;

            // Populates the GridView with Session Cart information or displays the error that the cart is empty
            if (!this.IsPostBack)
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
                }

                // Inputs rows that ARE checked into lCatItems list
                foreach (GridViewRow row in CartGridView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                    }
                }

                deposit = deposit * 10 / 100;
                txtDeposit.Text = "Deposit Amount: " + deposit.ToString("c");

                // Populates the Label (lblTotal) with the Total Amount of the Order
                foreach (GridViewRow row in CartGridView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                    }
                }

                lblTotal.Text = "Total: " + grdTotal.ToString("c");
            }   
        }


        protected void Checkout_Click(object sender, EventArgs e)
        {
            bool depositBool = false;

            if (ddlPaymentOnDelivery.Text == "Yes")
            {
                depositBool = true;
            }

            //Initiate new order with items,must have items or will throw exception
            //New Order
            bool bOrderSuccessful = false;

            // Create New Order
            Order objOrder = new Order(0, depositBool, 0, 2, 1, DateTime.Now);

            

            foreach (GridViewRow row in CartGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    OrderItem newOrderItem = new OrderItem();
                    newOrderItem.OrderItemId = 1;
                    newOrderItem.CatalogItemId = int.Parse(row.Cells[0].Text);
                    newOrderItem.Qty = int.Parse(row.Cells[5].Text);
                    newOrderItem.ItemPrice = decimal.Parse(row.Cells[6].Text);
                    newOrderItem.ItemContentType = OrderItem.ContentType.Engraved;
                    newOrderItem.Content = row.Cells[7].Text;

                    objOrder.OrderItems.Add(newOrderItem);
                }
            }

            bOrderSuccessful = objBAL.InsertOrder(objOrder, 1);
        }

        private static void AddCatalogInfoToOrderItems(ref List<CatalogItem> lCatalogItem, ref Order objOrder)
        {
            foreach (OrderItem objOrderItem in objOrder.OrderItems)
            {
                var ObjCatalogItem = lCatalogItem.FirstOrDefault(i => i.CatalogItemId == objOrderItem.CatalogItemId);
                objOrderItem.CatalogItemName = ObjCatalogItem.CatalogItemName;
                objOrderItem.CatalogItemDescr = ObjCatalogItem.CatalogItemDescr;
                objOrderItem.CatalogImagePath = ObjCatalogItem.CatalogImagePath;
            }
        }

    }
}