
namespace Nhom1_QuanLySieuThiMini
{
    partial class frmChiTietHoaDon
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Report_HoaDon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Report_HoaDon);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1327, 676);
            this.panel1.TabIndex = 0;
            // 
            // Report_HoaDon
            // 
            this.Report_HoaDon.ActiveViewIndex = -1;
            this.Report_HoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Report_HoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.Report_HoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Report_HoaDon.Location = new System.Drawing.Point(0, 0);
            this.Report_HoaDon.Name = "Report_HoaDon";
            this.Report_HoaDon.Size = new System.Drawing.Size(1327, 676);
            this.Report_HoaDon.TabIndex = 0;
            // 
            // frmChiTietHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 740);
            this.Controls.Add(this.panel1);
            this.Name = "frmChiTietHoaDon";
            this.Text = "Hoá đơn";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer Report_HoaDon;
    }
}