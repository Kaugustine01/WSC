<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ManageEmployees.aspx.cs" Inherits="WSC.Admin.ManageEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">
        <!--    Label for Edit Employees    -->
        <center>
                <asp:Label ID="Label1" runat="server" Text="Manage Employees"></asp:Label></center>
        <br />

        <!--    Grid View of Employees First Name, Last Name, PayRate, Start Date, End Date -->
        <center>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ID"> 
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False"
                        ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name"
                        SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name"
                        SortExpression="LastName" />
                    <asp:BoundField DataField="PayRate" HeaderText="Pay Rate"
                        SortExpression="PayRate" />
                    <asp:BoundField DataField="StartDate" HeaderText="Start Date"
                        SortExpression="StartDate" />
                    <asp:BoundField DataField="EndDate" HeaderText="End Date"
                        SortExpression="EndDate" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </center>
    </div>

</asp:Content>
