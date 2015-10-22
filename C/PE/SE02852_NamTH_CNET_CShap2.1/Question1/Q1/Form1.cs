using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Q1
{
    public partial class Form1 : Form
    {
        private Hashtable toughnessList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toughnessList = new Hashtable();
            SqlConnection cn = GetConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Toughness", cn);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                int ID = int.Parse(row["toughnessID"].ToString());
                String toughness = row["Toughness"].ToString();
                toughnessList.Add(ID, toughness);
                cbToughness.Items.Add(toughness);
            }
            cbToughness.SelectedIndex = 0;
        }

        private SqlConnection GetConnection()
        {
            SqlConnection result = new SqlConnection();
            SqlConnectionStringBuilder connectString = new SqlConnectionStringBuilder();
            connectString.DataSource = "IBRAHIM";
            connectString.IntegratedSecurity = true;
            connectString.InitialCatalog = "Y12S1B3";
            result.ConnectionString = connectString.ToString();
            result.Open();
            return result;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            String name = tbName.Text.Trim();
            String speed = tbSpeed.Text.Trim();
            String note = tbNote.Text.Trim();
            String cost = tbCost.Text.Trim();

            if (name.Length == 0 || speed.Length == 0 ||
                note.Length == 0 || cost.Length == 0)
            {
                MessageBox.Show("Must input values for all textboxes!");
            }

            int nCost;
            try
            {
                nCost = int.Parse(cost);
                if (nCost < 50 || nCost > 350)
                {
                    MessageBox.Show("Cost must between 50 and 350");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cost must be integer!");
                return;
            }

            SqlConnection cn = GetConnection();
            int toughnessID = 0;
            foreach (DictionaryEntry d in toughnessList) {
                if (d.Value.ToString().CompareTo(cbToughness.SelectedText) == 0) {
                    toughnessID = int.Parse(d.Key.ToString());
                }
            }
            String sql = "insert into Zombies values (N'" + name + "', " + toughnessID + ", N'" + speed + "', N'" + note + "', " + nCost + ")";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("New information of Zombie is added!");
        }
    }
}
