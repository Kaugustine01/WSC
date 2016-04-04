using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace WSC
{
    public partial class CustViewOrderItems : System.Web.UI.Page
    {
        // Creates decimal variable for the grand total
        decimal grdTotal = 0;
        BusinessLayer objBAL = null;
        List<CatalogItem> lCatalogItem = null;

        protected void Page_Load(object sender, EventArgs e)
        {


            // Populates the GridView with Session Cart information or displays the error that the cart is empty
            if (!this.IsPostBack)
            {
                objBAL = new BusinessLayer();

                //Get CatalogItems
                lCatalogItem = objBAL.GetCatalogItems();


                // Populate Grid View if Cart is not Empty, if cart is empty display error.
                if (Session["OrderItems"] != null)
                {
                    Order oCustOrder = new Order();
                    oCustOrder = Session["OrderItems"] as Order;


                    //Bind Catalog Info to the OrderItems
                    AddCatalogInfoToOrderItems(ref lCatalogItem, ref oCustOrder);

                    ViewOrderGridView.DataSource = oCustOrder.OrderItems;
                    ViewOrderGridView.DataBind();

                    // Populates the Label (lblTotal) with the Total Amount of the Order
                    foreach (GridViewRow row in ViewOrderGridView.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            grdTotal = grdTotal + decimal.Parse(row.Cells[5].Text);
                        }
                    }

                    lblTotal.Text = "Total: " + grdTotal.ToString("c");

                    // Order Number and Order Date
                    txtOrderDate.Text = (oCustOrder.OrderDate).ToString();
                    txtOrderNumber.Text = (oCustOrder.OrderId).ToString();

                    // Payment on Delivery
                    if (oCustOrder.IsPaymentOnDelivery == true)
                    {
                        txtPaymentDelivery.Text = "Yes";
                    }
                    else
                    {
                        txtPaymentDelivery.Text = "No";
                    }

                    // Payment Type
                    if (oCustOrder.PaymentId == 1)
                    {
                        txtPaymentType.Text = "Card";
                    }
                    else if (oCustOrder.PaymentId == 2)
                    {
                        txtPaymentType.Text = "PayPal";
                    }

                    // Status
                    if (oCustOrder.StatusId == 4)
                    {
                        txtStatus.Text = "Cancelled";
                    }
                    else if (oCustOrder.StatusId == 3)
                    {
                        txtStatus.Text = "Complete";
                    }
                    else if (oCustOrder.StatusId == 2)
                    {
                        txtStatus.Text = "Validated";
                    }
                    else
                    {
                        txtStatus.Text = "Processing";
                    }

                    // Deposit
                    if (txtPaymentDelivery.Text == "Yes")
                    {
                        txtDeposit.Visible = true;
                        lblDeposit.Visible = true;
                        txtDeposit.Text = (oCustOrder.DepositAmt).ToString();
                    }

                }
            }
        }

        private static void AddCatalogInfoToOrderItems(ref List<CatalogItem> lCatalogItem, ref Order objOrder)
        {
            // link Catalog to OrderItem
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