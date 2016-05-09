using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class NhanVien_BUS
    {
        public static DataTable GetAll()
        {
           
            return NhanVien_DAO.GetAll();
        }

        public static bool NhanVien_Insert(NhanVien_DTO nhanvienDTO)
        {
            return NhanVien_DAO.NhanVien_Insert(nhanvienDTO);
        }
        public static bool NhanVien_Update(NhanVien_DTO nhanvienDTO)
        {
            return NhanVien_DAO.NhanVien_Update(nhanvienDTO);
        }
        public static bool NhanVien_Delete(NhanVien_DTO nhanvienDTO)
        {
            return NhanVien_DAO.NhanVien_Delete(nhanvienDTO);
        }
    }
}
