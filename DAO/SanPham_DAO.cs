using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class SanPham_DAO
    {
        //Khởi tạo biến kết nối
        static SqlConnection con;
        //Load danh sách sản phẩm 
        public static DataTable LoadSanPham()
        {
            //Mở kết nối
            con = DataProvider.KetNoi();
            SqlCommand cmd = new SqlCommand("sp_TatCaSanPham",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Thêm 1 sản phẩm 
        public static void ThemSanPham(SanPham_DTO spDTO)
        {
            //Mở kết nối
            con = DataProvider.KetNoi();
            SqlCommand cmd = new SqlCommand("sp_ThemSanPham", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MaNhaSX", SqlDbType.Int);
            cmd.Parameters.Add("@MaNhaCC", SqlDbType.Int);
            cmd.Parameters.Add("@MauSac", SqlDbType.Int);
            cmd.Parameters.Add("@DGN", SqlDbType.Float);
            cmd.Parameters.Add("@DGB", SqlDbType.Float);
            cmd.Parameters.Add("@SoLuong", SqlDbType.Float);
            //Gán giá trị
            cmd.Parameters["@TenSP"].Value = spDTO.TenSP;
            cmd.Parameters["@MaNhaSX"].Value = spDTO.MaNhaSX;
            cmd.Parameters["@MaNhaCC"].Value = spDTO.MaNhaCC;
            cmd.Parameters["@MauSac"].Value = spDTO.MauSac;
            cmd.Parameters["@DGN"].Value = spDTO.DGN;
            cmd.Parameters["@DGB"].Value = spDTO.DGB;
            cmd.Parameters["@SoLuong"].Value = spDTO.SoLuong;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //Xóa 1 sản phẩm 
        public static void XoaSanPham(SanPham_DTO spDTO) {

        }

    }
}
