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
        public Form1()
        {
            InitializeComponent();
            SqlConnection cn = new SqlConnection("Data Source=KHJ;Initial Catalog=Y12S2B2;Integrated Security=True");
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from ChairTypes order by TypeName ",cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cbType.DataSource = ds.Tables[0];
            cbType.DisplayMember = "TypeName";
            cbType.ValueMember = "TypeID";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            String color;
            String material;            
            double price;
            String description;
            if (tbColor.Text == "")
            {
                MessageBox.Show("Please enter values into color");
            }
            else {
                color = tbColor.Text;
                if (tbMaterial.Text == "") {
                    MessageBox.Show("Please enter values into Material");
                }
                else{
                    material = tbMaterial.Text;
                    if (tbPrice.Text == "")
                    {
                        MessageBox.Show("Please enter values into Price");
                    }
                    else {
                        try
                        {
                            price = double.Parse(tbPrice.Text);
                            if (price <= 0) {
                                Exception ex = new Exception("Please enter price>0");
                                throw ex;
                            }
                            if (tbDescription.Text == "")
                            {
                                MessageBox.Show("Please enter values into Description");
                            }
                            else
                            {
                                try
                                {
                                    description = tbDescription.Text;
                                    SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Y12S2B2;Integrated Security=True");
                                    string sqlcmd = string.Format("insert into Chairs values('{0}','{1}',{2},{3},'{4}')", color, material, int.Parse(cbType.SelectedValue.ToString()), price, description);
                                    SqlCommand cmd = new SqlCommand(sqlcmd, cn);
                                    cn.Open();
                                    cmd.ExecuteNonQuery();
                                    cn.Close();
                                    MessageBox.Show("New information of Chair is added");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        catch (Exception ex) {
                            MessageBox.Show("Price : "+ex.Message);
                        }   
                    }

                }
            }
        }

    }
}
