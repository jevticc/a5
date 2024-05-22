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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       SqlConnection con= new SqlConnection(Properties.Settings.Default.a5ConnectionString);
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("insert into Aktivnosti values (@p1,@p2,@p3,@p4,@p5);", con);
                cm.Parameters.AddWithValue("p1", textBox1.Text);
                cm.Parameters.AddWithValue("p2", textBox2.Text);
                cm.Parameters.AddWithValue("p3", comboBox1.Text);
                cm.Parameters.AddWithValue("p4", textBox3.Text);
                cm.Parameters.AddWithValue("p5", textBox4.Text);
                cm.ExecuteNonQuery(); 
                this.pogledForm1TableAdapter.Fill(this.a5DataSet.PogledForm1);
                kopiraj(this.a5DataSet.PogledForm1, listView1);
                MessageBox.Show("Uspesno dodavanje");
            }
            catch
            {
                MessageBox.Show("Dodavanje nije uspelo");

            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void kopiraj(DataTable dt, ListView LV)
        {
            LV.View = View.Details;
            LV.Columns.Clear();
            foreach (DataColumn col in dt.Columns)
            {
                LV.Columns.Add(col.ColumnName);
            }
            LV.Items.Clear();
            LV.FullRowSelect = true;
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < dt.Columns.Count; i++)
                    item.SubItems.Add(row[i].ToString());
                LV.Items.Add(item);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'a5DataSet.PogledForm1' table. You can move, or remove it, as needed.
            this.pogledForm1TableAdapter.Fill(this.a5DataSet.PogledForm1);
            kopiraj(this.a5DataSet.PogledForm1, listView1);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string ID = listView1.SelectedItems[0].Text;
                textBox1.Text = ID;
                SqlCommand cm = new SqlCommand("select * from PogledForm1 where Sifra=@id", con);
                cm.Parameters.AddWithValue("id", ID);
                SqlDataReader r = cm.ExecuteReader();
                while (r.Read())
                {
                    textBox2.Text = r[1].ToString();
                    comboBox1.Text = r[2].ToString();
                    textBox3.Text = r[3].ToString();
                    textBox4.Text = r[4].ToString();
                }
            }
            catch
            {


            }
            con.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }
    }
}
