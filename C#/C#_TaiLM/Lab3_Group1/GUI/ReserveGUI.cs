using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lab3_Group1.DAL;

using System.Data.SqlClient;

using Lab3_Group1.BLL;
using Lab3_Group1.DTL;
namespace Lab3_Group1.GUI
{
    public partial class ReserveGUI : Form
    {
        public ReserveGUI()
        {
            InitializeComponent();
        }

        private void buttonReserveCheckMember_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(tbMemberID.Text);
                string s;
                s = ReservationDA.GetMemberName(id);
                if (s != null)
                {

                    tbMembername.Text = s;
                    tbBookID.Enabled = true;
                    buttonReserveCondition.Enabled = true;

                    DataSet ds = ReservationDA.SelectDS();
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.RowFilter = "borrowerNumber = " + id;
                    label2.Text = dv.Count.ToString();
                    dataGridView1.DataSource = dv;
                }

                else
                {
                    MessageBox.Show("Member Code doesn't Exist ");
                    tbMemberID.Text = "";
                    tbMemberID.Focus();
                    tbMembername.Text = "";
                }
            }
            catch (Exception EX){ }
        }

        private void buttonReserveCondition_Click(object sender, EventArgs e)
        {
            int memID = 0;
            int bookID = 0;
            try
            {
                 memID = int.Parse(tbMemberID.Text);
                 bookID = int.Parse(tbBookID.Text);
           
            int k = ReserveBL.check(memID,bookID);
            switch (k)
            {
                case 2: {
                        MessageBox.Show("Book Number doesn't Exist");
                        tbBookID.Text = "";
                        tbBookID.Focus();
                        break; 
                    }
                case 3: {
                        MessageBox.Show("One user can only reserve 1 book");
                        tbBookID.Text = "";
                        tbBookID.Focus();
                        break; 
                    }
                case 4:{
                        MessageBox.Show("Book still has available copy");
                        tbBookID.Text = "";
                        tbBookID.Focus();
                        break;
                    }
                case 5: { 
                        MessageBox.Show("Book is only referenced");
                        tbBookID.Text = "";
                        tbBookID.Focus();
                        break; 
                }
                case 1:
                    { 
                        MessageBox.Show("Ok.U can now click 'Reserve' button to reserve");
                        tbDate.Text = DateTime.Now.ToShortDateString();
                        btReserve.Enabled = true; 
                        break; 
                    }
            }
            }
            catch (Exception EX)
            { }
        }

        private void btReserve_Click(object sender, EventArgs e)
        {
            label2.Text = "1";
            int memID= int.Parse(tbMemberID.Text);
            int bookID=int.Parse(tbBookID.Text);
            Reservation c = new Reservation(memID,bookID,DateTime.Now,'R');
            ReservationDA.Insert(c);
            DataSet ds = ReservationDA.SelectDS();
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter="borrowerNumber="+memID + "And status='R'";            
            dataGridView1.DataSource=dv;
        }
        
    }
}
