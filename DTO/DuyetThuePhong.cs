using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DuyetThuePhong
    {
        private int _ID_DuyetThuePhong;
        private int _ID_PhongTro;
        private int _ID_KhachHang;
        private int _MaXacNhan;
        private DateTime _ThoiGianKichHoat;      //      thời gian chủ trọ tạo mã xác nhận cho phòng trọ cần gửi yêu cầu
        private DateTime _ThoiGianXacNhan;
        private DateTime _ThoiGianTraPhong;
        private int _DelFlg;
        private int _FlagInsert;

        public int ID_DuyetThuePhong { get => _ID_DuyetThuePhong; set => _ID_DuyetThuePhong = value; }
        public int ID_PhongTro { get => _ID_PhongTro; set => _ID_PhongTro = value; }
        public int ID_KhachHang { get => _ID_KhachHang; set => _ID_KhachHang = value; }
        public int MaXacNhan { get => _MaXacNhan; set => _MaXacNhan = value; }
        public DateTime ThoiGianKichHoat { get => _ThoiGianKichHoat; set => _ThoiGianKichHoat = value; }
        public int DelFlg { get => _DelFlg; set => _DelFlg = value; }
        public int FlagInsert { get => _FlagInsert; set => _FlagInsert = value; }
        public DateTime ThoiGianXacNhan { get => _ThoiGianXacNhan; set => _ThoiGianXacNhan = value; }
        public DateTime ThoiGianTraPhong { get => _ThoiGianTraPhong; set => _ThoiGianTraPhong = value; }

        public DuyetThuePhong(int iD_DuyetThuePhong, int iD_PhongTro, int iD_KhachHang, int maXacNhan, DateTime thoigiankh, DateTime thoigianxn, DateTime thoigiantp)
        {
            ID_DuyetThuePhong = iD_DuyetThuePhong;
            ID_PhongTro = iD_PhongTro;
            ID_KhachHang = iD_KhachHang;   
            MaXacNhan = maXacNhan;
            ThoiGianKichHoat = thoigiankh;
            ThoiGianXacNhan = thoigianxn;
            ThoiGianTraPhong = thoigiantp;
            DelFlg = 0;
            FlagInsert = 0;
        }
    }
}
