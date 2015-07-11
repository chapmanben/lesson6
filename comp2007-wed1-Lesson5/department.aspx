<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="department.aspx.cs" Inherits="comp2007_wed1_Lesson5.department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Department Details</h1>
    <h5>All fields are required</h5>
    <fieldset>
        <div class="col-sm-2">
            <label for="txtDepartmentName">Department:</label>
            <asp:TextBox ID="txtDepartmentName" runat="server" required MaxLength="50" />
        </div>
        <div class="col-sm-2">
            <label for="txtBudget">Budget:</label>
            <asp:TextBox ID="txtBudget" runat="server" required />
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtBudget" Type="Currency" MinimumValue="0" MaximumValue="10000000"></asp:RangeValidator>
        </div>

    </fieldset>
    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>

    <asp:Panel ID="pnlCourses" runat="server" Visible="false">
        <div>
            <h2>Courses</h2>
            <asp:GridView ID="grdCourses" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false"
                DataKeyNames="CourseID" OnRowDeleting="grdCourses_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Course" />
                    <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
</asp:Content>
