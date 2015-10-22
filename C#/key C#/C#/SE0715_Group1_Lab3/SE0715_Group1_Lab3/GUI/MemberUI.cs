using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SE0715_Group1_Lab3.DTL;
using SE0715_Group1_Lab3.DAL;
using SE0715_Group1_Lab3.BLL;
using System.Data.SqlClient;

namespace SE0715_Group1_Lab3
{
    public partial class MemberUI : Form
    {
        int AddSave = 0;
        int EditSave = 0;
        public MemberUI()
        {
            InitializeComponent();
            InitializeMemberData();
        }

        public void InitializeMemberData()
        {
            DataSet ds = MemberBL.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            dataGridView1.DataSource = dv;

            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                textBox1.Text=dataGridView1.Rows[e.RowIndex].Cells["borrowerNumber"].Value.ToString();
                textBox2.Text=dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                textBox3.Text=dataGridView1.Rows[e.RowIndex].Cells["sex"].Value.ToString();
                textBox4.Text=dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
                textBox5.Text=dataGridView1.Rows[e.RowIndex].Cells["telephone"].Value.ToString();
                textBox6.Text=dataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
            } catch(Exception) {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AddSave == 0)
            {
                button2.Text = "Save";
                SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("select max(borrowerNumber) from Borrower", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int member= int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1;
                textBox1.Text = member + "";
                textBox1.Enabled = false;
                textBox2.Text = "";
                textBox2.Enabled = true;
                textBox3.Text = "";
                textBox3.Enabled = true;
                textBox4.Text = "";
                textBox4.Enabled = true;
                textBox5.Text = "";
                textBox5.Enabled = true;
                textBox6.Text = "";
                textBox6.Enabled = true;

                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                AddSave = 1;//Save
            }
            else
            {
                bool fail = false;
                int borNum = new int();
                try
                {
                    borNum = int.Parse(textBox1.Text);
                }
                catch (Exception)
                {
                    memberError.SetError(textBox1, "Wrong input");
                    fail = true;
                }
                string name = textBox2.Text;
                char sex = new char();
                try
                {
                    sex = char.Parse(textBox3.Text);
                    memberError.Clear();
                }
                catch
                {
                    memberError.SetError(textBox3, "Wrong input !");
                    fail = true;
                }
                string address = textBox4.Text;
                string telephone = textBox5.Text;
                string email = textBox6.Text;

                if (sex != 'M' && sex != 'F')
                {
                    memberError.SetError(textBox3, "Sex must be M or F");
                    fail = true;
                }
                else
                {
                    fail = false;
                    memberError.Clear();
                }
                Borrower borrower = new Borrower(borNum,name,sex,address,telephone,email);
                if (fail == false)
                {
                    AddSave = 0;//Add
                    button2.Text = "Add";
                    try
                    {
                        MemberBL.Insert(borrower);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    InitializeMemberData();
                    button1.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim()!="") {
                memberError.Clear();
                String cmd="Select * from Borrower where borrowerNumber = "+textBox1.Text;
                SqlConnection cn=new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                SqlDataAdapter da=new SqlDataAdapter(cmd, cn);
                DataSet ds=new DataSet();
                da.Fill(ds);
                if(ds.Tables[0].Rows.Count==0) {
                    MessageBox.Show("Cannot found any member has member code = "+textBox1.Text);
                } else {
                    DataView dv=new DataView(ds.Tables[0]);
                    dataGridView1.DataSource=dv;
                }
            } else {
                memberError.SetError(textBox1, "This field cannot be blank when filter");
            }
        }

        private bool isSelected()
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return false;
            if (dataGridView1.SelectedRows[0].Cells["borrowerNumber"].Value == null) return false;
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!isSelected())
            {
                MessageBox.Show("Please select a book to edit");
                return;
            }
            if (EditSave == 0)
            {
                button3.Text = "Save";
                textBox1.Enabled = false;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;

                button2.Enabled = false;
                button4.Enabled = false;
                button1.Enabled = false;
                EditSave = 1;//Save
            }
            else
            {
                bool fail = false;
                int borNum = new int();
                try
                {
                    borNum = int.Parse(textBox1.Text);
                }
                catch (Exception)
                {
                    memberError.SetError(textBox1, "Wrong input");
                    fail = true;
                }
                string name = textBox2.Text;
                char sex = new char();
                try
                {
                    sex = char.Parse(textBox3.Text);
                    memberError.Clear();
                }
                catch
                {
                    memberError.SetError(textBox3, "Wrong input !");
                    fail = true;
                }
                string address = textBox4.Text;
                string telephone = textBox5.Text;
                string email = textBox6.Text;

                if (sex != 'M' && sex != 'F')
                {
                    memberError.SetError(textBox3, "Sex must be M or F");
                    fail = true;
                }
                else
                {
                    fail = false;
                    memberError.Clear();
                }
                Borrower borrower = new Borrower(borNum, name, sex, address, telephone, email);
                if (fail == false)
                {
                    
                    button3.Text = "Edit";
                    try
                    {
                        MemberBL.Update(borrower);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    button2.Enabled = true;
                    button4.Enabled = true;
                    button1.Enabled = true;
                    InitializeMemberData();
                    EditSave = 0;//Edit
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!isSelected())
            {
                MessageBox.Show("Please select a member to Delete");
                return;
            }

            Borrower b = new Borrower();
            b.BorrowerNumber = int.Parse(dataGridView1.SelectedRows[0].Cells["borrowerNumber"].Value.ToString());
            DialogResult result = MessageBox.Show("Do you really want to delete this member", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MemberBL.Delete(b);
            }
            else { }
            InitializeMemberData();
        }
    }



}
