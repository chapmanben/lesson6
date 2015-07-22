using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//referencing EF Models
using comp2007_wed1_Lesson5.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;


namespace comp2007_wed1_Lesson5
{
    public partial class course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                using (DefaultConnection db = new DefaultConnection())
                {
                    var Departments = (from d in db.Departments1
                                       orderby d.Name
                                       select new { d.DepartmentID, d.Name }).ToList();
                    ddlDepartments.DataValueField = "DepartmentID";
                    ddlDepartments.DataTextField = "Name";
                    ddlDepartments.DataSource = Departments;
                    ddlDepartments.DataBind();

                    if (!IsPostBack && (Request.QueryString.Count > 0))
                    {
                        pnlStudents.Visible = false;
                        getStudents();
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }
        }

        protected void getStudents()
        {
            Int32 courseID = Convert.ToInt32(Request.QueryString["CourseID"]);
            try
            {
                //connect to EF
                using (DefaultConnection db = new DefaultConnection())
                {
                    //query db
                    Course c = (from objs in db.Courses
                                where objs.CourseID == courseID
                                select objs).FirstOrDefault();

                    if (c != null)
                    {
                        txtCourseName.Text = c.Title;
                        ddlDepartments.SelectedValue = c.DepartmentID.ToString();
                    }

                    var objE = (from en in db.Enrollments
                                join s in db.Students on en.StudentID equals s.StudentID
                                join co in db.Courses on en.CourseID equals co.CourseID
                                where en.CourseID == courseID
                                select new { s.StudentID, s.LastName, s.FirstMidName });

                    grdStudents.DataSource = objE.ToList();
                    grdStudents.DataBind();
                    pnlStudents.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }
        }


        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);

            try
            {
                using (DefaultConnection db = new DefaultConnection())
                {
                    Enrollment objE = (from en in db.Enrollments
                                       where en.StudentID == StudentID
                                       select en).FirstOrDefault();

                    db.Enrollments.Remove(objE);
                    db.SaveChanges();

                    getStudents();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //use EF to connect to SQL server
                using (DefaultConnection db = new DefaultConnection())
                {

                    Course c = new Course();
                    Int32 courseID = 0;
                    //check the query string for an ID. To determine add or update
                    if (Request.QueryString["CourseID"] != null)
                    {
                        //get id from url
                        courseID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                        //get the current student from EF
                        c = (from objs in db.Courses
                             where objs.CourseID == courseID
                             select objs).FirstOrDefault();
                    }

                    //use student model to save new student 
                    c.Title = txtCourseName.Text;
                    c.DepartmentID = Convert.ToInt32(ddlDepartments.SelectedValue);

                    if (courseID == 0)
                    {
                        db.Courses.Add(c);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }

            Response.Redirect("courses.aspx");
            //redirect to the updated students page
        }
    }
}