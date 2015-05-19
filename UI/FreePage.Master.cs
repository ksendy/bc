using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class FreePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            shop.InnerHtml = Convert.ToString(Application["shopper"]);
            if (Application["shopper"] == null)
            { user.InnerText = "0"; shop.InnerHtml = "0"; }
            else
            { user.InnerText = Convert.ToString(Application["shopper"]); }
        }
    }
}