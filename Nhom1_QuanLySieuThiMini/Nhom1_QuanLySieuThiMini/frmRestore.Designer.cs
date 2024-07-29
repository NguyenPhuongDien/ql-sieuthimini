
namespace Nhom1_QuanLySieuThiMini
{
    partial class frmRestore
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
            this.btnKhoiPhuc = new System.Windows.Forms.Button();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.txtHienThi = new System.Windows.Forms.TextBox();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.btnKhoiPhuc);
            this.panel1.Controls.Add(this.lblErrorMessage);
            this.panel1.Controls.Add(this.txtHienThi);
            this.panel1.Controls.Add(this.btnChonFile);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 118);
            this.panel1.TabIndex = 0;
            // 
            // btnKhoiPhuc
            // 
            this.btnKhoiPhuc.AutoSize = true;
            this.btnKhoiPhuc.BackColor = System.Drawing.Color.LightBlue;
            this.btnKhoiPhuc.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoiPhuc.Location = new System.Drawing.Point(590, 27);
            this.btnKhoiPhuc.Margin = new System.Windows.Forms.Padding(4);
            this.btnKhoiPhuc.Name = "btnKhoiPhuc";
            this.btnKhoiPhuc.Size = new System.Drawing.Size(116, 35);
            this.btnKhoiPhuc.TabIndex = 15;
            this.btnKhoiPhuc.Text = "Khôi phục";
            this.btnKhoiPhuc.UseVisualStyleBackColor = false;
            this.btnKhoiPhuc.Click += new System.EventHandler(this.btnKhoiPhuc_Click_1);
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(16, 66);
            this.lblErrorMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(111, 17);
            this.lblErrorMessage.TabIndex = 14;
            this.lblErrorMessage.Text = "lblErrorMessage";
            // 
            // txtHienThi
            // 
            this.txtHienThi.AllowDrop = true;
            this.txtHienThi.Location = new System.Drawing.Point(20, 27);
            this.txtHienThi.Margin = new System.Windows.Forms.Padding(4);
            this.txtHienThi.Multiline = true;
            this.txtHienThi.Name = "txtHienThi";
            this.txtHienThi.ReadOnly = true;
            this.txtHienThi.Size = new System.Drawing.Size(381, 35);
            this.txtHienThi.TabIndex = 13;
            // 
            // btnChonFile
            // 
            this.btnChonFile.AutoSize = true;
            this.btnChonFile.BackColor = System.Drawing.Color.LightBlue;
            this.btnChonFile.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonFile.Location = new System.Drawing.Point(409, 27);
            this.btnChonFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(173, 35);
            this.btnChonFile.TabIndex = 12;
            this.btnChonFile.Text = "Chọn file";
            this.btnChonFile.UseVisualStyleBackColor = false;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click_1);
            // 
            // frmRestore
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(750, 137);
            this.Controls.Add(this.panel1);
            this.Name = "frmRestore";
            this.Text = "frmRestore";
            this.Load += new System.EventHandler(this.frmRestore_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnKhoiPhuc;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.TextBox txtHienThi;
        private System.Windows.Forms.Button btnChonFile;
    }
}