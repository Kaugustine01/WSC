<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="WSC.PasswordRecovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--
    Programmer: Daniel Bays
    Date:       4/05/2016
    Purpose:    Login Page
    Details:    This page is for the user to login.
    -->

    <div class="content">
        
        <asp:Panel ID="PanelGetUserName" runat="server" HorizontalAlign="Center" Visible="false">
            <!-- User Name -->
            <asp:Label ID="lblUserName" runat="server" Text="User Name:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="txtUserName" ErrorMessage="User Name Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />
            <!-- LinkButton for Submission -->
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" onClick="btnSubmit_Click" ValidationGroup="ValGroup" Visible="true"/>
            <br />
        </asp:Panel>     
        <asp:Panel ID="PanelEmailHasBeenSent" runat="server" HorizontalAlign="Center" Visible="false">
            Email has been sent to the email on file. The link will be good for 45mins.  
        </asp:Panel> 
        <asp:Panel ID="PanelNewPassword" runat="server" HorizontalAlign="Left" Visible="false">
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
        <!-- Error for the form not being properly submitted. -->
        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>   
    </div>
</asp:Content>
