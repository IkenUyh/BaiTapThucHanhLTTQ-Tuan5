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

namespace BaiTap10
{
    public partial class frmPenDemo : Form
    {
        public frmPenDemo()
        {
            InitializeComponent();
        }

        private void frmPenDemo_Load(object sender, EventArgs e)
        {
            cboDashStyle.DataSource = Enum.GetValues(typeof(DashStyle));
            int[] sizes = { 1, 3, 5, 8, 10, 15, 20, 25, 30 };
            cboWidth.DataSource = sizes;
            cboLineJoin.DataSource = Enum.GetValues(typeof(LineJoin));
            cboDashCap.DataSource = Enum.GetValues(typeof(DashCap));
            cboStartCap.DataSource = Enum.GetValues(typeof(LineCap));
            cboEndCap.DataSource = Enum.GetValues(typeof(LineCap));

            cboWidth.SelectedIndex = 3; 
            cboDashStyle.SelectedIndex = 0;

            foreach (Control ctrl in panelControls.Panel1.Controls)
            {
                if (ctrl is ComboBox box)
                {
                    box.SelectedIndexChanged += UpdateCanvas;
                }
            }
        }
        private void UpdateCanvas(object sender, EventArgs e)
        {
            pbCanvas.Invalidate();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (cboWidth.SelectedValue == null) return;
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var style = (DashStyle)cboDashStyle.SelectedValue;
            var join = (LineJoin)cboLineJoin.SelectedValue;
            var dCap = (DashCap)cboDashCap.SelectedValue;
            var sCap = (LineCap)cboStartCap.SelectedValue;
            var eCap = (LineCap)cboEndCap.SelectedValue;

            float size = float.Parse(cboWidth.SelectedValue.ToString());

            using (var demoPen = new Pen(Color.Red, size))
            {
                demoPen.DashStyle = style;
                demoPen.LineJoin = join;
                demoPen.DashCap = dCap;
                demoPen.StartCap = sCap;
                demoPen.EndCap = eCap;

                if (style == DashStyle.Custom)
                {
                    demoPen.DashPattern = new float[] { 2f, 2f };
                }
                g.DrawLine(demoPen, 40, 40, 200, 120);
                Point[] points = {
                    new Point(50, 180),            
                    new Point(pbCanvas.Width / 2, 350), 
                    new Point(pbCanvas.Width - 50, 180)  
                };

                g.DrawLines(demoPen, points);
            }
        }
    }
}
