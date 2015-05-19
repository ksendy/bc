using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace UI
{
    public partial class DeleteProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null || Convert.ToInt32(Session["lvl"]) != 3 )
            {
                Session["msg"] = "Hacking Attempt!";
                Response.Redirect("/home.aspx");
            }
            string id = Request.QueryString["id"];
            ProgramBAL pro = new ProgramBAL();

            if(!pro.CekProgram(id))
            {
                Session["msg"] = "Hacking Attempt!";
                Response.Redirect("/home.aspx");
            }
            Session["msg"] = (pro.DeleteProgram(id)) ? "Delete Success!" : "Delete Failed";
            Response.Redirect("/Program/AllProgram.aspx");

        }
    }
}