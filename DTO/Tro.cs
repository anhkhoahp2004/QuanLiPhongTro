using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Tro
    {
        private int _ID_Tro;
        private int _ID_ChuTro;
        private string _Ten;
        private string _DiaChi;
        private int _DelFlg;
        private int _FlagInsert;

        public int ID_Tro { get => _ID_Tro; set => _ID_Tro = value; }
        public int ID_ChuTro { get => _ID_ChuTro; set => _ID_ChuTro = value; }
        public string Ten { get => _Ten; set => _Ten = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public int DelFlg { get => _DelFlg; set => _DelFlg = value; }
        public int FlagInsert { get => _FlagInsert; set => _FlagInsert = value; }
        public Tro(int iD_Tro, int iD_ChuTro, string ten, string diaChi)
        {
            ID_Tro = iD_Tro;
            ID_ChuTro = iD_ChuTro;
            Ten = ten;
            DiaChi = diaChi;
            DelFlg = 0;
            FlagInsert = 0;
        }
    }
}
