using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace UI
{
    public partial class TopLinks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //pagar khusus admin dan login
            if (Session["lvl"] == null)
            { Session["msg"] = "Hacking Attempt!"; Response.Redirect("/home.aspx"); }
            else if (Convert.ToInt32(Session["lvl"]) != 3)
            { Session["msg"] = "No Access!"; Response.Redirect("/home.aspx"); }

            TopLinksDAL top = new TopLinksDAL();
            List<TopLink> tl = new List<TopLink>();
            tl = top.GetLinkList();
            int counter = 1;
            string contents = "<div class='grids_of_4'>";
            foreach (TopLink t in tl)
            {
                contents += "<div class='grid1_of_4' style='  border:1px solid rgb(223, 223, 223);'>";
                contents += "<h4 style='color:#777777;'>" + t.name + "</h4>";
                contents += "<ul class='f_nav'>";                
                contents += "<li>Link : " + t.links + "</li>";
                if (t.status == 0)
                { contents += "<li>Status : Non Active </li>"; }
                else { contents += "<li>Status : Active </li>"; }
                contents += "<li>Level : " + t.level + "</li>";
                contents += "</ul>";
                contents += "<a class='tombol' href='/TopLink/AddTopLink.aspx?type=u&id=" + Convert.ToString(t.idLink) + "'>Update</a>";
                contents += "</div>";
                if (counter % 4 == 0 && counter != 0)
                {
                    contents += "</div><div class='clear'></div><div class='grids_of_4'>";
                }
                counter++;
            }
            contents += "</div>";
            isi.InnerHtml = contents;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTopLink.aspx?type=i");
        }
    }
}