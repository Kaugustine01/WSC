<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="WSC.Catalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <center>
            <h1>
               WSC Catalog
            </h1>
            <asp:GridView ID="CatalogGridView" AutoGenerateColumns="False" runat="server" Width="388px">
                <Columns>
                    <asp:TemplateField HeaderText="Add to Cart">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRow" runat="server"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField DataField="CatalogItemID" HeaderText="Item ID" SortExpression="CatalogID" ReadOnly="true"/>
                <asp:BoundField DataField="CatalogItemName" HeaderText="Item Name" SortExpression="CatalogItemName" ReadOnly="true" />
                <asp:BoundField DataField="CatalogItemDescr" HeaderText="Description" SortExpression="ItemDescription" ReadOnly="true" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="ItemPrice" ReadOnly="true" />
                <asp:BoundField DataField="CatalogImagePath" HeaderText="Image" SortExpression="CatalogImagePath" ReadOnly="true" />
                    
            </Columns>
            </asp:GridView>
            <asp:Button ID="AddToCart" runat="server" Text="Add to Cart" OnClick="AddToCart_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Checkout" runat="server" Text="Check Out" OnClick="Checkout_Click" />
            <br />
            <br />
            <!-- Error for the form not being properly submitted. -->
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Your Cart is Empty</b></asp:Label>

        </center>
    </div>
</asp:Content>
