<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="UpdateCatalogItem.aspx.cs" Inherits="WSC.Admin.UpdateCatalogItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--
    Programmer: Daniel Bays
    Date:       4/05/2016
    Purpose:    Update Catalog Item Form
    Details:    This form is for Operations Manager to Update an Item for the Catalog.
    -->

    <!-- Add Catalog Form -->
    <div class="content">
        <center><h1>Update Catalog Item Form</h1></center>
        <p>
            <b>Price: </b> - Correct Price format is 10.55
        </p>
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">

            <!-- Catalog Id -->
            <asp:Label ID="lblCatalogId" runat="server" Text="Catalog Id:" Width="200px"></asp:Label>
            <asp:TextBox ID="txtCatalogId" runat="server" ReadOnly="true"></asp:TextBox>
            <br />
            <br />

            <!-- Catalog Item -->
            <asp:Label ID="lbCatalogItem" runat="server" Text="Catalog Item:" Width="200px"></asp:Label>
            <asp:TextBox ID="txtCatalogItem" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtCatalogItem" ErrorMessage="Catalog Item Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />
            <br />

            <!-- Catalog Description -->
            <asp:Label ID="lblCatalogDescr" runat="server" Text="Catalog Description:" Width="200px"></asp:Label>
            <asp:TextBox ID="txtCatalogDescr" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="txtCatalogDescr" ErrorMessage="Catalog Description Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />
            <br />

            <!-- Catalog Image -->
            <asp:Label ID="lblCatalogImage" runat="server" Text="Catalog Image:" Width="200px"></asp:Label>
            <asp:DropDownList ID="ddlCatalogImage" runat="server">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Plaque</asp:ListItem>
                <asp:ListItem>Trophy</asp:ListItem>
                <asp:ListItem>Mug</asp:ListItem>
                <asp:ListItem>Shirt</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCatalogImage"
                    ErrorMessage="Value Required" InitialValue="--Select--" ValidationGroup="ValGroup" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />

            <!-- Catalog Item Price -->
            <asp:Label ID="lblPrice" runat="server" Text="Price:" Width="200px"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                ControlToValidate="txtPrice" ErrorMessage="Price Required." ForeColor="Red" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
            <br />
            <br />

            <!-- Catalog Item Active -->
            <asp:Label ID="lblActive" runat="server" Text="Active" Width="200px"></asp:Label>
            <asp:DropDownList ID="ddlActive" runat="server">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlActive"
                    ErrorMessage="Value Required" InitialValue="--Select--" ValidationGroup="ValGroup" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />

            <!-- LinkButton for Submission -->
            <asp:Button ID="btnSubmit" class="button" runat="server" Text="Submit" OnClick="Submit_Click" ValidationGroup="ValGroup" Visible="true" />
            <br />

            <!-- Properly submitted. -->
            <asp:Label ID="lblComplete" runat="server" Visible="false" ForeColor="Red"><b>Updated was Successful.</b></asp:Label>

            <!-- Error for the form not being properly submitted. -->
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"><b>There was an Error</b></asp:Label>
        </asp:Panel>
    </div>

</asp:Content>
