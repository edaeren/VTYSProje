using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;


namespace sanatGalerisi1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=ArtGallery;User Id=postgres;password=leviroki55");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into \"SanatEseri\" (\"eserNo\",\"eserAdi\",\"teknik\",\"turKodu\",\"sanatciNo\",\"donemNo\") values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(TxteserNo.Text));
            komut1.Parameters.AddWithValue("@p2", TxteserAdi.Text);
            komut1.Parameters.AddWithValue("@p3", TxteserTeknigi.Text);
            komut1.Parameters.AddWithValue("@p4", int.Parse(TxtturKodu.Text));
            komut1.Parameters.AddWithValue("@p5", int.Parse(TxtsanatciNo.Text));
            komut1.Parameters.AddWithValue("@p6", int.Parse(TxtdonemNo.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Eser ekleme islemi basarili.");
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            
            string sorgu = "select * from \"SanatEseri\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From \"SanatEseri\" where \"eserNo\"=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(TxteserNo.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Urun silme islemi basarili.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("Update \"SanatEseri\" set \"eserAdi\"=@p2,\"teknik\"=@p3,\"turKodu\"=@p4,\"sanatciNo\"=@p5,\"donemNo\"=@p6 where \"eserNo\"=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(TxteserNo.Text));
            komut3.Parameters.AddWithValue("@p2", TxteserAdi.Text);
            komut3.Parameters.AddWithValue("@p3", TxteserTeknigi.Text);
            komut3.Parameters.AddWithValue("@p4", int.Parse(TxtturKodu.Text));
            komut3.Parameters.AddWithValue("@p5", int.Parse(TxtsanatciNo.Text));
            komut3.Parameters.AddWithValue("@p6", int.Parse(TxtdonemNo.Text));
            komut3.ExecuteNonQuery();
            MessageBox.Show("Urun guncelleme islemi basarili.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TxteserNo.Text != string.Empty) {
                baglanti.Open();
                string sorgu = "Select * From \"SanatEseri\" where \"eserNo\" =" + TxteserNo.Text;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                baglanti.Close();
            }

            if (TxteserAdi.Text != string.Empty) {
                baglanti.Open();
                string sorgu2 = "Select * From \"SanatEseri\" where \"eserAdi\" " + "Like '%" + TxteserAdi.Text + "%'";
                NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView1.DataSource = ds2.Tables[0];
                baglanti.Close();
            }

            if (TxteserTeknigi.Text != string.Empty) {
                baglanti.Open();
                string sorgu3 = "Select * From \"SanatEseri\" where \"teknik\" " + "Like '%" + TxteserTeknigi.Text + "%'";
                NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, baglanti);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                dataGridView1.DataSource = ds3.Tables[0];
                baglanti.Close();
            }

            if (TxtturKodu.Text != string.Empty) {
                baglanti.Open();
                string sorgu4 = "Select * From \"SanatEseri\" where \"turKodu\"= " + TxtturKodu.Text;
                NpgsqlDataAdapter da4 = new NpgsqlDataAdapter(sorgu4, baglanti);
                DataSet ds4 = new DataSet();
                da4.Fill(ds4);
                dataGridView1.DataSource = ds4.Tables[0];
                baglanti.Close();
            }

            if (TxtsanatciNo.Text != string.Empty) {
                baglanti.Open();
                string sorgu5 = "Select * From \"SanatEseri\" where \"sanatciNo\"= " + TxtsanatciNo.Text;
                NpgsqlDataAdapter da5 = new NpgsqlDataAdapter(sorgu5, baglanti);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5);
                dataGridView1.DataSource = ds5.Tables[0];
                baglanti.Close();
            }

            if (TxtdonemNo.Text != string.Empty) {
                baglanti.Open();
                string sorgu6 = "Select * From \"SanatEseri\" where \"donemNo\"= " + TxtdonemNo.Text;
                NpgsqlDataAdapter da6 = new NpgsqlDataAdapter(sorgu6, baglanti);
                DataSet ds6 = new DataSet();
                da6.Fill(ds6);
                dataGridView1.DataSource = ds6.Tables[0];
                baglanti.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sorgu7 = "select * from \"eserDegisiklikIzle\"";
            NpgsqlDataAdapter da7 = new NpgsqlDataAdapter(sorgu7, baglanti);
            DataSet ds7 = new DataSet();
            da7.Fill(ds7);
            dataGridView1.DataSource = ds7.Tables[0];
        }
    }
}
