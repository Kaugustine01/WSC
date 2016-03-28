<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="WSC.Admin.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content" style="overflow: auto;">
        <!--    Label for Edit Users    -->
        <center>
                <asp:Label ID="Label1" runat="server" Text="Manage Users"></asp:Label></center>
        <br />
        <!--    Grid View of Users -->
        <asp:GridView ID="ManageUsersGridView" AutoGenerateColumns="false" AutoGenerateEditButton="true" runat="server" OnRowUpdating="ManageUsersGridView_RowUpdating" OnRowEditing="ManageUsersGridView_RowEditing" AllowPaging="true">
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" SortExpression="CustomerID" ReadOnly="true"/>
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

        <!-- Label and Text Field for Searching last name -->
        <asp:Label ID="Label2" runat="server" Text="Search Last Name"></asp:Label></center>
        <asp:TextBox ID="txtSearchLastName" runat="server"></asp:TextBox>
        <br />
        <br />

        <!-- LinkButton for Submission -->
        <asp:Button ID="btnFind" runat="server" Text="Find" OnClick="btnSubmit_Click" />
        <br />

        <!-- Properly submitted. -->
        <asp:Label ID="lblComplete" runat="server" Visible="false" ForeColor="Red"><b>Account has been updated.</b></asp:Label>

        <!-- Error for the form not being properly submitted. -->
        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Sorry no user was found.</b></asp:Label>

        </center>
       
    </div>

</asp:Content>
