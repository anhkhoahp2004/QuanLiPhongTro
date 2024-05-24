using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_KhachHang
    {
        #region thêm
        public void AddKhachHang(KhachHang kh)
        {
            DAL_KhachHang dal = new DAL_KhachHang();
            dal.AddKhachHang(kh);
        }
        #endregion
        #region sửa
        public void UpDateKhachHang(KhachHang kh)
        {
            DAL_KhachHang dal = new DAL_KhachHang();
            dal.UpDateKhachHang(kh);
        }
        public void UpDateID_PhongTro(KhachHang kh)
        {
            DAL_KhachHang dal = new DAL_KhachHang();
            dal.UpDateID_PhongTro(kh);
        }
        #endregion
        #region xóa
        public void DeleteKhachHang(int ID_khachhang)
        {
            DAL_KhachHang dal = new DAL_KhachHang();
            dal.DeleteKhachHang(ID_khachhang);
        }
        #endregion
        #region get
        public List<KhachHang> GetAllKhachHang()
        {
            List<KhachHang> dt = new List<KhachHang>();
            DAL_KhachHang dal = new DAL_KhachHang();
            foreach (KhachHang i in dal.GetAllKhachHang())
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<KhachHang> GetKhachHangByID_KhachHang(int ID_khachhang)
        {
            List<KhachHang> dt = new List<KhachHang>();
            DAL_KhachHang dal = new DAL_KhachHang();
            foreach (KhachHang i in dal.GetKhachHangByID_KhachHang(ID_khachhang))
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<KhachHang> GetKhachHangByID_PhongTro(int ID_phongtro)
        {
            List<KhachHang> dt = new List<KhachHang>();
            DAL_KhachHang dal = new DAL_KhachHang();
            foreach (KhachHang i in dal.GetKhachHangByID_PhongTro(ID_phongtro))
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<KhachHang> GetRecentKhachHang()
        {
            List<KhachHang> dt = new List<KhachHang>();
            DAL_KhachHang dal = new DAL_KhachHang();
            foreach (KhachHang i in dal.GetRecentKhachHang())
            {
                dt.Add(i);
            }
            return dt;
        }
        #endregion
    }
}
