<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="CustViewOrderItems.aspx.cs" Inherits="WSC.CustViewOrderItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--
    Programmer: Daniel Bays
    Date:       3/30/2016
    Purpose:    View Cart Form
    Details:    This form is for the customer to view the cart information regarding their current sessions order.
    -->

    <div class="content">
        <center>
            <h1>
               View Order
            </h1>

            <!-- Panel for the Order Details -->
            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">

                <!-- Order Number -->
                <asp:Label ID="lblOrderNumber" runat="server" Text="Order Number:" Width="130px"></asp:Label>
                <asp:TextBox ID="txtOrderNumber" runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />

                <!-- Order Date -->
                <asp:Label ID="lblOrderDate" runat="server" Text="Order Date:" Width="130px"></asp:Label>
                <asp:TextBox ID="txtOrderDate" runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />

                <!-- Payment on Delivery -->
                <asp:Label ID="lblPaymentDelivery" runat="server" Text="Payment on Delivery:" Width="130px"></asp:Label>
                <asp:TextBox ID="txtPaymentDelivery" runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />

                <!-- Status -->
                <asp:Label ID="lblStatus" runat="server" Text="Status:" Width="130px"></asp:Label>
                <asp:TextBox ID="txtStatus" runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />

                <!-- Payment Type -->
                <asp:Label ID="lblPaymentType" runat="server" Text="Payment Type:" Width="130px"></asp:Label>
                <asp:TextBox ID="txtPaymentType" runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />

                <!-- Deposite Amount -->
                <asp:Label ID="lblDeposit" runat="server" Text="Deposit Amount:" Width="130px"></asp:Label>
                <asp:TextBox ID="txtDeposit" runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />

                <!-- Used to Display the total of the Order -->
                <asp:Label ID="lblTotal" runat="server" Text="Total:" Width="130px"></asp:Label>
            </asp:Panel>
            <br />
            <br />

            <!-- GridView for the Order Items -->
            <asp:GridView  ID="ViewOrderGridView" AutoGenerateColumns="false" runat="server" CellPadding="5">
                <HeaderStyle BackColor="Black" ForeColor="White"/>
                <RowStyle BackColor="#c5d5cb" />
                <AlternatingRowStyle BackColor="#e3e0cf" />
                <Columns>
                    <asp:BoundField DataField="CatalogItemID" HeaderText="Item ID" SortExpression="CatalogID" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogItemName" HeaderText="Item Name" SortExpression="CatalogItemName" ReadOnly="true" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="CatalogItemDescr" HeaderText="Description" SortExpression="CatalogItemDescr" ReadOnly="true" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="CatalogImagePath" HeaderText="Image" SortExpression="CatalogImagePath" ReadOnly="true" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="Qty" HeaderText="Quantity" SortExpression="Qty" ReadOnly="true" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="ItemPrice" HeaderText="Price" SortExpression="ItemPrice" ReadOnly="true" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" ReadOnly="true" ItemStyle-Width="50px" />
                </Columns>
            </asp:GridView>

        </center>
    </div>
</asp:Content>
