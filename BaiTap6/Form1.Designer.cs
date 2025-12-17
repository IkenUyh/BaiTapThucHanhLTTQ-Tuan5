namespace BaiTap6
{
    partial class FrmOwnerDraw
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
            this.lstFonts = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstFonts
            // 
            this.lstFonts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFonts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstFonts.FormattingEnabled = true;
            this.lstFonts.ItemHeight = 26;
            this.lstFonts.Location = new System.Drawing.Point(0, 0);
            this.lstFonts.Name = "lstFonts";
            this.lstFonts.Size = new System.Drawing.Size(278, 380);
            this.lstFonts.TabIndex = 0;
            this.lstFonts.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstFonts_DrawItem);
            // 
            // FrmOwnerDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 380);
            this.Controls.Add(this.lstFonts);
            this.Name = "FrmOwnerDraw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All fonts";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOwnerDraw_FormClosing);
            this.Load += new System.EventHandler(this.FrmOwnerDraw_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstFonts;
    }
}

