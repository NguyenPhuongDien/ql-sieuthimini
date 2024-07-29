using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Nhom1_QuanLySieuThiMini
{
    public partial class frmRestore : Form
    {
        public frmRestore()
        {
            InitializeComponent();
        }


        private void btnChonFile_Click_1(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn file backup
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Backup files (*.bak)|*.bak";
            dialog.Title = "Chọn file backup";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn file backup
                string path = dialog.FileName;

                // Hiển thị đường dẫn file backup
                txtHienThi.Text = path;
            }
        }

        private void btnKhoiPhuc_Click_1(object sender, EventArgs e)
        { // Kiểm tra đường dẫn file backup
            if (string.IsNullOrEmpty(txtHienThi.Text))
            {
                lblErrorMessage.Text = "Chưa chọn file backup";
                return;
            }
            // Khôi phục cơ sở dữ liệu
            string connectionString = "Data Source=admin-pc;Initial Catalog=master;Integrated Security=True";
            string commandText =  "RESTORE DATABASE SieuThiMiNi FROM DISK = '" + txtHienThi.Text + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();

                    MessageBox.Show("Khôi phục thành công!");
                }
            }

        }

        private void frmRestore_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
        }
    }
}
