<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="WSC.Catalog" %>

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
               WSC Catalog
            </h1>

            <!-- This displays a grid view of the Catalog. -->
            <asp:GridView ID="CatalogGridView" AutoGenerateColumns="False" runat="server" CellPadding="5" Width="500">
                <HeaderStyle BackColor="Black" ForeColor="White"/>
                <RowStyle BackColor="#c5d5cb" />
                <AlternatingRowStyle BackColor="#e3e0cf" />
                <Columns>
                    <asp:TemplateField HeaderText="Add">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRow" runat="server"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CatalogItemID" HeaderText="Item ID" SortExpression="CatalogID" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogItemName" HeaderText="Item Name" SortExpression="CatalogItemName" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogItemDescr" HeaderText="Description" SortExpression="ItemDescription" ReadOnly="true" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="ItemPrice" ReadOnly="true"/>
                    <asp:BoundField DataField="CatalogImagePath" HeaderText="Image" SortExpression="CatalogImagePath" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQty" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="txtContent" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <!-- Button to Add items from the Cart -->
            <asp:Button ID="AddToCart" runat="server" Text="Add to Cart" OnClick="AddToCart_Click" />

            &nbsp;&nbsp;&nbsp;&nbsp;

            <!-- Button to Move to the Check Out Page -->
            <asp:Button ID="Checkout" runat="server" Text="Check Out" OnClick="Checkout_Click" />
            <br />
            <br />

            <!-- Error to say cart is empty when user clicks on Check Out Page while the cart is empty. -->
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Your Cart is Empty</b></asp:Label>

        </center>
    </div>
</asp:Content>
