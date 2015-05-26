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
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string uid = Request.QueryString["id"];
            if (uid == null || Session["username"] == null || Convert.ToInt32(Session["lvl"]) != 3)
            { Session["msg"] = "Hacking Attempt!"; Response.Redirect("/home.aspx"); }
            else
            {
                if (!IsPostBack)
                {
                    UserBAL ub = new UserBAL();
                    MsUserBAL mu = new MsUserBAL();

                    mu = ub.GetUserById(uid);

                    Image1.ImageUrl = "/images/usrImg/" + mu.img;
                    Image1.Visible = true;
                    Names.Text = mu.nama;
                    level.Text = Convert.ToString(mu.lvl);
                    usrnm.Text = mu.username;
                    mail.Text = mu.email;
                    tel.Text = mu.telp;
                    alamat.Value = mu.alamat;
                    city.Text = mu.kota;
                    prov.Text = mu.provinsi;
                    kdpos.Text = mu.kodepos;
                    //pwrd.Text = mu.pwd;
                }

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            UserBAL ub = new UserBAL();
            MsUserBAL mu = new MsUserBAL();
            mu = ub.GetUserById(id);
            Pass p = new Pass();
            id = p.AddZero(id);
            mu.idCustomer = id;
            //mu.img = Image1.ImageUrl;
            mu.nama = Names.Text;
            mu.username = usrnm.Text;
            mu.email = mail.Text;
            mu.telp = tel.Text;
            mu.alamat = alamat.Value;
            mu.kota = city.Text;
            mu.provinsi = prov.Text;
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string uploadFolder = Request.PhysicalApplicationPath + "images\\usrImg\\";
                    string extension = Path.GetExtension(FileUploadControl.PostedFile.FileName);
                    FileUploadControl.SaveAs(uploadFolder + id + extension);
                    Response.Write("<script>alert('File uploaded!')</script>");
                    mu.img = id + extension;
                }
                catch (Exception ex)
                {
                    string err = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    Response.Write("<script>alert('" + err + "')</script>");
                }
            }
            Session["msg"] = ub.UpdateUser(mu)? "Update Success!": "Update Failed";
            Response.Redirect("/User/AllUser.aspx");


        }
    }
}