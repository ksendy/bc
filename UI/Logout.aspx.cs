using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null && Session["lvl"] != null)
            {
                Application.Lock();              
                int shopper = Convert.ToInt32(Application["shopper"]) - 1;
                Application["shopper"] = shopper.ToString();
                Application.UnLock();
            }
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Home.aspx");
            
            
        }
    }
}