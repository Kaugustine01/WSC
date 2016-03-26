<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="WSC.Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <center>
            <h1>
               WSC Catalog
            </h1>
            <asp:GridView ID="CatalogGridView" AutoGenerateColumns="true" runat="server">

            </asp:GridView>
        </center>
    </div>
</asp:Content>
