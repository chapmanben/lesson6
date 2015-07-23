<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="comp2007_wed1_Lesson5.students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <h1>Students</h1>
        <a href="student.aspx">Add Student</a>

        <asp:Label ID="lblUserId" runat="server" />

        <div>
            <label for="ddlPageSize">Records Per Page</label>
            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                <asp:ListItem Value="5" Text="5"></asp:ListItem>
                <asp:ListItem Value="10" Text="10"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <asp:GridView ID="grdStudents" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" 
            OnRowDeleting="grdStudents_RowDeleting" DataKeyNames="StudentID" AllowPaging="true" PageSize="3" OnPageIndexChanging="grdStudents_PageIndexChanging" AllowSorting="true"
            OnSorting="grdStudents_Sorting" OnRowDataBound="grdStudents_RowDataBound">
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="Student ID" SortExpression="StudentID"/>
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName"/>
                <asp:BoundField DataField="FirstMidName" HeaderText="First Name" SortExpression="FirstMidName" />
                <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" DataFormatString="{0:dddd, MMMM dd, yyyy}" SortExpression="EnrollmentDate"/>
                <asp:HyperLinkField HeaderText="Edit" text="Edit" NavigateUrl="student.aspx" DataNavigateUrlFields="StudentID" 
                    DataNavigateUrlFormatString="student.aspx?StudentID={0}"/>
                <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
               
            </Columns>  

        </asp:GridView>
    </div>
</asp:Content>
