using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentOtomation;

namespace CarRentOtomation
{
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        RentCarProjectEntities db = new RentCarProjectEntities();
        public void Listele1()
        {
            if(cmbMarka.SelectedItem == "Mercedes")
            {
                dataGridView2.DataSource = db.TblMercedes.ToList();
            }
            else if(cmbMarka.SelectedItem == "Toyota")
            {
                dataGridView2.DataSource = db.TblToyota.ToList();
            }
        }
        public void Listele2()
        {
            dataGridView1.DataSource = db.TblMusteri.ToList();
        }
        private void btnListele2_Click(object sender, EventArgs e)
        {
            Listele1();
        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            cmbMarka.Items.Add("Mercedes");
            cmbMarka.Items.Add("Toyota");
        }

        private void btnKaydet2_Click(object sender, EventArgs e)
        {
            if(cmbMarka.SelectedItem == "Mercedes")
            {
                TblMercedes mercedes = new TblMercedes();
                mercedes.ArabaModel = txtModel.Text;
                mercedes.ArabaFiyat = txtFiyat.Text;
                mercedes.ArabaCategory = txtKategori.Text;
                mercedes.ArabaYil = Convert.ToDateTime(txtYil.Text);
                db.TblMercedes.Add(mercedes);
                db.SaveChanges();
            }
            else if(cmbMarka.SelectedItem == "Toyota")
            {
                TblToyota toyota = new TblToyota();
                toyota.ArabaModel = txtModel.Text;
                toyota.ArabaFiyat = txtFiyat.Text;
                toyota.ArabaCategory = txtKategori.Text;
                toyota.ArabaYil = Convert.ToDateTime(txtYil.Text);
                db.TblToyota.Add(toyota);
                db.SaveChanges();
            }
            MessageBox.Show("Veri Eklendi");
        }

        private void btnSil2_Click(object sender, EventArgs e)
        {
            if(cmbMarka.SelectedItem == "Mercedes")
            {
                int x = Convert.ToInt16(txtId.Text);
                var mercedes = db.TblMercedes.Find(x);
                db.TblMercedes.Remove(mercedes);
                db.SaveChanges();
            }
            else if(cmbMarka.SelectedItem == "Toyota")
            {
                int y = Convert.ToInt16(txtId.Text);
                var toyota = db.TblToyota.Find(y);
                db.TblToyota.Remove(toyota);
                db.SaveChanges();
            }
            MessageBox.Show("Veri Silindi");
        }

        private void btnListele1_Click(object sender, EventArgs e)
        {
            Listele2();
        }

        private void btnKaydet1_Click(object sender, EventArgs e)
        {
            TblMusteri musteri = new TblMusteri();
            musteri.MusteriAd = txtAd.Text;
            musteri.MusteriSoyad = txtSoyad.Text;
            musteri.MusteriTc = txtTc.Text;
            if (radioButton1.Checked)
            {
                musteri.MusteriCinsiyet = true;
                
            }
            else if (radioButton2.Checked)
            {
                musteri.MusteriCinsiyet = false;
            }
            db.TblMusteri.Add(musteri);
            db.SaveChanges();
            MessageBox.Show("Veri Eklendi");
        }

        private void btnSil1_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt16(textBox1.Text);
            var musteri = db.TblMusteri.Find(index);
            db.TblMusteri.Remove(musteri);
            db.SaveChanges();
            MessageBox.Show("Veri Silindi");
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt16(textBox1.Text);
            var musteri = db.TblMusteri.Find(index);
            db.TblMusteri.AddOrUpdate(musteri);
            db.SaveChanges();
            MessageBox.Show("Veri Güncellendi");
        }
    }
}
