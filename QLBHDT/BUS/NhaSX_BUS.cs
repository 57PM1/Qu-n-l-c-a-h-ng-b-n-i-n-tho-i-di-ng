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
    public class NhaSX_BUS
    {
        public static DataTable GetAll()
        {
            return NhaSX_DAO.GetAll();
        }

        public static bool NhaSX_Insert(NhaSX_DTO nhasxDTO)
        {
            return NhaSX_DAO.NhaSX_Insert(nhasxDTO);
        }
        public static bool NhaSX_Update(NhaSX_DTO nhasxDTO)
        {
            return NhaSX_DAO.NhaSX_Update(nhasxDTO);
        }
        public static bool NhaSX_Delete(NhaSX_DTO nhasxDTO)
        {
            return NhaSX_DAO.NhaSX_Delete(nhasxDTO);
        }
        public static DataTable GetByID(NhaSX_DTO tukhoa)
        {
            return NhaSX_DAO.GetByID(tukhoa);
        }
    }
}
