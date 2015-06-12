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
    public partial class departments : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDepartments();
                
            }
        }

        protected void getDepartments()
        {
            //connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                //query db
                var Departments = from d in db.Departments1
                               select d;

                grdDepartments.DataSource = Departments.ToList();
                grdDepartments.DataBind();
                
            }
        }//end of getDepartments()
        
        protected void grdDepartments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked.
            Int32 selectedRow = e.RowIndex;

            //get the selected StudentID using the grids Data Key collection
            Int32 departmentID = Convert.ToInt32(grdDepartments.DataKeys[selectedRow].Values["DepartmentID"]);

            //use EF to remove the selected student from the DB
            using (DefaultConnection db = new DefaultConnection())
            {
                Departments d = (from objs in db.Departments1
                             where objs.DepartmentID == departmentID
                             select objs).FirstOrDefault();

                //do the delete
                db.Departments1.Remove(d);
                db.SaveChanges();
            }
            //refresh the grid
            getDepartments();

        } //end of grdDepartments_RowDeleting

        
        
    }
}