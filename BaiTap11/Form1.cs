using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;

namespace BaiTap11
{
    public partial class FrmBaiThi : Form
    {
        Point startPoint;
        Point endPoint;
        bool isDrawing = false;
        Color currentLineColor = Color.Black;
        Bitmap drawingSurface;
        public FrmBaiThi()
        {
            InitializeComponent();
            drawingSurface = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            using (Graphics g = Graphics.FromImage(drawingSurface))
            {
                g.Clear(Color.White);
            }
            pbCanvas.Image = drawingSurface;
            rbLine.Checked = true;
            txtWidth.Text = "1";
        }

        private void pbCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                startPoint = e.Location;
            }
        }

        private void pbCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                endPoint = e.Location;
                pbCanvas.Invalidate(); 
            }
        }

        private void pbCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;
            isDrawing = false;
            endPoint = e.Location;
            using (Graphics g = Graphics.FromImage(drawingSurface))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                DrawShape(g); 
            }
            pbCanvas.Invalidate();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                DrawShape(e.Graphics); 
            }
        }
        private void DrawShape(Graphics g)
        {
            int width = 1;
            int.TryParse(txtWidth.Text, out width);
            if (width <= 0) width = 1;
            Pen p = new Pen(currentLineColor, width);
            if (rbLine.Checked)
            {
                g.DrawLine(p, startPoint, endPoint);
            }
            else
            {
                Rectangle rect = GetRectangle(startPoint, endPoint);
                if (rect.Width <= 0 || rect.Height <= 0) return;
                using (Brush b = GetSelectedBrush(rect))
                {
                    if (rbRectangle.Checked)
                    {
                        g.FillRectangle(b, rect);
                    }
                    else if (rbEllipse.Checked)
                    {
                        g.FillEllipse(b, rect);
                    }
                }
            }
        }
        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y)
            );
        }
        private Brush GetSelectedBrush(Rectangle rect)
        {
            if (rbSolidBrush.Checked)
            {
                return new SolidBrush(Color.Green);
            }
            else if (rbHatchBrush.Checked)
            {
                return new HatchBrush(HatchStyle.Horizontal, Color.Blue, Color.Green);
            }
            else if (rbTextureBrush.Checked)
            {
                try
                {
                    string path = Path.Combine(Application.StartupPath, "yuuka.jpg");
                    return new TextureBrush(new Bitmap(path));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không load được ảnh: " + ex.Message);
                    return Brushes.Gray; 
                }
            }
            else if (rbGradientBrush.Checked)
            {
                return new LinearGradientBrush(rect, Color.Red, Color.Green, LinearGradientMode.Vertical);
            }

            return Brushes.Black;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                currentLineColor = cd.Color;
            }
        }

        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void FrmBaiThi_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
