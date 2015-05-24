using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace UI
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //pagar khusus admin dan login
            if (Session["lvl"] == null)
            { Session["msg"] = "Hacking Attempt!"; Response.Redirect("/home.aspx"); }
            else if (Convert.ToInt32(Session["lvl"]) != 3)
            { Session["msg"] = "No Access!"; Response.Redirect("/home.aspx"); }
            //pagination inisiasi
            int perPage = 9;
            int page = Convert.ToInt32(Request.QueryString["page"]);
            page = (Request.QueryString["page"] == null || Request.QueryString["page"] == "1") ? 0 : page * perPage;
                               
            PenjualanBAL pbal = new PenjualanBAL();
            List<MsPenjualanBAL> lb = new List<MsPenjualanBAL>();
            lb = pbal.GetPenjualanList();
            tbJual.InnerHtml += "<table border='1' style=''>";
            tbJual.InnerHtml += "<tr class='judul'><td>Tanggal</td><td>Nama</td><td>Judul</td><td>Size</td></tr>";
            foreach (MsPenjualanBAL mp in lb.Skip(page).Take(perPage))
            {
                string[] result = mp.detail.Split(new char[] { ';' });
                UserBAL ub = new UserBAL();

                foreach (string s in result)
                {
                    if (s == null || s == "")
                    { break; }
                    ProgramBAL pb = new ProgramBAL();
                    MsProgramBAL probal = new MsProgramBAL();
                    probal = pb.getProgramById(s);
                    tbJual.InnerHtml += "<tr>";
                    tbJual.InnerHtml += "<td>" + mp.tglTrans.Substring(0, 10) + "</td>";
                    tbJual.InnerHtml += "<td>" + ub.GetUserById(mp.idCustomer).nama + "</td>";
                    tbJual.InnerHtml += "<td>" + probal.title + "</td>";
                    tbJual.InnerHtml += "<td>" + probal.size + " MB</td>";
                    tbJual.InnerHtml += "</tr>";
                }
            }
            tbJual.InnerHtml += "</table>";
            //pagination
            int i = 1;
            int k = (pbal.GetPenjualanList().Count % perPage) != 0 ? 0 : 1;
            int j = (pbal.GetPenjualanList().Count / perPage) + k;
            do
            {
                pagination.InnerHtml += " &nbsp; <a href='/History.aspx?page=" + i + "'>" + i + "</a> &nbsp; ";
                i++;
            } while (i <= j);
        }
    }
}