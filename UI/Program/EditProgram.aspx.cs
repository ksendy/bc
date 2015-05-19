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
    public partial class EditProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Convert.ToInt32(Session["lvl"]) != 3 || Request.QueryString["id"] == null)
            { Session["msg"] = "Hacking Attempt!"; Response.Redirect("/home.aspx"); }
            string id = Request.QueryString["id"];
            ProgramBAL pro = new ProgramBAL();
            MsProgramBAL probal = new MsProgramBAL();
            if (!pro.CekProgram(id))
            { Session["msg"] = "Hacking Attempt!"; Response.Redirect("/home.aspx"); }
            probal = pro.getProgramById(id);
            if (!IsPostBack)
            {
                title.Text = probal.title;
                descr.Text = probal.descr;
                size.Text = probal.size.ToString();
                os.Text = probal.os;
                license.Text = probal.license;
                tech.Text = probal.technology;
                Image1.ImageUrl = "/images/ProgramImg/" + probal.img;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ProgramBAL pb = new ProgramBAL();
            MsProgramBAL pro = new MsProgramBAL();
             string id = Request.QueryString["id"];
            pro = pb.getProgramById(id);            
                pro.title = title.Text;
                pro.descr = descr.Text;
                pro.size = Convert.ToInt32(size.Text);
                pro.os = os.Text;
                pro.license = license.Text;
                pro.technology = tech.Text;
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string uploadFolder = Request.PhysicalApplicationPath + "images\\ProgramImg\\";
                    string extension = Path.GetExtension(FileUploadControl.PostedFile.FileName);
                    FileUploadControl.SaveAs(uploadFolder + id + extension);
                    Response.Write("<script>alert('File uploaded!')</script>");
                    pro.img = id + extension;
                }
                catch (Exception ex)
                {
                    string err = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    Response.Write("<script>alert('" + err + "')</script>");
                }
            }

            if (pb.UpdateProgram(pro) && Page.IsValid)
            { Session["msg"] = "Edit Program Success"; }
            else
            { Session["msg"] = "Edit Program Failed"; }
            Response.Redirect("/home.aspx");
        }
    }
}