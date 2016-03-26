<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="WSC.Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <center>
            <h1>
               WSC Catalog
            </h1>
            <asp:GridView ID="CatalogGridView" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField DataField="CatalogItemID" HeaderText="Item ID" sortExpression="CatalogID" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogItemName" HeaderText="Item Name" sortExpression="CatalogItemName" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogItemDescr" HeaderText="Description" SortExpression="ItemDescription" ReadOnly="true" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="ItemPrice" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogImagePath" HeaderText="Image" SortExpression="CatalogImagePath" ReadOnly="true" />
                </Columns>
            </asp:GridView>
        </center>
    </div>
</asp:Content>
