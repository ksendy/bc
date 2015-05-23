using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace UI
{
    public partial class details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            //User Autentifikasi 
            if (id == null)
            { Response.Redirect("/Program/AllProgram.aspx"); }
            if (Session["username"] == null || Session["lvl"] == null)
            { Session["msg"] = "No Access, Please Login!"; Response.Redirect("/home.aspx"); }

            //ambil keterangan program
            ProgramBAL probal = new ProgramBAL();
            MsProgramBAL b = new MsProgramBAL();

            if (!probal.CekProgram(id))
            { Session["msg"] = "Hacking Attempt!"; Response.Redirect("/Program/AllProgram.aspx"); }
            b = probal.getProgramById(id);

            Session["produk"] = b;
            string title = b.title;
            Label1.Text = "<h3>" + title + "</h3>";
            keterangan.InnerText = b.descr;
            ukuran.InnerText = b.size + " MB";
            gambar.Src = "/images/ProgramImg/" + b.img;
            gambar.Alt = title;
            OS.InnerHtml += b.os;
            License.InnerHtml += b.license;
            Tec.InnerHtml += b.technology;
            descr.InnerHtml += b.descr;
            rating.InnerHtml += b.rating;
            ra.InnerHtml = (b.rating.ToString().Length >= 4) ? b.rating.ToString().Substring(0, 4) : b.rating.ToString();

            //ambil comment

            CommentBAL com = new CommentBAL();
            List<MsCommentBAL> mc = new List<MsCommentBAL>();
            UserBAL ubal = new UserBAL();
            komentar.InnerHtml = "";
            mc = com.GetCommentsByProduct(id);
            string comment = "";
            if (mc != null)
            {
                foreach (MsCommentBAL cb in mc.Take(5))
                { comment += "<li><a href='#'>&quot;" + cb.Comment + "&quot;<br>" + ubal.GetUserById(cb.idCustomer).username + "</a></li>"; }
                komentar.InnerHtml += comment; ra.InnerHtml = comment;
            }
            else
            { komentar.InnerHtml += "<li><a href='#'>No Comment Yet</a></li>"; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            ProgramBAL probal = new ProgramBAL();
            MsProgramBAL b = new MsProgramBAL();
            b = probal.getProgramById(id);
            int tot = (Session["total"] == null) ? 0 : Convert.ToInt32(Session["total"]);
            tot += b.size;

            if (tot < 100)
            {
                List<string> order = new List<string>();
                if (Session["order"] != null)
                { order = (List<string>)Session["order"]; }
                order.Add(b.idProgram);
                Session["order"] = order;
                Session["msg"] = "Program Added to Cart";
                Session["total"] = tot;
            }
            else { Session["msg"] = "Full CD, Total size bigger than 100MB, Please Check Out"; }
            
            Response.Redirect("/Program/AllProgram.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ta.Value.Trim() == "" || ta.Value == null)
            { Response.Write("<script>alert('Empty Comment')</script>"); }
            else if (IsPostBack)
            {
                CommentBAL bal = new CommentBAL();
                UserBAL ub = new UserBAL();
                Pass p = new Pass();
                MsCommentBAL cb = new MsCommentBAL()
                {
                    idProgram = Request.QueryString["id"],
                    idCustomer = ub.getUserByUsername(Convert.ToString(Session["username"])).idCustomer,
                    Comment = ta.Value,
                    idComment = p.AddZero(p.AddZero(bal.GetNextId())),
                };
                if (bal.AddComment(cb))
                {
                    Response.Write("<script>alert('Comment Success')</script>");
                    Response.Redirect("/Program/details.aspx?id=" + Request.QueryString["id"]);
                }
                else { Response.Write("<script>alert('Comment Failed')</script>"); }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ProgramBAL bal = new ProgramBAL();
            string id = Request.QueryString["id"];
            MsProgramBAL probal = new MsProgramBAL();
            double rating = bal.getProgramById(id).rating;
            if (rate.SelectedIndex == 0 || Convert.ToInt32(rate.Value) < 1 || Convert.ToInt32(rate.Value) > 5)
            { Response.Write("<script>alert('Failed to Rate')</script>"); }
            else
            {
                if (bal.UpdateNewRating(id, Convert.ToInt32(rate.Value)))
                { Response.Write("<script>alert('Success to Rate')</script>"); }
                else { Response.Write("<script>alert('Failed to Update Rating')</script>"); }
            }
        }
    }
}