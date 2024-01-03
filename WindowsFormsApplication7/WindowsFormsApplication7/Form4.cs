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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection maconnection = new SqlConnection(@"Data Source=DESKTOP-F99O069\SQLEXPRESS;Initial Catalog=DBgestion_election;Integrated Security=True");
        SqlCommand macommande = new SqlCommand();
        private void Form4_Load(object sender, EventArgs e)
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
            try
            {
                if (textBox1.Text == "")
                {
                    textBox1.Focus();
                    throw new Exception("REMPLIR LE NOM D'ADMIN");
                }
                if (textBox2.Text == "")
                {
                    textBox2.Focus();
                    throw new Exception("REMPLIR LE MOTPASS D'ADMIN");
                }
                if (textBox4.Text == "")
                {
                    textBox4.Focus();
                    throw new Exception("REMPLIR LE NOM DE NV ADMIN");
                }
                if (textBox3.Text == "")
                {
                    textBox3.Focus();
                    throw new Exception("REMPLIR LE MOTPASS DE NV ADMIN");
                }
                macommande.Connection = maconnection;
                macommande.CommandText = "select * from Compte where NomC=@NomC and MotPassC=@MotPassC";
                macommande.Parameters.Clear();
                macommande.Parameters.AddWithValue("@NomC", SqlDbType.VarChar).Value = textBox1.Text;
                macommande.Parameters.AddWithValue("@MotPassC", SqlDbType.VarChar).Value = textBox2.Text;
                SqlDataReader DR9 = macommande.ExecuteReader();
                if (DR9.HasRows)
                {
                    macommande.Connection = maconnection;
                    macommande.CommandText = "update Compte set NomC=@NomC , MotPassC=@MotPassC where NomC=@NomC and MotPassC=@MotPassC";
                    macommande.Parameters.Clear();
                    macommande.Parameters.AddWithValue("@NomC", SqlDbType.VarChar).Value = textBox1.Text;
                    macommande.Parameters.AddWithValue("@MotPassC", SqlDbType.VarChar).Value = textBox2.Text;
                    macommande.Parameters.AddWithValue("@NomC", SqlDbType.VarChar).Value = textBox4.Text;
                    macommande.Parameters.AddWithValue("@MotPassC", SqlDbType.VarChar).Value = textBox3.Text;
                    DR9.Close();
                    int I = macommande.ExecuteNonQuery();
                    if (I != 0)
                    {
                        MessageBox.Show("Changement effectué");
                        Form2 f2 = new Form2();
                        f2.Show();
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Changement non validé");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox4.Clear();
                        textBox3.Clear();
                    }
                }
                else
                {

                    string message = "Nom admin ou mot de pass incorrect";
                    string title = "Warning";
                    MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    if (result == DialogResult.Cancel)
                    {
                        this.Close();
                    }

                    else
                    {
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox4.Clear();
                        textBox3.Clear();
                    }
                }

                DR9.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox3.UseSystemPasswordChar = true;
            }
            else
            {
                textBox3.UseSystemPasswordChar = false;
            }
        }


    }
}
