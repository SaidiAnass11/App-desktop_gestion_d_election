using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace WindowsFormsApplication7
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection maconnection = new SqlConnection(@"Data Source=DESKTOP-F99O069\SQLEXPRESS;Initial Catalog=DBgestion_election;Integrated Security=True");
        SqlCommand macommande = new SqlCommand();
        private void Form7_Load(object sender, EventArgs e)
        {
            if (maconnection.State != ConnectionState.Open)
            {
                maconnection.Open();
            }
            else
            {
                maconnection.Close();
            }
            //Combobox1
            macommande.Connection = maconnection;
            macommande.CommandText = "select distinct Commune from DBelection";
            SqlDataReader DR = macommande.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(DR);
            comboBox1.DataSource = DT;
            comboBox1.DisplayMember = "Commune";
            comboBox1.ValueMember = "Commune";


        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            textBox1.Text = comboBox1.Text;

        }
        
         private void button1_Click(object sender, EventArgs e)
        {
            CrystalReport1 cr1 = new CrystalReport1();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication7.Properties.Settings.DBgestion_electionConnectionString"].ToString();

            TextObject text = (TextObject)cr1.ReportDefinition.Sections["Section1"].ReportObjects["Text11"];
            text.Text = textBox1.Text;
            crystalReportViewer1.ReportSource = cr1;
            string sql = "select * from View_imp order by Num_Electeur";
            //crystalReportViewer1.SelectionFormula = "{select View_imp from DBelection order by Num_Electeur}" + comboBox1.SelectedValue;
            //macommande.Parameters.AddWithValue("@Commune", SqlDbType.NVarChar).Value = comboBox1.SelectedValue;

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

            adapter.Fill(ds, "View_imp");
            DataTable dt = ds.Tables["View_imp"];

            cr1.SetDataSource(ds.Tables["View_imp"]);
            //crystalReport.SetParametreValue();
            crystalReportViewer1.ReportSource = cr1;
            crystalReportViewer1.Refresh();



        }
        //click dans picture accueil est transferer a formule accueil
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {
            //this.crystalReportViewer1.RefreshReport();
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
   
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

            //Pour Combobox 2 est liee avec combobox1
            macommande.Connection = maconnection;
            macommande.CommandText = "select distinct Nom_Bureau_Election from DBelection where Commune=@Commune";
            macommande.Parameters.Clear();
            macommande.Parameters.AddWithValue("@Commune", SqlDbType.NVarChar).Value = comboBox1.SelectedValue;
            SqlDataReader DR1 = macommande.ExecuteReader();
            DataTable DT1 = new DataTable();
            DT1.Load(DR1);
            comboBox2.DataSource = DT1;
            comboBox2.DisplayMember = "Nom_Bureau_Election";
            comboBox1.ValueMember = "Commune";
            DR1.Close();
        }
    }
}
