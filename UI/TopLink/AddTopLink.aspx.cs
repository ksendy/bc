using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace UI
{
    public partial class AddTopLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            int id = Convert.ToInt32(Request.QueryString["id"]);

            if (type == "u")
            {
                if (!IsPostBack)
                {
                    TopLinksDAL dal = new TopLinksDAL();
                    TopLink tl = new TopLink();
                    tl = dal.GetSingleLink(id);
                    TextBox1.Text = tl.name;
                    TextBox2.Text = tl.links;
                    stats.SelectedIndex = tl.status;
                    //TextBox3.Text = Convert.ToString(tl.status);
                    TextBox4.Text = Convert.ToString(tl.level);
                }
            }
            else if (type == "i")
            {
            }
            else
            {
                Response.Redirect("/home.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            int id = Convert.ToInt32(Request.QueryString["id"]);

            if (type == "u")
            {
                TopLinksDAL td = new TopLinksDAL();
                TopLink tl = new TopLink();
                tl = td.GetSingleLink(id);
                tl.name = TextBox1.Text;
                tl.links = TextBox2.Text;
                tl.status = Convert.ToInt32(stats.Value);
                //tl.status = Convert.ToInt32(TextBox3.Text);
                tl.level = Convert.ToInt32(TextBox4.Text);
                if (td.UpdateLink(tl))
                {
                    Response.Write("<script>alert('berhasil')</script>");
                    Response.Redirect("TopLinks.aspx");
                }
                else
                {
                    Response.Write("<script>alert('gagal')</script>");
                }

            }
            if (type == "i")
            {
                TopLink tl = new TopLink
                {
                    name = TextBox1.Text,
                    links = TextBox2.Text,
                    status = Convert.ToInt32(stats.Value),
                    level = Convert.ToInt32(TextBox4.Text)
                };
                TopLinksDAL dal = new TopLinksDAL();
                if (dal.AddLink(tl))
                {
                    Response.Write("<script>confirm('berhasil')</script>");
                    Response.Redirect("TopLinks.aspx");
                }
                else
                {
                    Response.Write("<script>alert('gagal')</script>");
                }

            }

        }

    }
}