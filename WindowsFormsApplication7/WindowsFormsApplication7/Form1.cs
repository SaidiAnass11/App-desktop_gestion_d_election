using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection maconnection = new SqlConnection(@"Data Source=DESKTOP-F99O069\SQLEXPRESS;Initial Catalog=DBgestion_election;Integrated Security=True");
        SqlCommand macommande = new SqlCommand();
        private void Form1_Load(object sender, EventArgs e)
        {
            if (maconnection.State != ConnectionState.Open)
            {
                maconnection.Open();
            }
            else
            {
                maconnection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            macommande.Connection = maconnection;
            macommande.CommandText = "select * from Compte where Nom=@Nom and MotPass=@MotPass";
            macommande.Parameters.Clear();
            macommande.Parameters.AddWithValue("@Nom", SqlDbType.VarChar).Value = textBox1.Text;
            macommande.Parameters.AddWithValue("@MotPass", SqlDbType.VarChar).Value = textBox2.Text;
            SqlDataReader DR = macommande.ExecuteReader();
            if (DR.HasRows)
            {
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Le Mot De Pass Ou Email Incorrect");
                return;
            }
            DR.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }
    }
}
