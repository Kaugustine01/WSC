<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="NoAccess.aspx.cs" Inherits="WSC.Admin.NoAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--
    Programmer: Daniel Bays
    Date:       4/05/2016
    Purpose:    No Access Page
    Details:    This program is used display that the user doesn't have access.
    -->
    <div class="content">
        <center>
            <h1>No Access</h1>
            <p>
                You do not have access to this page, please login as an Admin User.
            </p>
        </center>
    </div>
</asp:Content>
