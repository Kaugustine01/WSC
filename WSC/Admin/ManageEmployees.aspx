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
            <asp:GridView ID="ManageEmployeesGridView" AutoGenerateColumns="true" runat="server"> 
                
            </asp:GridView>
        </center>
    </div>

</asp:Content>
