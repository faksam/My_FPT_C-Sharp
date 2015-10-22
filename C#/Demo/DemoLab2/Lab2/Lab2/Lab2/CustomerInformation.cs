using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class CustomerInformation : Form
    {
        public CustomerInformation()
        {
            InitializeComponent();
        }

        bool check_CustomerID()
        {
            string s = txt_CustomerID.Text;
            if (s.Length > 5)
            {
                err_CustomerID.SetError(txt_CustomerID, "Customer ID accepts maximum 5 characters");
                txt_CustomerID.Focus();
                return false;
            }
            foreach (char c in s.ToCharArray())
            {
                if (!Char.IsUpper(c))
                {
                    err_CustomerID.SetError(txt_CustomerID, "All characters must be entered in upper case");
                    txt_CustomerID.Focus();
                    return false;
                }
            }
            err_CustomerID.Dispose();
            return true;
        }

        bool check_Email()
        {
            string s = txt_Email.Text;
            bool ok1 = false, ok2 = false;
            foreach (char c in s.ToCharArray())
            {
                if (c == '@')
                {
                    ok1 = true;
                }
                if (c == '.')
                {
                    ok2 = true;
                }
                if (ok1 && ok2)
                {
                    break;
                }
            }
            if (!ok1 || !ok2)
            {
                err_Email.SetError(txt_Email, "Email must have (@) and (.)");
                txt_Email.Focus();
                return false;
            }
            if (s.Length < 10)
            {
                err_Email.SetError(txt_Email, "Email must have at least 10 characters in total");
                txt_Email.Focus();
                return false;
            }
            err_Email.Dispose();
            return true;
        }
        bool check_PhoneNo()
        {
            if (!mtb_PhoneNo.MaskCompleted)
            {
                err_PhoneNo.SetError(mtb_PhoneNo, "Enter phone number");
                mtb_PhoneNo.Focus();
                return false;
            }
            err_PhoneNo.Dispose();
            return true;
        }

        bool check_Extension()
        {
            string s = txt_Extension.Text;
            foreach (char c in s.ToCharArray())
            {
                if (!Char.IsDigit(c))
                {
                    err_Extension.SetError(txt_Extension, "Extension must be numeric");
                    txt_Extension.Focus();
                    return (false);
                }
            }
            if (s.Length > 3)
            {
                err_Extension.SetError(txt_Extension, "Extension accepts maximum 3 chars");
                txt_Extension.Focus();
                return (false);
            }
            err_Extension.Dispose();
            return true;
        }

        bool check_PostalCode()
        {
            string s = txt_PostalCode.Text;
            foreach (char c in s.ToCharArray())
            {
                if (!Char.IsDigit(c))
                {
                    err_PostalCode.SetError(txt_PostalCode, "Postal code must be numeric");
                    txt_PostalCode.Focus();
                    return (false);
                }
            }
            if (s.Length > 3)
            {
                err_PostalCode.SetError(txt_PostalCode, "Postal code accepts maximum 3 chars");
                txt_PostalCode.Focus();
                return (false);
            }
            err_PostalCode.Dispose();
            return true;
        }

        bool check_Country()
        {
            int i = cbb_Country.SelectedIndex;
            if (i < 0)
            {
                err_Country.SetError(cbb_Country, "Choose a country");
                return false;
            }
            err_Country.Dispose();
            return true;
        }

        bool data_valid()
        {
            bool ok;
            bool ok1 = check_CustomerID(); 
            bool ok2 = check_Email(); 
            bool ok3 = check_PhoneNo(); 
            bool ok4 = check_Extension();
            bool ok5 = check_PostalCode();
            bool ok6 = check_Country();
            ok = ok1 && ok2 && ok3 && ok4 && ok5 && ok6;
            return ok;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            
            if (!data_valid())
                return;
            string s = "" + txt_CustomerID.Text + "\n" +
                            txt_CustomerName.Text + "\n" +
                            txt_Email.Text + "\n" +
                            mtb_PhoneNo.Text + "\n" +
                            txt_Extension.Text + "\n" +
                            txt_Address.Text + "\n" +
                            cbb_Country.SelectedItem.ToString() + "\n" +
                            txt_PostalCode.Text;
            MessageBox.Show(s, "Information");
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
