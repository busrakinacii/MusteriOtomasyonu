using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace MusteriOtomasyonu
{
    public partial class FrmMusteriGirisSayfasi : Form
    {
        public FrmMusteriGirisSayfasi()
        {
            InitializeComponent();
        }
        connect bgl = new connect();

        void clean()
        {
            TxtAd.Text = "";
            MskTel.Text = "";
            RchAdres.Text = "";
            RchSikayet.Text = "";
            MskTarih.Text = "";
            TxtFiyat.Text = "";

;        }
        private void BtnMusteriler_Click(object sender, EventArgs e)
        {
            FrmMusterilerSayfasi fr = new FrmMusterilerSayfasi();
            fr.Show();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text == "" || MskTel.Text== "" || RchAdres.Text=="" || RchSikayet.Text=="" || MskTarih.Text=="" || TxtFiyat.Text=="")
            {
                MessageBox.Show("Kayıt Gerçekleştirilemedi. \nLütfen Değerleri Eksiksiz Olarak Doldurunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {

                    SqlCommand code = new SqlCommand("insert into Tbl_Musteriler (MusteriAdSoyad,MusteriTel,MusteriAdres,MusteriSikayet,MusteriTarih,MusteriFiyat) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.conn());
                    code.Parameters.AddWithValue("@p1", TxtAd.Text);
                    code.Parameters.AddWithValue("@p2", MskTel.Text);
                    code.Parameters.AddWithValue("@p3", RchAdres.Text);
                    code.Parameters.AddWithValue("@p4", RchSikayet.Text);
                    code.Parameters.AddWithValue("@p5", MskTarih.Text);
                    code.Parameters.AddWithValue("@p6", TxtFiyat.Text);
                    code.ExecuteNonQuery();
                    bgl.conn().Close();
                    MessageBox.Show("Kayıt Gerçekleştirilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception)
                {
                    MessageBox.Show("Kayıt Gerçekleştirilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    clean();
                }

            }

        }
    }
}
