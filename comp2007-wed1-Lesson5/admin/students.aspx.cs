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
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["sortColumn"] = "StudentID";
                Session["sortDirection"] = "ASC";
                getStudents();
            }
        }

        protected void getStudents()
        {
            try
            {
                //connect to EF
                using (DefaultConnection db = new DefaultConnection())
                {
                    //query db
                    var Students = from s in db.Students
                                   select new { s.StudentID, s.LastName, s.FirstMidName, s.EnrollmentDate };

                    string sortString = Session["sortColumn"].ToString() + " " + Session["sortDirection"].ToString();
                    grdStudents.DataSource = Students.AsQueryable().OrderBy(sortString).ToList();
                    grdStudents.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked.
            Int32 selectedRow = e.RowIndex;

            //get the selected StudentID using the grids Data Key collection
            Int32 studentID = Convert.ToInt32(grdStudents.DataKeys[selectedRow].Values["StudentID"]);

            //use EF to remove the selected student from the DB
            try
            {
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
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }

        }


        protected void grdStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStudents.PageSize = e.NewPageIndex;
            getStudents();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set new page size
            grdStudents.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            getStudents();
        }
        

        protected void grdStudents_Sorting(object sender, GridViewSortEventArgs e)
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
            getStudents();
        }

        protected void grdStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdStudents.Columns.Count - 1; i++)
                    {
                        if (grdStudents.Columns[i].SortExpression == Session["sortColumn"].ToString())
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