<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="WSC.PasswordRecovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--
    Programmer: Daniel Bays
    Date:       4/05/2016
    Purpose:    Login Page
    Details:    This page is for the user to login.
    -->

    <div class="content">
        
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
            <!-- User Name -->
            <asp:Label ID="lblUserName" runat="server" Text="User Name:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="txtUserName" ErrorMessage="User Name Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />
            <!-- LinkButton for Submission -->
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" onClick="btnSubmit_Click" ValidationGroup="ValGroup" Visible="true"/>
            <br />
        </asp:Panel>     
        <!-- Error for the form not being properly submitted. -->
        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>   
    </div>
</asp:Content>
