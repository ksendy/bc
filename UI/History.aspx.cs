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
            page = (Request.QueryString["page"] == null) ? 0 : (page-1) * perPage;

            if (!IsPostBack)
            {
                string sort = Request.QueryString["s"];
                int zahl = Convert.ToInt32(Request.QueryString["z"]);
                PenjualanBAL pbal = new PenjualanBAL();
                List<MsPenjualanBAL> lb = new List<MsPenjualanBAL>();
                DropDownList1.DataSource = pbal.GetListMonth(); DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "-select month-"); DropDownList1.SelectedIndex = 0;
                DropDownList2.DataSource = pbal.GetListYear(); DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, "-select year-"); DropDownList2.SelectedIndex = 0;

                lb = (sort == null) ? pbal.GetPenjualanList() : pbal.GetListByDate(sort, zahl);
                if (lb == null)
                { Response.Write("<script>alert('Data Not Found')</script>"); }
                tbJual.InnerHtml = null;
                tbJual.InnerHtml += "<table border='1' style=''>";
                tbJual.InnerHtml += "<tr class='judul'><td>Tanggal</td><td>Nama</td><td>Judul</td><td>Size</td></tr>";
                foreach (MsPenjualanBAL mp in lb.Skip(page).Take(perPage))
                {
                    string[] result = mp.detail.Split(new char[] { ';' });
                    UserBAL ub = new UserBAL();
                    int counter = 0; int total = 0;
                    foreach (string s in result)
                    {
                        if (s == null || s == "")
                        { break; }
                        ProgramBAL pb = new ProgramBAL();
                        MsProgramBAL probal = new MsProgramBAL();
                        probal = pb.getProgramById(s);
                        tbJual.InnerHtml += "<tr><td>";
                        tbJual.InnerHtml += (counter == 0) ? mp.tglTrans.Substring(0, 10) : "";
                        tbJual.InnerHtml += "</td><td>";
                        tbJual.InnerHtml += (counter == 0) ? ub.GetUserById(mp.idCustomer).nama : "";
                        tbJual.InnerHtml += "</td><td>" + probal.title + "</td>";
                        tbJual.InnerHtml += "<td>" + probal.size + " MB</td></tr>";
                        counter++; total += probal.size;
                    }
                    tbJual.InnerHtml += "<tr><td></td><td></td><td><b>Total</b></td><td>" + total + " MB</td></tr>";
                    tbJual.InnerHtml += "<tr><td colspan='4'> &nbsp; </td></tr>";
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Server.Transfer("/history.aspx?s=mo&z=" + DropDownList1.SelectedValue.ToString());
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Server.Transfer("/history.aspx?s=ye&z=" + DropDownList2.SelectedValue.ToString());
        }
    }
}