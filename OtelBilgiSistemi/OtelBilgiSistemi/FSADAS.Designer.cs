namespace OtelBilgiSistemi
{
    partial class FSADAS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOtelEkle = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOtelAdres = new System.Windows.Forms.TextBox();
            this.txtOtelPuanı = new System.Windows.Forms.TextBox();
            this.txtOtelOdaSayısı = new System.Windows.Forms.TextBox();
            this.txtOtelYıldızSayısı = new System.Windows.Forms.TextBox();
            this.txtOtelİl = new System.Windows.Forms.TextBox();
            this.txtOtelİlçe = new System.Windows.Forms.TextBox();
            this.txtOtelTelefon = new System.Windows.Forms.TextBox();
            this.txtOtelEposta = new System.Windows.Forms.TextBox();
            this.txtOtelAd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOtelEkle
            // 
            this.btnOtelEkle.Location = new System.Drawing.Point(375, 421);
            this.btnOtelEkle.Name = "btnOtelEkle";
            this.btnOtelEkle.Size = new System.Drawing.Size(75, 23);
            this.btnOtelEkle.TabIndex = 37;
            this.btnOtelEkle.Text = "Ekle";
            this.btnOtelEkle.UseVisualStyleBackColor = true;
            this.btnOtelEkle.Click += new System.EventHandler(this.BtnOtelEkle_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(218, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Adres";
            this.label9.Click += new System.EventHandler(this.Label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(218, 277);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "otel puanı";
            this.label8.Click += new System.EventHandler(this.Label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(218, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "oda sayısı";
            this.label7.Click += new System.EventHandler(this.Label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "yıldız sayısı";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "eposta";
            this.label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "telefon";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "ilçe";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "il";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "ad";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // txtOtelAdres
            // 
            this.txtOtelAdres.Location = new System.Drawing.Point(350, 296);
            this.txtOtelAdres.Multiline = true;
            this.txtOtelAdres.Name = "txtOtelAdres";
            this.txtOtelAdres.Size = new System.Drawing.Size(233, 87);
            this.txtOtelAdres.TabIndex = 27;
            this.txtOtelAdres.TextChanged += new System.EventHandler(this.TxtOtelAdres_TextChanged);
            // 
            // txtOtelPuanı
            // 
            this.txtOtelPuanı.Location = new System.Drawing.Point(350, 270);
            this.txtOtelPuanı.Name = "txtOtelPuanı";
            this.txtOtelPuanı.Size = new System.Drawing.Size(100, 20);
            this.txtOtelPuanı.TabIndex = 26;
            this.txtOtelPuanı.TextChanged += new System.EventHandler(this.TxtOtelPuanı_TextChanged);
            // 
            // txtOtelOdaSayısı
            // 
            this.txtOtelOdaSayısı.Location = new System.Drawing.Point(350, 243);
            this.txtOtelOdaSayısı.Name = "txtOtelOdaSayısı";
            this.txtOtelOdaSayısı.Size = new System.Drawing.Size(100, 20);
            this.txtOtelOdaSayısı.TabIndex = 25;
            this.txtOtelOdaSayısı.TextChanged += new System.EventHandler(this.TxtOtelOdaSayısı_TextChanged);
            // 
            // txtOtelYıldızSayısı
            // 
            this.txtOtelYıldızSayısı.Location = new System.Drawing.Point(350, 217);
            this.txtOtelYıldızSayısı.Name = "txtOtelYıldızSayısı";
            this.txtOtelYıldızSayısı.Size = new System.Drawing.Size(100, 20);
            this.txtOtelYıldızSayısı.TabIndex = 24;
            this.txtOtelYıldızSayısı.TextChanged += new System.EventHandler(this.TxtOtelYıldızSayısı_TextChanged);
            // 
            // txtOtelİl
            // 
            this.txtOtelİl.Location = new System.Drawing.Point(350, 50);
            this.txtOtelİl.Name = "txtOtelİl";
            this.txtOtelİl.Size = new System.Drawing.Size(100, 20);
            this.txtOtelİl.TabIndex = 23;
            this.txtOtelİl.TextChanged += new System.EventHandler(this.TxtOtelİl_TextChanged);
            // 
            // txtOtelİlçe
            // 
            this.txtOtelİlçe.Location = new System.Drawing.Point(350, 96);
            this.txtOtelİlçe.Name = "txtOtelİlçe";
            this.txtOtelİlçe.Size = new System.Drawing.Size(100, 20);
            this.txtOtelİlçe.TabIndex = 22;
            this.txtOtelİlçe.TextChanged += new System.EventHandler(this.TxtOtelİlçe_TextChanged);
            // 
            // txtOtelTelefon
            // 
            this.txtOtelTelefon.Location = new System.Drawing.Point(350, 131);
            this.txtOtelTelefon.Name = "txtOtelTelefon";
            this.txtOtelTelefon.Size = new System.Drawing.Size(100, 20);
            this.txtOtelTelefon.TabIndex = 21;
            this.txtOtelTelefon.TextChanged += new System.EventHandler(this.TxtOtelTelefon_TextChanged);
            // 
            // txtOtelEposta
            // 
            this.txtOtelEposta.Location = new System.Drawing.Point(350, 160);
            this.txtOtelEposta.Name = "txtOtelEposta";
            this.txtOtelEposta.Size = new System.Drawing.Size(100, 20);
            this.txtOtelEposta.TabIndex = 20;
            this.txtOtelEposta.TextChanged += new System.EventHandler(this.TxtOtelEposta_TextChanged);
            // 
            // txtOtelAd
            // 
            this.txtOtelAd.Location = new System.Drawing.Point(350, 7);
            this.txtOtelAd.Name = "txtOtelAd";
            this.txtOtelAd.Size = new System.Drawing.Size(100, 20);
            this.txtOtelAd.TabIndex = 19;
            this.txtOtelAd.TextChanged += new System.EventHandler(this.TxtOtelAd_TextChanged);
            // 
            // FSADAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOtelEkle);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOtelAdres);
            this.Controls.Add(this.txtOtelPuanı);
            this.Controls.Add(this.txtOtelOdaSayısı);
            this.Controls.Add(this.txtOtelYıldızSayısı);
            this.Controls.Add(this.txtOtelİl);
            this.Controls.Add(this.txtOtelİlçe);
            this.Controls.Add(this.txtOtelTelefon);
            this.Controls.Add(this.txtOtelEposta);
            this.Controls.Add(this.txtOtelAd);
            this.Name = "FSADAS";
            this.Text = "FSADAS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOtelEkle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOtelAdres;
        private System.Windows.Forms.TextBox txtOtelPuanı;
        private System.Windows.Forms.TextBox txtOtelOdaSayısı;
        private System.Windows.Forms.TextBox txtOtelYıldızSayısı;
        private System.Windows.Forms.TextBox txtOtelİl;
        private System.Windows.Forms.TextBox txtOtelİlçe;
        private System.Windows.Forms.TextBox txtOtelTelefon;
        private System.Windows.Forms.TextBox txtOtelEposta;
        private System.Windows.Forms.TextBox txtOtelAd;
    }
}