﻿using System;
using BAL;

/*
    Programmer: Daniel Bays
    Date:       4/02/2016
    Purpose:    Registration Process
    Details:    This program is used to Populate Customer Registration.
 */

namespace WSC
{
    public partial class Registration : System.Web.UI.Page
    {
        // Creates business layer object
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Initiates Customer Class
            Customer objCustomer = null;

            try
            {

                // Creates User Account for the Customer and stores into the database
                UserAccount objUA = new UserAccount(0, txtUserName.Text, txtPassword.Text, UserAccount.UserRole.Customer, txtEmail.Text);
                objUA = objBAL.InsertUser(objUA);


                // Creates Customer and stores into the database.
                objCustomer = new Customer(0, objUA.UserId, txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtAddress2.Text, txtCity.Text, txtState.Text, txtZipCode.Text, txtPhone.Text);
                objCustomer = objBAL.InsertCustomer(objCustomer);

                // Displays that the registration was complete
                lblComplete.Visible = true;

                // Removes Submit Buttion
                btnSubmit.Visible = false;

            }
            catch (Exception)
            {
                // Displays an error if the registration process failed
                lblError.Visible = true;
            }

        }
    }
}