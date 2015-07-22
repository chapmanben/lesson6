<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="comp2007_wed1_Lesson5.registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Register</h1>
    <h5>All Fields Are Required</h5>

    <asp:Label ID="lblStatus" runat="server"/>

    <div class="form-group">
        <label for="txtusername">Username: </label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtpassword">Password: </label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtConfirm">Confirm: </label>
        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords Do Not Match" operator="Equal" ControlToValidate="txtConfirm" ControlToCompare="txtPassword" CssClass="label label-warning"></asp:CompareValidator>
    </div>
    <div class="col-sm-offset-2">
        <asp:Button ID="btnRegister" runat="server" Text="Submit" OnClick="btnRegister_Click" />
    </div>

</asp:Content>
