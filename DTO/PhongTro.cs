using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongTro
    {
        private int _ID_PhongTro;
        private string _Ten;
        private int _ID_Tro;
        private int _TienPhong;
        private int _GiaDien;
        private int _GiaNuoc;
        private int _SoNguoiToiDa;  // số người ở tối đa trong 1 phòng 
        private int _SoNguoiO;      // số người ở tại thời điểm hiện tại
        private string _TrangThaiPhong;  // khi khởi tạo --> mặc định là DangChoThue
        // 'Đang cho thuê', 'Có người', 'Sửa chữa'
        private int _SoThangNo;
        // số tháng nợ hóa đơn ban đầu là 0, nếu mỗi tháng nợ --> tăng lên 1
        private int _DelFlg;
        private int _FlagInsert;

        public int ID_PhongTro { get => _ID_PhongTro; set => _ID_PhongTro = value; }
        public string Ten { get => _Ten; set => _Ten = value; }
        public int ID_Tro { get => _ID_Tro; set => _ID_Tro = value; }
        public int TienPhong { get => _TienPhong; set => _TienPhong = value; }
        public int GiaDien { get => _GiaDien; set => _GiaDien = value; }
        public int GiaNuoc { get => _GiaNuoc; set => _GiaNuoc = value; }
        public int SoNguoiToiDa { get => _SoNguoiToiDa; set => _SoNguoiToiDa = value; }
        public int SoNguoiO { get => _SoNguoiO; set => _SoNguoiO = value; }
        public string TrangThaiPhong { get => _TrangThaiPhong; set => _TrangThaiPhong = value; }
        public int DelFlg { get => _DelFlg; set => _DelFlg = value; }
        public int FlagInsert { get => _FlagInsert; set => _FlagInsert = value; }
        public int SoThangNo { get => _SoThangNo; set => _SoThangNo = value; }

        public PhongTro (int id_phongtro, string ten, int id_tro, int tienphong, int giadien, int gianuoc, int sntd, int sno, string ttp, int stn)
        {
            ID_PhongTro = id_phongtro;
            Ten = ten;
            ID_Tro = id_tro;
            TienPhong = tienphong;
            GiaDien = giadien;
            GiaNuoc = gianuoc;
            SoNguoiToiDa = sntd;
            SoNguoiO = sno;
            TrangThaiPhong = ttp;
            SoThangNo = stn;
            DelFlg = 0;
            FlagInsert = 0;
        }
    }
}
