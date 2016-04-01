<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="WSC.ViewCart" %>


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
               Shopping Cart
            </h1>

            <!-- This displays a grid view of the customers current sessions shopping cart. -->
            <asp:GridView  ID="CartGridView" AutoGenerateColumns="false" runat="server" CellPadding="5">
                <HeaderStyle BackColor="Black" ForeColor="White"/>
                <RowStyle BackColor="#c5d5cb" />
                <AlternatingRowStyle BackColor="#e3e0cf" />
                <Columns>
                    <asp:TemplateField HeaderText="Remove" ItemStyle-Width="10px">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRow" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CatalogItemName" HeaderText="Item Name" SortExpression="CatalogItemName" ReadOnly="true" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="CatalogItemDescr" HeaderText="Description" SortExpression="CatalogItemDescr" ReadOnly="true" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="CatalogImagePath" HeaderText="Image" SortExpression="CatalogImagePath" ReadOnly="true" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="Qty" HeaderText="Quantity" SortExpression="Qty" ReadOnly="true" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="ItemPrice" HeaderText="Price" SortExpression="ItemPrice" ReadOnly="true" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" ReadOnly="true" ItemStyle-Width="50px" />
                </Columns>
            </asp:GridView>
            <br />
            <br />

            <!-- Label to display the Total Amount of the Order -->
            <asp:Label ID="lblTotal" runat="server" />
            <br />
            <br />

            <!-- Button to Remove items from the Cart -->
            <asp:Button ID="btnRemoveFromCart" runat="server" Text="Remove from Cart" OnClick="RemoveFromCart_Click"/>

            &nbsp;&nbsp;&nbsp;&nbsp;

            <!-- Button to Move to the Check Out Page -->
            <asp:Button ID="btnConfirmPurchase" runat="server" Text="Check Out" OnClick="ConfirmPurchase_Click" />
            <br />
            <br />

            <!-- Error for the cart being empty -->
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Your Cart is Empty</b></asp:Label>

            </center>
    </div>

</asp:Content>
