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

namespace SE0715_Group1_Lab3
{
    public partial class ReserveUI : Form
    {

        public ReserveUI()
        {
            InitializeComponent();
            txtBookNumber.Enabled = false;
            txtName.Enabled = false;
            btnCheckReservation.Enabled = false;
            textBox4.Enabled = false;
            button3.Enabled = false;
        }
        //public bool
        int memcode;
        int bookcode;
        private void btnCheckMember_Click(object sender, EventArgs e)
        {
            try
            {
                memcode = int.Parse(txtMemberCode.Text);
                BorrowBL b = new BorrowBL();
                if (b.checkMember(memcode))
                {
                    txtName.Text = b.showMemberName(memcode);
                    
                }
                else
                {
                    MessageBox.Show("doesn't match with any menber ! Please try again.");
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is OverflowException || ex is ArgumentNullException)
                {
                    MessageBox.Show("Wrong input");
                    return;
                }
                else
                    MessageBox.Show("somethings wrong in checkmember funtion");
            }
            txtMemberCode.Enabled = false;
            txtBookNumber.Enabled = true;
            btnCheckReservation.Enabled = true;
            DataSet ds = ReserveBL.selectTableReservation(memcode);
            DataView dv = new DataView(ds.Tables[0]);
            dataGridView1.DataSource = dv;
            label6.Text = "" + ds.Tables[0].Rows.Count;
        }

        private void btnCheckReservation_Click(object sender, EventArgs e)
        {

            try
            {
                BorrowBL b = new BorrowBL();
                bookcode = int.Parse(txtBookNumber.Text);

                if (ReserveBL.checkReservation(bookcode, memcode) && b.checkMember(memcode))
                {
                    txtName.Text = b.showMemberName(bookcode);
                    textBox4.Enabled = true;
                    button3.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is OverflowException || ex is ArgumentNullException)
                {
                    MessageBox.Show("Wrong book number!");
                    return;
                }
                else
                    MessageBox.Show("somethings wrong in checkReservation funtion");
            }
            
        }

        private void ReserveUI_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ok");
            if (txtMemberCode.Text == "")
            {
                txtBookNumber.Enabled = false;
                btnCheckReservation.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime reserveDate = new DateTime();
            try
            {
                reserveDate = GetDate(textBox4.Text.Trim());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Date ! Please try again !");
            }
            Reservation re = new Reservation(memcode, bookcode, reserveDate);
            re.Id = ReserveBL.IDMax() + 1;
            ReserveDA.Insert(re);

            DataSet ds = ReserveBL.selectTableReservation(memcode);
            DataView dv = new DataView(ds.Tables[0]);
            dataGridView1.DataSource = dv;
            label6.Text = "" + ds.Tables[0].Rows.Count;
        }
        public static DateTime GetDate(String s)
        {
            DateTime date;
            String[] time1 = s.Split('/');
            int[] time2 = new int[3];
            for (int i = 0; i < time1.Length; i++)
            {
                time2[i] = int.Parse(time1[i]);
            }
            date = new DateTime(time2[2], time2[1], time2[0]);
            return date;
        }
    }
}
