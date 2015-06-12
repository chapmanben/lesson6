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
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getStudents();
            }
        }

        protected void getStudents()
        {
            //connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                //query db
                var Students = from s in db.Students
                               select s;

                grdStudents.DataSource = Students.ToList();
                grdStudents.DataBind();
            }
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked.
            Int32 selectedRow = e.RowIndex;

            //get the selected StudentID using the grids Data Key collection
            Int32 studentID = Convert.ToInt32(grdStudents.DataKeys[selectedRow].Values["StudentID"]);

            //use EF to remove the selected student from the DB
            using (DefaultConnection db = new DefaultConnection())
            {
                Student s = (from objs in db.Students
                             where objs.StudentID == studentID
                             select objs).FirstOrDefault();

                //do the delete
                db.Students.Remove(s);
                db.SaveChanges();

            }
                //refresh the grid
                getStudents();

        }

        

    }
}