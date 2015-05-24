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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            { Session["msg"] = "You have already login"; Response.Redirect("/home.aspx"); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserBAL ub = new UserBAL();
            int id = Convert.ToInt32(ub.GetLastId()) + 1;
            Pass pa = new Pass();
            string ids = pa.AddZero(id.ToString());
            MsUserBAL ubal = new MsUserBAL
           {
               idCustomer = ids,
               nama = Names.Text,
               username = usrnm.Text,
               email = mail.Text,
               telp = tel.Text,
               alamat = alamat.InnerText,
               kota = city.Text,
               provinsi = prov.Text,
               kodepos = kdpos.Text,
               img = "anon.jpg",
               lvl = 2,
               pwd = pwrd.Text,
               status = '1'
           };
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string uploadFolder = Request.PhysicalApplicationPath + "images\\usrImg\\";
                    string extension = Path.GetExtension(FileUploadControl.PostedFile.FileName);
                    FileUploadControl.SaveAs(uploadFolder + ids + extension);
                    Response.Write("<script>alert('File uploaded!')</script>");
                    ubal.img = ids + extension;
                }
                catch (Exception ex)
                {
                    string err = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    Response.Write("<script>alert('" + err + "')</script>");
                }
            }
            else
            { ubal.img = "anon.jpg"; }
            if (ub.AddUser(ubal) && Page.IsValid && ub.getUserByUsername(ubal.username) == null)
            { Response.Write("<script>alert('Register Success')</script>"); }
            else
            { Response.Write("<script>alert('Register Failed')</script>"); }
        }
    }
}