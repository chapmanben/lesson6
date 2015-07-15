<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="courses.aspx.cs" Inherits="comp2007_wed1_Lesson5.courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <h1>Courses</h1>
        <a href="course.aspx">Add Course</a>
        <div>
            <label for="ddlPageSize">Records Per Page</label>
            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                <asp:ListItem Value="5" Text="5"></asp:ListItem>
                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                <asp:ListItem Value="9999" Text="All"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <asp:GridView ID="grdCourses" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false"
            OnRowDeleting="grdCourses_RowDeleting" DataKeyNames="CourseID" AllowPaging="true" PageSize="3" 
            OnPageIndexChanging="grdCourses_PageIndexChanging" AllowSorting="true" OnSorting="grdCourses_Sorting"
            OnRowDataBound="grdCourses_RowDataBound">
            <Columns>
                <asp:BoundField DataField="CourseID" HeaderText="Course ID" SortExpression="CourseID" />
                <asp:BoundField DataField="Title" HeaderText="Course Title" SortExpression="Title"/>
                <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits"/>
                <asp:BoundField DataField="Name" HeaderText="Department" SortExpression="Name"/>
                <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="course.aspx" DataNavigateUrlFields="CourseID"
                    DataNavigateUrlFormatString="course.aspx?CourseID={0}" />
                <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
