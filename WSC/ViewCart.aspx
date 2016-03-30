<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="WSC.ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <center>
            <h1>
               Shopping Cart
            </h1>
    <asp:GridView ID="CartGridView" AutoGenerateColumns="true" runat="server" Width="388px">
        <Columns>
            <asp:TemplateField HeaderText="Add to Cart">
                <ItemTemplate>
                    <asp:CheckBox ID="chkRow" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        </asp:GridView>
        <asp:Button ID="RemoveFromCart" runat="server" Text="Remove from Cart" OnClick="RemoveFromCart_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ConfirmPurchase" runat="server" Text="Check Out" OnClick="ConfirmPurchase_Click" />
        <br />
        <br />
        <!-- Error for the form not being properly submitted. -->
        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Your Cart is Empty</b></asp:Label>
    
</asp:Content>
