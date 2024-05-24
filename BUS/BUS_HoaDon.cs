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
    public class BUS_HoaDon
    {
        #region thêm hóa đơn
        public void AddHoaDon(HoaDon hoadon)
        {
            DAL_HoaDon dal = new DAL_HoaDon();
            dal.AddHoaDon(hoadon);
        }
        #endregion
        #region sửa hóa đơn
        public void UpdateHoaDon(int hoadon)
        {
            DAL_HoaDon dal = new DAL_HoaDon();
            dal.UpdateHoaDon(hoadon);
        }
        public void UpdateThongTinHoaDon(int hoadon, int sodienmoi, int sonuocmoi, DateTime ngayketthuc, int tien)
        {
            DAL_HoaDon dal = new DAL_HoaDon();
            dal.UpdateThongTinHoaDon(hoadon, sodienmoi, sonuocmoi, ngayketthuc, tien);
        }
        #endregion
        #region xóa hóa đơn
        public void DeleteHoaDon(int ID_HoaDon)
        {
            DAL_HoaDon dal = new DAL_HoaDon();
            dal.DeleteHoaDon(ID_HoaDon);
        }
        #endregion
        #region get hóa đơn
        public List<HoaDon> GetAllHoaDon()
        {
            List<HoaDon> dt = new List<HoaDon>();
            DAL_HoaDon dal = new DAL_HoaDon();
            foreach (HoaDon i in dal.GetAllHoaDon())
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<HoaDon> GetHoaDonByID_PhongTro(int ID_phongtro)
        {
            List<HoaDon> dt = new List<HoaDon>();
            DAL_HoaDon dal = new DAL_HoaDon();
            foreach (HoaDon i in dal.GetHoaDonByID_PhongTro(ID_phongtro))
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<HoaDon> GetHoaDonByID_HoaDon(int ID_hoadon)
        {
            List<HoaDon> dt = new List<HoaDon>();
            DAL_HoaDon dal = new DAL_HoaDon();
            foreach (HoaDon i in dal.GetHoaDonByID_HoaDon(ID_hoadon))
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<HoaDon> GetHoaDonByDate(DateTime date)
        {
            // get những hóa đơn có ngày bắt đầu sau ngày chỉ định
            List<HoaDon> dt = new List<HoaDon>();
            DAL_HoaDon dal = new DAL_HoaDon();
            foreach (HoaDon i in dal.GetDataTableByDate(date))
            {
                dt.Add(i);
            }
            return dt;
        }
        // get những hóa đơn có mã phòng ID_PhongTro có ngày bắt đầu sau ngày chỉ định
        public List<HoaDon> GetHoaDonByID_PhongTro(int ID_phongtro, DateTime date)
        {
            List<HoaDon> dt = new List<HoaDon>();
            DAL_HoaDon dal = new DAL_HoaDon();
            foreach (HoaDon i in dal.GetHoaDonByID_PhongTro(ID_phongtro))
            {
                if (i.NgayBatDau >= date)
                    dt.Add(i);
            }
            return dt;
        }
        // get hóa đơn phòng ID_Phongtro gần nhất
        public List<HoaDon> GetRecentHoaDonByID_PhongTro(int ID_phongtro)
        {
            List<HoaDon> dt = new List<HoaDon>();
            DAL_HoaDon dal = new DAL_HoaDon();
            foreach (HoaDon i in dal.GetRecentHoaDonByID_PhongTro(ID_phongtro))
            {
                dt.Add(i);
            }
            return dt;
        }
        #endregion
    }
}
