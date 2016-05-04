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
    public class TaiKhoan_DAO
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public static bool TaiKhoan_Insert(TaiKhoan_DTO tkhoanDTO)
        {
            conn = DataProvider.KetNoi();
            string sTruyVan = "TaiKhoan_Insert";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = tkhoanDTO.TaiKhoan;
            cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = tkhoanDTO.MatKhau;
            cmd.Parameters.Add("@Quyen", SqlDbType.NVarChar).Value = tkhoanDTO.Quyen;
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
        public static bool TaiKhoan_Update(TaiKhoan_DTO tkhoanDTO)
        {
            conn = DataProvider.KetNoi();
            string sTruyVan = "TaiKhoan_Update";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = tkhoanDTO.TaiKhoan;
            cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = tkhoanDTO.MatKhau;
            cmd.Parameters.Add("@Quyen", SqlDbType.NVarChar).Value = tkhoanDTO.Quyen;
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
        public static bool TaiKhoan_Delete(TaiKhoan_DTO tkhoanDTO)
        {
            conn = DataProvider.KetNoi();
            string sTruyVan = "TaiKhoan_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = tkhoanDTO.TaiKhoan;
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
            SqlDataAdapter adapter = new SqlDataAdapter("TaiKhoan_SelectAll", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
        public static DataTable GetByID(TaiKhoan_DTO dt)
        {
            cmd = new SqlCommand("TaiKhoan_GetByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = dt.TaiKhoan;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }


    }
}
