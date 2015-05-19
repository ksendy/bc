using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.IO;

namespace UI
{
    public partial class AddProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Convert.ToInt32(Session["lvl"]) != 3)
            { Session["msg"] = "Hacking Attempt!"; Response.Redirect("/home.aspx"); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ProgramBAL pb = new ProgramBAL();
            int id = Convert.ToInt32(pb.getLastId()) + 1;
            Pass p = new Pass();
            string ids = p.AddZero((Convert.ToInt32(pb.getLastId()) + 1).ToString());
            MsProgramBAL pro = new MsProgramBAL
            {
                idProgram = ids,
                title = title.Text,
                descr = descr.Text,
                size = Convert.ToInt32(size.Text),
                os = os.Text,
                license = license.Text,
                technology = tech.Text,
                rating = 0,
                date = Convert.ToString(DateTime.Now),
                img = "default.png",
            };
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string uploadFolder = Request.PhysicalApplicationPath + "images\\ProgramImg\\";
                    string extension = Path.GetExtension(FileUploadControl.PostedFile.FileName);
                    FileUploadControl.SaveAs(uploadFolder + ids + extension);
                    Response.Write("<script>alert('File uploaded!')</script>");
                    pro.img = ids + extension; 
                }
                catch (Exception ex)
                {
                    string err = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    Response.Write("<script>alert('" + err + "')</script>");
                }
            }
            else
            { pro.img = "default.png"; }


            if (pb.AddProgram(pro) && Page.IsValid)
            { Session["msg"] = "Add Program Success"; }
            else
            { Session["msg"] = "Add Program Failed"; }
            Response.Redirect("/home.aspx");
        }
    }
}