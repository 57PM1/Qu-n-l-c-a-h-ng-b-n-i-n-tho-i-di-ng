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
    public class NhanVien_DAO
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public static bool NhanVien_Insert(NhanVien_DTO nhanvienDTO)
        {
            conn = DataProvider.KetNoi();
            string sTruyVan = "NhanVien_Insert";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nhanvienDTO.TenNV;
            cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = nhanvienDTO.GioiTinh;
            cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = nhanvienDTO.SDT;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhanvienDTO.DiaChi;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            try
            {
                DataProvider.ThucThiTruyVanNonQuery(sTruyVan, conn);
                //Đóng kết nối
                DataProvider.DongKetNoi(conn);
                return true;
            }
            catch (Exception ex)
            {
                //Đóng kết nối
                DataProvider.DongKetNoi(conn);
                return false;
            }
        }
        public static bool NhanVien_Update(NhanVien_DTO nhanvienDTO)
        {
            conn = DataProvider.KetNoi();
            string sTruyVan = "NhanVien_Update";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = nhanvienDTO.MaNV;
            cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nhanvienDTO.TenNV;
            cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = nhanvienDTO.GioiTinh;
            cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = nhanvienDTO.SDT;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhanvienDTO.DiaChi;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            try
            {
                DataProvider.ThucThiTruyVanNonQuery(sTruyVan, conn);
                //Đóng kết nối
                DataProvider.DongKetNoi(conn);
                return true;
            }
            catch (Exception ex)
            {
                //Đóng kết nối
                DataProvider.DongKetNoi(conn);
                return false;
            }
        }
        public static bool NhanVien_Delete(NhanVien_DTO nhanvienDTO)
        {
            conn = DataProvider.KetNoi();
            string sTruyVan = "NhanVien_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = nhanvienDTO.MaNV;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            try
            {
                DataProvider.ThucThiTruyVanNonQuery(sTruyVan, conn);
                //Đóng kết nối
                DataProvider.DongKetNoi(conn);
                return true;
            }
            catch (Exception ex)
            {
                //Đóng kết nối
                DataProvider.DongKetNoi(conn);
                return false;
            }
        }
        public static DataTable GetAll()
        {
            conn = DataProvider.KetNoi();
            SqlDataAdapter adapter = new SqlDataAdapter("NhanVien_SelectAll", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
        
    }
}
