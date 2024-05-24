using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        private int _ID_KhachHang;
        private string _Ten;
        private string _CCCD;
        private string _SDT;
        private string _Email;
        private string _NgheNghiep;
        private int _ID_PhongTro;
        private int _DelFlg;
        private int _FlagInsert;

        public int ID_KhachHang { get => _ID_KhachHang; set => _ID_KhachHang = value; }
        public string Ten { get => _Ten; set => _Ten = value; }
        public string CCCD { get => _CCCD; set => _CCCD = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string NgheNghiep { get => _NgheNghiep; set => _NgheNghiep = value; }
        public int ID_PhongTro { get => _ID_PhongTro; set => _ID_PhongTro = value; }
        public int DelFlg { get => _DelFlg; set => _DelFlg = value; }
        public int FlagInsert { get => _FlagInsert; set => _FlagInsert = value; }
        public KhachHang(int iD_KhachHang, string ten, string cCCD, string sDT, string email, string ngheNghiep, int id_Phongtro)
        {
            ID_KhachHang = iD_KhachHang;
            Ten = ten;
            CCCD = cCCD;
            SDT = sDT;
            Email = email;
            NgheNghiep = ngheNghiep;
            ID_PhongTro = id_Phongtro;    // null
            DelFlg = 0;
            FlagInsert = 0;
        }
    }
}
