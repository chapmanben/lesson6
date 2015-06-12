<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="departments.aspx.cs" Inherits="comp2007_wed1_Lesson5.departments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <h1>Departments</h1>
        <a href="department.aspx">Add Department</a>

        <asp:GridView ID="grdDepartments" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false"
            OnRowDeleting="grdDepartments_RowDeleting" DataKeyNames="DepartmentID" >
            <Columns>
                <asp:BoundField DataField="DepartmentID" HeaderText="Department ID" />
                <asp:BoundField DataField="Name" HeaderText="Department" />
                <asp:BoundField DataField="Budget" HeaderText="Budget" DataFormatString="{0:c}" />
                <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="department.aspx" DataNavigateUrlFields="DepartmentID"
                    DataNavigateUrlFormatString="department.aspx?DepartmentID={0}" />
                <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
