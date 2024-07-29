
namespace Nhom1_QuanLySieuThiMini
{
    partial class frmBackUp
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaoLuu = new System.Windows.Forms.Button();
            this.btnChonfile = new System.Windows.Forms.Button();
            this.txtTenFile = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox2.Controls.Add(this.btnSaoLuu);
            this.groupBox2.Controls.Add(this.btnChonfile);
            this.groupBox2.Controls.Add(this.txtTenFile);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(700, 118);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backup Database";
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.BackColor = System.Drawing.Color.LightBlue;
            this.btnSaoLuu.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSaoLuu.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnSaoLuu.FlatAppearance.BorderSize = 0;
            this.btnSaoLuu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaoLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaoLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaoLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaoLuu.Location = new System.Drawing.Point(223, 57);
            this.btnSaoLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.Size = new System.Drawing.Size(115, 30);
            this.btnSaoLuu.TabIndex = 30;
            this.btnSaoLuu.Text = "Sao lưu";
            this.btnSaoLuu.UseVisualStyleBackColor = false;
            this.btnSaoLuu.Click += new System.EventHandler(this.btnSaoLuu_Click);
            // 
            // btnChonfile
            // 
            this.btnChonfile.BackColor = System.Drawing.Color.LightBlue;
            this.btnChonfile.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnChonfile.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnChonfile.FlatAppearance.BorderSize = 0;
            this.btnChonfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChonfile.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChonfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChonfile.Location = new System.Drawing.Point(498, 22);
            this.btnChonfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChonfile.Name = "btnChonfile";
            this.btnChonfile.Size = new System.Drawing.Size(115, 30);
            this.btnChonfile.TabIndex = 29;
            this.btnChonfile.Text = "Chọn file";
            this.btnChonfile.UseVisualStyleBackColor = false;
            this.btnChonfile.Click += new System.EventHandler(this.btnChonfile_Click);
            // 
            // txtTenFile
            // 
            this.txtTenFile.Location = new System.Drawing.Point(158, 22);
            this.txtTenFile.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtTenFile.Name = "txtTenFile";
            this.txtTenFile.Size = new System.Drawing.Size(304, 22);
            this.txtTenFile.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(43, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Tên file:";
            // 
            // frmBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(726, 145);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmBackUp";
            this.Text = "frmBackUp";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaoLuu;
        private System.Windows.Forms.Button btnChonfile;
        private System.Windows.Forms.TextBox txtTenFile;
        private System.Windows.Forms.Label label9;
    }
}