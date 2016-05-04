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
    public class NhaCC_DAO
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public static bool NhaCC_Insert(NhaCC_DTO nhaccDTO)
        {
            conn = DataProvider.KetNoi();
            string sTruyVan = "NhaCC_Insert";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenNhaCC", SqlDbType.NVarChar).Value = nhaccDTO.TenNhaCC;
            cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = nhaccDTO.SDT;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhaccDTO.DiaChi;
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
        public static bool NhaCC_Update(NhaCC_DTO nhaccDTO)
        {
            conn = DataProvider.KetNoi();
            string sTruyVan = "NhaSX_Update";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaNhaCC", SqlDbType.Int).Value = nhaccDTO.MaNhaCC;
            cmd.Parameters.Add("@TenNhaCC", SqlDbType.NVarChar).Value = nhaccDTO.TenNhaCC;
            cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = nhaccDTO.SDT;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhaccDTO.DiaChi;
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
        public static bool NhaCC_Delete(NhaCC_DTO nhaccDTO)
        {
            conn = DataProvider.KetNoi();
            string sTruyVan = "NhaCC_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaNhaCC", SqlDbType.Int).Value = nhaccDTO.MaNhaCC;
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
        public static DataTable GetByID(NhaCC_DTO nhaccDTO)
        {
            cmd = new SqlCommand("ProcedureName", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaNhaCC", SqlDbType.Int).Value = nhaccDTO.MaNhaCC;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }
    }
}
