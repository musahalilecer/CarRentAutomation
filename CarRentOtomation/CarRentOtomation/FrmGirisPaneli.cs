using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentOtomation;

namespace CarRentOtomation
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        RentCarProjectEntities db = new RentCarProjectEntities();
        public string MusteriAd;
        public string MusteriSoyad;
        public string MusteriTc;
        public bool MusteriCinsiyet;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
        public string Cinsiyet;
        private void btnGiris1_Click(object sender, EventArgs e)
        {
            /*TblUrun tbl = new TblUrun();
            tbl.UrunAd = txtAd.Text;
            tbl.Marka = txtMarka.Text;
            tbl.Stok = Convert.ToInt16(txtStok.Text);
            tbl.Fiyat = Convert.ToInt16(txtFiyat.Text);
            tbl.Durum = true;
    //        tbl.Kategory = Convert.ToInt16(txtKategori.Text);
            db.TblUrun.Add(tbl);
            db.SaveChanges();
            MessageBox.Show("Veri Eklendi");
            Listele();*/
            TblMusteri tbl = new TblMusteri();
            tbl.MusteriAd = txtAd1.Text;
            tbl.MusteriSoyad = txtSoyad1.Text;
            tbl.MusteriTc = txtTc.Text;
            
            if (radioButton1.Checked)
            {
                Cinsiyet = "Erkek";
                label10.Text = Cinsiyet;
            }
            else if (radioButton2.Checked)
            {
                Cinsiyet = "Kiz";
                label10.Text = Cinsiyet;
            }
            db.TblMusteri.Add(tbl);
            db.SaveChanges();
            MessageBox.Show("Kayıt Yapıldı");
            FrmMusteriPanel frm = new FrmMusteriPanel();
            frm.Show();

            MusteriAd = txtAd1.Text;
            MusteriSoyad = txtSoyad1.Text;
            MusteriTc = txtTc.Text;
            if (radioButton1.Checked)
            {
                MusteriCinsiyet = true;
            }
            else if (radioButton2.Checked)
            {
                MusteriCinsiyet = false;
            }

        }

        private void btnGiris2_Click(object sender, EventArgs e)
        {
            // var sorgu = from x in db.TblKullaniciPaneli where x.KullaniciAdi == txtAd.Text && x.Sifre == txtSifre.Text select x;
            var sorgu = from x in db.TblPersonel where x.PersonelAd == txtAd2.Text && x.PersonelSoyad == txtSoyad2.Text && x.PersonelSifre == txtSifre.Text select x;
            if(sorgu.Any())
            {
                FrmPersonel frm = new FrmPersonel();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş");
            }
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
            
        }
    }
}
