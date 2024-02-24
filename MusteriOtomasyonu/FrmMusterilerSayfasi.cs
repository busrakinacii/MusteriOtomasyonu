using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MusteriOtomasyonu
{
    public partial class FrmMusterilerSayfasi : Form
    {
        public FrmMusterilerSayfasi()
        {
            InitializeComponent();
        }
        connect bgl = new connect();
        void list()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Musteriler", bgl.conn());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void FrmMusterilerSayfasi_Load(object sender, EventArgs e)
        {
            list();
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int chosen = dataGridView1.SelectedCells[0].RowIndex;

            FrmMusteriBilgileriDuzenleme fr = new FrmMusteriBilgileriDuzenleme();
            fr.id = dataGridView1.Rows[chosen].Cells[0].Value.ToString();
            fr.name = dataGridView1.Rows[chosen].Cells[1].Value.ToString();
            fr.phone = dataGridView1.Rows[chosen].Cells[2].Value.ToString();
            fr.adress = dataGridView1.Rows[chosen].Cells[3].Value.ToString();
            fr.complaint = dataGridView1.Rows[chosen].Cells[4].Value.ToString();
            fr.date = dataGridView1.Rows[chosen].Cells[5].Value.ToString();
            fr.price = dataGridView1.Rows[chosen].Cells[6].Value.ToString();

            fr.Show();
            this.Hide();

        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            SqlCommand conn = new SqlCommand("Select * From Tbl_Musteriler where MusteriTel like '%" + MskTel.Text + "%'", bgl.conn());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            MskTel.Text = "";
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            list();
        }

        private void BtnAra2_Click(object sender, EventArgs e)
        {
            SqlCommand conn = new SqlCommand("Select * From Tbl_Musteriler where MusteriAdSoyad=@p1", bgl.conn());
            conn.Parameters.AddWithValue("@p1", TxtAdSoyad.Text);
            //conn.Parameters.AddWithValue("@p2", TxtAdSoyad.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            TxtAdSoyad.Text = "";
        }
    }
}
