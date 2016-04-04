<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="CustViewOrders.aspx.cs" Inherits="WSC.CustManageOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <center>
            <h1>
               View Orders
            </h1>

            `
            <!-- This displays a grid view of the Order Items. -->
            <asp:GridView ID="ManageOrdersGridView" AutoGenerateColumns="False" runat="server" CellPadding="5" Width="500px" OnSelectedIndexChanged="OnSelectedIndexChange">
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
         </center>
    </div>
</asp:Content>
