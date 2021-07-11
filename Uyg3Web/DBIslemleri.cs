using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Uyg3Web
{
      public class DBIslemleri
    {
        // static string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiString"].ToString();
        static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mgoek\Downloads\Uyg3\db\OgrIsleri.mdf;Integrated Security=True;Connect Timeout=30";
        static SqlConnection baglanti = new SqlConnection(baglantiYolu);
        public static bool girisKontrol(int ogrNo, string sifre)
        {
            string sql = "select * from Ogrenciler where OgrNo=@pogrNo and Sifre=@psifre";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pogrNo", ogrNo);
            komut.Parameters.AddWithValue("@psifre", sifre);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();
            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;
            return sonuc;

        }
        public static bool adminkontrol(int ogrNo, string sifre)
        {
            string sql = "select * from Ogrenciler where OgrNo=@pogrNo and Sifre=@psifre and Soyadi=2";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pogrNo", ogrNo);
            komut.Parameters.AddWithValue("@psifre", sifre);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();
            bool admin = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                admin = true;
            return admin;
        }

        public static DataSet dersleriCek()
        {
            string sql = "Select * from Dersler";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet derslerDS = new DataSet();
            baglanti.Open();
            adaptor.Fill(derslerDS);
            baglanti.Close();
            return derslerDS;
        }

        public static void DersEkle(int ogrNo, string dersKodu)
        {
            string sql = "insert into Notlar(OgrNo,DersID) values(@pogrno,@pderskodu)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pogrno", ogrNo);
            komut.Parameters.AddWithValue("@pderskodu", dersKodu);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public static DataSet notlariCek(int OgrNo)
        {

            string sql = "Select Dersler.DersID, DersAdi, Vize, Final, (Vize*0.4+Final*0.6) as Ort from Notlar";
            sql=sql+" inner join Dersler on Dersler.DersId=Notlar.DersID where OgrNo=" + OgrNo;
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet notlarDS = new DataSet();
            baglanti.Open();
            adaptor.Fill(notlarDS);
            baglanti.Close();
            return notlarDS;

        }
    }
}