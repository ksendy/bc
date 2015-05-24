using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace UI
{
    public partial class CekOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ambil message, tampilkan
            if (Session["msg"] != null)
            { Response.Write("<script>alert('" + Session["msg"] + "')</script>"); Session["msg"] = null; }
            
            if (Session["username"] == null || Session["lvl"] == null)
            { Session["msg"] = "No Access, Please Login!"; Response.Redirect("/home.aspx"); }
            
            if (Session["order"] != null)
            {
                List<string> order = new List<string>();
                order = (List<string>)Session["order"];
                int totalSize = 0; int counter = 1;
                cekout.InnerHtml += "<table><tr class='judul'><td>No.</td><td>Judul</td><td>Size</td><td>Delete</td></tr>";
                foreach (string o in order)
                {
                    ProgramBAL bal = new ProgramBAL();
                    MsProgramBAL probal = new MsProgramBAL();
                    probal = bal.getProgramById(o);
                    cekout.InnerHtml += "<tr>";
                    cekout.InnerHtml += "<td>" + counter + "</td>";
                    cekout.InnerHtml += "<td>" + probal.title + "</td>";
                    cekout.InnerHtml += "<td>" + probal.size + "</td>";
                    cekout.InnerHtml += "<td><a href='DeleteOrder.aspx?id=" + o + "'><img width='20px' height='20px' src='/images/file_delete.png' alt='Delete' /></a></td>";
                    cekout.InnerHtml += "</tr>";
                    totalSize += probal.size; counter++;
                }
                cekout.InnerHtml += "</table>";
                cekout.InnerHtml += "<h1> Total : " + totalSize + "</h1>";
                //cekout.InnerHtml += "<a class='tombol' href='/CekOut.aspx' >Cek Out</a>";
            }
            else
            {
                Session["msg"] = "Order Empty!"; Response.Redirect("/home.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MsUserBAL ubal = new MsUserBAL();
            UserBAL user = new UserBAL();
            PenjualanBAL pbal = new PenjualanBAL();
            MsPenjualanBAL jual = new MsPenjualanBAL();
            ubal = user.getUserByUsername(Convert.ToString(Session["username"]));
            jual.idCustomer = ubal.idCustomer;
            //jual.detail = (List<string>) Session["order"];
            foreach (string det in (List<string>)Session["order"])
            {
                jual.detail += det + ";";
            }
            jual.idPenjualan = pbal.GetNextId().ToString();
            jual.tglTrans = DateTime.Now.ToString("yyyy-MM-dd");
            if( pbal.AddPenjualan(jual))
            {
                Session["msg"] = "Cek Out Berhasil!"; Session["order"] = null;
                cekout.InnerHtml = "";
                Response.Redirect("/home.aspx");
            }
            else
            {Session["msg"] = "Cek Out Gagal!";}
        }
    }
}