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
    public partial class frmQuanLyTaiKhoan : Form
    {
        bool themmoi;
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
            this.Load += frmQuanLyTaiKhoan_Load;
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDgvTaiKhoan();
        }
        private void LoadDgvTaiKhoan()
        {
            dgvDanhSachTaiKhoan.DataSource = TaiKhoan_BUS.GetAll();
            //DataTable DgvTaiKhoan = TaiKhoan_BUS.GetAll();
            //dgvDanhSachTaiKhoan.DataSource = DgvTaiKhoan;
            return;
        }
        private void dgvDanhSachTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTaiKhoan.Text = dgvDanhSachTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMatKhau.Text = dgvDanhSachTaiKhoan.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbQuyen.Text = dgvDanhSachTaiKhoan.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            // Kiểm tra dữ liệu
            if (txtTaiKhoan.Text == "" | txtMatKhau.Text == "" | cmbQuyen.Text =="")
            {
                MessageBox.Show("Vui lòng nhập vào dữ liệu!", "Thông báo");
                return;
            }
            //Khởi tạo đối tượng tài khoản DTO
            TaiKhoan_DTO tkhoanDTO = new TaiKhoan_DTO();
            tkhoanDTO.TaiKhoan = txtTaiKhoan.Text;
            tkhoanDTO.MatKhau = txtMatKhau.Text;
            tkhoanDTO.Quyen = cmbQuyen.Text;
            //Gọi lớp nghiệp vụ TaiKhoan_BUS
            if (TaiKhoan_BUS.TaiKhoan_Insert(tkhoanDTO) == true)
            {
                MessageBox.Show("Thêm thành công !", "Thông báo");
                //Load lại dữ liệu cho control datagridview
                LoadDgvTaiKhoan();
                return;
            }
            MessageBox.Show("Thêm thất bại !", "Thông báo");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            themmoi = false;
            // Kiểm tra dữ liệu
            if (txtTaiKhoan.Text == "" | txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập vào dữ liệu!", "Thông báo");
                return;
            }
            //Khởi tạo đối tượng tài khoản DTO
            TaiKhoan_DTO tkhoanDTO = new TaiKhoan_DTO();
            tkhoanDTO.TaiKhoan = txtTaiKhoan.Text;
            tkhoanDTO.MatKhau = txtMatKhau.Text;
            tkhoanDTO.Quyen = cmbQuyen.Text;
            //Gọi lớp nghiệp vụ TaiKhoan_BUS
            if (TaiKhoan_BUS.TaiKhoan_Update(tkhoanDTO) == true)
            {
                MessageBox.Show("Sửa thành công !", "Thông báo");
                //Load lại dữ liệu cho control datagridview
                dgvDanhSachTaiKhoan.DataSource = TaiKhoan_BUS.GetAll();
                return;
            }
            MessageBox.Show("Sửa thất bại !", "Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Hãy chọn tài khoản cần xóa!", "Thông báo");
                return;
            }
            //Khởi tạo đối tượng tài khoản DTO
            TaiKhoan_DTO tkhoanDTO = new TaiKhoan_DTO();
            tkhoanDTO.TaiKhoan = txtTaiKhoan.Text;
            tkhoanDTO.MatKhau = txtMatKhau.Text;
            tkhoanDTO.Quyen = cmbQuyen.Text;
            //Gọi lớp nghiệp vụ TaiKhoan_BUS
            if (TaiKhoan_BUS.TaiKhoan_Delete(tkhoanDTO) == true)
            {
                MessageBox.Show("Xóa thành công !", "Thông báo");
                //Load lại dữ liệu cho control datagridview
                LoadDgvTaiKhoan();
                return;
            }
            else
            {
                MessageBox.Show("Xóa thất bại !", "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            cmbQuyen.Text = "";
        }


        //private void btnTimKiem_Click(object sender, EventArgs e)
        //{

        //    if (txtTaiKhoan.Text != "")
        //    {
        //        var tukhoa = txtTimKiem.Text;
        //       DataTable DgvTaiKhoan = TaiKhoan_BUS.GetByID(tukhoa);
        //        if (DgvTaiKhoan == null)
        //        {
        //            MessageBox.Show("Không có kết quả nào !", "Thông báo");
        //            return;
        //        }
        //        dgvDanhSachTaiKhoan.DataSource = DgvTaiKhoan;
        //    }
        //}

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
        }

        private void frmQuanLyTaiKhoan_Load_1(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void gbTimKiem_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDanhSachTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
