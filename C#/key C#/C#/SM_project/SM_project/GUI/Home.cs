using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SM_project.GUI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            SellGUI sell = new SellGUI();
            FillPanel(sell);
            Timer tmr = new Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();
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
            lbSignOut.Font = new Font(lbSignOut.Font,FontStyle.Underline);
        }

        private void lbSignOut_MouseLeave(object sender, EventArgs e)
        {
            lbSignOut.Font = new Font(lbSignOut.Font,FontStyle.Regular);
        }

        private void lbModify_MouseLeave(object sender, EventArgs e)
        {
            lbModify.Font = new Font(lbSignOut.Font, FontStyle.Regular);
        }

        private void lbModify_MouseMove(object sender, MouseEventArgs e)
        {
            lbModify.Font = new Font(lbSignOut.Font, FontStyle.Underline);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox2.Image = global::SM_project.Properties.Resources.Shopping_cart85;
            lbWellcome.Text = "Sell the product !";
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.Image = global::SM_project.Properties.Resources.Shopping_cart70;
            lbWellcome.Text = "Wellcome to this fucking program !";
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox1.Image = global::SM_project.Properties.Resources.warehouse_icon85;
            lbWellcome.Text = "List of all product in the warehouse";
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::SM_project.Properties.Resources.warehouse_icon701;
            lbWellcome.Text = "Wellcome to this fucking program !";
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.Image = global::SM_project.Properties.Resources.customer70;
            lbWellcome.Text = "Wellcome to this fucking program !";
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox3.Image = global::SM_project.Properties.Resources.customer85;
            lbWellcome.Text = "Information of patrons !";
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = global::SM_project.Properties.Resources.account70;
            lbWellcome.Text = "Wellcome to this fucking program !";
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox4.Image = global::SM_project.Properties.Resources.account85;
            lbWellcome.Text = "Watch and update your information";
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox5.Image = global::SM_project.Properties.Resources.statistic70;
            lbWellcome.Text = "Wellcome to this fucking program !";
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox5.Image = global::SM_project.Properties.Resources.statistic85;
            lbWellcome.Text = "Statistical information";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SellGUI sell = new SellGUI();
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

    }
}
