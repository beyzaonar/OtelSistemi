using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelBilgiSistemi
{
    class DBİşlemleri
    {
       SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-OLTHGF9\\SQLEXPRESS;Initial Catalog=OtelBilgiSistemi;Integrated Security=True");

       private static DBİşlemleri instance;
       public BST_Otel OtelAğacı = new BST_Otel();
       public HashTable İlTable, İlçeTable;
       public Müşteri OturumMüşteri;
       
        private DBİşlemleri()
        {

        }

      public void AğacaEkle(Otel YeniOtel)
        {
            OtelAğacı.Ekle(YeniOtel);
        }

       public void İlTableEkle(Otel YeniOtel)
        {
           İlTable.AddOtel(YeniOtel,YeniOtel.il);
        }

        void İlçeTableEkle(Otel YeniOtel)
        {
            İlçeTable.AddOtel(YeniOtel, YeniOtel.ilçe);
        }

        public static DBİşlemleri GetInstance()
        {
            if( instance==null)
            instance = new DBİşlemleri();

            return instance;
        }


        public bool MüşteriOturumu(string ad, string şifre)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT trim(KullanıcıTürü) from Kullanıcı where Ad=@p1 and Şifre=@p2", sqlConnection);
            cmd.Parameters.AddWithValue("@p1", ad);
            cmd.Parameters.AddWithValue("@p2", şifre);

            SqlDataReader dr = cmd.ExecuteReader();

            string KullanıcıTürü = "";

            while (dr.Read())
            {
                KullanıcıTürü = dr[0].ToString().ToLower();
            }

            sqlConnection.Close();

            if (KullanıcıTürü == "müşteri")
                return true;
            else
                return false;
        }


       public bool OturumVer(string ad,string şifre)
       {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT trim(Ad),trim(Soyad),trim(tcKimlikNo),trim(telefon),trim(adres),trim(eposta) from Kullanıcı where Ad=@p1 and Şifre=@p2",sqlConnection);
            cmd.Parameters.AddWithValue("@p1",ad);
            cmd.Parameters.AddWithValue("@p2",şifre);

            SqlDataReader dr = cmd.ExecuteReader();

            OturumMüşteri = new Müşteri();

            while (dr.Read())
            {
                OturumMüşteri.ad = dr[0].ToString();
                OturumMüşteri.soyad = dr[1].ToString();
                OturumMüşteri.tcKimlikNo = dr[2].ToString();
                OturumMüşteri.telefon = dr[3].ToString();
                OturumMüşteri.adres = dr[4].ToString();
                OturumMüşteri.eposta = dr[5].ToString();
            }

            sqlConnection.Close();

            if (OturumMüşteri.ad == "")
                return false;
            else
                return true;
        }



        private void İlTableAyarla()
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from iltekrari",sqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();

            int sayi = 0;
            while(dr.Read())
            {
                sayi = Convert.ToInt32(dr[0]);
            }
            sqlConnection.Close();

            sqlConnection.Open();
            
            this.İlTable = new HashTable(sayi);

            SqlCommand cmd1 = new SqlCommand("SELECT TekrarSayısı,trim(İl) from iltekrari", sqlConnection);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                sayi = Convert.ToInt32(dr1[0]);
                this.İlTable.HeapYeriAç(sayi, dr1[1].ToString().ToLower()); //heap yerleri açıldı
            }

            sqlConnection.Close();
        }

        private void İlçeTableAyarla()
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from ilcetekrari", sqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();

            int sayi = 0;
            while (dr.Read())
            {
                sayi = Convert.ToInt32(dr[0]);
            }
            sqlConnection.Close();

            sqlConnection.Open();

            this.İlçeTable = new HashTable(sayi);

            SqlCommand cmd1 = new SqlCommand("SELECT TekrarSayısı,trim(İlçe) from ilcetekrari", sqlConnection);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                sayi = Convert.ToInt32(dr1[0]);
                this.İlçeTable.HeapYeriAç(sayi, dr1[1].ToString().ToLower()); //heap yerleri açıldı
            }

            sqlConnection.Close();
        }



        public void MüşteriOtelleriAl()
        {
            İlTableAyarla();
            İlçeTableAyarla();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT trim(ad),trim(il),trim(ilçe),trim(adres),trim(telefon),trim(eposta),trim(odaTipleri),yıldızSayisi,odaSayisi,otelPuani from oteller", sqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                Otel otel = new Otel();

                otel.ad = dr[0].ToString();
                otel.il= dr[1].ToString();
                otel.ilçe = dr[2].ToString();
                otel.adres = dr[3].ToString();
                otel.telefon=dr[4].ToString();
                otel.eposta= dr[5].ToString();
                otel.odaTipleri = dr[6].ToString();
                otel.yıldızSayısı = Convert.ToInt32(dr[7]);
                otel.odaSayısı = Convert.ToInt32(dr[8]);
                otel.otelPuanı = Convert.ToDouble(dr[9]);

                AğacaEkle(otel);
                İlTableEkle(otel);
                İlçeTableEkle(otel);
            }
            sqlConnection.Close();
        }

        public void YöneticiOtelleriAl()
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT trim(ad),trim(il),trim(ilçe),trim(adres),trim(telefon),trim(eposta),trim(odaTipleri),yıldızSayisi,odaSayisi,otelPuani from oteller", sqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Otel otel = new Otel();

                otel.ad = dr[0].ToString();
                otel.il = dr[1].ToString();
                otel.ilçe = dr[2].ToString();
                otel.adres = dr[3].ToString();
                otel.telefon = dr[4].ToString();
                otel.eposta = dr[5].ToString();
                otel.odaTipleri = dr[6].ToString();
                otel.yıldızSayısı = Convert.ToInt32(dr[7]);
                otel.odaSayısı = Convert.ToInt32(dr[8]);
                otel.otelPuanı = Convert.ToDouble(dr[9]);

                AğacaEkle(otel);
            }
            sqlConnection.Close();
        }

        public void PersonelleriAl()
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT trim(ad),trim(soyad),trim(telefon),trim(adres),trim(eposta),trim(departman),trim(pozisyon),personelPuan,tcKimlikNo,trim(KimeAit) from Personeller", sqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();

            string Otel;
            while (dr.Read())
            {
                Personel personel = new Personel();

                personel.ad = dr[0].ToString();
                personel.soyad = dr[1].ToString();
                personel.telefon = dr[2].ToString();
                personel.adres = dr[3].ToString();
                personel.eposta = dr[4].ToString();
                personel.departman= dr[5].ToString();
                personel.pozisyon= dr[6].ToString();
                personel.personelPuanı = Convert.ToInt16(dr[7]);
                personel.tcKimlikNo = dr[8].ToString();
                Otel = dr[9].ToString();


               OtelAğacı.Ara(Otel).otel.PersonelEkle(personel);

               
            }
            sqlConnection.Close();
        }


        public void YorumlarıAl()
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT trim(yorum),trim(sahipAdi),trim(sahipSoyadi),trim(SahipEposta),trim(KimeAit) from Yorumlar", sqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();


            while(dr.Read())
            {
                Yorum yorum = new Yorum(dr[0].ToString());
                yorum.sahipAdı = dr[1].ToString();
                yorum.sahipSoyadı = dr[2].ToString();
                yorum.sahipEpostası = dr[3].ToString();
                OtelAğacı.Ara(dr[4].ToString()).otel.YorumEkle(yorum);
            }

            sqlConnection.Close();
        }

        public void YorumGönder(Yorum yorum,Otel otel)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Yorumlar(yorum,sahipAdi,sahipSoyadi,SahipEposta,KimeAit) VALUES('"+yorum.yorum+"','"+yorum.sahipAdı+"','"+yorum.sahipSoyadı+"','"+yorum.sahipEpostası+"','"+otel.ad+"')", sqlConnection);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            sqlConnection.Close();
        }

        public void OtelEkle(Otel YeniOtel)
        {           
            sqlConnection.Open();
            SqlCommand ekle = new SqlCommand("insert into Oteller(ad,il,ilçe,adres,telefon,eposta,odaTipleri,yıldızSayisi,odaSayisi,otelPuani,PuanVerilmeSayısı) VALUES('"+ YeniOtel.ad + "','"+ YeniOtel.il+ "','"+ YeniOtel.ilçe+ "','"+ YeniOtel.adres+ "','"+ YeniOtel.telefon+ "','"+ YeniOtel.eposta+ "','"+YeniOtel.odaTipleri+"','"+ YeniOtel.yıldızSayısı+ "','"+ YeniOtel.odaSayısı+ "','"+0+"','"+0+"')", sqlConnection);            

            ekle.ExecuteNonQuery();
            ekle.Dispose();
                    
            sqlConnection.Close();

            İlçeTekrarıKontrolEt(YeniOtel);
            İlTekrarıKontrolEt(YeniOtel);
            
        }

        public void OtelSime(Otel SilinecekOtel)
        {
            İlçeTekrarıKontrolEtSilme(SilinecekOtel);
            İlTekrarıKontrolEtSilme(SilinecekOtel);

          sqlConnection.Open();
          SqlCommand sil = new SqlCommand("DELETE Oteller where trim(ad)=@p1", sqlConnection);
          sil.Parameters.AddWithValue("@p1", SilinecekOtel.ad);
          sil.ExecuteNonQuery();
                   
          sqlConnection.Close();
            
        }

        public void OtelGüncelle(Otel GüncellenecekOtel)
        {          
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("UPDATE  Oteller  SET adres=@p1,telefon=@p2,eposta=@p3,yıldızSayisi=@p4,odaSayisi=@p5,odaTipleri=@p6 WHERE trim(ad)=@p7", sqlConnection);

            cmd.Parameters.AddWithValue("@p1", GüncellenecekOtel.adres);
            cmd.Parameters.AddWithValue("@p2", GüncellenecekOtel.telefon);
            cmd.Parameters.AddWithValue("@p3", GüncellenecekOtel.eposta);
            cmd.Parameters.AddWithValue("@p4", GüncellenecekOtel.yıldızSayısı);
            cmd.Parameters.AddWithValue("@p5", GüncellenecekOtel.odaSayısı);
            cmd.Parameters.AddWithValue("@p6", GüncellenecekOtel.odaTipleri);
            cmd.Parameters.AddWithValue("@p7", GüncellenecekOtel.ad);
            cmd.ExecuteNonQuery();


          
            sqlConnection.Close();
            
        }

        private void İlçeTekrarıKontrolEt(Otel YeniOtel)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TekrarSayısı from ilcetekrari where trim(İlçe)=@p1", sqlConnection);
            cmd.Parameters.AddWithValue("@p1", YeniOtel.ilçe.ToLower());
            int sayi = 0;
            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                sayi = Convert.ToInt32(dr[0]);
            }

            sqlConnection.Close();
            sqlConnection.Open();


            if (sayi!=0)
            {

                SqlCommand cmd1 = new SqlCommand("UPDATE ilcetekrari SET TekrarSayısı=@p1 where trim(İlçe)=@p2", sqlConnection);
                cmd1.Parameters.AddWithValue("@p1", sayi+1);
                cmd1.Parameters.AddWithValue("@p2", YeniOtel.ilçe.ToLower());
                cmd1.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO ilcetekrari(İlçe,TekrarSayısı) VALUES('"+YeniOtel.ilçe.ToLower()+"','"+1+"')", sqlConnection);

                cmd1.ExecuteNonQuery();
                cmd1.Dispose();
                sqlConnection.Close();
            }
        }


        private void İlçeTekrarıKontrolEtSilme(Otel SilinecekOtel)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TekrarSayısı from ilcetekrari where trim(İlçe)=@p1", sqlConnection);
            cmd.Parameters.AddWithValue("@p1", SilinecekOtel.ilçe.ToLower());
            int sayi = 0;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                sayi = Convert.ToInt32(dr[0]);
            }

            sqlConnection.Close();
            sqlConnection.Open();


            if (sayi != 1)
            {

                SqlCommand cmd1 = new SqlCommand("UPDATE ilcetekrari SET TekrarSayısı=@p1 where trim(İlçe)=@p2", sqlConnection);
                cmd1.Parameters.AddWithValue("@p1", sayi - 1);
                cmd1.Parameters.AddWithValue("@p2", SilinecekOtel.ilçe.ToLower());
                cmd1.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("DELETE from ilcetekrari WHERE trim(ilçe)=@p1", sqlConnection);
                cmd1.Parameters.AddWithValue("@p1", SilinecekOtel.ilçe.ToLower());
                cmd1.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        private void İlTekrarıKontrolEt(Otel YeniOtel)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TekrarSayısı from iltekrari where trim(İl)=@p1", sqlConnection);
            cmd.Parameters.AddWithValue("@p1", YeniOtel.il.ToLower());
            int sayi = 0;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                sayi = Convert.ToInt32(dr[0]);
            }

            sqlConnection.Close();
            sqlConnection.Open();

            if (sayi != 0)
            {

                SqlCommand cmd1 = new SqlCommand("UPDATE iltekrari SET TekrarSayısı=@p1 where trim(İl)=@p2", sqlConnection);
                cmd1.Parameters.AddWithValue("@p1", sayi + 1);
                cmd1.Parameters.AddWithValue("@p2", YeniOtel.il.ToLower());
                cmd1.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO iltekrari (İl,TekrarSayısı)  VALUES('" + YeniOtel.il.ToLower() + "','" + 1 + "')", sqlConnection);

                cmd1.ExecuteNonQuery();
                cmd1.Dispose();
                sqlConnection.Close();
            }
        }


        private void İlTekrarıKontrolEtSilme(Otel SilinecekOtel)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TekrarSayısı from iltekrari where trim(İl)=@p1", sqlConnection);
            cmd.Parameters.AddWithValue("@p1", SilinecekOtel.il.ToLower());
            int sayi = 0;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                sayi = Convert.ToInt32(dr[0]);
            }

            sqlConnection.Close();
            sqlConnection.Open();


            if (sayi != 1)
            {

                SqlCommand cmd1 = new SqlCommand("UPDATE iltekrari SET TekrarSayısı=@p1 where trim(İl)=@p2", sqlConnection);
                cmd1.Parameters.AddWithValue("@p1", sayi - 1);
                cmd1.Parameters.AddWithValue("@p2", SilinecekOtel.il.ToLower());
                cmd1.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("DELETE from iltekrari WHERE trim(il)=@p1", sqlConnection);
                cmd1.Parameters.AddWithValue("@p1", SilinecekOtel.il.ToLower());
                cmd1.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public double YeniPuanHesapla(Otel otel,int verilenPuan)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Select otelPuani,PuanVerilmeSayısı from Oteller where ad=@p1 ", sqlConnection);
            cmd.Parameters.AddWithValue("@p1", otel.ad);
            SqlDataReader dr = cmd.ExecuteReader();

            double otelpuanı = 0;
            int sayi = 0;
            while (dr.Read())
            {
                otelpuanı = Convert.ToDouble(dr[0]);
                sayi = Convert.ToInt32(dr[1]);              
            }
            sqlConnection.Close();

            sqlConnection.Open();
            SqlCommand cmd1 = new SqlCommand("UPDATE Oteller SET PuanVerilmeSayısı = @p2 WHERE ad = @p3", sqlConnection);
            cmd1.Parameters.AddWithValue("@p2", sayi+1);
            cmd1.Parameters.AddWithValue("@p3", otel.ad);
            cmd1.ExecuteNonQuery();
            sqlConnection.Close();

            double YeniPuan = ((otelpuanı * sayi) + (verilenPuan)) / (sayi + 1);

            return YeniPuan;
        }

        public void PuanıGüncelle(Otel otel)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Oteller SET otelPuani=@p1 WHERE  ad=@p2 ", sqlConnection);
            cmd.Parameters.AddWithValue("@p1", otel.otelPuanı);
            cmd.Parameters.AddWithValue("@p2",otel.ad);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void PersonelEkle(Personel personel,string OtelAdı)
        {
            
                sqlConnection.Open();
                SqlCommand ekle = new SqlCommand("INSERT INTO Personeller(tcKimlikNo,ad,soyad,telefon,adres,departman,pozisyon,personelPuan,eposta,KimeAit)  VALUES('"+ personel.tcKimlikNo + "','"+ personel.ad + "','"+ personel.soyad + "','"+ personel.telefon + "','"+ personel.adres+ "','"+ personel.departman + "','"+ personel.pozisyon + "','"+ personel.personelPuanı + "','"+personel.eposta+"','"+ OtelAdı + "')",sqlConnection);

                ekle.ExecuteNonQuery();
   
                ekle.Dispose();
           
            
                sqlConnection.Close();
            
        }

        public void PersonelSil(Personel personel)
        {
            
                sqlConnection.Open();
                SqlCommand sil = new SqlCommand("delete Personeller where trim(tcKimlikNo)=@p1", sqlConnection);
                sil.Parameters.AddWithValue("@p1",personel.tcKimlikNo);
                sil.ExecuteNonQuery();
                    
         
                sqlConnection.Close();
            
        }

        public void PersonelGüncelle(Personel personel)
        {
           
                sqlConnection.Open();
                SqlCommand güncelle = new SqlCommand("UPDATE Personeller set ad=@ad,soyad=@soyad,telefon=@telefon,adres=@adres,departman=@departman,pozisyon=@pozisyon,personelPuan=@personelPuan where trim(tcKimlikNo)=@tcKimlikNo", sqlConnection);
                güncelle.Parameters.AddWithValue("@tcKimlikNo", personel.tcKimlikNo);
                güncelle.Parameters.AddWithValue("@ad", personel.ad);
                güncelle.Parameters.AddWithValue("@soyad", personel.soyad);
                güncelle.Parameters.AddWithValue("@telefon", personel.telefon);
                güncelle.Parameters.AddWithValue("@adres", personel.adres);
                güncelle.Parameters.AddWithValue("@departman", personel.departman);
                güncelle.Parameters.AddWithValue("@pozisyon", personel.pozisyon);
                güncelle.Parameters.AddWithValue("@personelPuan", Convert.ToInt16(personel.personelPuanı));
                güncelle.ExecuteNonQuery();
    
     

           
                sqlConnection.Close();
            
        }

    }

   
}
