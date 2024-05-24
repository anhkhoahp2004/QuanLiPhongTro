using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BUS
{
    public class BUS_DuyetThuePhong
    {
        #region thêm 
        public void AddDuyetThuePhong(DuyetThuePhong dtp)
        {
            DAL_DuyetThuePhong dal = new DAL_DuyetThuePhong();
            dal.AddDuyetThuePhong(dtp);
        }
        #endregion
        #region sửa 
        public void UpdateDuyetThuePhong(DuyetThuePhong dtp)
        {
            DAL_DuyetThuePhong dal = new DAL_DuyetThuePhong();
            dal.UpdateDuyetThuePhong(dtp);
        }
        #endregion
        #region xóa 
        public void DeleteDuyetThuePhong()
        {
            // xóa những mã xác nhận quá hạn (quá 1 ngày từ khi khởi tạo)
            DAL_DuyetThuePhong dal = new DAL_DuyetThuePhong();
            dal.DeleteDuyetThuePhong();
        }
        #endregion
        #region get 
        public List<DuyetThuePhong> GetAllDuyetThuePhong()
        {
            List<DuyetThuePhong> list = new List<DuyetThuePhong>();
            DAL_DuyetThuePhong dal = new DAL_DuyetThuePhong();
            foreach (DuyetThuePhong i in dal.GetAllDuyetThuePhong())
            {
                list.Add(i);
            }
            return list;
        }
        // get những yêu cầu đối với phòng có mã ID_phong
        public List<DuyetThuePhong> GetDuyetThuePhongByID_Phong(int ID_phong)
        {
            List<DuyetThuePhong> list = new List<DuyetThuePhong>();
            DAL_DuyetThuePhong dal = new DAL_DuyetThuePhong();
            foreach (DuyetThuePhong i in dal.GetDuyetThuePhongByID_Phong(ID_phong))
            {
                list.Add(i);
            }
            return list;
        }
        public List<DuyetThuePhong> GetDuyetThuePhongByID_KhachHang(int ID_phong)
        {
            List<DuyetThuePhong> list = new List<DuyetThuePhong>();
            DAL_DuyetThuePhong dal = new DAL_DuyetThuePhong();
            foreach (DuyetThuePhong i in dal.GetDuyetThuePhongByID_KhachHang(ID_phong))
            {
                list.Add(i);
            }
            return list;
        }
        public List<DuyetThuePhong> GetRecentDuyetThuePhongByID_KhachHang(int ID_phong)
        {
            List<DuyetThuePhong> list = new List<DuyetThuePhong>();
            DAL_DuyetThuePhong dal = new DAL_DuyetThuePhong();
            foreach (DuyetThuePhong i in dal.GetRecentDuyetThuePhongByID_KhachHang(ID_phong))
            {
                list.Add(i);
            }
            return list;
        }
        // get những yêu cầu đối với phòng có mã ID_phong với thời gian mở mã xác nhận sau thời gian chỉ định
        public List<DuyetThuePhong> GetDuyetThuePhongByID_Phong(int ID_phong, DateTime date)
        {
            List<DuyetThuePhong> list = new List<DuyetThuePhong>();
            DAL_DuyetThuePhong dal = new DAL_DuyetThuePhong();
            foreach (DuyetThuePhong i in dal.GetDuyetThuePhongByID_Phong(ID_phong))
            {
                if (i.ThoiGianKichHoat >= date)
                    list.Add(i);
            }
            return list;
        }
        public List<DuyetThuePhong> GetDuyetThuePhongByMaXacNhan(int maxacnhan)
        {
            List<DuyetThuePhong> list = new List<DuyetThuePhong>();
            DAL_DuyetThuePhong dal = new DAL_DuyetThuePhong();
            foreach (DuyetThuePhong i in dal.GetDuyetThuePhongByMaXacNhan(maxacnhan))
            {
                list.Add(i);
            }
            return list;
        }
        #endregion
    }
}
