using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace comp2007_wed1_Lesson5
{
    public partial class site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated) { 
            plhPublic.Visible = false;
            plhPrivate.Visible = true;
        } else {
            plhPublic.Visible = true;
            plhPrivate.Visible = false;
        }
        }
    }
}