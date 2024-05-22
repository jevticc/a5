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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.a5ConnectionString);
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'a5DataSet.PogledForm2' table. You can move, or remove it, as needed.
            this.pogledForm2TableAdapter.Fill(this.a5DataSet.PogledForm2);

        }
        private void Crtaj()

        {
            try
            {
                chart1.Series[0].Points.Clear();
                int n = dataGridView1.RowCount - 1;
                int[] brojevi = new int[n];
                string[] godine = new string[n];

                for (int i = 0; i < n; i++)
                {
                    brojevi[i] = (int)dataGridView1.Rows[i].Cells[1].Value;
                    godine[i] = dataGridView1.Rows[i].Cells[0].Value.ToString();

                    chart1.Series[0].Points.Add(brojevi[i]);
                    chart1.Series[0].Points[i].AxisLabel = godine[i];
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);

            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'a5DataSet.PogledForm2' table. You can move, or remove it, as needed.
                this.pogledForm2TableAdapter.Fill(this.a5DataSet.PogledForm2);
                Crtaj();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
