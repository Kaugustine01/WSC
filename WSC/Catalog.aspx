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

            <!-- Display Login Message if the user is not Logged in -->
            <asp:Label ID="lblLogin" runat="server" Visible="false" ForeColor="Red"><b>You must login to place an Order</b></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Login_Click" Visible="false"/>
            <br />
            <br />

            <!-- This displays a grid view of the Catalog. -->
            <asp:GridView ID="CatalogGridView" AutoGenerateColumns="False" runat="server" CellPadding="5" Width="500">
                <HeaderStyle BackColor="Black" ForeColor="White"/>
                <RowStyle BackColor="#c5d5cb" />
                <AlternatingRowStyle BackColor="#e3e0cf" />
                
                <Columns>
                    <asp:TemplateField HeaderText="Add" ItemStyle-Width="10px">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRow" runat="server"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CatalogItemID" HeaderText="Item ID" SortExpression="CatalogID" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogItemName" HeaderText="Item Name" SortExpression="CatalogItemName" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogItemDescr" HeaderText="Description" SortExpression="ItemDescription" ReadOnly="true" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="ItemPrice" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogImagePath" HeaderText="Image" SortExpression="CatalogImagePath" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQty" runat="server" />
                             <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Range: 0 - 100" ControlToValidate="txtQty" MaximumValue="100" MinimumValue="0" Type="Double" ValidationGroup="ValGroup"></asp:RangeValidator>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="Content">
                        <ItemTemplate>
                            <asp:TextBox ID="txtContent" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />

            <!-- Button to Add items from the Cart -->
            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="AddToCart_Click" Visible="true" />

            &nbsp;&nbsp;&nbsp;&nbsp;

            <!-- Button to Move to the Check Out Page -->
            <asp:Button ID="btnViewCart" runat="server" Text="View Cart" OnClick="ViewCart_Click" Visible="true" />
            <br />
            <br />

            <!-- Displays if items were added to the cart -->
            <asp:Label ID="lblItemsAdded" runat="server" Visible="false" ForeColor="Red"><b>Items were added to your Shopping Cart</b></asp:Label>

            <!-- Error to say cart is empty when user clicks on Check Out Page while the cart is empty. -->
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Your Cart is Empty</b></asp:Label>

        </center>
    </div>
</asp:Content>
