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

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //use EF to connect to SQL server
            using (gc200261581Entities1 db = new gc200261581Entities1())
            {
                //use student model to save new student 
                Student s = new Student();

                s.LastName = txtLastName.Text;
                s.FirstMidName = txtFirstMidName.Text;
                s.EnrollmentDate = Convert.ToDateTime(txtEnrollmentDate.Text);

                db.Students.Add(s);
                db.SaveChanges();
            }

            Response.Redirect("students.aspx");
            //redirect to the updated students page
        }
    }
}