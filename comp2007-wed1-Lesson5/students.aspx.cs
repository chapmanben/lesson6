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
            using (gc200261581Entities1 db = new gc200261581Entities1())
            {
                //query db
                var Students = from s in db.Students
                               select s;

                grdStudents.DataSource = Students.ToList();
                grdStudents.DataBind();
            }
        }
    }
}