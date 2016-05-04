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
    public class NhaSX_DAO
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public static bool NhaSX_Insert(NhaSX_DTO nhasxDTO)
        {
            conn = DataProvider.KetNoi();
            string sTruyVan = "NhaSX_Insert";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenNhaSX", SqlDbType.NVarChar).Value = nhasxDTO.TenNhaSX;
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
        public static bool NhaSX_Update(NhaSX_DTO nhasxDTO)
        {
            conn = DataProvider.KetNoi();
            string sTruyVan = "NhaSX_Update";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaNhaSX", SqlDbType.Int).Value = nhasxDTO.MaNhaSX;
            cmd.Parameters.Add("@TenNhaSX", SqlDbType.NVarChar).Value = nhasxDTO.TenNhaSX;
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
        public static bool NhaSX_Delete(NhaSX_DTO nhasxDTO)
        {
            conn = DataProvider.KetNoi();
            string sTruyVan = "NhaSX_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaNhaSX", SqlDbType.Int).Value = nhasxDTO.MaNhaSX;
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
            SqlDataAdapter adapter = new SqlDataAdapter("GetAll", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
        public static DataTable GetByID(NhaSX_DTO nhasxDTO)
        {
            cmd = new SqlCommand("GetByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaNhaSX", SqlDbType.Int).Value = nhasxDTO.MaNhaSX;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }
    }
}
