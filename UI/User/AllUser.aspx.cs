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
            if (Session["msg"] != null)
            { Response.Write("<script>alert(" + Session["msg"].ToString() + ")</script>"); Session["msg"] = null; }

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
                string isi = "<div class='grids_of_44'>";
                foreach (MsUserBAL ub in lb)
                {
                    //cetak
                    isi += "<div class='grid1_of_44'>";
                    if (Convert.ToInt32(Session["lvl"]) == 3)
                    {
                        isi += "<div class='del'>";
                        isi += "<a onclick=\"return confirm(" + "\'Are You Sure?\'" + ")\" ";
                        isi += "href='/User/DeleteUser.aspx?id=" + ub.idCustomer + "'>";
                        isi += "<img src='/images/delete3.png' /></a>";
                        isi += "</div><div class='edit2'>";
                        isi += "<a href='/User/User.aspx?id=" + ub.idCustomer + "'>";
                        isi += "<img src='/images/edit2.png' /></a>";
                        isi += "</div>";
                    }
                    isi += "<a href='/User/User.aspx?id=" + ub.idCustomer + "'>";
                    isi += "<img class='GbrUsr' src='/images/usrImg/" + ub.img + "' alt=''/>";
                    isi += "<h4 class='judulUsr'>" + ub.nama + "</h4>";
                    isi += "<div class='price'>";
                    isi += "<h4 class='judulUsr'>" + ub.username + " <span>View</span></h4>";
                    isi += "</div><span class='b_btm'></span></a></div>";
                    counter++;
                    if (counter % 4 == 0 && counter != 0 && lb.Count() != counter)
                    { isi += "</div>" + "<div class='clear'></div>" + "<div class='grids_of_44'>"; }
                }
                isi += "</div>";
                isi += "<div class='clear'></div>";
                pro.InnerHtml = isi;
            }
            else
            { pro.InnerHtml = "<h2>Data Not Found</h2>"; }
        }
    }
}