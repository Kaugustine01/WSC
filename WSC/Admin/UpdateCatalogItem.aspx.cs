﻿using System;
using System.Collections.Generic;
using BAL;

/*
    Programmer: Daniel Bays
    Date:       04/05/2016
    Purpose:    Update Catalog Process
    Details:    This program is used to Update an existing item in the Catalog.
 */

namespace WSC.Admin
{
    public partial class UpdateCatalogItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // allows user to display page if they are a Operations Manager
            if (Session["SecurityLevel"] == "M")
            {
                if (!this.IsPostBack)
                {
                    if (Session["CatalogItem"] != null)
                    {
                        // Create and get catalogItem
                        CatalogItem catalogItem = new CatalogItem();
                        catalogItem = Session["CatalogItem"] as CatalogItem;

                        // Add Text to TextBoxs
                        txtCatalogDescr.Text = catalogItem.CatalogItemDescr;
                        txtCatalogItem.Text = catalogItem.CatalogItemName;
                        txtPrice.Text = (catalogItem.Price).ToString();
                        txtCatalogId.Text = (catalogItem.CatalogItemId).ToString();

                        // Updated ddlCatalogImage
                        if (catalogItem.CatalogImagePath == @"Images\CatalogItems\Plaque.jpg")
                        {
                            ddlCatalogImage.Text = "Plaque";
                        }
                        else if (catalogItem.CatalogImagePath == @"Images\CatalogItems\Trophy.jpg")
                        {
                            ddlCatalogImage.Text = "Trophy";
                        }
                        else if (catalogItem.CatalogImagePath == @"Images\CatalogItems\RedMug.jpg")
                        {
                            ddlCatalogImage.Text = "Mug";
                        }
                        else if (catalogItem.CatalogImagePath == @"Images\CatalogItems\Shirt.jpg")
                        {
                            ddlCatalogImage.Text = "Shirt";
                        }

                        // update ddlActive
                        if (catalogItem.Active == true)
                        {
                            ddlActive.Text = "Yes";
                        }
                        else
                        {
                            ddlActive.Text = "No";
                        }

                    }
                }
            }
            else
            {
                Response.Redirect("~/NoAccess.aspx");
            }
        }


        protected void Submit_Click(object sender, EventArgs e)
        {
                // creates a catalog item list to add a new item.
                List<CatalogItem> lCatItems = null;

                // Creates a Business Layer Obeject to Call Functions
                BusinessLayer objBAL = new BusinessLayer();

                // Creates Catalog Item to input data
                CatalogItem catalogItem = new CatalogItem();

                // creates string to update the image path
                string sImagePath = "";

                bool active = true;

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

                // update active if ddlActive is no
                if (ddlActive.Text == "No")
                {
                    active = false;
                }

                // Add items to catalogItem
                catalogItem.CatalogItemId = Convert.ToInt32(txtCatalogId.Text);
                catalogItem.CatalogItemName = txtCatalogItem.Text;
                catalogItem.CatalogItemDescr = txtCatalogDescr.Text;
                catalogItem.Price = Convert.ToDecimal(txtPrice.Text);
                catalogItem.CatalogImagePath = sImagePath;
                catalogItem.Active = active;
                

                //Update Existing Item
                lCatItems = objBAL.UpdateCatalogItem(catalogItem);

                // display the completion of the adding an item to the catalog
                lblComplete.Visible = true;
                btnSubmit.Visible = false;
            }

            
        }
    }
