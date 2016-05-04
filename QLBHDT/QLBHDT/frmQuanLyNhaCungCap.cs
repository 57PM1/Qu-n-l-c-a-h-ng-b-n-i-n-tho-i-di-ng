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
    public partial class frmQuanLyNhaCungCap : Form
    {
        
        public frmQuanLyNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmQuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadDgvNhaCC();
        }
        void LoadDgvNhaCC()
        {
            dgvDanhSachTaiKhoan.DataSource = NhaCC_BUS.GetAll();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenNhacc.Text = "";
             txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtma.Text = "";
        }

        private void dgvDanhSachTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtTenNhacc.Text = dgvDanhSachTaiKhoan.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSDT.Text = dgvDanhSachTaiKhoan.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDiaChi.Text = dgvDanhSachTaiKhoan.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtma.Text= dgvDanhSachTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString(); 
               
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (txtTenNhacc.Text == "")
            {
                MessageBox.Show("Vui lòng nhập vào dữ liệu!", "Thông báo");
                return;
            }
            DataTable tbl=NhaCC_BUS.GetAll();
            foreach(DataRow i in tbl.Rows)
            {
                if (i["TenNhaCC"].ToString().CompareTo(txtTenNhacc.Text) == 0)
                {
                    MessageBox.Show("Tên nhà cung cấp đã tồn tại \n mời bạn nhập tên khác!", "Thông báo");
                    return;
                }
            }
            
            //Khởi tạo đối tượng tài khoản DTO

            NhaCC_DTO NhaccDTO = new NhaCC_DTO();
            
            NhaccDTO.TenNhaCC = txtTenNhacc.Text;
            NhaccDTO.SDT = txtSDT.Text;
            NhaccDTO.DiaChi = txtDiaChi.Text;
            //Gọi lớp nghiệp vụ TaiKhoan_BUS
            if (NhaCC_BUS.NhaCC_Insert(NhaccDTO) == true)
            {
                MessageBox.Show("Thêm thành công !", "Thông báo");
                //Load lại dữ liệu cho control datagridview
                LoadDgvNhaCC();
                return;
            }
            MessageBox.Show("Thêm thất bại !", "Thông báo");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtma.Text == "")
            {
                MessageBox.Show("Nha cung cấp chưa tồn tại\n Bạn vui lòng chọn dữ liệu từ gridview rồi sửa lại", "Thông báo");
                return;
            }
            if (txtTenNhacc.Text == "")
            {
                MessageBox.Show("Vui lòng nhập vào dữ liệu!", "Thông báo");
                return;
            }
           
            DataTable tbl = NhaCC_BUS.GetAll();
            foreach (DataRow i in tbl.Rows)
            {
                if (i["TenNhaCC"].ToString().CompareTo(txtTenNhacc.Text) == 0)
                {
                    MessageBox.Show("Tên nhà cung cấp đã tồn tại \n mời bạn nhập tên khác!", "Thông báo");
                    return;
                }
            }
            //Khởi tạo đối tượng tài khoản DTO
            NhaCC_DTO NhaccDTO = new NhaCC_DTO();
            NhaccDTO.MaNhaCC = Int32.Parse(txtma.Text);
            NhaccDTO.TenNhaCC = txtTenNhacc.Text;
            NhaccDTO.SDT = txtSDT.Text;
            NhaccDTO.DiaChi = txtDiaChi.Text;
            //Gọi lớp nghiệp vụ TaiKhoan_BUS
            if (NhaCC_BUS.NhaCC_Update(NhaccDTO) == true)
            {
                MessageBox.Show("Sửa thành công !", "Thông báo");
                //Load lại dữ liệu cho control datagridview
                LoadDgvNhaCC();
                return;
            }
            MessageBox.Show("Sửa thất bại !", "Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtma.Text =="")
            {
                MessageBox.Show("Nha cung cấp chưa tồn tại\n Bạn vui lòng chọn dữ liệu từ gridview rồi sửa lại", "Thông báo");
                return;
            }
            //Khởi tạo đối tượng tài khoản DTO
            NhaCC_DTO NhaccDTO = new NhaCC_DTO();
            NhaccDTO.MaNhaCC = Int32.Parse(txtma.Text);
            NhaccDTO.TenNhaCC = txtTenNhacc.Text;
            NhaccDTO.SDT = txtSDT.Text;
            NhaccDTO.DiaChi = txtDiaChi.Text;
            //Gọi lớp nghiệp vụ TaiKhoan_BUS
            if (NhaCC_BUS.NhaCC_Delete(NhaccDTO) == true)
            {
                MessageBox.Show("Xóa thành công !", "Thông báo");
                //Load lại dữ liệu cho control datagridview
                LoadDgvNhaCC();
                return;
            }
            MessageBox.Show("Xóa thất bại !", "Thông báo");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenNhacc.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtma.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Mời bạn nhập nội dung tìm kiếm !", "Thông báo");
            }
            NhaCC_DTO ncc = new NhaCC_DTO();
            ncc.TenNhaCC = txtTimKiem.Text;
            dgvDanhSachTaiKhoan.DataSource = NhaCC_BUS.GetByName(ncc);
        }
    }
    
}
