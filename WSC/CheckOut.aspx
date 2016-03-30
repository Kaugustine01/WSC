<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="WSC.CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <center>
            <h1>
               Check Out
            </h1>
    <asp:GridView ID="CartGridView" AutoGenerateColumns="true" runat="server" Width="500">
                        <HeaderStyle BackColor="Black" ForeColor="White"/>
                <RowStyle BackColor="#c5d5cb" />
                <AlternatingRowStyle BackColor="#e3e0cf" />
        </asp:GridView>
        <br />
        <br />
        <!-- Error for the form not being properly submitted. -->
        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Your Cart is Empty</b></asp:Label>

            </center>
    </div>
</asp:Content>
