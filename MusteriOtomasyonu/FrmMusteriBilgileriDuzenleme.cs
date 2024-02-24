using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusteriOtomasyonu
{
    public partial class FrmMusteriBilgileriDuzenleme : Form
    {
        public FrmMusteriBilgileriDuzenleme()
        {
            InitializeComponent();
        }

        connect bgl = new connect();

        public string id;
        public string name;
        public string phone;
        public string adress;
        public string complaint;
        public string date;
        public string price;
  
        private void FrmMusteriBilgileriDuzenleme_Load(object sender, EventArgs e)
        {
            Txtid.Text = id;
            TxtAd.Text = name;
            MskTel.Text = phone;
            RchAdres.Text = adress;
            RchSikayet.Text = complaint;
            MskTarih.Text = date;
            TxtFiyat.Text = price;
           
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Müşteri Kaydını Silmek İstediğinize Emin Misiniz?.", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result1 == DialogResult.Yes)
            {
                try
                {
                    SqlCommand code = new SqlCommand("Delete From Tbl_Musteriler where Musteriid=@p1", bgl.conn());
                    code.Parameters.AddWithValue("@p1", Txtid.Text);
                    code.ExecuteNonQuery();
                    bgl.conn().Close();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.ToString());
                }

                MessageBox.Show("Müşteri Kaydı Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kayıt Silinememiştir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Hide();
            }


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text == "" || MskTel.Text== "" || RchAdres.Text=="" || RchSikayet.Text=="" || MskTarih.Text=="" || TxtFiyat.Text=="")
            {
                MessageBox.Show("Lütfen Verileri Eksiksik Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    SqlCommand code = new SqlCommand("update Tbl_Musteriler set MusteriAdSoyad=@m1,MusteriTel=@m2,MusteriAdres=@m3,MusteriSikayet=@m4,MusteriTarih=@m5,MusteriFiyat=@m6 where Musteriid=@m7", bgl.conn());
                    code.Parameters.AddWithValue("@m1", TxtAd.Text);
                    code.Parameters.AddWithValue("@m2", MskTel.Text);
                    code.Parameters.AddWithValue("@m3", RchAdres.Text);
                    code.Parameters.AddWithValue("@m4", RchSikayet.Text);
                    code.Parameters.AddWithValue("@m5", MskTarih.Text);
                    code.Parameters.AddWithValue("@m6", TxtFiyat.Text);
                    code.Parameters.AddWithValue("@m7", Txtid.Text);
                    code.ExecuteNonQuery();
                    bgl.conn().Close();
                    MessageBox.Show("Bilgileriniz Güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    FrmMusterilerSayfasi fr=new FrmMusterilerSayfasi();
                    fr.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Müşteri Kaydı Güncellenememiştir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
           

        }

    }
}
