using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap4
{
    public partial class FrmFont : Form
    {
        public FrmFont()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void FrmFont_FormClosing(object sender, FormClosingEventArgs e)
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

        private void FrmFont_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                cboFont.Items.Add(font.Name);
            }
            cboFont.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboFont.AutoCompleteSource = AutoCompleteSource.ListItems;

            int[] sizes= { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach(int i in sizes)
            {
                cboSize.Items.Add(i.ToString());
            }

            cboFont.Text = "Arial";
            cboSize.Text = "28";
            txtHienThi.Font = new Font("Arial", 28);
            radCenter.Checked = true;
        }

        private void CapNhatHienThi()
        {
            string fontName = txtHienThi.Font.FontFamily.Name;
            if (cboFont.SelectedItem != null)
            {
                fontName = cboFont.SelectedItem.ToString();
            }
            if (cboFont.Items.Contains(cboFont.Text))
            {
                fontName = cboFont.Text;
            }

            float fontSize = txtHienThi.Font.Size;
            if(!float.TryParse(cboSize.Text, out float parsedSize))
            {
                MessageBox.Show(
                    "Vui lòng nhập số nguyên hợp lệ!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                cboSize.Text = "14";
                return;
            }

            if (parsedSize <= 0)
            {
                MessageBox.Show(
                    "Font size phải lớn hơn 0.",
                    "Lỗi nhập lệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                cboSize.Text = "14";
                return;
            }
            fontSize = parsedSize;
            FontStyle style = FontStyle.Regular;
            if (chkDam.Checked) style |= FontStyle.Bold;
            if (chkNghien.Checked) style |= FontStyle.Italic;
            if (chkGachChan.Checked) style |= FontStyle.Underline;

            try
            {
                txtHienThi.Font = new Font(fontName, fontSize, style);
            }
            catch
            {

            }
            if (radLeft.Checked) txtHienThi.TextAlign = HorizontalAlignment.Left;
            if (radCenter.Checked) txtHienThi.TextAlign = HorizontalAlignment.Center;
            if (radRight.Checked) txtHienThi.TextAlign = HorizontalAlignment.Right;
        }

        private void cboFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatHienThi();
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatHienThi();
        }

        private void chkDam_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatHienThi();
        }

        private void chkNghien_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatHienThi();
        }

        private void chkGachChan_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatHienThi();
        }

        private void radLeft_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatHienThi();
        }

        private void radCenter_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatHienThi();
        }

        private void radRight_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatHienThi();
        }

        private void cboSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                CapNhatHienThi();
                e.SuppressKeyPress = true;
            }
        }

        private void cboSize_Leave(object sender, EventArgs e)
        {
            CapNhatHienThi();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtHienThi.ForeColor = colorDialog.Color;
                btnColor.BackColor = colorDialog.Color;
            }
        }
    }
}
