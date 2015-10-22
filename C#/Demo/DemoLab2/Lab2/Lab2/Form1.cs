using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          //  Form1 v = new Form1();
          //  v.Text = "Customer Information";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        { //CustomerID
            string v = textBox1.Text;
            if (string.IsNullOrEmpty(v))
            {
                MessageBox.Show("Entered text can not be empty");
                textBox1.Focus();
                return;
            }
            if (v.Length > 5)
            {
                MessageBox.Show("Entered text maximum 5 character");
                textBox1.Focus();
                return;
            }
           

            //CustomerName

            string k = textBox2.Text;
            if (string.IsNullOrEmpty(k))
            {
                MessageBox.Show("Entered text can not be empty");
                textBox2.Focus();
                return;
            }
          


            //Email

            string h = textBox3.Text;
            
            if (string.IsNullOrEmpty(h) || h.Length < 10 )
            {
                MessageBox.Show("Entered email again");
                textBox3.Focus();
                return;
            }

            MessageBox.Show("CustomerID: " + v.ToUpper() + "\nCustomerName: " + k + "\nEmail: " + h);

            //Phone
            if (!maskedTextBox1.MaskCompleted)
            {
                MessageBox.Show("Entered again");
                maskedTextBox1.Focus();
                return;
            }

            //Extension
            
            int iCharacterCounter = 0;
            // Extension validation
            foreach (char c in textBox5.Text)
            {
                if (char.IsNumber(c))
                {
                    

                    if (iCharacterCounter > 3)
                    {
                        // Display error message
                        MessageBox.Show("Extension only accepts maximum 3 chars");

                        // Set focus on Extension Text Field
                        textBox5.Focus();

                        return;
                    }
                }
            }

            iCharacterCounter = 0;
            foreach (char cCharacter in textBox7.Text)
            {
                if (!char.IsLetter(cCharacter))
                {
                    iCharacterCounter++;

                    if (iCharacterCounter > 3)
                    {
                        // Display error message
                        MessageBox.Show("Postal Code only accepts maximum 3 chars");

                        // Set focus on Extension Text Field
                        textBox7.Focus();

                        return;
                    }
                }
            }

           

            //Address
            string n = textBox6.Text;


            if (string.IsNullOrEmpty(h))
            {
                MessageBox.Show("Entered again");
                textBox6.Focus();
                return;
            }
            
            //Country
          // comboBox1.Enter("VietNam", "malaysia", "ThaiLand", "Philippins", "Brunei", "Indonesia", "Myanmar", "Laos", "Cambodia");
            string[] szCountryName = { "VietNam", "Malaysia", "ThaiLand", "Philippines", "Brunei", "Indonesia", "Myanmar", "Laos", "Cambodia" };

            foreach (string szInfo in szCountryName)
                comboBox1.Items.Add(szInfo);

         //   comboBox1.SelectedIndex = 0;
            //Postal

            MessageBox.Show("CustomerID: " + v.ToUpper() + "\nCustomerName: " + k + "\nEmail: " + h + "\nPhone No.: " + maskedTextBox1.Text + "\nExtension: " + textBox5.Text + "\nAddress: " + textBox6.Text + "\nCountry" + comboBox1.SelectedItem.ToString() + "\nPostal Code: " + textBox7.Text);
        }
    }
}
