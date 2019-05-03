using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUIDGen
{
    public partial class GUIDGen : Form
    {
        public GUIDGen()
        {
            InitializeComponent();
        }

        private void cmdGenerateGUID_Click(object sender, EventArgs e)
        {
            Guid g = new Guid();
            while (!g.ToString().ToLower().StartsWith(txtGUIDStart.Text.ToLower()))
            {
                g = Guid.NewGuid();
            }
            txtGUID.Text = g.ToString();
        }

        private void txtGUIDStart_TextChanged(object sender, EventArgs e)
        {
            string item = txtGUIDStart.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) && item != String.Empty)
            {
                txtGUIDStart.Text = item.Remove(item.Length - 1, 1);
                txtGUIDStart.SelectionStart = txtGUIDStart.Text.Length;
            }
        }

        private void GUIDGen_Load(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
        }
    }
}
