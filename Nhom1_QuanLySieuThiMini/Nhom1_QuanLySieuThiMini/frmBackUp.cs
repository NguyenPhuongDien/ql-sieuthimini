using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom1_QuanLySieuThiMini
{
    public partial class frmBackUp : Form
    {
        public frmBackUp()
        {
            InitializeComponent();
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenFile.Text))
            {
                MessageBox.Show("Chưa chọn thư mục lưu trữ backup");
                return;
            }

            string backupPath = txtTenFile.Text;

            try
            {
                string connectionString = "Data Source=admin-pc;Initial Catalog=SieuThiMini;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        connection.Open();

                        // Using parameters to prevent SQL injection
                        command.CommandText = "BACKUP DATABASE SieuThiMini TO DISK = @BackupPath WITH INIT, DESCRIPTION = 'Backup full vao o dia D'";
                        command.Parameters.AddWithValue("@BackupPath", backupPath);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Sao lưu thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi sao lưu: " + ex.Message);
            }
        }


        private void btnChonfile_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn thư mục lưu trữ backup
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Backup files (*.bak)|*.bak";
            dialog.Title = "Chọn thư mục lưu trữ backup";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn thư mục lưu trữ backup
                string path = dialog.FileName;

                // Hiển thị đường dẫn thư mục lưu trữ backup
                txtTenFile.Text = path;
            }
        }
    }
}
