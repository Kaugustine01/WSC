<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="WSC.Admin.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content" style="overflow:auto;">
        <!--    Label for Edit Users    -->
        <center>
                <asp:Label ID="Label1" runat="server" Text="Manage Users"></asp:Label></center>
        <br />

        <!--    Grid View of Users -->
        <center>
            <asp:GridView ID="ManageUsersGridView" AutoGenerateColumns="true" runat="server" >

            </asp:GridView>
               
    </div>

</asp:Content>
