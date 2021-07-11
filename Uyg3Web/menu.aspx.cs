using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uyg3Web
{
    public partial class menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToBoolean(Session["girisKontrol"]) == false)
                Response.Redirect("giris.aspx?msg=Once giris yapiniz");
            else
                Response.Write("Hosgeldin " + Session["OgrNo"].ToString());

        }
    }
}