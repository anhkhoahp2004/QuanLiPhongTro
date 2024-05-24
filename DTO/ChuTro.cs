using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChuTro
    {
        private int _ID_ChuTro;
        private string _Ten;
        private string _SDT;
        private string _DiaChi;
        private string _CCCD;
        private string _Email;
        private int _DelFlg;
        private int _FlagInsert;

        public int ID_ChuTro { get => _ID_ChuTro; set => _ID_ChuTro = value; }
        public string Ten { get => _Ten; set => _Ten = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public string CCCD { get => _CCCD; set => _CCCD = value; }
        public string Email { get => _Email; set => _Email = value; }
        public int DelFlg { get => _DelFlg; set => _DelFlg = value; }
        public int FlagInsert { get => _FlagInsert; set => _FlagInsert = value; }

        public ChuTro(int iD_ChuTro, string ten, string sDT, string diaChi, string cCCD, string email)
        {
            ID_ChuTro = iD_ChuTro;
            Ten = ten;
            SDT = sDT;
            DiaChi = diaChi;
            CCCD = cCCD;
            Email = email;
            DelFlg = 0;
            FlagInsert = 0;
        }
    }
}
