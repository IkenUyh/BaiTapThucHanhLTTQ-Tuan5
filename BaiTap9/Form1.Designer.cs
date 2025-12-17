namespace BaiTap9
{
    partial class FrmPaintShape
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboShapes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboShapes
            // 
            this.cboShapes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboShapes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboShapes.FormattingEnabled = true;
            this.cboShapes.Items.AddRange(new object[] {
            "Circle",
            "Square",
            "Ellipse",
            "Pie",
            "Filled Circle",
            "Filled Square",
            "Filled Ellipse",
            "Filled Pie"});
            this.cboShapes.Location = new System.Drawing.Point(25, 22);
            this.cboShapes.Name = "cboShapes";
            this.cboShapes.Size = new System.Drawing.Size(149, 21);
            this.cboShapes.TabIndex = 0;
            this.cboShapes.SelectedIndexChanged += new System.EventHandler(this.cboShapes_SelectedIndexChanged);
            // 
            // FrmPaintShape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 325);
            this.Controls.Add(this.cboShapes);
            this.Name = "FrmPaintShape";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComboBoxTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPaintShape_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmPaintShape_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboShapes;
    }
}

