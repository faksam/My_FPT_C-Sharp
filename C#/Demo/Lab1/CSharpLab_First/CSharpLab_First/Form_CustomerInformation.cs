using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpLab_First
{
    public partial class Form_CustomerInformation : Form
    {
        public Form_CustomerInformation()
        {
            InitializeComponent();

            // Customer ID settings
            TXT_CustomerId.MaxLength = 5;
            TXT_CustomerId.CharacterCasing = CharacterCasing.Upper;

            // Country Name Combo box
            string[] szCountryName = { "VietNam", "Malaysia", "ThaiLand", "Philippines", "Brunei", "Indonesia", "Myanmar", "Laos", "Cambodia" };

            foreach (string szInfo in szCountryName)
                CBX_CountryName.Items.Add(szInfo);

            CBX_CountryName.SelectedIndex = 0;
             
            /////////////////////////////////////////////////////////////////////////////////////
            // Button events
            
            BTN_Save.Click += new EventHandler(BTN_Save_Click);
            BTN_Close.Click += new EventHandler(BTN_Close_Click);
            /////////////////////////////////////////////////////////////////////////////////////
            // Text Field Events
            TXT_Email.KeyPress += new KeyPressEventHandler(TXT_Email_KeyPress);
            TXT_Extension.KeyPress += new KeyPressEventHandler(TXT_Extension_KeyPress);

        }

        void BTN_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (TXT_CustomerId.TextLength < 1)
            {
                MessageBox.Show("Customer ID must be filled");
                TXT_CustomerId.Focus();
                return;
            }

            if (TXT_CustomerName.TextLength < 1)
            {
                MessageBox.Show("Customer Name must be filled");
                TXT_CustomerName.Focus();
                return;
            }

            if (TXT_Email.Text.Length < 10)
            {
                // Display error message
                MessageBox.Show("Email must have at least 10 characters");

                // Focus on Email Text Field
                TXT_Email.Focus();

                return;
            }

            if (!TXT_PhoneNumber.MaskCompleted)
            {
                MessageBox.Show("Phone Number must be filled");
                TXT_PhoneNumber.Focus();
                return;
            }

            if (TXT_Extension.TextLength < 1)
            {
                MessageBox.Show("Extension must be filled");
                TXT_Extension.Focus();
                return;
            }

            if (TXT_Address.TextLength < 1)
            {
                MessageBox.Show("Address must be filled");
                TXT_Address.Focus();
                return;
            }

            if (TXT_PostalCode.TextLength < 1)
            {
                MessageBox.Show("Postal Code must be filled");
                TXT_PostalCode.Focus();
                return;
            }

            ///////////////////////////////////////////////////////////////////////////////////////
            // Email validation
            

            // There is no . character in Email Text Field
            if (TXT_Email.Text.IndexOf('.') == -1)
            {
               // Display error message
                MessageBox.Show("Email must contain (.) character");

                // Focus on Email Text Field
                TXT_Email.Focus();

                return;
            }

            // There is no @ character in Email Text Field
            if (TXT_Email.Text.IndexOf('@') == -1)
            {
                // Display error message
                MessageBox.Show("Email must contain (@) character");

                // Focus on Email Text Field
                TXT_Email.Focus();

                return;
            }

            ///////////////////////////////////////////////////////////////////////////////////////

            
            int iCharacterCounter = 0;
            // Extension validation
            foreach (char cCharacter in TXT_Extension.Text)
            {
                if (char.IsLetter(cCharacter))
                {
                    iCharacterCounter++;

                    if (iCharacterCounter > 3)
                    {
                        // Display error message
                        MessageBox.Show("Extension only accepts maximum 3 chars");

                        // Set focus on Extension Text Field
                        TXT_Extension.Focus();

                        return;
                    }
                }
            }

            iCharacterCounter = 0;
            foreach (char cCharacter in TXT_PostalCode.Text)
            {
                if (char.IsLetter(cCharacter))
                {
                    iCharacterCounter++;

                    if (iCharacterCounter > 3)
                    {
                        // Display error message
                        MessageBox.Show("Postal Code only accepts maximum 3 chars");

                        // Set focus on Extension Text Field
                        TXT_PostalCode.Focus();

                        return;
                    }
                }
            }

            
            MessageBox.Show(String.Format("ID = {0}\nNAME = {1}\nEMAIL = {2}\nPHONE_NO = {3}\nEXT = {4}\nADDRESS = {5}\nCountry = {6}\nPostal Code = {7}\n",
                                    TXT_CustomerId.Text, TXT_CustomerName.Text, TXT_Email.Text, TXT_PhoneNumber.Text, TXT_Extension.Text, TXT_Address.Text, CBX_CountryName.SelectedItem.ToString(), TXT_PostalCode.Text));
        }
            

        private void TXT_Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '@' && TXT_Email.Text.IndexOf('@') != -1)
            {
                e.Handled = true;
                return;
            }
        }

        private void TXT_Extension_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != (char)8) )
            {
                e.Handled = true;
                return;
            }
        }

       

    }
}
