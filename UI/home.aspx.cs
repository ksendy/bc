using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace UI
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ambil message, tampilkan, kosongkan msg
            if (Session["msg"] != null)
            { Response.Write("<script>alert('" + Session["msg"] + "')</script>"); Session["msg"] = null; }
            //inisiasi pagination
            int perPage = 9;
            int page = Convert.ToInt32(Request.QueryString["page"]);
            page =  (Request.QueryString["page"] == null) ? 0 : (page-1) * perPage;
            List<MsProgramBAL> p = new List<MsProgramBAL>();
            ProgramBAL bal = new ProgramBAL(); int counter = 1;
            p = bal.GetProgramList("home");
            string texthtml = "<div class='grids_of_3'>";
            foreach (MsProgramBAL b in p.Skip(page).Take(perPage))
            {
                texthtml += "<div class='grid1_of_3'>";
                texthtml += "<a href='/Program/details.aspx?id=" + b.idProgram + "'>";
                texthtml += "<div class='gambar'><img style='margin:auto;' src='/images/ProgramImg/" + b.img + "' alt=''/></div>";
                texthtml += "<h3>" + b.title + "</h3>";
                int g = b.descr.Length;
                if (g >= 30)
                { g = 30; }
                if (Session["username"] != null || Session["lvl"] != null)
                {
                    texthtml += "<div class='price'><h4>" + b.descr.Substring(0, g) + " ... More >></h4></div>";
                }
                texthtml += "<div class='price'><h4>" + b.date.Substring(0, 10) + "</h4></div>";
                texthtml += "<div class='price'><h4>Rating : " + b.rating + "</h4></div>";
                texthtml += "<div class='price'><h4>" + b.size + "MB<span>BUY</span></h4></div>";
                texthtml += "<span class='b_btm'></span></a></div>";
                if (counter % 3 == 0 && counter != 0)
                { texthtml += "</div><div class='clear'></div><div class='grids_of_3'>"; }
                counter++;
            }
            texthtml += "</div><div class='clear'></div>";
            pr.InnerHtml = texthtml;

            //pagination

            int i = 1;
            int k = (p.Count % perPage) != 0 ? 0 : 1;
            k = p.Count == perPage ? 0 : 1;
            int j = (p.Count/perPage)+k;           
            do
            {
                pagination.InnerHtml += " &nbsp; <a href='/home.aspx?page=" + i + "'>" + i + "</a> &nbsp; ";
                i++;
            } while (i <= j);
        }
    }
}