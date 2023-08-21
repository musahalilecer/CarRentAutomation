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
    public partial class FrmMusteriPanel : Form
    {
        public FrmMusteriPanel()
        {
            InitializeComponent();
        }
        RentCarProjectEntities db = new RentCarProjectEntities();
        public void Listele()
        {
            var mercedes = db.TblMercedes.ToList();
            var toyota = db.TblToyota.ToList();
         //   dataGridView1.DataSource = toyota;
            if(cmbMarka.SelectedText == "Mercedes")
            {
                dataGridView1.DataSource = mercedes;
            }
            else if(cmbMarka.SelectedText == "Toyota")
            {
                dataGridView1.DataSource = toyota;
            }
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
        FrmGiris frm = new FrmGiris();
        private void FrmMusteriPanel_Load(object sender, EventArgs e)
        {
            cmbMarka.Items.Add("Mercedes");
            cmbMarka.Items.Add("Toyota");
            cmbMarka.Items.Add("Audi");
            cmbMarka.Items.Add("Volkswagen");
            cmbMarka.Items.Add("Honda");
            cmbMarka.Items.Add("Ford");
            cmbMarka.Items.Add("BMW");
            cmbMarka.Items.Add("Renault");


            txtAd.Text = frm.MusteriAd;
            txtSoyad.Text = frm.MusteriSoyad;
            txtTc.Text = frm.MusteriTc;
            if (frm.MusteriCinsiyet == true)
            {
                radioButton1.Checked = true;
            }
            else if (frm.MusteriCinsiyet == false)
            {
                radioButton2.Checked = true;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var sorgu = cmbMarka.Text;
            if(sorgu == "Mercedes")
            {
                TblMercedes mercedes = new TblMercedes();
                mercedes.ArabaModel = txtModel.Text;
                mercedes.ArabaFiyat = txtFiyat.Text;
                mercedes.ArabaYil = Convert.ToDateTime(txtYil.Text);
                mercedes.ArabaCategory = txtkategori.Text;
                db.TblMercedes.Add(mercedes);
                db.SaveChanges();
                MessageBox.Show("Veri Eklendi");
            }
            else if (sorgu == "Toyota")
            {
                TblToyota toyota = new TblToyota();
                toyota.ArabaModel = txtModel.Text;
                toyota.ArabaFiyat = txtFiyat.Text;
                toyota.ArabaCategory = txtkategori.Text;
                toyota.ArabaYil = Convert.ToDateTime(txtYil.Text);
                db.TblToyota.Add(toyota);
                db.SaveChanges();
                MessageBox.Show("Veri Eklendi");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var sorgu = cmbMarka.Text;
            if(sorgu == "Mercedes")
            {   
                int index1 = Convert.ToInt16(txtId.Text);
                var mercedes = db.TblMercedes.Find(index1);
                db.TblMercedes.Remove(mercedes);
                db.SaveChanges();
            }
            else if(sorgu == "Toyota")
            {
                int index2 = Convert.ToInt16(txtId.Text);
                var toyota = db.TblToyota.Find(index2);
                db.TblToyota.Remove(toyota);
                db.SaveChanges();
            }
            MessageBox.Show("Veri Silindi");

        }
    }
}
