using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Uyg3Web
{
    public partial class notlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["girisKontrol"]) == false)
                Response.Redirect("giris.aspx?msg=Once giris yapiniz");
            else
            {
                Response.Write("Hosgeldin " + Session["OgrNo"].ToString());
                int ogrNo = Convert.ToInt32(Session["OgrNo"]);
                DataSet notlarDS = DBIslemleri.notlariCek(ogrNo);
                GridView1.DataSource = notlarDS.Tables[0];
                GridView1.DataBind();
            }
        }
    }
}