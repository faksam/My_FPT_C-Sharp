using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SM_project.Class;

namespace SM_project.GUI
{
    public partial class HomeGUI : Form
    {
        LoginGUI form;
        LoginCL login = new LoginCL();
        public HomeGUI()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            lbUserName.Text = login.Lastname;
            lbAccount.Text = login.User;
            if (login.Title.Equals("Admin"))
            {
                lbMode.Text = "Admistrator";
                pictureBox4.Visible = true;
            }
            else
            {
                lbMode.Text = "Employee";
            }
            Timer tmr = new Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();
        }
        public HomeGUI(LoginGUI form, LoginCL login): this()
        {
            this.form = form;
            this.login = login;
            loadData();
            SellGUI sell = new SellGUI(login);
            FillPanel(sell);
        }
        public HomeGUI(LoginGUI form)
            : this()
        {
            this.form = form;
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
        private void tmr_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void FillPanel(Form form)
        {
            panel1.Controls.Clear();
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Visible = true;
            form.Dock = DockStyle.Fill;
            panel1.Controls.Add(form);
            panel1.Show();
        }

        private void lbUserName_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbUserName.Font = new System.Drawing.Font("Lucida Sans", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
        }

        private void lbUserName_MouseLeave(object sender, EventArgs e)
        {
            this.lbUserName.Font = new System.Drawing.Font("Lucida Sans", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
        }

        private void lbSignOut_MouseMove(object sender, MouseEventArgs e)
        {
            lbSignOut.Font = new Font(lbSignOut.Font, FontStyle.Underline);
        }

        private void lbSignOut_MouseLeave(object sender, EventArgs e)
        {
            lbSignOut.Font = new Font(lbSignOut.Font, FontStyle.Regular);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox2.Image = global::SM_project.Properties.Resources.Shopping_cart85;
            lbWellcome.Text = "Sell the product !";
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.Image = global::SM_project.Properties.Resources.Shopping_cart70;
            lbWellcome.Text = "Wellcome to G1 Supermarket System !";
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox1.Image = global::SM_project.Properties.Resources.warehouse_icon85;
            lbWellcome.Text = "List of all product in the warehouse";
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::SM_project.Properties.Resources.warehouse_icon701;
            lbWellcome.Text = "Wellcome to G1 Supermarket System !";
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.Image = global::SM_project.Properties.Resources.customer70;
            lbWellcome.Text = "Wellcome to G1 Supermarket System !";
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox3.Image = global::SM_project.Properties.Resources.customer85;
            lbWellcome.Text = "Information of patrons !";
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = global::SM_project.Properties.Resources.account70;
            lbWellcome.Text = "Wellcome to G1 Supermarket System !";
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox4.Image = global::SM_project.Properties.Resources.account85;
            lbWellcome.Text = "Administrator Panel ";
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox5.Image = global::SM_project.Properties.Resources.statistic70;
            lbWellcome.Text = "Wellcome to G1 Supermarket System !";
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox5.Image = global::SM_project.Properties.Resources.statistic85;
            lbWellcome.Text = "Statistical information";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SellGUI sell = new SellGUI(login);
            FillPanel(sell);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WarehouseGUI ware = new WarehouseGUI();
            FillPanel(ware);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CustomerGUI cus = new CustomerGUI();
            FillPanel(cus);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            StatisticGUI sta = new StatisticGUI();
            FillPanel(sta);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AdminGUI ad = new AdminGUI();
            FillPanel(ad);
        }
        private void lbSignOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to sign out", "Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                form.Show();
            }
            else
            { }
        }

        private void HomeGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show("Exit G1 Supermarket System ?", "Confirm", MessageBoxButtons.YesNo);
            //if (result == DialogResult.Yes)
            //{
                Application.Exit();
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }

        private void lbUserName_Click(object sender, EventArgs e)
        {
            PasswordGUI pass = new PasswordGUI(login);
            pass.Show();
        }
    }
}
