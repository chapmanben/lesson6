<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="errors.aspx.cs" Inherits="comp2007_wed1_Lesson5.errors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Ooops... </h1>
    <asp:Label ID="lblErrorMessage" runat="server">Something went wrong. Try reloading the page or going back to the previous page.</asp:Label>
</asp:Content>
