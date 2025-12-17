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

namespace BaiTap8
{
    public partial class frmAnalogClockApp : Form
    {
        public frmAnalogClockApp()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            timer.Interval = 1000; 
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int cx = this.ClientSize.Width / 2;
            int cy = this.ClientSize.Height / 2;
            int radius = Math.Min(cx, cy) - 20;

            for (int i = 0; i < 60; i++)
            {
                double ang = i * Math.PI / 30;
                int rSmall = radius - 10;
                int x = cx + (int)(rSmall * Math.Cos(ang - Math.PI / 2));
                int y = cy + (int)(rSmall * Math.Sin(ang - Math.PI / 2));

                if (i % 5 == 0)
                    g.FillEllipse(Brushes.White, x - 6, y - 6, 12, 12);
                else
                    g.FillEllipse(Brushes.White, x - 2, y - 2, 4, 4);
            }

            DateTime t = DateTime.Now;
            double secAng = (Math.PI / 30) * t.Second;
            double minAng = (Math.PI / 30) * t.Minute + secAng / 60;
            double hourAng = (Math.PI / 6) * (t.Hour % 12) + minAng / 12;

            DrawHandPolygon(g, cx, cy, radius * 0.5f, hourAng, 12); 
            DrawHandPolygon(g, cx, cy, radius * 0.7f, minAng, 8);   
            DrawHandPolygon(g, cx, cy, radius * 0.85f, secAng, 4); 
        }

        private void DrawHandPolygon(Graphics g, int cx, int cy, float len, double angle, int width)
        {
            using (Pen p = new Pen(Color.White, 1)) 
            {
                double a = angle - Math.PI / 2;
                PointF pTop = new PointF(
                    cx + (float)(len * Math.Cos(a)),
                    cy + (float)(len * Math.Sin(a)));
                PointF pRight = new PointF(
                    cx + (float)(width * Math.Cos(a + Math.PI / 2)),
                    cy + (float)(width * Math.Sin(a + Math.PI / 2)));
                PointF pBottom = new PointF(
                    cx + (float)(20 * Math.Cos(a + Math.PI)),
                    cy + (float)(20 * Math.Sin(a + Math.PI)));
                PointF pLeft = new PointF(
                    cx + (float)(width * Math.Cos(a - Math.PI / 2)),
                    cy + (float)(width * Math.Sin(a - Math.PI / 2)));
                g.DrawPolygon(p, new PointF[] { pTop, pRight, pBottom, pLeft });
            }
        }

        private void frmAnalogClockApp_FormClosing(object sender, FormClosingEventArgs e)
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
