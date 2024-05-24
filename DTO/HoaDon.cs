using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        private int _ID_HoaDon;
        private int _ID_PhongTro;
        private int _SoDienCu;
        private int _SoNuocCu;
        private int _SoDienMoi;
        private int _SoNuocMoi;
        private int _ThanhTien;
        private DateTime _NgayBatDau;
        private DateTime _NgayKetThuc;
        private string _TrangThai;          // 'Chưa thanh toán', 'Đã thanh toán'
        private int _DelFlg;
        private int _FlagInsert;

        public int ID_HoaDon { get => _ID_HoaDon; set => _ID_HoaDon = value; }
        public int ID_PhongTro { get => _ID_PhongTro; set => _ID_PhongTro = value; }
        public int SoDienCu { get => _SoDienCu; set => _SoDienCu = value; }
        public int SoNuocCu { get => _SoNuocCu; set => _SoNuocCu = value; }
        public int SoDienMoi { get => _SoDienMoi; set => _SoDienMoi = value; }
        public int SoNuocMoi { get => _SoNuocMoi; set => _SoNuocMoi = value; }
        public int ThanhTien { get => _ThanhTien; set => _ThanhTien = value; }
        public DateTime NgayBatDau { get => _NgayBatDau; set => _NgayBatDau = value; }
        public DateTime NgayKetThuc { get => _NgayKetThuc; set => _NgayKetThuc = value; }
        public string TrangThai { get => _TrangThai; set => _TrangThai = value; }
        public int DelFlg { get => _DelFlg; set => _DelFlg = value; }
        public int FlagInsert { get => _FlagInsert; set => _FlagInsert = value; }
        public HoaDon(int iD_HoaDon, int iD_PhongTro, int soDienCu, int soNuocCu, int soDienMoi, int soNuocMoi, int thanhTien, DateTime ngayBatDau, DateTime ngayKetThuc, string trangthai)
        {           // SoDienCu, SoNuocCu, ThanhTien được tính toán trước khi truyền vào
            ID_HoaDon = iD_HoaDon;
            ID_PhongTro = iD_PhongTro;
            SoDienCu = soDienCu;
            SoNuocCu = soNuocCu;
            SoDienMoi = soDienMoi;
            SoNuocMoi = soNuocMoi;
            ThanhTien = thanhTien;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            TrangThai = trangthai;
            DelFlg = 0;
            FlagInsert = 0;
        }
    }
}
