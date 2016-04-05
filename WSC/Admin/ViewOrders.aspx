<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ViewOrders.aspx.cs" Inherits="WSC.Admin.ViewOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <center>
            <h1>
               Manage Orders
            </h1>

            <!-- This displays a grid view of the Order Items. -->
            <asp:GridView ID="ManageOrdersGridView" AutoGenerateColumns="False" runat="server" CellPadding="5" Width="100%" OnSelectedIndexChanged="OnSelectedIndexChange">
                <HeaderStyle BackColor="Black" ForeColor="White"/>
                <RowStyle BackColor="#c5d5cb" />
                <AlternatingRowStyle BackColor="#e3e0cf" />
                <Columns>
                    <asp:ButtonField Text="View Details" CommandName="Select" ItemStyle-Width="30" />
                    <asp:BoundField DataField="OrderId" HeaderText="Order Number" SortExpression="OrderId" ReadOnly="true" />
                    <asp:BoundField DataField="OrderDate" HeaderText="Order Date" SortExpression="OrderDate" ReadOnly="true" />
                    <asp:BoundField DataField="StatusId" HeaderText="Status" SortExpression="StatusId" ReadOnly="true" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <!-- Error to say cart is empty when user clicks on Check Out Page while the cart is empty. -->
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>There was an error.</b></asp:Label>
         </center>
    </div>
</asp:Content>
