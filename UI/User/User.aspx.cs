using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace UI
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string uid = Request.QueryString["uid"];
            if (uid == null)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    UserBAL ub = new UserBAL();
                    MsUserBAL mu = new MsUserBAL();

                    mu = ub.GetUserById(uid);
                    
                    Image1.ImageUrl = mu.img;
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
            string uid = Request.QueryString["uid"];
            UserBAL ub = new UserBAL();
            MsUserBAL mu = new MsUserBAL();
            mu = ub.GetUserById(uid);

            mu.idCustomer = uid;
            mu.img = Image1.ImageUrl;
            mu.nama = Names.Text;
            mu.username = usrnm.Text;
            mu.email = mail.Text;
            mu.telp = tel.Text;
            mu.alamat = alamat.Value;
            mu.kota = city.Text;
            mu.provinsi = prov.Text;

            ub.UpdateUser(mu);

        }
    }
}