using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Data.OleDb;


namespace WindowsFormsApplication7
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection maconnection = new SqlConnection(@"Data Source=DESKTOP-F99O069\SQLEXPRESS;Initial Catalog=DBgestion_election;Integrated Security=True");
        SqlCommand macommande = new SqlCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            if (OpenFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox1.Text = OpenFileDialog1.FileName;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox2.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(PathConn);

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from ["+ textBox2.Text+"$]",conn);
            DataTable dt = new DataTable();

            myDataAdapter.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlDataReader DR1 = macommande.ExecuteReader();
            DataTable DT1 = new DataTable();
            DT1.Load(DR1);
            dataGridView1.DataSource = DT1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
