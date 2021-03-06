﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ViewOrderItems.aspx.cs" Inherits="WSC.Admin.ViewOrderItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--
    Programmer: Daniel Bays
    Date:       4/05/2016
    Purpose:    Order Details Form
    Details:    This form is for the customer to view the Order Details for an Order.
    -->

    <div class="content">
        <center>
            <h1>
               Manage Order Details
            </h1>

            <!-- Panel for the Order Details -->
            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">

                <!-- Order Number -->
                <asp:Label ID="lblOrderNumber" runat="server" Text="Order Number:" Width="130px"></asp:Label>
                <asp:TextBox ID="txtOrderNumber" runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />

                <!-- Order Date -->
                <asp:Label ID="lblOrderDate" runat="server" Text="Order Date:" Width="130px"></asp:Label>
                <asp:TextBox ID="txtOrderDate" runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />

                <!-- Payment on Delivery -->
                <asp:Label ID="lblPaymentDelivery" runat="server" Text="Payment on Delivery:" Width="130px"></asp:Label>
                <asp:TextBox ID="txtPaymentDelivery" runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />

                <!-- Status -->
                <asp:Label ID="lblStatus" runat="server" Text="Current Status:" Width="130px"></asp:Label>
                <asp:TextBox ID="txtStatus" runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />

                <!-- Status Update -->
                <asp:Label ID="lblUpdateStatus" runat="server" Text="Update Status:" Width="130px"></asp:Label>
                <asp:DropDownList ID="ddlUpdateStatus" runat="server" >
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Validated</asp:ListItem>
                    <asp:ListItem>Closed</asp:ListItem>
                    <asp:ListItem>Cancelled</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlUpdateStatus"
                    ErrorMessage="Value Required" InitialValue="--Select--" ValidationGroup="ValGroup" Fore-Color="Red"></asp:RequiredFieldValidator>
                <br />
                <br />

                <!-- Payment Type -->
                <asp:Label ID="lblPaymentType" runat="server" Text="Payment Type:" Width="130px"></asp:Label>
                <asp:TextBox ID="txtPaymentType" runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />

                <!-- Deposite Amount -->
                <asp:Label ID="lblDeposit" runat="server" Text="Deposit Amount:" Width="130px" Visible="false"></asp:Label>
                <asp:TextBox ID="txtDeposit" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                <br />
                <br />

                <!-- Used to Display the total of the Order -->
                <asp:Label ID="lblTotal" runat="server" Text="Total:" Width="130px"></asp:Label>
                <br />
                <br />
                
                <!-- Update Button -->
                <asp:Button ID="btnUpdate" class="button" runat="server" Text="Update" ValidationGroup="ValGroup" OnClick="Update_Click" Visible="true"/>
                <br />

                <!-- Label for Updated Complete -->
                <asp:Label ID="lblComplete" runat="server" Visible="false" ForeColor="Red"><b>Update been processed.</b></asp:Label>

                <!-- Error for the form not being properly submitted. -->
                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Error During Update</b></asp:Label>
            </asp:Panel>
            <br />
            <br />

            <!-- GridView for the Order Items -->
            <asp:GridView  ID="ViewOrderGridView" AutoGenerateColumns="false" runat="server" CellPadding="5" Width="100%">
                <HeaderStyle BackColor="Black" ForeColor="White"/>
                <RowStyle BackColor="#c5d5cb" />
                <AlternatingRowStyle BackColor="#e3e0cf" />
                <Columns>
                    <asp:BoundField DataField="CatalogItemID" HeaderText="Item ID" SortExpression="CatalogID" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogItemName" HeaderText="Item Name" SortExpression="CatalogItemName" ReadOnly="true" />
                    <asp:BoundField DataField="CatalogItemDescr" HeaderText="Description" SortExpression="CatalogItemDescr" ReadOnly="true" />
                    <asp:TemplateField HeaderText="" >
                        <ItemTemplate>                          
                            <asp:Image ID="imgCatalogItem" runat="server" ImageUrl='<%# Eval("CatalogImagePath","~/{0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Qty" HeaderText="Quantity" SortExpression="Qty" ReadOnly="true" />
                    <asp:BoundField DataField="ItemPrice" HeaderText="Price" SortExpression="ItemPrice" ReadOnly="true" />
                    <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" ReadOnly="true" />
                </Columns>
            </asp:GridView>
        </center>
    </div>
</asp:Content>
