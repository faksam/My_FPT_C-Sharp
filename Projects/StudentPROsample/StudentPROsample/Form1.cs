using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace StudentPROsample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlDataAdapter da;
        DataSet ds;
        IEnumerator i;

        private void button1_Click(object sender, EventArgs e)
        {
             da = new SqlDataAdapter("select  RollNo,major,FullName,Name,Nationality from class, semester,student",App.ConectionString);
            //da = new SqlDataAdapter( "Select Student.RollNo,Class.ClassCode,FullName, "
                  //  + "Nationality,Batch,Major,SemesterId,SemesterNo,Status "
                  //  + " From Student,StudentStatus,Class Where (Class.Major AND StudentStatus.SemesterNo "
                  //  + " AND StudentStatus.Status AND Class.ClassCode=Student.ClassCode AND Student.RollNo=StudentStatus.RollNo );",App.ConectionString);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            i = ds.Tables[0].Rows.GetEnumerator();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rows = ds.Tables[0].Rows.Count;
            MessageBox.Show("No. of Rows are : " + rows.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cols = ds.Tables[0].Columns.Count;

            MessageBox.Show("No. of columns are : " + cols.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            i.MoveNext();
            textBox1.Text = ((DataRow)i.Current)[0].ToString();
            textBox2.Text = ((DataRow)i.Current)[1].ToString();
            textBox3.Text = ((DataRow)i.Current)[2].ToString();
            textBox4.Text = ((DataRow)i.Current)[3].ToString();
            textBox5.Text = ((DataRow)i.Current)[4].ToString();
            textBox6.Text = ((DataRow)i.Current)[5].ToString();
            textBox7.Text = ((DataRow)i.Current)[6].ToString();
            textBox8.Text = ((DataRow)i.Current)[7].ToString();
            textBox9.Text = ((DataRow)i.Current)[8].ToString();

        }
    }
}
