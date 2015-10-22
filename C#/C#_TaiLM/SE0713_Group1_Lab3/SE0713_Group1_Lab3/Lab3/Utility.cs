using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab3_Group1
{
    class Utility
    {
        public enum ErrorBorrow
        {
            OK,
            Connect,
            TooMuch,
            CopyNotExist,
            CopyReferenced,
            CopyBorrowed,
            CopyReserved
        };

        public enum ErrorReserve
        {
            OK,
            Connect,
            CopyNotExist,
            Reserved,
            Available,
            Referenced
        };

        public static void Embed(Panel p, Form f)
        {
            p.Controls.Clear(); // delete all child controls in panel

            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            f.Visible = true;
            f.Dock = DockStyle.Fill;

            p.Controls.Add(f);//add new form into panel
            p.Show(); // show panel
        }
    }
}
