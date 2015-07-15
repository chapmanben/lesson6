<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="comp2007_wed1_Lesson5.student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student Details</h1>
    <h5>All fields are required</h5>
    <fieldset>
        <div class="col-sm-2">
            <label for="txtLastName">Last Name:</label>
            <asp:TextBox ID="txtLastName" runat="server" required MaxLength="50" />
        </div>
        <div class="col-sm-2">
            <label for="txtFirstMidName">First Name:</label>
            <asp:TextBox ID="txtFirstMidName" runat="server" required MaxLength="50" />
        </div>
        <div class="col-sm-2">
            <label for="txtEnrollmentDate">Enrollment Date</label>
            <asp:TextBox ID="txtEnrollmentDate" runat="server" required TextMode="Date" />
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Must Be A Date"
                ControlToValidate="txtEnrollmentDate" CssClass="alert alert-danger" Type="Date" MinimumValue="01/01/2000" MaximumValue="12/31/2999"></asp:RangeValidator>
        </div>
    </fieldset>
    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
    <asp:Panel ID="pnlCourses" runat="server" Visible="false">
        <div>
            <h2>Courses</h2>
            <asp:GridView ID="grdCourses" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false"
                DataKeyNames="EnrollmentID" OnRowDeleting="grdCourses_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Department" />
                    <asp:BoundField DataField="Title" HeaderText="Course" />
                    <asp:BoundField DataField="Grade" HeaderText="Grade" />
                    <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
</asp:Content>
