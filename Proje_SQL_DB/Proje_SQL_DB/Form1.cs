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

namespace Proje_SQL_DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void BtnUrun_Click(object sender, EventArgs e)
        {
            FrmUrun fr3 = new FrmUrun();
            fr3.Show();
        }

        private void BtnKategori_Click(object sender, EventArgs e)
        {
            FrmKategoriler fr = new FrmKategoriler();
            fr.Show();
        }

        private void BtnMusteri_Click(object sender, EventArgs e)
        {
            FrmMusteri fr2 = new FrmMusteri();
            fr2.Show();
        }
        private void BtnPersonel_Click(object sender, EventArgs e)
        {
            FrmPersonel fr4 = new FrmPersonel();
            fr4.Show();
        }
        private void BtnKasa_Click(object sender, EventArgs e)
        {
            FrmKasa fr5 = new FrmKasa();
            fr5.Show();
        }
        private void BtnIstatistik_Click(object sender, EventArgs e)
        {
            FrmIstatistik fr6 = new FrmIstatistik();
            fr6.Show();
        }



        SqlConnection baglanti = new SqlConnection(@"Data Source = ASUSPC; Initial Catalog = SatisVT; Integrated Security = True");
        private void Form1_Load(object sender, EventArgs e)
        { //Stok Durum
            SqlCommand komut = new SqlCommand("Execute Test4", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Grafik
            //chart1.Series["Akdeniz"].Points.AddXY("Adana", 24);
            //chart1.Series["Akdeniz"].Points.AddXY("Isparta", 21);

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select KATEGORIAD, COUNT(*) FROM TBLKATEGORI INNER JOIN TBLURUNLER ON TBLKATEGORI.KATEGORIID = TBLURUNLER.KATEGORI GROUP BY KATEGORIAD", baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Kategoriler"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();

            //Grafik2
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select MUSTERISEHIR, COUNT(*) FROM TBLMUSTERI GROUP BY MUSTERISEHIR", baglanti);
            SqlDataReader dr1 = komut3.ExecuteReader();
            while (dr1.Read())
            {
                chart2.Series["Şehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
