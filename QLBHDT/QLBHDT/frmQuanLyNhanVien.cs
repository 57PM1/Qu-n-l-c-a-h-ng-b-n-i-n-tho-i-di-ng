using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLBHDT
{
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtma.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            rdbtn1.Checked = false;
            rdbtn2.Checked = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtma.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            rdbtn1.Checked = false;
            rdbtn2.Checked = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên vào!", "Thông báo");
                return;
            }
           

            //Khởi tạo đối tượng tài khoản DTO

            NhanVien_DTO NhanVienDTO = new NhanVien_DTO();

            NhanVienDTO.TenNV = txtTenNV.Text;
            NhanVienDTO.GioiTinh = "";
            if (rdbtn1.Checked) NhanVienDTO.GioiTinh = "Nam";
            if (rdbtn2.Checked) NhanVienDTO.GioiTinh = "Nữ";
            NhanVienDTO.SDT = txtSDT.Text;
            NhanVienDTO.DiaChi = txtDiaChi.Text;
            //Gọi lớp nghiệp vụ TaiKhoan_BUS
            if (NhanVien_BUS.NhanVien_Insert(NhanVienDTO) == true)
            {
                MessageBox.Show("Thêm thành công !", "Thông báo");
                //Load lại dữ liệu cho control datagridview
                LoadDgvNhanVien();
                return;
            }
            MessageBox.Show("Thêm thất bại !", "Thông báo");
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadDgvNhanVien();
        }
        void LoadDgvNhanVien()
        {
            dgvDanhSachNhanVien.DataSource = NhanVien_BUS.GetAll();
        }

        private void dgvDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtTenNV.Text = dgvDanhSachNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
                string xau= dgvDanhSachNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (xau.CompareTo("Nam") == 0)
                {
                    rdbtn1.Checked = true;
                    rdbtn2.Checked = false;
                }else if (xau.CompareTo("Nữ") == 0)
                {
                        rdbtn1.Checked = false;
                        rdbtn2.Checked = true;
                }
                txtSDT.Text = dgvDanhSachNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDiaChi.Text = dgvDanhSachNhanVien.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtma.Text = dgvDanhSachNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtma.Text == "")
            {
                MessageBox.Show("Nha cung cấp chưa tồn tại\n Bạn vui lòng chọn dữ liệu từ gridview rồi sửa lại", "Thông báo");
                return;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên vào!", "Thông báo");
                return;
            }

            //Khởi tạo đối tượng tài khoản DTO

            NhanVien_DTO NhanVienDTO = new NhanVien_DTO();

            NhanVienDTO.MaNV = Int32.Parse(txtma.Text);
            NhanVienDTO.TenNV = txtTenNV.Text;
            NhanVienDTO.GioiTinh = "";
            if (rdbtn1.Checked) NhanVienDTO.GioiTinh = "Nam";
            if (rdbtn2.Checked) NhanVienDTO.GioiTinh = "Nữ";
            NhanVienDTO.SDT = txtSDT.Text;
            NhanVienDTO.DiaChi = txtDiaChi.Text;
            //Gọi lớp nghiệp vụ TaiKhoan_BUS
            if (NhanVien_BUS.NhanVien_Update(NhanVienDTO) == true)
            {
                MessageBox.Show("Sửa thành công !", "Thông báo");
                //Load lại dữ liệu cho control datagridview
                LoadDgvNhanVien();
                return;
            }
            MessageBox.Show("Sửa thất bại !", "Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtma.Text == "")
            {
                MessageBox.Show("Nha cung cấp chưa tồn tại\n Bạn vui lòng chọn dữ liệu từ gridview rồi sửa lại", "Thông báo");
                return;
            }
           

            //Khởi tạo đối tượng tài khoản DTO

            NhanVien_DTO NhanVienDTO = new NhanVien_DTO();

            NhanVienDTO.MaNV = Int32.Parse(txtma.Text);
           
            //Gọi lớp nghiệp vụ TaiKhoan_BUS
            if (NhanVien_BUS.NhanVien_Delete(NhanVienDTO) == true)
            {
                MessageBox.Show("Xóa thành công !", "Thông báo");
                //Load lại dữ liệu cho control datagridview
                txtma.Text = "";
                txtTenNV.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                rdbtn1.Checked = false;
                rdbtn2.Checked = false;
                LoadDgvNhanVien();
                return;
            }
            MessageBox.Show("Xóa thất bại !", "Thông báo");
        }
    }
}
