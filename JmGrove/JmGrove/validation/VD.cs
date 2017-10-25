using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bsnl.Validation
{
    class VD
    {
        public static bool IsNull(TextBox txt)
        {
            bool chk = false;
            if (txt.Text.Trim().Length == 0)
            {
                MessageBox.Show(txt.Tag + " should not be null..!!", "Check", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt.Focus();
                chk = true;
            }
            return chk;
        }
        public static bool IsSelect(ComboBox cmb)
        {
            bool chk = true;
            if (cmb.SelectedIndex == 0)
            {
                MessageBox.Show(cmb.Tag + " Should be selected", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmb.Focus();
                chk = false;
            }
            return chk;

        }



    }
}
