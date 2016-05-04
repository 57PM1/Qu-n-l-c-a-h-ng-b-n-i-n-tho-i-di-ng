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
    public class NhaCC_BUS
    {
        public static DataTable GetAll()
        {
            return NhaCC_DAO.GetAll();
        }

        public static bool NhaCC_Insert(NhaCC_DTO nhaccDTO)
        {
            return NhaCC_DAO.NhaCC_Insert(nhaccDTO);
        }
        public static bool NhaCC_Update(NhaCC_DTO nhaccDTO)
        {
            return NhaCC_DAO.NhaCC_Update(nhaccDTO);
        }
        public static bool NhaCC_Delete(NhaCC_DTO nhaccDTO)
        {
            return NhaCC_DAO.NhaCC_Delete(nhaccDTO);
        }
        
        public static DataTable GetByName(NhaCC_DTO tukhoa)
        {
            return NhaCC_DAO.GetByName(tukhoa);
        }
    }
}
