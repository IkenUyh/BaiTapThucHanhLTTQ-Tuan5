using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap6
{
    public partial class FrmOwnerDraw : Form
    {
        public FrmOwnerDraw()
        {
            InitializeComponent();
        }

        private void FrmOwnerDraw_Load(object sender, EventArgs e)
        {
            InstalledFontCollection installedFonts = new InstalledFontCollection();
            foreach(FontFamily font in installedFonts.Families)
            {
                lstFonts.Items.Add(font.Name);
            }
        }

        private void lstFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            string fontName = lstFonts.Items[e.Index].ToString();
            Font fontToDraw;
            try
            {
                fontToDraw = new Font(fontName, 14, FontStyle.Regular);
            }
            catch
            {
                try
                {
                    fontToDraw = new Font(fontName, 14, FontStyle.Bold);
                }
                catch
                {
                    fontToDraw = new Font("Arial", 14, FontStyle.Regular);
                }
            }
            e.DrawBackground();
            e.Graphics.DrawString(fontName, fontToDraw, Brushes.Black, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void FrmOwnerDraw_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn thoát chương trình ?",
            "Xác nhận thoát",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
