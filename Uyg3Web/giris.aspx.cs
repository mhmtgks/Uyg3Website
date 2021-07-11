using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uyg3Web
{
    public partial class giris : System.Web.UI.Page
    {
        public int[] dizi = new int[5] { 9, 8, 7, 6, 5 };
        protected void Page_Load(object sender, EventArgs e)
        {
            string mesaj = Request.QueryString["msg"];
            Response.Write(mesaj);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int ogrNo = Convert.ToInt32(TextBox1.Text);
            string sifre = TextBox2.Text;
            bool sonuc = DBIslemleri.girisKontrol(ogrNo, sifre);
            if (sonuc == false)
                sonuc = false;
            else
            {
                bool Admin = DBIslemleri.adminkontrol(ogrNo, sifre);
                //menu sayfasini ac
                if (Admin == false)
                {
                    Session["girisKontrol"] = true;
                    Session["OgrNo"] = ogrNo;
                    Response.Redirect("menu.aspx");
                }
                else
                {
                    Session["girisKontrol"] = true;
                    Session["OgrNo"] = ogrNo;
                    Response.Redirect("admin.aspx");
                }
            }
        }
    }
}