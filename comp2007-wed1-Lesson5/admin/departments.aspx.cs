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
    public partial class departments : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["sortColumn"] = "DepartmentID";
                Session["sortDirection"] = "ASC";
                getDepartments();
                
            }
        }

        protected void getDepartments()
        {
            try
            {
                //connect to EF
                using (DefaultConnection db = new DefaultConnection())
                {
                    //query db
                    var Departments = from d in db.Departments1
                                      select new { d.DepartmentID, d.Name, d.Budget };

                    string sortString = Session["sortColumn"].ToString() + " " + Session["sortDirection"].ToString();
                    grdDepartments.DataSource = Departments.AsQueryable().OrderBy(sortString).ToList();

                    grdDepartments.DataBind();

                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }
        }//end of getDepartments()
        
        protected void grdDepartments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked.
            Int32 selectedRow = e.RowIndex;

            //get the selected StudentID using the grids Data Key collection
            Int32 departmentID = Convert.ToInt32(grdDepartments.DataKeys[selectedRow].Values["DepartmentID"]);

            try
            {
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
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }

        }

        protected void grdDepartments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDepartments.PageIndex = e.NewPageIndex;
            getDepartments();
        }

        protected void grdDepartments_Sorting(object sender, GridViewSortEventArgs e)
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
            getDepartments();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set new page size
            grdDepartments.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            getDepartments();
        }


        protected void grdDepartments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdDepartments.Columns.Count - 1; i++)
                    {
                        if (grdDepartments.Columns[i].SortExpression == Session["sortColumn"].ToString())
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
        } //end of grdDepartments_RowDeleting

        
        
    }
}