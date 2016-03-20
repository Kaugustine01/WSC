<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="WSC.Admin.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">
        <!--    Label for Edit Users    -->
        <center>
                <asp:Label ID="Label1" runat="server" Text="Manage Users"></asp:Label></center>
        <br />

        <!--    Grid View of Users -->
        <center>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ID"> 
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="User Name" InsertVisible="False"
                        ReadOnly="True" SortExpression="UserName" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name"
                        SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name"
                        SortExpression="LastName" />
                    <asp:BoundField DataField="Address" HeaderText="Address"
                        SortExpression="Address" />
                    <asp:BoundField DataField="City" HeaderText="City"
                        SortExpression="City" />
                    <asp:BoundField DataField="State" HeaderText="State"
                        SortExpression="State" />
                    <asp:BoundField DataField="ZipCode" HeaderText="Zip Code"
                        SortExpression="ZipCode" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone"
                        SortExpression="Phone" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </center>
    </div>

</asp:Content>
