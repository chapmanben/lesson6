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
    public partial class courses : System.Web.UI.Page
    {

            protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["sortColumn"] = "CourseID";
                Session["sortDirection"] = "ASC";
                getCourses();
                
            }
        }

        protected void getCourses()
        {
            //connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                //query db
                var Courses = from c in db.Courses
                              select new { c.CourseID, c.Title, c.Credits, c.Department.Name };

                string sortString = Session["sortColumn"].ToString()+ " " + Session["sortDirection"].ToString();
                grdCourses.DataSource = Courses.AsQueryable().OrderBy(sortString).ToList();
                grdCourses.DataBind();
                
            }
        }//end of getDepartments()
        
        protected void grdCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked.
            Int32 selectedRow = e.RowIndex;

            //get the selected StudentID using the grids Data Key collection
            Int32 courseID = Convert.ToInt32(grdCourses.DataKeys[selectedRow].Values["CourseID"]);

            //use EF to remove the selected student from the DB
            using (DefaultConnection db = new DefaultConnection())
            {
                Course c = (from objs in db.Courses
                             where objs.CourseID == courseID
                             select objs).FirstOrDefault();

                //do the delete
                db.Courses.Remove(c);
                db.SaveChanges();
            }
            //refresh the grid
            getCourses();

        }//end of grdDepartments_RowDeleting

        protected void grdCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new page #
            grdCourses.PageIndex = e.NewPageIndex;
            getCourses();

        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set new page size
            grdCourses.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            getCourses();
        }

        protected void grdCourses_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["sortColumn"] = e.SortExpression;

            if (Session["sortDirection"].ToString() == "ASC")
            {
                Session["sortDirection"] = "DESC";
            }
            else
            {
                Session["sortDirection"] = "ASC";
            }
            getCourses();

        }

        protected void grdCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack) 
            { 
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();
                
                    for (int i = 0; i <= grdCourses.Columns.Count -1; i++) 
                    {
                        if (grdCourses.Columns[i].SortExpression == Session["sortColumn"].ToString())
                        {
                            if (Session["sortDirection"].ToString() == "DESC")
                            {
                                SortImage.ImageUrl = "images/desc.jpg";
                                SortImage.AlternateText = "Sort Descending";
                            }
                            else
                            {
                                SortImage.ImageUrl = "images/asc.jpg";
                                SortImage.AlternateText = "Sort Ascending";
                            }
                            e.Row.Cells[i].Controls.Add(SortImage); 
                        }
                    }
                }
            }
        }   
    }     
}