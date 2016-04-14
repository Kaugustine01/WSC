<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="NoAccess.aspx.cs" Inherits="WSC.NoAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--
    Programmer: Daniel Bays
    Date:       4/05/2016
    Purpose:    No Access Page
    Details:    This is used to tell the user they don't have access.
    -->

    <div class="content">
        <h1>Access Denied</h1>
        <p>
            You do not have permssion to access this page.
        </p>
    </div>
</asp:Content>
