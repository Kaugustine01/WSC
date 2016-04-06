<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="WSC.Admin.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--
    Programmer: Daniel Bays
    Date:       4/05/2016
    Purpose:    Manage Users Form
    Details:    This form is for the Operations Manager to Update the Users Acccess.
    -->

    <div class="content" style="overflow: auto;">
        <!--    Label for Edit Users    -->
        <center>
                <asp:Label ID="Label1" runat="server" Text="Manage Users"></asp:Label></center>
        <br />

        <!-- Label and Text Field for Searching last name -->
        <asp:Label ID="lblSearchLastName" runat="server" Text="Search Last Name"></asp:Label>
        <asp:TextBox ID="txtSearchLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtSearchLastName" ErrorMessage="Last Name Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
        <br />
        <br />

        <!-- LinkButton for Submission -->
        <asp:Button ID="btnFind" runat="server" Text="Find" OnClick="btnSubmit_Click" ValidationGroup="ValGroup" />
        <br />

        <!-- Properly submitted. -->
        <asp:Label ID="lblComplete" runat="server" Visible="false" ForeColor="Red"><b>Account has been updated.</b></asp:Label>

        <!-- Error for the form not being properly submitted. -->
        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Sorry no user was found.</b></asp:Label>
        <br />
        <br />
        <!--    Grid View of Users -->
        <asp:GridView ID="ManageUsersGridView" AutoGenerateColumns="false" runat="server" CellPadding="5" Width="100%">
            <HeaderStyle BackColor="Black" ForeColor="White" />
            <RowStyle BackColor="#c5d5cb" />
            <AlternatingRowStyle BackColor="#e3e0cf" />
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" SortExpression="CustomerID" ReadOnly="true" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" ReadOnly="true" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" ReadOnly="false" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" ReadOnly="false" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" ReadOnly="false" />
                <asp:BoundField DataField="Address2" HeaderText="Address 2" SortExpression="Address2" ReadOnly="false" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" ReadOnly="false" />
                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" ReadOnly="false" />
                <asp:BoundField DataField="ZipCode" HeaderText="Zip" SortExpression="Zip" ReadOnly="false" />
                <asp:BoundField DataField="PhoneNo" HeaderText="Phone Number" SortExpression="PhoneNo" ReadOnly="false" />
            </Columns>
        </asp:GridView>
        <br />
        <br />

        <!-- Displays users User Name -->
        <asp:Label ID="lblUserName" runat="server" Text="User Name: " Visible="false"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
        <br />
        <br />

        <!-- Displays Users Account Type -->
        <asp:Label ID="lblUserType" runat="server" Text="User Type: " Visible="false"></asp:Label>
        <asp:DropDownList ID="ddlUserType" runat="server" Visible="false">
            <asp:ListItem>--Select--</asp:ListItem>
            <asp:ListItem>Customer</asp:ListItem>
            <asp:ListItem>Sales</asp:ListItem>
            <asp:ListItem>Operations Manager</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlUserType"
                    ErrorMessage="Value Required" InitialValue="--Select--" ValidationGroup="ValGroup2" Fore-Color="Red"></asp:RequiredFieldValidator>
        <br />
        <br />

        <!-- Button to Update User -->
        <asp:Button ID="btnUpdateUser" runat="server" Text="Update User" OnClick="UpdateUser_Click" ValidationGroup="ValGroup2" Visible="false"/>
        <br />
        <!-- Properly submitted. -->
        <asp:Label ID="lblUserUpdateConfirmed" runat="server" Visible="false" ForeColor="Red"><b>Users has been updated.</b></asp:Label>

        <!-- Error for the form not being properly submitted. -->
        <asp:Label ID="lblUserUpdateFailed" runat="server" Visible="false" ForeColor="Red"><b>Sorry something went wrong.</b></asp:Label>

        </center>
       
    </div>

</asp:Content>
