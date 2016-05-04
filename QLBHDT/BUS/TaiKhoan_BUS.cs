using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public class TaiKhoan_BUS
    {
        public static DataTable GetAll()
        {
            return TaiKhoan_DAO.GetAll();
        }

        public static bool TaiKhoan_Insert(TaiKhoan_DTO tkhoanDTO)
        {
            return TaiKhoan_DAO.TaiKhoan_Insert(tkhoanDTO);
        }
        public static bool TaiKhoan_Update(TaiKhoan_DTO tkhoanDTO)
        {
            return TaiKhoan_DAO.TaiKhoan_Update(tkhoanDTO);
        }
        public static bool TaiKhoan_Delete(TaiKhoan_DTO tkhoanDTO)
        {
            return TaiKhoan_DAO.TaiKhoan_Delete(tkhoanDTO);
        }
        public static DataTable GetByID(TaiKhoan_DTO tukhoa)
        {
            return TaiKhoan_DAO.GetByID(tukhoa);
        }
    }
}
