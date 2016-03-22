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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                DataKeyNames="CustID" DataSourceID="SqlDataSource1" ShowFooter="True" CellPadding="4" ForeColor="#333333" GridLines="None"> 
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="CustID" HeaderText="ID" InsertVisible="False"
                        ReadOnly="True" SortExpression="CustID" ControlStyle-CssClass="cssWdth"/>

                    <asp:BoundField DataField="FirstName" HeaderText="First Name"
                        SortExpression="FirstName" ControlStyle-CssClass="cssWdth"/>

                    <asp:BoundField DataField="LastName" HeaderText="Last Name"
                        SortExpression="LastName" ControlStyle-CssClass="cssWdth"/>
                       
                    <asp:BoundField DataField="Address" HeaderText="Address"
                        SortExpression="Address" ControlStyle-CssClass="cssWdth"/>
               
                    <asp:BoundField DataField="City" HeaderText="City"
                        SortExpression="City" ControlStyle-CssClass="cssWdth"/>
                   
                    <asp:BoundField DataField="State" HeaderText="State"
                        SortExpression="State" ControlStyle-CssClass="cssWdth"/>
                    
                    <asp:BoundField DataField="Zip" HeaderText="Zip Code"
                        SortExpression="Zip" ControlStyle-CssClass="cssWdth"/>
                    
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number"
                        SortExpression="PhoneNumber" ControlStyle-CssClass="cssWdth"/>
                   
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:CommandField ShowInsertButton="true" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
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
