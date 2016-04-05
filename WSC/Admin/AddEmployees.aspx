<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AddEmployees.aspx.cs" Inherits="WSC.Admin.AddEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--
    Programmer: Daniel Bays
    Date:       4/05/2016
    Purpose:    Add Employees Form
    Details:    This form is for the Admin to Add Employees.
    -->

    <!-- Employee Form -->
    <div class="content">
        <center><h1>Add Employee Form</h1></center>
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
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtUserName" ErrorMessage="User Name Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />

            <!-- Password -->
            <asp:Label ID="lblPassword" runat="server" Text="Password:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                ControlToValidate="txtPassword" ErrorMessage="Password Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="Regex1" runat="server" ControlToValidate="txtPassword"
                ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$"
                ErrorMessage="Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character" ForeColor="Red" ValidationGroup="ValGroup" />
            <br />

            <!-- Confirm Password -->
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />
            <asp:CompareValidator ID="comparePassword" runat="server" ControlToValidate="txtConfirmPassword"
                ControlToCompare="txtPassword" ErrorMessage="Password Does Not Match" ForeColor="Red" ValidationGroup="ValGroup"></asp:CompareValidator>
            <br />

            <!-- Employee Type -->
            <asp:Label ID="lblEmpType" runat="server" Text="Employee Type:" Width="130px"></asp:Label>
            <asp:DropDownList ID="ddlEmpType" runat="server">
                <asp:ListItem>Sales</asp:ListItem>
                <asp:ListItem>Operations Manager</asp:ListItem>
            </asp:DropDownList>
            <br />

            <!-- LinkButton for Submission -->
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" onClick="btnSubmit_Click" Visible="true" ValidationGroup="ValGroup" />
            <br />
            <br />
            <!-- Submission Complete -->
            <asp:Label ID="lblSubmission" runat="server" Visible="false" ForeColor="Red"><b>Employee Created</b></asp:Label>
            <!-- Error for the form not being properly submitted. -->
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>User Already Exists</b></asp:Label>
        </asp:Panel>
    </div>

</asp:Content>
