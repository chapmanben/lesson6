<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="comp2007_wed1_Lesson5.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login</h1>
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <div class="form-group">
        <label for="txtusername">Username: </label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtpassword">Password: </label>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    </div>

    <div class="col-sm-offset-2">
        <asp:Button ID="btnRegister" runat="server" Text="Submit" OnClick="btnLogin_Click" />
    </div>

</asp:Content>
