using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//referencing EF Models
using comp2007_wed1_Lesson5.Models;
using System.Web.ModelBinding;

namespace comp2007_wed1_Lesson5
{
    public partial class department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if sav wasn't clicked & we have a student ID in the url.
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                pnlCourses.Visible = false;
                getDepartments();
            }
        }

        protected void getDepartments()
        {
             Int32 departmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
            
            //connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                //query db
                Departments d = (from objs in db.Departments1
                                 where objs.DepartmentID == departmentID
                                 select objs).FirstOrDefault();

                if (d != null) {
                    txtDepartmentName.Text = d.Name;
                    txtBudget.Text = d.Budget.ToString();
                }

                var objE = (from en in db.Courses
                            join dept in db.Departments1 on en.DepartmentID equals dept.DepartmentID
                            where en.DepartmentID == departmentID
                            select new { en.CourseID, en.Title });

                grdCourses.DataSource = objE.ToList();
                grdCourses.DataBind();
                pnlCourses.Visible = true;
            }
        }//end of getDepartments()

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //use EF to connect to SQL server
            using (DefaultConnection db = new DefaultConnection())
            {

                Departments d = new Departments();
                Int32 departmentID = 0;
                //check the query string for an ID. To determine add or update
                if (Request.QueryString["DepartmentID"] != null)
                {
                    //get id from url
                    departmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    //get the current student from EF
                    d = (from objs in db.Departments1
                         where objs.DepartmentID == departmentID
                         select objs).FirstOrDefault();
                }

                //use student model to save new student 
                d.Name = txtDepartmentName.Text;
                d.Budget = Convert.ToDecimal(txtBudget.Text);
                
                if (departmentID == 0)
                {
                    db.Departments1.Add(d);
                }
                db.SaveChanges();
            }

            Response.Redirect("departments.aspx");
            //redirect to the updated students page
        }

        protected void grdCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 CourseID = Convert.ToInt32(grdCourses.DataKeys[e.RowIndex].Values["CourseID"]);

            using (DefaultConnection db = new DefaultConnection())
            {
                Course objE = (from en in db.Courses
                                   where en.CourseID == CourseID
                                   select en).FirstOrDefault();
                db.Courses.Remove(objE);
                db.SaveChanges();

                getDepartments();
            }
        }
    }
}