using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace UI
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            UserBAL ud = new UserBAL();
            if (!ud.CekUser(id) || Convert.ToInt32(Session["lvl"])!= 3)
            { Session["msg"] = "Hacking Attempt!"; Response.Redirect("/home.aspx"); }
            Session["msg"] = (ud.ChangeStatus(id)) ? "Delete User Success" : "Delete User Failed";
            string msg = Session["msg"].ToString();
            Response.Redirect("/User/AllUser.aspx");

        }
    }
}