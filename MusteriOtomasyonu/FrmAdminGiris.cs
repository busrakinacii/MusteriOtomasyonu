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

namespace MusteriOtomasyonu
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }
        connect bgl = new connect();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand code = new SqlCommand("Select * from Tbl_Admin where AdminKullaniciAdi=@p1 and AdminSifre=@p2", bgl.conn());
            code.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
            code.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = code.ExecuteReader();
            if (dr.Read())
            {
                FrmMusteriGirisSayfasi fr = new FrmMusteriGirisSayfasi();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Yada Şifre Hatalı! \n Bilgilerinizi Kontrol Ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
