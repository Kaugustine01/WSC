<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ViewOrders.aspx.cs" Inherits="WSC.CustManageOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--
    Programmer: Daniel Bays
    Date:       4/05/2016
    Purpose:    Customers View Order Form
    Details:    This form is for the customer to view the order information.
    -->

    <div class="content">
        <center>
            <h1>
               View Orders
            </h1>

            <!-- If the users doe not have any orders.. -->
            <asp:Label ID="lblNoOrders" runat="server" Visible="false" ForeColor="Red"><b>You have no previous orders to display.</b></asp:Label>

            <!-- This displays a grid view of the Order customers placed orders. -->
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
            <!-- Display Error Message if somethign goes wrong. -->
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>There was an error.</b></asp:Label>
         </center>
    </div>
</asp:Content>
