using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DataProvider
    {
        //Kết nối 
        public static SqlConnection KetNoi()
        {
            string sChuoiKetNoi = @"Data Source=DESKTOP-V7FFSAL\SQLEXPRESS;Initial Catalog=QL_BanHangDienThoai;Persist Security Info=True;User ID=sa;Password=123456";
            SqlConnection conn = new SqlConnection(sChuoiKetNoi);
            conn.Open();
            return conn;
        }
        //Đóng kết nối
        public static void DongKetNoi(SqlConnection conn)
        {
            conn.Close();
        }
        //Lấy DataTable
        public static DataTable LayDataTable(string sTruyVan, SqlConnection conn)
        {
            SqlDataAdapter da = new SqlDataAdapter(sTruyVan, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //Thực thi truy vấn ExcuteNonQuery
        public static bool ThucThiTruyVanNonQuery(string sTruyVan, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sTruyVan, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
