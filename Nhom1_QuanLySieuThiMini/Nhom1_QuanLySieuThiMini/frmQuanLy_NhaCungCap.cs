using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Nhom1_QuanLySieuThiMini
{
    public partial class frmQuanLy_NhaCungCap : Form
    {
        DBConnect db;

        string maNCC;

        string tenNCC;

        string diaChiNCC;

        DataTable dt;
        public frmQuanLy_NhaCungCap()
        {
            InitializeComponent();
            db = new DBConnect();
        }
        // 0.2 Tắt Group Box nhập thông tin
        public void Load_GRB_NhaCungCap()
        {
            grb_ThongTinNCC.Enabled = false;
        }
        // 0.3 Load Data Grid View NhaCungCap
        public void Load_DGV_NhaCungCap()
        {
            string sql = "SELECT * FROM NhaCungCap";

            dt = db.ExecuteReader(sql);

            dgv_DanhSachNCC.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (grb_ThongTinNCC.Enabled == false)
                grb_ThongTinNCC.Enabled = true;
            else if (IsValidInput())
            {
                Load_Input_Data();

                string sql = "INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi_NCC) " + $"VALUES ('{maNCC}', '{tenNCC}', '{diaChiNCC}')";

                db.ExecuteNonQuery(sql);

                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AddDataToDataTable(maNCC, tenNCC, diaChiNCC);
            }
        }
        // 1.2 Kiểm tra dữ liệu đầu vào
        private bool IsValidInput()
        {
            if (string.IsNullOrEmpty(txtTenNCC.Text) || string.IsNullOrEmpty(txtDiaChiNCC.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        // 1.3 Load textbox vào các đối tượng
        public void Load_Input_Data()
        {
            string sql = "select count(MaNCC) from NhaCungCap";
            int stt = (int)db.getScalar(sql) + 1;
            string strStt = stt.ToString("000");
            string maNCC_ = "NCC" + strStt;

            maNCC = maNCC_;
            tenNCC = txtTenNCC.Text;
            diaChiNCC = txtDiaChiNCC.Text;

            MessageBox.Show(maNCC);
        }
        // 1.4 Thêm dữ liệu vào DataTable
        private void AddDataToDataTable(string maPGG, string tenPGG, string diaChiNCC)
        {
            DataRow newRow = dt.NewRow();

            newRow["MaNCC"] = maPGG;
            newRow["TenNCC"] = tenPGG;
            newRow["DiaChi_NCC"] = diaChiNCC;
            dt.Rows.Add(newRow);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgv_DanhSachNCC.SelectedRows.Count > 0)
            {
                string maNCCToDelete = dgv_DanhSachNCC.SelectedRows[0].Cells["MaNCC"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string deleteSql = $"DELETE FROM NhaCungCap WHERE MaNCC = '{maNCCToDelete}'";
                        db.ExecuteNonQuery(deleteSql);
                        dgv_DanhSachNCC.Rows.RemoveAt(dgv_DanhSachNCC.SelectedRows[0].Index);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng bạn muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool isEditing = false;
        private int rowIndexToEdit = -1;
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                SaveEditedData();

                Load_DGV_NhaCungCap();
                Load_GRB_NhaCungCap();

                txtMaNCC.Clear();
                txtTenNCC.Clear();
                txtDiaChiNCC.Clear();
                txtSearchName.Clear();

                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (dgv_DanhSachNCC.SelectedRows.Count > 0)
                {
                    Load_Input_Data_2();

                    txtMaNCC.Text = maNCC;
                    txtTenNCC.Text = tenNCC;
                    txtDiaChiNCC.Text = diaChiNCC;

                    rowIndexToEdit = dgv_DanhSachNCC.SelectedRows[0].Index;
                    isEditing = true;
                    btnSua.Text = "Lưu";
                    grb_ThongTinNCC.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng bạn muốn sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        // 4.2 Phương thức để lưu dữ liệu sau khi sửa
        private void SaveEditedData()
        {
            maNCC = txtMaNCC.Text;
            tenNCC = txtTenNCC.Text;
            diaChiNCC = txtDiaChiNCC.Text;

            string updateSql = $"UPDATE NhaCungCap SET TenNCC = '{tenNCC}', DiaChi_NCC = '{diaChiNCC}' WHERE MaNCC = '{maNCC}'";
            db.ExecuteNonQuery(updateSql);

            // Cập nhật dòng trong DataTable
            dt.Rows[rowIndexToEdit]["MaNCC"] = maNCC;
            dt.Rows[rowIndexToEdit]["TenNCC"] = tenNCC;
            dt.Rows[rowIndexToEdit]["DiaChi_NCC"] = diaChiNCC;

            isEditing = false;
            rowIndexToEdit = -1;

            btnSua.Text = "Sửa";
        }
        // 4.3 Gán lại các đối tượng sau khi sửa
        public void Load_Input_Data_2()
        {
            maNCC = dgv_DanhSachNCC.SelectedRows[0].Cells["MaNCC"].Value.ToString();
            tenNCC = dgv_DanhSachNCC.SelectedRows[0].Cells["TenNCC"].Value.ToString();
            diaChiNCC = dgv_DanhSachNCC.SelectedRows[0].Cells["DiaChi_NCC"].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTen = txtSearchName.Text.ToLower();

                DataTable filteredDataTable = dt.Clone();

                foreach (DataRow row in dt.Rows)
                {
                    string tenNCC = row.Field<string>("TenNCC").ToLower();

                    if (tenNCC.IndexOf(searchTen) != -1)
                        filteredDataTable.ImportRow(row);
                }

                dgv_DanhSachNCC.DataSource = filteredDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQuanLy_NhaCungCap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void frmQuanLy_NhaCungCap_Load(object sender, EventArgs e)
        {
            Load_DGV_NhaCungCap();
            Load_GRB_NhaCungCap();

            dgv_DanhSachNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Load_DGV_NhaCungCap();
            Load_GRB_NhaCungCap();

            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChiNCC.Clear();
            txtSearchName.Clear();

            MessageBox.Show("Làm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgv_DanhSachNCC_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_DanhSachNCC.SelectedRows.Count > 0)
            {
                Load_Input_Data_2();

                txtMaNCC.Text = maNCC;
                txtTenNCC.Text = tenNCC;
                txtDiaChiNCC.Text = diaChiNCC;
            }
        }
    }
}
