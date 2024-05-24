using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DuyetThuePhong
    {
        /*private int _ID_DuyetThuePhong;
        private int _ID_PhongTro;
        private int _ID_KhachHang;
        private int _MaXacNhan;
        private DateTime _ThoiGianKichHoat;      //      thời gian chủ trọ tạo mã xác nhận cho phòng trọ cần gửi yêu cầu
        private DateTime _ThoiGianXacNhan;
        private DateTime _ThoiGianTraPhong;
        private int _DelFlg;
        private int _FlagInsert;*/
        #region thêm 
        public void AddDuyetThuePhong(DuyetThuePhong dtp)
        {
            string query = string.Format("insert into DuyetThuePhong values ('{0}', null, '{1}', '{2}', '{3}', 0, 0, 0)"
                                        , dtp.ID_PhongTro.ToString(), dtp.MaXacNhan.ToString(), 
                                        dtp.ThoiGianKichHoat.ToString("yyyy-MM-dd HH:mm:ss"), dtp.ThoiGianXacNhan.ToString("yyyy-MM-dd HH:mm:ss"));
            if (dtp.MaXacNhan == 0)
            {
                query = string.Format("insert into DuyetThuePhong values ('{0}', '{1}', 0, '{2}', '{3}', 0, 0, 0)"
                                        , dtp.ID_PhongTro.ToString(), dtp.ID_KhachHang.ToString(), dtp.ThoiGianKichHoat.ToString("yyyy-MM-dd HH:mm:ss"),
                                        dtp.ThoiGianXacNhan.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region sửa 
        public void UpdateDuyetThuePhong(DuyetThuePhong dtp)
        {
            string query = string.Format("update DuyetThuePhong set ID_KhachHang = '{0}', ThoiGianXacNhan = '{1}', ThoiGianTraPhong = '{2}' where ID_DuyetThuePhong = '{3}'",
                dtp.ID_KhachHang.ToString(), dtp.ThoiGianXacNhan.ToString("yyyy-MM-dd HH:mm:ss"), dtp.ThoiGianTraPhong.ToString("yyyy-MM-dd HH:mm:ss"), dtp.ID_DuyetThuePhong.ToString());   
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region xóa 
        public void DeleteDuyetThuePhong()
        {
            // xóa những mã xác nhận quá hạn (quá 1 ngày từ khi khởi tạo) mà không có ai yêu cầu
            string query = "update DuyetThuePhong set DelFlg = 1 WHERE DATEDIFF(day, ThoiGianKichHoat, GETDATE()) > 1 and ID_KhachHang = null";
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region get 
        /*public DataTable GetAllDuyetThuePhong()
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from DuyetThuePhong where DelFlg = 0").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<DuyetThuePhong> GetAllDuyetThuePhong()
        {
            List<DuyetThuePhong> list = new List<DuyetThuePhong>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from DuyetThuePhong where DelFlg = 0").Rows)
            {
                list.Add(new DuyetThuePhong(Convert.ToInt32(i["ID_DuyetThuePhong"].ToString()), Convert.ToInt32(i["ID_PhongTro"].ToString()),
                    Convert.ToInt32(i["ID_KhachHang"].ToString()), Convert.ToInt32(i["MaXacNhan"].ToString()), Convert.ToDateTime(i["ThoiGianKichHoat"].ToString()),
                    Convert.ToDateTime(i["ThoiGianXacNhan"].ToString()), Convert.ToDateTime(i["ThoiGianTraPhong"].ToString())));
            }
            return list;
        }
        /*public DataTable GetDuyetThuePhongByID_Phong(int ID_phong)
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from DuyetThuePhong where DelFlg = 0 and ID_PhongTro = '" + ID_phong + "'").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<DuyetThuePhong> GetDuyetThuePhongByID_Phong(int ID_phong)
        {
            List<DuyetThuePhong> list = new List<DuyetThuePhong>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from DuyetThuePhong where DelFlg = 0 and ID_PhongTro = '" + ID_phong + "'").Rows)
            {
                list.Add(new DuyetThuePhong(Convert.ToInt32(i["ID_DuyetThuePhong"].ToString()), Convert.ToInt32(i["ID_PhongTro"].ToString()),
                    Convert.ToInt32(i["ID_KhachHang"].ToString()), Convert.ToInt32(i["MaXacNhan"].ToString()), Convert.ToDateTime(i["ThoiGianKichHoat"].ToString()),
                    Convert.ToDateTime(i["ThoiGianXacNhan"].ToString()), Convert.ToDateTime(i["ThoiGianTraPhong"].ToString())));
            }
            return list;
        }
        /*public DataTable GetDuyetThuePhongByMaXacNhan(int maxacnhan)
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from DuyetThuePhong where DelFlg = 0 and MaXacNhan = '" + maxacnhan + "'").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<DuyetThuePhong> GetDuyetThuePhongByID_KhachHang(int ID_phong)
        {
            List<DuyetThuePhong> list = new List<DuyetThuePhong>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from DuyetThuePhong where DelFlg = 0 and ID_KhachHang = '" + ID_phong + "' and ThoiGianXacNhan >= ThoiGianKichHoat").Rows)
            {
                list.Add(new DuyetThuePhong(Convert.ToInt32(i["ID_DuyetThuePhong"].ToString()), Convert.ToInt32(i["ID_PhongTro"].ToString()),
                    Convert.ToInt32(i["ID_KhachHang"].ToString()), Convert.ToInt32(i["MaXacNhan"].ToString()), Convert.ToDateTime(i["ThoiGianKichHoat"].ToString()),
                    Convert.ToDateTime(i["ThoiGianXacNhan"].ToString()), Convert.ToDateTime(i["ThoiGianTraPhong"].ToString())));
            }
            return list;
        }
        public List<DuyetThuePhong> GetRecentDuyetThuePhongByID_KhachHang(int ID_phong)
        { 
            List<DuyetThuePhong> list = new List<DuyetThuePhong>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select top 1 * from DuyetThuePhong where DelFlg = 0 and ID_KhachHang = '" + ID_phong + "' and ThoiGianXacNhan >= ThoiGianKichHoat order by ThoiGianXacNhan desc").Rows)
            {
                list.Add(new DuyetThuePhong(Convert.ToInt32(i["ID_DuyetThuePhong"].ToString()), Convert.ToInt32(i["ID_PhongTro"].ToString()),
                    Convert.ToInt32(i["ID_KhachHang"].ToString()), Convert.ToInt32(i["MaXacNhan"].ToString()), Convert.ToDateTime(i["ThoiGianKichHoat"].ToString()),
                    Convert.ToDateTime(i["ThoiGianXacNhan"].ToString()), Convert.ToDateTime(i["ThoiGianTraPhong"].ToString())));
            }
            return list;
        }
        public List<DuyetThuePhong> GetDuyetThuePhongByMaXacNhan(int maxacnhan)
        {
            List<DuyetThuePhong> list = new List<DuyetThuePhong>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from DuyetThuePhong where DelFlg = 0 and MaXacNhan = '" + maxacnhan + "'").Rows)
            {
                list.Add(new DuyetThuePhong(Convert.ToInt32(i["ID_DuyetThuePhong"].ToString()), Convert.ToInt32(i["ID_PhongTro"].ToString()),
                    Convert.ToInt32(i["ID_KhachHang"].ToString()), Convert.ToInt32(i["MaXacNhan"].ToString()), Convert.ToDateTime(i["ThoiGianKichHoat"].ToString()),
                    Convert.ToDateTime(i["ThoiGianXacNhan"].ToString()), Convert.ToDateTime(i["ThoiGianTraPhong"].ToString())));
            }
            return list;
        }
        #endregion
    }
}
