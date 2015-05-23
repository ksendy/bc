using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace UI
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["lvl"] == null)
            { Session["msg"] = "No Access, Please Login!"; Response.Redirect("/home.aspx"); }
            if (Request.QueryString["search"] == null )
            { Session["msg"] = "Hacking Attempt"; Response.Redirect("/home.aspx"); }
            else if (Request.QueryString["search"] == "")
            { Session["msg"] = "Empty Search"; Response.Redirect("/home.aspx"); }

            //inisiasi pagination
            int perPage = 9;
            int page = Convert.ToInt32(Request.QueryString["page"]);
            page = (Request.QueryString["page"] == null || Request.QueryString["page"] == "1") ? 0 : page * perPage;

            string search = Request.QueryString["search"];
            
            ProgramBAL bal = new ProgramBAL();
            page = (Request.QueryString["page"] == null || Request.QueryString["page"] == "1") ? 0 : page * perPage;
            List<MsProgramBAL> p = new List<MsProgramBAL>();
            int counter = 1;
            p = bal.SearchProgram(search);
            jdl.InnerText = "SEARCH : " + search + " -- " + p.Count + " DATA(S) FOUND";
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
            int j = (p.Count / perPage) + k;
            do
            {
                pagination.InnerHtml += " &nbsp; <a href='/home.aspx?page=" + i + "'>" + i + "</a> &nbsp; ";
                i++;
            } while (i <= j);
        }
    }
}