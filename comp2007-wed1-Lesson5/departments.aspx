<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="departments.aspx.cs" Inherits="comp2007_wed1_Lesson5.departments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <h1>Departments</h1>
        <a href="department.aspx">Add Department</a>

        <div>
            <label for="ddlPageSize">Records Per Page</label>
            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                <asp:ListItem Value="5" Text="5"></asp:ListItem>
                <asp:ListItem Value="10" Text="10"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <asp:GridView ID="grdDepartments" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false"
            OnRowDeleting="grdDepartments_RowDeleting" DataKeyNames="DepartmentID" AllowPaging="true" PageSize="3" OnPageIndexChanging="grdDepartments_PageIndexChanging"
            AllowSorting="true" OnSorting="grdDepartments_Sorting" OnRowDataBound="grdDepartments_RowDataBound" >
            <Columns>
                <asp:BoundField DataField="DepartmentID" HeaderText="Department ID" SortExpression="DepartmentID"/>
                <asp:BoundField DataField="Name" HeaderText="Department" SortExpression="Name" />
                <asp:BoundField DataField="Budget" HeaderText="Budget" DataFormatString="{0:c}" SortExpression="Budget" />
                <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="department.aspx" DataNavigateUrlFields="DepartmentID"
                    DataNavigateUrlFormatString="department.aspx?DepartmentID={0}" />
                <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
    </div>

 

</asp:Content>
