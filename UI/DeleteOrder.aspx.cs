using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class DeleteOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (Session["order"] != null && id != null)
            {
                List<string> order = new List<string>();
                order = (List<string>)Session["order"];
                Session["msg"] = (order.Remove(id)) ? "Delete Order Berhasil!" : "Delete Order Gagal!";
                Response.Redirect("CekOut.aspx");
            }
            else
            { Session["msg"] = "Hacking Attempt!"; Response.Redirect("/home.aspx"); }
        }
    }
}