using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Uyg3Web
{
    public partial class dersSec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["girisKontrol"]) == false)
                Response.Redirect("giris.aspx?msg=Once giris yapiniz");
            else
            {
                if (!IsPostBack)
                {
                    Response.Write("Hosgeldin " + Session["OgrNo"].ToString());
                    DataSet derslerDS = DBIslemleri.dersleriCek();
                    DropDownList1.DataTextField = "DersAdi";
                    DropDownList1.DataValueField = "DersId";
                    DropDownList1.DataSource = derslerDS.Tables[0];
                    DropDownList1.DataBind();
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int ogrNo = Convert.ToInt32(Session["OgrNo"]);
            string dersKodu = DropDownList1.SelectedValue.ToString();
            DBIslemleri.DersEkle(ogrNo, dersKodu);
            Response.Write("Ders Eklendi");
        }
    }
}