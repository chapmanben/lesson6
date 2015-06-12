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
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if sav wasn't clicked & we have a student ID in the url.
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                getStudent();
            }
            
        }

        protected void getStudent() { 
        //populate the form with student information
            Int32 studentID = Convert.ToInt32(Request.QueryString["StudentID"]);

            using (DefaultConnection db = new DefaultConnection()){
                Student s = (from objs in db.Students
                                 where objs.StudentID == studentID
                                 select objs).FirstOrDefault();
                if (s != null)
                {
                    txtFirstMidName.Text = s.FirstMidName;
                    txtLastName.Text = s.LastName;
                    txtEnrollmentDate.Text = s.EnrollmentDate.ToString("mm-dd-yyyy");
                }
                //else
                //{
                //    Response.Redirect("students.aspx");
                //}


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //use EF to connect to SQL server
            using (DefaultConnection db = new DefaultConnection())
            {
                
                Student s = new Student();
                Int32 StudentID = 0;
                //check the query string for an ID. To determine add or update
                if (Request.QueryString["StudentID"] != null)
                {
                    //get id from url
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    //get the current student from EF
                    s = (from objs in db.Students
                         where objs.StudentID == StudentID
                         select objs).FirstOrDefault();
                }

                //use student model to save new student 
                s.LastName = txtLastName.Text;
                s.FirstMidName = txtFirstMidName.Text;
                s.EnrollmentDate = Convert.ToDateTime(txtEnrollmentDate.Text);

                if(StudentID == 0){ 
                db.Students.Add(s);
                }
                db.SaveChanges();
            }

            Response.Redirect("students.aspx");
            //redirect to the updated students page
        }
    }
}