using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap9
{
    public partial class FrmPaintShape : Form
    {
        Pen blackPen;
        SolidBrush blackBrush;
        public FrmPaintShape()
        {
            InitializeComponent();
            blackPen = new Pen(Color.FromArgb(139, 0, 0), 4);
            blackBrush = new SolidBrush(Color.FromArgb(139, 0, 0));
        }

        private void FrmPaintShape_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void cboShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void DrawEllipse(Graphics g, int w, int h)
        {
            g.DrawEllipse(blackPen, this.ClientSize.Width / 2 - w / 2, this.ClientSize.Height / 2 - h / 2, w, h);
        }

        private void DrawRectangle(Graphics g, int w, int h)
        {
            g.DrawRectangle(blackPen, this.ClientSize.Width / 2 - w / 2, this.ClientSize.Height / 2 - h / 2, w, h);
        }
        
        private void DrawPie(Graphics g, int w, int h, int a)
        {
            g.DrawPie(blackPen, this.ClientSize.Width / 2 - w / 2, this.ClientSize.Height / 2 - h / 2, w, h, 0 , a);
        }

        private void DrawFilledEllipse(Graphics g, int w, int h)
        {
            g.FillEllipse(blackBrush, this.ClientSize.Width / 2 - w / 2, this.ClientSize.Height / 2 - h / 2, w, h);
        }

        private void DrawFilledRectangle(Graphics g, int w, int h)
        {
            g.FillRectangle(blackBrush, this.ClientSize.Width / 2 - w / 2, this.ClientSize.Height / 2 - h / 2, w, h);
        }

        private void DrawFilledPie(Graphics g, int w, int h, int a)
        {
            g.FillPie(blackBrush, this.ClientSize.Width / 2 - w / 2, this.ClientSize.Height / 2 - h / 2, w, h, 0, a);
        }
        private void FrmPaintShape_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            switch (cboShapes.Text)
            {
                case "Circle":
                    DrawEllipse(g, 220, 220);
                    break;
                case "Square":
                    DrawRectangle(g, 220, 220);
                    break;
                case "Ellipse":
                    DrawEllipse(g, 220, 150);
                    break;
                case "Pie":
                    DrawPie(g, 220, 220, 300);
                    break;
                case "Filled Circle":
                    DrawFilledEllipse(g, 220, 220);
                    break;
                case "Filled Square":
                    DrawFilledRectangle(g, 220, 220);
                    break;
                case "Filled Ellipse":
                    DrawFilledEllipse(g, 220, 150);
                    break;
                case "Filled Pie":
                    DrawFilledPie(g, 220, 220, 300);
                    break;
            }
        }
    }
}
