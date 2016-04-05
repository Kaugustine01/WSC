<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="WSC.CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--
    Programmer: Daniel Bays
    Date:       3/30/2016
    Purpose:    Check Out Form
    Details:    This form is for the customer to purchase the items that are currently in their cart.
    -->

    <div class="content">
        <center>
            <h1>
               Check Out
            </h1>
            <asp:Label ID="lblSuccess" runat="server" Visible="false" ForeColor="Red"><b>Your order has been placed. 
                Thank you for your Purchase</b></asp:Label>
            <br />
            <br />
            
            <!-- This displays a grid view of the Order. -->
            <asp:GridView ID="CartGridView" AutoGenerateColumns="false" runat="server" CellPadding="5" Width="500">
                <HeaderStyle BackColor="Black" ForeColor="White"/>
                <RowStyle BackColor="#c5d5cb" />
                <AlternatingRowStyle BackColor="#e3e0cf" />
                <Columns>
                    <asp:BoundField DataField="CatalogItemID" HeaderText="Item ID" SortExpression="CatalogItemID" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogItemName" HeaderText="Item Name" SortExpression="CatalogItemName" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogItemDescr" HeaderText="Description" SortExpression="CatalogItemDescr" ReadOnly="true" />
                    <asp:TemplateField HeaderText="" >
                        <ItemTemplate>                          
                            <asp:Image ID="imgCatalogItem" runat="server" ImageUrl='<%# Eval("CatalogImagePath","~/{0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Qty" HeaderText="Quantity" SortExpression="Qty" ReadOnly="true" />
                    <asp:BoundField DataField="ItemPrice" HeaderText="Price" SortExpression="ItemPrice" ReadOnly="true"/>
                    <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" ReadOnly="true" />
                </Columns>
            </asp:GridView>
            <br />
            <br />

            <!-- Error for the cart being empty-->
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Your Cart is Empty</b></asp:Label>
            <br />
            <br />

            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">

                <!-- Label to display the Total Amount of the Order -->
                <asp:Label ID="lblTotal" runat="server" />
                <br />
                <br />

                <!-- Payment on Delivery -->
                <asp:Label ID="lblPaymentOnDelivery" runat="server" Text="Payment on Delivery: " Width="200px"></asp:Label>
                <asp:DropDownList ID="ddlPaymentOnDelivery" runat="server" >
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPaymentOnDelivery" ErrorMessage="Payment on Delivery Required." ForeColor="Red"></asp:RequiredFieldValidator>
                <br />

                <!-- Deposit Amount -->
                <asp:Label ID="lblDeposit" runat="server" Text="Deposit Amount: " Width="200px"></asp:Label>
                <asp:TextBox ID="txtDeposit" runat="server" ReadOnly="true"/>
                <br />

                <!-- Payment Type -->
                <asp:Label ID="lblPaymentType" runat="server" Text="Payment Type: " Width="200px"></asp:Label>
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
            <asp:Button ID="btnCheckOut" runat="server" Text="Confirm Purchase" OnClick="Checkout_Click" Visible="true" />

            <!-- Properly submitted. -->
            <asp:Label ID="lblComplete" runat="server" Visible="false" ForeColor="Red"><b>Your Purchase has been Completed</b></asp:Label>

            <!-- Error for the form not being properly submitted. -->
            <asp:Label ID="Label1" runat="server" Visible="false" ForeColor="Red"><b>Sorry something went wrong.</b></asp:Label>
        </center>
    </div>
</asp:Content>
