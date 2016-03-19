<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Registration Form -->
    <div class="content">
        <center><h1>Registration Form</h1></center>
        <p>
            <b>User Name</b> - Only Numbers and Letters, no Special Characters.
            <br />  
            <b>Password</b> - Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character.
            <br />
            <b>Phone Number</b> - Correct Phone Number format is 123-456-7890.
        </p>
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">

            <!-- User Name -->
            <asp:Label ID="lblUserName" runat="server" Text="User Name:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtUserName" ErrorMessage="User Name Required." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <!-- Password -->
            <asp:Label ID="lblPassword" runat="server" Text="Password:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                ControlToValidate="txtPassword" ErrorMessage="Password Required." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="Regex1" runat="server" ControlToValidate="txtPassword"
                ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$"
                ErrorMessage="Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character" ForeColor="Red" />
            <br />

            <!-- Confirm Password -->
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password Required." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:CompareValidator ID="comparePassword" runat="server" ControlToValidate="txtConfirmPassword"
                ControlToCompare="txtPassword" ErrorMessage="Password Does Not Match" ForeColor="Red"></asp:CompareValidator>
            <br />

            <!-- First Name -->
            <asp:Label ID="lblFirstName" runat="server" Text="First Name" Width="130px"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ControlToValidate="txtFirstName" ErrorMessage="First Name Required." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <!-- Last Name -->
            <asp:Label ID="lblLastName" runat="server" Text="Last Name:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                ControlToValidate="txtLastName" ErrorMessage="Last Name Required." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <!-- Address -->
            <asp:Label ID="lblAddress" runat="server" Text="Address:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                ControlToValidate="txtAddress" ErrorMessage="Address Required." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <!-- City -->
            <asp:Label ID="lblCity" runat="server" Text="City:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                ControlToValidate="txtCity" ErrorMessage="City Required." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <!-- State -->
            <asp:Label ID="lblState" runat="server" Text="State:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                ControlToValidate="txtState" ErrorMessage="State Required." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <!-- Zip Code -->
            <asp:Label ID="lblZipCode" runat="server" Text="Zip Code:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                ControlToValidate="txtZipCode" ErrorMessage="Zip Code Required." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <!-- Phone Number -->
            <asp:Label ID="lblPhone" runat="server" Text="Phone Number:" Width="130px"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ErrorMessage="Enter valid Phone number" ControlToValidate="txtPhone" 
                ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" ForeColor="Red"></asp:RegularExpressionValidator>
            <br />
            <br />

            <!-- LinkButton for Submission -->
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" onClick="btnSubmit_Click" />
            <br />

            <!-- Error for the form not being properly submitted. -->
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>

