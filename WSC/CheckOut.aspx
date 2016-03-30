<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="WSC.CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <center>
            <h1>
               Check Out
            </h1>
    <asp:GridView ID="CartGridView" AutoGenerateColumns="true" runat="server" Width="388px">

        </asp:GridView>
        <br />
        <br />
        <!-- Error for the form not being properly submitted. -->
        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Your Cart is Empty</b></asp:Label>

            </center>
    </div>
</asp:Content>
