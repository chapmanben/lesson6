<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="comp2007_wed1_Lesson5.students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <h1>Students</h1>
        <a href="student.aspx">Add Student</a>

        <asp:GridView ID="grdStudents" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" 
            OnRowDeleting="grdStudents_RowDeleting" DataKeyNames="StudentID" >
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name"/>
                <asp:BoundField DataField="FirstMidName" HeaderText="First Name" />
                <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" DataFormatString="{0:dddd, MMMM dd, yyyy}" />
                <asp:HyperLinkField HeaderText="Edit" text="Edit" NavigateUrl="student.aspx" DataNavigateUrlFields="StudentID" 
                    DataNavigateUrlFormatString="student.aspx?StudentID={0}"/>
                <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
               
            </Columns>  

        </asp:GridView>
    </div>
</asp:Content>
