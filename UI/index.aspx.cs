using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace UI
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TopLinksDAL d = new TopLinksDAL();
            List<TopLink> tl = new List<TopLink>();
            tl = d.GetLink(1);

            menuAtas.InnerHtml = "";
            menuMobile.InnerHtml = "";

            foreach (TopLink a in tl)
            {
                menuAtas.InnerHtml += "<li><a href='" + a.links + "'>"+a.name+"</a></li> |";
                menuMobile.InnerHtml += "<li class='nav-item'><a href='" + a.links + "'>" + a.name + "</a></li>";
            }

        }
    }
}