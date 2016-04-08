﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WSC.Login" %>
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
            <asp:Login ID="Login1" runat="server" OnAuthenticate="OnAuthenticate" BackColor="#F7F7DE" BorderColor="#CCCC99"
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" UserName="" >
                <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
            </asp:Login>
        </center>
    </div>
</asp:Content>
