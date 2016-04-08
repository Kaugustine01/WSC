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
        <center>
            <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99"
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt">
            </asp:PasswordRecovery>
        </center>
    </div>

</asp:Content>
