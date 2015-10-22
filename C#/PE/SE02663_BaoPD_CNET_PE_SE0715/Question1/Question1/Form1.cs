using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Question1
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Y12S2B1;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            Load_comboBox();
            cbFrame.SelectedIndex = 1;
        }

        private void Load_comboBox()
        {
            SqlCommand cmd = new SqlCommand("select * from Frames", con);
            SqlDataReader dr;
            List<ComboBoxItem> cbi = new List<ComboBoxItem>();
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ComboBoxItem cb = new ComboBoxItem();
                        cb.value = int.Parse(dr[0].ToString());
                        cb.Text = dr[1].ToString();
                        cbi.Add(cb);
                    }
                    //cbFrame.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                for (int i = 0; i < cbi.Count; i++)
                {
                    cbFrame.Items.Add(cbi[i]);
                }
            }
        }
        private bool checkDigit(string x)
        {
            bool valid = false;
            try
            {
                double a = double.Parse(x);
                valid = true;
                if (a > 0)
                {
                    valid = true;
                }
                else
                {
                    MessageBox.Show("Weight must greater than 0");
                    valid = false;
                }
            }
            catch (Exception)
            {
                valid = false;
                MessageBox.Show("Weight is not a numberic ! Please try again");
            }
            return valid;
        }

        private bool checkInt(string x)
        {
            bool valid = false;
            try
            {
                int a = int.Parse(x);
                valid = true;
                if (a > 0)
                {
                    valid = true;
                }
                else
                {
                    MessageBox.Show("Wheelbase must greater than 0");
                    valid = false;
                }
            }
            catch (Exception)
            {
                valid = false;
                MessageBox.Show("Wheelbase is not a integer ! Please try again");
            }
            return valid;
        }

        public int GetMax(string attribute, string table)
        {
            int max = 0;
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select Max(" + attribute + ")from " + table, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    try
                    {
                        max = int.Parse(dr[0].ToString());
                    }
                    catch (Exception)
                    {
                        max = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return max;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            bool valid = true;
            if (txtModel.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please input value for Model field !");
                valid = true;
                return;
            }
            if (txtDimen.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please input value for Dimension field !");
                valid = true;
                return;
            }
            if (txtWeight.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please input value for Weight field !");
                valid = true;
                return;
            }
            if (txtWhelbase.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please input value for Wheelbase field !");
                valid = true;
                return;
            }
            if (valid)
            {
                int ID = GetMax("BikeID", "Bikes")+1;
                int frame = ((ComboBoxItem)cbFrame.SelectedItem).value;
                string model = txtModel.Text;
                string dimens = txtDimen.Text;
                string weight = txtWeight.Text;
                string wheelbase = txtWhelbase.Text;
                if (checkDigit(weight) && checkInt(wheelbase))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT [dbo].[Bikes] On insert into Bikes(BikeID,Model,FrameID,Dimensions,Weight,Wheelbase) "
                            +"values (@BikeID,@Model,@FrameID,@Dimensions,@Weight,@Wheelbase) SET IDENTITY_INSERT [dbo].[Bikes] Off", con);
                        cmd.Parameters.AddWithValue("@BikeID", ID);
                        cmd.Parameters.AddWithValue("@Model", model);
                        cmd.Parameters.AddWithValue("@FrameID", frame);
                        cmd.Parameters.AddWithValue("@Dimensions", dimens);
                        cmd.Parameters.AddWithValue("@Weight", weight);
                        cmd.Parameters.AddWithValue("@Wheelbase", wheelbase);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("New information of Bike is added");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }

    public class ComboBoxItem
    {
        public int value;
        public string Text;

        public ComboBoxItem()
        {
        }

        public ComboBoxItem(int value, string text)
        {
            this.value = value;
            this.Text = text;
        }
        public override string ToString()
        {
            return this.Text;
        }
    }
}
