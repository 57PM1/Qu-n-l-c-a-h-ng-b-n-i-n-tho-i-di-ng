using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham_DTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int MaNhaSX { get; set; }
        public int MaNhaCC { get; set; }
        public string HeDieuHanh { get; set; }
        public string ManHinh { get; set; }
        public string Camera { get; set; }
        public string CPU { get; set; }
        public string Ram { get; set; }
        public string BoNhoTrong { get; set; }
        public string Pin { get; set; }
        public string KetNoi { get; set; }
        public string DungLuongPin { get; set; }
        public string CNDacBiet { get; set; }
        public string MauSac { get; set; }
        public float DGN { get; set; }
        public float DGB { get; set; }
        public float SoLuong { get; set; }
    }
}
