using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BAL;

namespace UI
{
    public partial class ProgramFiles : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ambil top link start
            TopLinksDAL d = new TopLinksDAL();
            List<TopLink> tl = new List<TopLink>();
            int lvl = Convert.ToInt32(Session["lvl"]);
            if (Session["username"] == null || Session["lvl"] == null)
            {
                tl = d.GetLinkNoLogin();
                Ul1.InnerHtml = "<li><h3>Please Login To See Online User</h3></li>";
                cart.InnerHtml = "<li><h3>Please Login To Shop</h3></li>";
            }
            else
            {
                tl = d.GetLink(lvl);
                Ul1.InnerHtml = "<li><h3>user Login : " + Convert.ToString(Application["shopper"]) + "</h3></li>";
                I1.InnerHtml = Convert.ToString(Application["shopper"]);
                if (Session["order"] == null)
                {
                    cart.InnerHtml = "<li><h3>shopping cart empty</h3></li>"+"<li><p>To Shop, Click Program at the Menu</p></li>";
                    total.InnerText = "0MB";
                }
                else
                {
                    cart.InnerHtml = "<li><h3>Your Cart</h3></li>";
                    List<string> order = new List<string>();
                    order = (List<string>)Session["order"];
                    int totalSize = 0;
                    foreach (string o in order)
                    {
                        ProgramBAL bal = new ProgramBAL();
                        MsProgramBAL probal = new MsProgramBAL();
                        probal = bal.getProgramById(o);
                        cart.InnerHtml += "<li><p>" + probal.title + " " + probal.size + " MB" + "</p></li>";
                        totalSize += probal.size;
                    }
                    cart.InnerHtml += "<li><h3>Total : " + totalSize + " MB</h3></li>";
                    total.InnerText = totalSize + "MB";
                    cart.InnerHtml += "<a class='tombol' href='/CekOut.aspx' >Cek Out</a>";
                }
            }
            menuAtas.InnerHtml = "<li></li>";
            menuMobile.InnerHtml = "<li></li>";
            int panjang = tl.Count; int count = 1;
            foreach (TopLink a in tl)
            {
                menuAtas.InnerHtml += "<li><a href='" + a.links + "'>" + a.name + "</a></li>";
                if (count != panjang) { menuAtas.InnerHtml += "|"; }
                menuMobile.InnerHtml += "<li class='nav-item'><a href='" + a.links + "'>" + a.name + "</a></li>";
                count++;
            } //ambil top link end               
        }
    }
}