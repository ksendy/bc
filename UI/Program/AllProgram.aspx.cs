using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace UI
{
    public partial class AllProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["lvl"] == null)
            { Session["msg"] = "No Access, Please Login!"; Response.Redirect("/home.aspx"); }
            if (Session["msg"] != null)
            { Response.Write("<script>alert('" + Session["msg"] + "')</script>"); Session["msg"] = null; }
            if (Convert.ToInt32(Session["lvl"]) == 3)
            { tec.InnerHtml += "<a href='/Program/AddProgram.aspx'><div class='tech'>ADD PROGRAM</div></a>"; }

            //inisiasi pagination
            int perPage = 9;
            int page = Convert.ToInt32(Request.QueryString["page"]);
            page = (Request.QueryString["page"] == null || Request.QueryString["page"] == "1") ? 0 : page * perPage;


            ProgramBAL bal = new ProgramBAL();
            List<MsProgramBAL> lb = new List<MsProgramBAL>();
            List<string> technologies = new List<string>();
            string tt = Request.QueryString["t"];
            //ambil tech
            technologies = bal.GetTechList();
            foreach (string t in technologies)
            { tec.InnerHtml += "<a href='/Program/AllProgram.aspx?t=" + t + "'><div class='tech'>" + t + "</div></a>"; }
            lb = (tt == null) ? bal.GetProgramList() : bal.GetProgramListByTech(tt);
            int counter = 0;
            if (lb != null)
            {
                string isi = "<div class='grids_of_3'>";
                foreach (MsProgramBAL probal in lb)
                {
                    //cetak
                    isi += "<div class='grid1_of_3'>";
                    //display delete kalau admin
                    if (Convert.ToInt32(Session["lvl"]) == 3)
                    {
                        isi += "<div class='del'><a href='/Program/DeleteProgram.aspx?id=" + probal.idProgram + "'>";
                        isi += "<img src='/images/delete.png'/></a></div>";
                    }
                    isi += "<a href='details.aspx?id=" + probal.idProgram + "'>";
                    isi += "<div class='gambar'><img src='/images/ProgramImg/" + probal.img + "' alt=''/></div>";
                    isi += "<h3>" + probal.title + "</h3>";
                    isi += "<div class='price'>";
                    isi += "<h4>" + probal.size + "MB <span>Buy</span></h4>";
                    isi += "</div>";
                    isi += "<span class='b_btm'></span>";
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
            { pro.InnerHtml = "<h2>Data Not Found</h2>"; }
            int i = 1;
            int k = (lb.Count % perPage) != 0 ? 0 : 1;
            k = lb.Count == perPage ? 0 : 1;
            int j = (lb.Count / perPage) + k;
            string path = (Request.QueryString["t"] == null) ? "/Program/Allprogram.aspx?" : "/Program/Allprogram.aspx?t=" + tt + "&";
            do
            {
                pagination.InnerHtml += " &nbsp; <a href='" + path + "page=" + i + "'>" + i + "</a> &nbsp; ";
                i++;
            } while (i <= j);
        }
    }
}