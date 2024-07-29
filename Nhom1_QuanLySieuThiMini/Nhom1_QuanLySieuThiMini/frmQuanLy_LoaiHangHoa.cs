using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom1_QuanLySieuThiMini
{
    public partial class frmQuanLy_LoaiHangHoa : Form
    {
        DBConnect db = new DBConnect();
        KiemTraInput kt = new KiemTraInput();
        public frmQuanLy_LoaiHangHoa()
        {
            InitializeComponent();
        }
        private void load_LoaiHangHoa()
        {
            DataTable tblLoaiHangHoa = db.getDatatable("SELECT * FROM LoaiHangHoa");
            tblLoaiHangHoa.Columns[0].ColumnName = "Mã loại hàng hóa";
            tblLoaiHangHoa.Columns[1].ColumnName = "Tên loại hàng hóa";

            dataGridViewLoaiHangHoa.DataSource = tblLoaiHangHoa;
        }

        private void frmQuanLy_LoaiHangHoa_Load(object sender, EventArgs e)
        {
            load_LoaiHangHoa();

            dataGridViewLoaiHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridViewLoaiHangHoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewLoaiHangHoa.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewLoaiHangHoa.SelectedRows[0];
                string maLoaiHangHoa = row.Cells[0].Value.ToString();
                string tenLoaiHangHoa = row.Cells[1].Value.ToString();
                txtMaLoai.Text = maLoaiHangHoa;
                txtTenLoai.Text = tenLoaiHangHoa;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiem tra du lieu trong textbox
            if (kt.KiemTraMaLoaiHangHoa(txtMaLoai.Text) == false)
            {
                MessageBox.Show("Mã loại hàng hóa không hợp lệ! Vui lòng nhập lại! \nMã loại hàng hóa phải có hai ký tự đầu là LH và các ký tự theo sau là số \nVí dụ: LH0010");
                return;
            }

            //Kiem tra trung khoa
            if (db.isDuplicate(txtMaLoai.Text, "LoaiHangHoa", "MaLoaiHH"))
            {
                MessageBox.Show("Trùng khóa! Vui lòng chọn mã khác!");
                return;
            }
            if (db.isDuplicate(txtTenLoai.Text, "LoaiHangHoa", "TenLoaiHH"))
            {
                MessageBox.Show("Trùng tên! Vui lòng tên khác!");
                return;
            }
            //Them vao database
            int kq = db.getNonQuery("INSERT INTO LoaiHangHoa VALUES('" + txtMaLoai.Text + "',N'" + txtTenLoai.Text + "')");
            if (kq == 0)
            {
                MessageBox.Show("Thêm không thành công!");
                return;
            }
            else
            {
                MessageBox.Show("Thêm thành công!");
                load_LoaiHangHoa();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Hiển thị cảnh báo muốn xóa không?
            DialogResult luaChon = MessageBox.Show("Bạn có muốn xóa không?", "", MessageBoxButtons.YesNo);
            if (luaChon == DialogResult.No)
            {
                return;
            }


            //Xóa
            if (dataGridViewLoaiHangHoa.SelectedRows.Count > 1)
            {
                foreach (DataGridViewRow row in dataGridViewLoaiHangHoa.SelectedRows)
                {

                    //Xóa trong database
                    int kq = db.getNonQuery("DELETE FROM LoaiHangHoa WHERE MaLoaiHH = '" + row.Cells[0].Value.ToString() + "'");
                    if (kq == 0)
                    {
                        MessageBox.Show("Xóa sản phẩm " + row.Cells[0].Value.ToString() + " không thành công!");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thành công sản phẩm " + row.Cells[0].Value.ToString());
                    }
                }
                load_LoaiHangHoa();
            }
            else
            {
                //Xóa trong database
                int kq = db.getNonQuery("DELETE FROM LoaiHangHoa WHERE MaLoaiHH = '" + txtMaLoai.Text + "'");
                if (kq == 0)
                {
                    MessageBox.Show("Xóa không thành công!");
                    return;
                }
                else
                {
                    MessageBox.Show("Xóa thành công!");
                    load_LoaiHangHoa();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Kiem tra du lieu trong textbox
            if (kt.KiemTraMaLoaiHangHoa(txtMaLoai.Text) == false)
            {
                MessageBox.Show("Mã loại hàng hóa không hợp lệ! Vui lòng nhập lại! \nMã loại hàng hóa phải có hai ký tự đầu là LH và các ký tự theo sau là số \nVí dụ: LH0010");
            }

            //Kiem tra khóa có tồn tại không
            if (!db.isDuplicate(txtMaLoai.Text, "LoaiHangHoa", "MaLoaiHH"))
            {
                MessageBox.Show("Không tồn tại loại hàng hóa với mã đã nhập! Vui lòng kiểm tra!");
            }

            //Them vao database
            int kq = db.getNonQuery("UPDATE LoaiHangHoa SET TenLoaiHH = N'" + txtTenLoai.Text + "' WHERE MaLoaiHH = '" + txtMaLoai.Text + "'");
            if (kq == 0)
            {
                MessageBox.Show("Sửa không thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thành công!");
                load_LoaiHangHoa();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            load_LoaiHangHoa();
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtSearchTenLoai.Clear();
            dataGridViewLoaiHangHoa.ClearSelection();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable tblLoaiHangHoa = db.getDatatable("SELECT * FROM LoaiHangHoa WHERE MaLoaiHH LIKE N'%" + txtSearchTenLoai.Text + "%' OR TenLoaiHH LIKE N'%" + txtSearchTenLoai.Text + "%';");
            tblLoaiHangHoa.Columns[0].ColumnName = "Mã loại hàng hóa";
            tblLoaiHangHoa.Columns[1].ColumnName = "Tên loại hàng hóa";

            dataGridViewLoaiHangHoa.DataSource = tblLoaiHangHoa;
        }
    }
}
