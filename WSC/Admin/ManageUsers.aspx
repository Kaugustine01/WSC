<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="WSC.Admin.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content" style="overflow: auto;">
        <!--    Label for Edit Users    -->
        <center>
                <asp:Label ID="Label1" runat="server" Text="Manage Users"></asp:Label></center>
        <br />
        <!--    Grid View of Users -->
        <asp:GridView ID="ManageUsersGridView" AutoGenerateColumns="true" runat="server">
            
        </asp:GridView>
        <br />
        <br />

        <!-- Label and Text Field for Searching last name -->
        <asp:Label ID="Label2" runat="server" Text="Search Last Name"></asp:Label></center>
        <asp:TextBox ID="txtSearchLastName" runat="server"></asp:TextBox>
        <br />
        <br />

        <!-- LinkButton for Submission -->
        <asp:Button ID="btnFind" runat="server" Text="Find" OnClick="btnSubmit_Click" />
        <br />

        <!-- Properly submitted. -->
        <asp:Label ID="lblComplete" runat="server" Visible="false" ForeColor="Red"><b>Account has been updated.</b></asp:Label>

        <!-- Error for the form not being properly submitted. -->
        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>Sorry no user was found.</b></asp:Label>

        </center>
       
    </div>

</asp:Content>
