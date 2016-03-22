<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="WSC.Admin.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">
        <!--    Label for Edit Users    -->
        <center>
                <asp:Label ID="Label1" runat="server" Text="Manage Users"></asp:Label></center>
        <br />

        <!--    Grid View of Users -->
        <center>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                DataKeyNames="CustID" DataSourceID="SqlDataSource1" ShowFooter="True"> 
                <Columns>
                    <asp:BoundField DataField="CustID" HeaderText="Customer ID" InsertVisible="False"
                        ReadOnly="True" SortExpression="CustID" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name"
                        SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name"
                        SortExpression="LastName" />
                    <asp:BoundField DataField="Address" HeaderText="Address"
                        SortExpression="Address" />
                    <asp:BoundField DataField="City" HeaderText="City"
                        SortExpression="City" />
                    <asp:BoundField DataField="State" HeaderText="State"
                        SortExpression="State" />
                    <asp:BoundField DataField="Zip" HeaderText="Zip Code"
                        SortExpression="Zip" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number"
                        SortExpression="PhoneNumber" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </center>

        <!-- Delete, Insert, Select, and Upate statement for Edit Users -->
        <asp:SqlDataSource ID="SQLDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:WSCDatabaseConnectionString%>"
            DeleteCommand="DELETE FROM [CustomerT] WHERE [CustID] = ?"
            InsertCommand="INSERT INTO [CustomerT] ([FirstName], [LastName], [Address], [City], [State], [Zip], [PhoneNumber]) VALUES (?, ?, ?, ?, ?, ?, ?)"
            ProviderName="<%$ ConnectionStrings:WSCDatabaseConnectionString.ProviderName %>"
            SelectCommand="SELECT * FROM [CustomerT]"
            UpdateCommand="UPDATE [CustomerT] SET [FirstName] = ?, [LastName] = ?, [Address] = ?, [City] = ?, [State] = ?, [Zip] = ?, [PhoneNumber] = ? WHERE [CustID] = ?">

            <DeleteParameters>
                <asp:Parameter Name="CustID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="PhoneNumber" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="PhoneNumber" Type="String" />
                <asp:Parameter Name="CustID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>

</asp:Content>
