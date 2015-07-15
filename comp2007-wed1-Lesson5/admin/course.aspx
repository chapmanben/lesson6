<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="course.aspx.cs" Inherits="comp2007_wed1_Lesson5.course" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Course Details</h1>
    <h5>All fields are required</h5>
    <fieldset>
        <div>
            <label for="txtCourseName">Course:</label>
            <asp:TextBox ID="txtCourseName" runat="server" required MaxLength="50" />
        </div>
        <div>
            <label for="ddlDepartments">Deparment:</label>
            <asp:DropDownList ID="ddlDepartments" runat="server" AutoPostBack="true">
            </asp:DropDownList>
        </div>

    </fieldset>
    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>

    <asp:Panel ID="pnlStudents" runat="server" Visible="false">
        <div>
            <h2>Courses</h2>
            <asp:GridView ID="grdStudents" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false"
                DataKeyNames="StudentID" OnRowDeleting="grdStudents_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                    <asp:BoundField DataField="FirstMidName" HeaderText="first Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
</asp:Content>
