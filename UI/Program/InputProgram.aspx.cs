using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace UI
{
    public partial class InputProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MsProgramBAL probal = new MsProgramBAL();
            ProgramBAL bal = new ProgramBAL();
            int id = Convert.ToInt32(bal.getLastId())+1;
            string nol="";
            for (int i = 0; i < (10 - Convert.ToString(id).Length); i++)
            { nol += "0"; }
            probal.idProgram = nol +  Convert.ToString(id); 
            probal.title = title.Value;
            probal.size = Convert.ToInt32(ukuran.Value);
            probal.technology = tech.Value;
            probal.descr = descr.Value;
            probal.rating = 0;
            probal.img = FileUpload1.FileName;

            if (FileUpload1.HasFile)
            {
                try
                {
                    string filename = FileUpload1.FileName;
                    FileUpload1.SaveAs(Server.MapPath("~/usrImg/") + filename);
                    Response.Write("<script>alert('File uploaded!')</script>");
                }
                catch (Exception ex)
                {
                    string err = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    Response.Write("<script>alert('" + err + "')</script>");

                }
            }
            
            if (bal.AddProgram(probal))
            {
                Response.Write("<script>alert('Input Success')</script>");
                Response.Redirect("AllProgram.aspx");
            }
            else 
            {
                Response.Write("<script>alert('Input Failed')</script>");
            }
        }

    }
}