using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SM_project.Class;
using SM_project.Data.Access;

namespace SM_project.GUI
{
    public partial class SellGUI : Form
    {
        List<ProductCL> ware;
        LoginCL login;
        int TradingCode = 0;
        double totalCost = 0;
        int DiscountMode = 0;
        int CustomerMode = 0;

        public SellGUI()
        {
            InitializeComponent();
            loadData();
            ware = SelectDA.getAllProductSell();
            TradingCode = SelectDA.GetMax("OrderID", "Orders") + 1;
            txtTradingCode.Text = TradingCode + "";
            txtReceive.LostFocus += new EventHandler(txtReceive_LostFocus);
        }

        public SellGUI(LoginCL log)
            : this()
        {
            this.login = log;
            txtSeller.Text = login.User;
        }
        private void loadData()
        {
            Timer tm = new Timer();
            tm.Interval = 60000;
            tm.Tick += new EventHandler(tm_Tick);
            tm.Start();
            txtTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
        private void tm_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private bool checkValid()
        {
            int ID, quantity = 0, discount = 0, cusID = -1;
            bool ready1, ready2 = false, ready3 = false, ready4, ready5;
            try
            {
                ID = int.Parse(txtProductCode.Text.Trim());
                ready1 = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong type of Product ID ! Check your Input");
                ready1 = false;
            }

            try
            {
                quantity = int.Parse(txtQuantity.Text.Trim());
                ready2 = true;
                if (quantity <= 0)
                {
                    MessageBox.Show("Quantity must be integer and greater than 0");
                    txtQuantity.Focus();
                    ready3 = false;
                }
                else
                {
                    ready3 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong type of Quantity ! Check your Input");
                txtQuantity.Focus();
                ready2 = false;
            }


            try
            {
                cusID = int.Parse(txtCustomer.Text.Trim());
                ready5 = true;
            }
            catch (Exception ex)
            {
                ready5 = false;
            }
            if (ready1 && ready2 && ready3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void CalTotalCost()
        {
            totalCost = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                double cost = (double)dataGridView1.Rows[i].Cells[5].Value;
                totalCost += cost;
            }
            txtTotalCost.Text = totalCost + "";
        }
        private void CalDiscount()
        {
            int di = int.Parse(txtDiscount.Text.Trim());
            double afterDiscount = totalCost - ((totalCost / 100) * di);
            txtAfterDiscount.Text = afterDiscount + "";
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            int ID = 0, quantity = 0, discount = 0, cusID = -1;

            if (checkValid() == true)
            {
                ID = int.Parse(txtProductCode.Text);
                quantity = int.Parse(txtQuantity.Text);
                bool exist = false;
                for (int i = 0; i < ware.Count; i++)
                {
                    if (ID == ware[i].ProductID)
                    {
                        bool dup = false;
                        exist = true;
                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            int id = int.Parse(dataGridView1.Rows[j].Cells[0].Value.ToString());
                            if (ID == id)
                            {
                                dup = true;
                                int qua = int.Parse(dataGridView1.Rows[j].Cells[4].Value.ToString());
                                qua += quantity;
                                dataGridView1.Rows[j].Cells[4].Value = qua;
                                double totalDup = ware[i].Price * qua;
                                dataGridView1.Rows[j].Cells[5].Value = totalDup;
                                CalTotalCost();
                                if (checkDiscount())
                                {
                                    CalDiscount();
                                }
                                break;
                            }
                        }
                        if (dup == false)
                        {
                            double total = ware[i].Price * quantity;
                            dataGridView1.Rows.Add(new object[] { ware[i].ProductID, ware[i].ProductName, ware[i].SupplierName, ware[i].Price, quantity, total });
                            txtQuantity.Text = "1";
                            totalCost += total;
                            txtTotalCost.Text = totalCost + "";
                            if (checkDiscount())
                            {
                                discount = int.Parse(txtDiscount.Text);
                                double afterDiscount = totalCost - ((totalCost * discount) / 100);
                                txtAfterDiscount.Text = afterDiscount + "";
                            }
                            break;
                        }
                    }

                }
                if (exist == false)
                {
                    MessageBox.Show("Invalid Product ID ! Check your Input");
                }
            }
            txtProductCode.Text = "";
            txtProductCode.Focus();
        }

        private bool checkCustomer()
        {
            try
            {
                int a = int.Parse(txtCustomer.Text);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Customer ID must be integer ! Check your input");
                txtCustomer.Focus();
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CustomerMode == 0)
            {
                btCus.Text = "Apply";
                btAdd.Enabled = false;
                btClear.Enabled = false;
                btComplete.Enabled = false;
                btDiscount.Enabled = false;

                txtCustomer.Enabled = true;
                CustomerMode = 1;
            }
            else
            {
                btAdd.Enabled = true;
                btClear.Enabled = true;
                btComplete.Enabled = true;
                btDiscount.Enabled = true;
                bool isCus = SelectDA.isCustomer(int.Parse(txtCustomer.Text));
                if (checkCustomer())
                {
                    if (!isCus)
                    {
                        MessageBox.Show("Can not found any customer have ID  = " + txtCustomer.Text);
                    }
                    else
                    {
                        txtDiscount.Text = (SelectDA.getDiscount(int.Parse(txtCustomer.Text))) + "";
                        CalDiscount();
                        btCus.Text = "Edit Customer ID";
                        txtCustomer.Enabled = false;
                        CustomerMode = 0;
                    }
                }
            }
        }

        private bool checkDiscount()
        {
            int discount = -1;
            bool ready = false;
            try
            {
                discount = int.Parse(txtDiscount.Text.Trim());
                ready = true;
                if (discount > 100 || discount < 0)
                {
                    ready = false;
                    MessageBox.Show("Value of discount must be in rage 0 to 100");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong type of discount");
                ready = false;
            }
            return ready;
        }

        private bool checkReceive()
        {
            int receive = -1;
            bool ready = false;
            try
            {
                receive = int.Parse(txtDiscount.Text.Trim());
                ready = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong type of receive");
                ready = false;
            }
            return ready;
        }

        private void txtReceive_LostFocus(object sender, EventArgs e)
        {
            int receive = 0;
            int refund = 0;
            int cost = int.Parse(txtAfterDiscount.Text);
            if (checkReceive())
            {
                receive = int.Parse(txtReceive.Text);
                refund = receive - cost;
                txtRefund.Text = refund + "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DiscountMode == 0)
            {
                btDiscount.Text = "Apply";

                btAdd.Enabled = false;
                btClear.Enabled = false;
                btComplete.Enabled = false;
                btCus.Enabled = false;
                txtDiscount.Enabled = true;
                DiscountMode = 1;

            }
            else
            {
                btAdd.Enabled = true;
                btClear.Enabled = true;
                btComplete.Enabled = true;
                btCus.Enabled = true;
                if (checkDiscount())
                {
                    int dis = int.Parse(txtDiscount.Text);
                    int cost = int.Parse(txtTotalCost.Text);
                    CalDiscount();
                    txtDiscount.Enabled = false;
                    DiscountMode = 0;
                    btDiscount.Text = "Edit";
                }
            }
        }

        private void setToDefault()
        {
            dataGridView1.Rows.Clear();
            txtCustomer.Text = "10";
            txtDiscount.Text = "0";
            txtQuantity.Text = "1";
            txtRefund.Text = "";
            txtReceive.Text = "";
            txtAfterDiscount.Text = "";
            txtTotalCost.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Clear all data in this table ?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                setToDefault();
            }
            else { }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalTotalCost();
            if (checkDiscount())
            {
                CalDiscount();
            }
        }

        private void btComplete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int tradingCode = int.Parse(txtTradingCode.Text);
                int empId = SelectDA.getEmpID(txtSeller.Text);
                int cusID = int.Parse(txtCustomer.Text);
                int dis = int.Parse(txtDiscount.Text);
                OrderCL or = new OrderCL(tradingCode, cusID, empId, dis);
                InsertDA.InsertOrder(or);

                int proID = 0, quan = 0, pri = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    proID = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    quan = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    pri = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    OrderDetailCL orDe = new OrderDetailCL(tradingCode, proID, quan, pri);
                    InsertDA.InsertOrderDetail(orDe);
                }
                tradingCode++;
                txtTradingCode.Text = tradingCode + "";
                setToDefault();
            }
            else
            {
                MessageBox.Show("Input product to sell !");
            }
        }

    }
}
