using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace UI
{
    public partial class AllUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //pagar khusus admin dan login
            if (Session["lvl"] == null)
            { Session["msg"] = "Hacking Attempt!"; Response.Redirect("/home.aspx"); }
            else if (Convert.ToInt32(Session["lvl"]) != 3)
            { Session["msg"] = "No Access!"; Response.Redirect("/home.aspx"); }

            UserBAL bal = new UserBAL();

            List<MsUserBAL> lb = new List<MsUserBAL>();
            lb = bal.GetUserList();
            int counter = 0;
            if (lb != null)
            {
                string isi = "<div class='grids_of_4'>";
                foreach (MsUserBAL ub in lb)
                {
                    //cetak
                    isi += "<div class='grid1_of_4'>";
                    isi += "<a href='details.aspx?id=" + ub.idCustomer + "'>";
                    isi += "<img src='/images/usrImg/" + ub.img + "' alt=''/>";
                    isi += "<h4 style='color:#777777;'>" + ub.nama + "</h4>";
                    isi += "<div class='price'>";
                    isi += "<h4 style='color:#777777;'>" + ub.username + " <span>View</span></h4>";
                    isi += "</div>";
                    isi += "<span class='b_btm'></span><div class='clear'></div>";
                    isi += "</a>";
                    isi += "</div>";
                    counter++;
                    if (counter % 3 == 0 && counter != 0 && lb.Count() != counter)
                    {
                        isi += "</div>" + "<div class='clear'></div>" + "<div class='grids_of_3'>";
                    }
                }

                isi += "</div>";
                isi += "<div class='clear'></div>";

                pro.InnerHtml = isi;
            }
            else
            {
                pro.InnerHtml = "<h2>Data Not Found</h2>";
            }
        }
    }
}