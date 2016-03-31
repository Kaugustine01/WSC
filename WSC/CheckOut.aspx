<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="WSC.CheckOut" %>
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
               Check Out
            </h1>

            <!-- This displays a grid view of the Order. -->
            <asp:GridView ID="CartGridView" AutoGenerateColumns="true" runat="server" CellPadding="5" Width="500">
                <HeaderStyle BackColor="Black" ForeColor="White"/>
                <RowStyle BackColor="#c5d5cb" />
                <AlternatingRowStyle BackColor="#e3e0cf" />
            </asp:GridView>
            <br />
            <br />

            <!-- Error for the cart being empty-->
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Your Cart is Empty</b></asp:Label>
            <br />
            <br />

            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">

                <!-- Payment on Delivery -->
                <asp:Label ID="lblPaymentOnDelivery" runat="server" Text="Payment on Delivery: " Width="130px"></asp:Label>
                <asp:DropDownList ID="ddlPaymentOnDelivery" runat="server">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPaymentOnDelivery" ErrorMessage="Payment on Delivery Required." ForeColor="Red"></asp:RequiredFieldValidator>
                <br />

                <!-- Deposit Amount -->
                <asp:Label ID="lblDeposit" runat="server" Text="Deposit Amount: " Width="130px"></asp:Label>
                <asp:TextBox ID="txtDeposit" runat="server" ReadOnly="true"/>
                <br />

                <!-- Payment Type -->
                <asp:Label ID="lblPaymentType" runat="server" Text="Payment Type: " Width="130px"></asp:Label>
                <asp:DropDownList ID="ddlPaymentType" runat="server">
                    <asp:ListItem>Card</asp:ListItem>
                    <asp:ListItem>Check</asp:ListItem>
                    <asp:ListItem>Cash</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlPaymentType" ErrorMessage="Payment Type is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                <br />            
            </asp:Panel>
            <br />
            <br />

            <!-- Check Out Button -->
            <asp:Button ID="btnCheckOut" runat="server" Text="Confirm Purchase" OnClick="Checkout_Click" />
        </center>
    </div>
</asp:Content>
