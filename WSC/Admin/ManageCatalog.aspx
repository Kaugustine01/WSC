<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ManageCatalog.aspx.cs" Inherits="WSC.Admin.ManageCatalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--
    Programmer: Daniel Bays
    Date:       4/05/2016
    Purpose:    Manage Catalog Form
    Details:    This form is for the Operations Manager to Update the Catalog.
    -->

    <div class="content">
        <center>
            <h1>
               Manage Catalog
            </h1>

            <!-- Display Login Message if the user is not Logged in -->
            <asp:Label ID="lblLogin" runat="server" Visible="false" ForeColor="Red"><b>You must be logged in as Operations Manager to Edit the Catalog</b></asp:Label>
            <br />
            <br />

            <!-- This displays a grid view of the Catalog. -->
            <asp:GridView ID="CatalogGridView" AutoGenerateColumns="False" runat="server" CellPadding="5" Width="100%" OnSelectedIndexChanged="OnSelectedIndexChange">
                <HeaderStyle BackColor="Black" ForeColor="White"/>
                <RowStyle BackColor="#c5d5cb" />
                <AlternatingRowStyle BackColor="#e3e0cf" />
                
                <Columns>
                    <asp:TemplateField HeaderText="" >
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRow" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CatalogItemID" HeaderText="Item ID" SortExpression="CatalogID" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogItemName" HeaderText="Item Name" SortExpression="CatalogItemName" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogItemDescr" HeaderText="Description" SortExpression="ItemDescription" ReadOnly="true" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="ItemPrice" ReadOnly="true" />
                    <asp:TemplateField HeaderText="" >
                        <ItemTemplate>                          
                            <asp:Image ID="imgCatalogItem" runat="server" ImageUrl='<%# Eval("CatalogImagePath","~/{0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" >
                        <ItemTemplate>
                            <asp:Button ID="btnUpdateCatalogItem" class="button" runat="server" Text="Update Item" Visible="true" CommandName="Select" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />

            <!-- Button to Move to the Check Out Page -->
            <asp:Button ID="btnDeleteChkRow" class="button" runat="server" Text="Delete Item" OnClick="DeleteChkRow_Click" Visible="true" />

            &nbsp;&nbsp;&nbsp;&nbsp;

            <!-- Button to Add an Item to the Catalog -->
            <asp:Button ID="btnAddCatalogItem" class="button" runat="server" Text="Add Item" OnClick="AddCatalogItem_Click" Visible="true" />
            <br />
            <br />

            <!-- Displays if items were Deleted from the Catalog -->
            <asp:Label ID="lblDeletedCatalogItems" runat="server" Visible="false" ForeColor="Red"><b>Items were Deleted</b></asp:Label>

            <!-- Label to display Error. -->
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>There was an error.</b></asp:Label>

        </center>
    </div>

</asp:Content>
