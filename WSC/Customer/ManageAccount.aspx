<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ManageAccount.aspx.cs" Inherits="WSC.ManageAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--
    Programmer: Daniel Bays
    Date:       4/05/2016
    Purpose:    Customer Manage Account Form
    Details:    This form is for the customer to manage their account.
    -->

     <!-- Manage Account Form -->
    <div class="content">
        <center><h1>Manage Account</h1></center>
        <p>
            <b>User Name</b> - Only Numbers and Letters, no Special Characters.
            <br />  
            <b>Password</b> - Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character.
            <br />
            <b>Phone Number</b> - Correct Phone Number format is 123-456-7890.
        </p>
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">

            <!-- User Name -->
            <asp:Label ID="lblUserName" runat="server" Text="User Name:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server" ReadOnly="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtUserName" ErrorMessage="User Name Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />

            <!-- First Name -->
            <asp:Label ID="lblFirstName" runat="server" Text="First Name" Width="130px"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ControlToValidate="txtFirstName" ErrorMessage="First Name Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />

            <!-- Last Name -->
            <asp:Label ID="lblLastName" runat="server" Text="Last Name:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                ControlToValidate="txtLastName" ErrorMessage="Last Name Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />

            <!-- Address -->
            <asp:Label ID="lblAddress" runat="server" Text="Address:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                ControlToValidate="txtAddress" ErrorMessage="Address Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />

            <!-- Address Line 2 -->
            <asp:Label ID="lblAddressTwo" runat="server" Text="Address Line 2:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtAddressTwo" runat="server" Width="300px"></asp:TextBox>
            <br />

            <!-- City -->
            <asp:Label ID="lblCity" runat="server" Text="City:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                ControlToValidate="txtCity" ErrorMessage="City Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />

            <!-- State -->
            <asp:Label ID="lblState" runat="server" Text="State:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                ControlToValidate="txtState" ErrorMessage="State Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />

            <!-- Zip Code -->
            <asp:Label ID="lblZipCode" runat="server" Text="Zip Code:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                ControlToValidate="txtZipCode" ErrorMessage="Zip Code Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />

            <!-- Phone Number -->
            <asp:Label ID="lblPhone" runat="server" Text="Phone Number:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ErrorMessage="Enter valid Phone number" ControlToValidate="txtPhone" 
                ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" ForeColor="Red" ValidationGroup="ValGroup"></asp:RegularExpressionValidator>
            <br />
            <br />
            <p>Password Required for Update</p>
            <br />
            <!-- Password -->
            <asp:Label ID="lblPassword" runat="server" Text="Password:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                ControlToValidate="txtPassword" ErrorMessage="Password Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />
            <br />

            <!-- LinkButton for Submission -->
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" onClick="btnSubmit_Click" ValidationGroup="ValGroup"/>
            <br />

            <!-- Properly submitted. -->
            <asp:Label ID="lblComplete" runat="server" Visible="false" ForeColor="Red"><b>Account has been updated.</b></asp:Label>

            <!-- Error for the form not being properly submitted. -->
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Sorry there was an error.</b></asp:Label>
            <br />
            <br />
            <br />

            <!-- Update Password -->
            <p>Below is used to update your password, each field is required.</p>
            <p><b>Password Requirements: </b>Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character.</p>
            <br />
            <br />
            
            <!-- Old Password -->
            <asp:Label ID="lblOldPassword" runat="server" Text="Old Password:" Width="200px"></asp:Label>
            <asp:TextBox ID="txtOldPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="txtOldPassword" ErrorMessage="Password Required." ForeColor="Red" ValidationGroup="ValGroup2"></asp:RequiredFieldValidator>
            <br />
            <br />

            <!-- New Password -->
            <asp:Label ID="lblNewPassword" runat="server" Text="New Password:" Width="200px"></asp:Label>
            <asp:TextBox ID="txtNewPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                ControlToValidate="txtNewPassword" ErrorMessage="Password Required." ForeColor="Red" ValidationGroup="ValGroup2"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNewPassword"
                ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$"
                ErrorMessage="Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character" ForeColor="Red" ValidationGroup="ValGroup2"/>
            <br />

            <!-- Confirm New Password -->
            <asp:Label ID="lblNewConfirmPassword" runat="server" Text="Confirm New Password:" Width="200px"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password Required." ForeColor="Red" ValidationGroup="ValGroup2"></asp:RequiredFieldValidator>
            <br />
            <asp:CompareValidator ID="comparePassword" runat="server" ControlToValidate="txtConfirmPassword"
                ControlToCompare="txtNewPassword" ErrorMessage="Password Does Not Match" ForeColor="Red" ValidationGroup="ValGroup2"></asp:CompareValidator>
            <br />

            <!-- LinkButton for Submission -->
            <asp:Button ID="btnUpdatePassword" runat="server" Text="Update Password" OnClick="UpdatePassword_Click" ValidationGroup="ValGroup2"/>
            <br />

            <!-- Properly submitted. -->
            <asp:Label ID="lblUpdateComplete" runat="server" Visible="false" ForeColor="Red"><b>Your password has been updated.</b></asp:Label>

            <!-- Error for the form not being properly submitted. -->
            <asp:Label ID="lblWrongPassword" runat="server" Visible="false" ForeColor="Red"><b>Something went wrong, please check your Password and try again.</b></asp:Label>
            <br />
            <br />
            <br />
            
        </asp:Panel>
    </div>
</asp:Content>
