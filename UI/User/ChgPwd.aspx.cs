using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace UI
{
    public partial class ChgPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["lvl"] == null)
            { Session["msg"] = "Please Login"; Response.Redirect("/home.aspx"); }
            if (Session["msg"] != null)
            { Response.Write("<script>alert('" + Session["msg"] + "')</sxript>"); Session["msg"] = null; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = (Convert.ToString(Session["username"]));
            string newPass = newP.Value;
            string rePass = reP.Value;
            string oldPass = oldP.Value;
            UserBAL bal = new UserBAL();
            MsUserBAL ubal = new MsUserBAL();
            ubal = bal.getUserByUsername(username);
            if (oldPass == ubal.pwd)
            {
                if (newPass == rePass)
                {
                    ubal.pwd = newPass;
                    if (bal.UpdateUser(ubal))
                    { Session["msg"] = "Update Success!"; Response.Redirect("/home.aspx"); }
                    else
                    {  Session["msg"] = "Update Failed!"; Response.Redirect("/home.aspx"); }
                }
                else
                { Session["msg"] = "Password Not Match"; Label1.Visible = true; }
            }
            else
            { Session["msg"] = "Wrong Password"; Label2.Visible = true; }
        }
    }
}