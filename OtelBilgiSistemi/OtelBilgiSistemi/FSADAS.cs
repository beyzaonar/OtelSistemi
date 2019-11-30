using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelBilgiSistemi
{
    public partial class FSADAS : Form
    {
        public FSADAS()
        {
            InitializeComponent();
        }

        private void BtnOtelEkle_Click(object sender, EventArgs e)
        {
            Otel Otel = new Otel();

            Otel.ad = txtOtelAd.Text;
            Otel.il = txtOtelİl.Text;
            Otel.ilçe = txtOtelİlçe.Text;
            Otel.telefon = txtOtelTelefon.Text;
            Otel.eposta = txtOtelEposta.Text;
            Otel.adres = txtOtelAdres.Text;
            Otel.yıldızSayısı = Convert.ToInt32(txtOtelYıldızSayısı.Text);
            Otel.odaSayısı = Convert.ToInt32(txtOtelOdaSayısı.Text);
            Otel.otelPuanı = Convert.ToInt32(txtOtelPuanı.Text);

            MessageBox.Show("Yeni otel Eklendi!");
        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TxtOtelAdres_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtOtelPuanı_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtOtelOdaSayısı_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtOtelYıldızSayısı_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtOtelİl_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtOtelİlçe_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtOtelTelefon_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtOtelEposta_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtOtelAd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
