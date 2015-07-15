﻿<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="main_menu.aspx.cs" Inherits="comp2007_wed1_Lesson5.main_menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Main Menu</h1>

    <div class="well">
        <h3>Departments</h3>
        <ul class="list">
            <li class="list-group-item"><a href="department.aspx">Add Department</a></li>
            <li class="list-group-item"><a href="departments.aspx">List Departments</a></li>
        </ul>
    </div>
        <div class="well">
        <h3>Courses</h3>
        <ul class="list">
            <li class="list-group-item"><a href="course.aspx">Add Course</a></li>
            <li class="list-group-item"><a href="courses.aspx">List Courses</a></li>
        </ul>
    </div>
        <div class="well">
        <h3>Students</h3>
        <ul class="list">
            <li class="list-group-item"><a href="student.aspx">Add Student</a></li>
            <li class="list-group-item"><a href="students.aspx">List Students</a></li>
        </ul>
    </div>

</asp:Content>