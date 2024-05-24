using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan // có 2 khóa chính ID_TaiKhoan <-> ID_ChuTro/ID_KhachHang và Quyen
    {
        private int _ID_TaiKhoan;
        private string _Username;
        private string _Password;
        private string _Quyen;          // ChuTro, KhachHang
        private int _DelFlg;
        private int _FlagInsert;

        public int ID_TaiKhoan { get => _ID_TaiKhoan; set => _ID_TaiKhoan = value; }
        public string Username { get => _Username; set => _Username = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Quyen { get => _Quyen; set => _Quyen = value; }
        public int DelFlg { get => _DelFlg; set => _DelFlg = value; }
        public int FlagInsert { get => _FlagInsert; set => _FlagInsert = value; }
        public TaiKhoan(int iD_TaiKhoan, string username, string password, string quyen)
        {
            ID_TaiKhoan = iD_TaiKhoan;
            Username = username;
            Password = password;
            Quyen = quyen;
            DelFlg = 0;
            FlagInsert = 0;
        }
    }
}
