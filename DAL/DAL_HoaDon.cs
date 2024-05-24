using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HoaDon
    {
        /*private int _ID_HoaDon;
        private int _ID_PhongTro;
        private int _SoDienCu;
        private int _SoNuocCu;
        private int _SoDienMoi;
        private int _SoNuocMoi;
        private int _ThanhTien;
        private DateTime _NgayBatDau;
        private DateTime _NgayKetThuc;
        private string _TrangThai;          // chưa thanh toán, đã thanh toán
        private int _DelFlg;
        private int _FlagInsert;*/
        #region thêm hóa đơn
        public void AddHoaDon(HoaDon hoadon)
        {
            string query = string.Format("insert into HoaDon values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', N'{8}', 0, 0)",
                                        hoadon.ID_PhongTro, hoadon.SoNuocCu, hoadon.SoNuocCu, hoadon.SoDienMoi, hoadon.SoNuocMoi,
                                        hoadon.ThanhTien, hoadon.NgayBatDau, hoadon.NgayKetThuc, hoadon.TrangThai);
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region sửa hóa đơn
        public void UpdateHoaDon(int hoadon)
        {
            string query = string.Format("update HoaDon set TrangThai = N'Đã thanh toán' where ID_HoaDon = '{0}'",hoadon.ToString());
            DataProvider.instance.ExecuteDB(query);
        }
        public void UpdateThongTinHoaDon(int hoadon, int sodienmoi, int sonuocmoi, DateTime ngayketthuc, int tien)
        {
            string query = string.Format("update HoaDon set SoNuocMoi = '{0}', SoDienMoi = '{1}', NgayKetThuc = '{2}', ThanhTien = '{3}' where ID_HoaDon = '{4}'",
                sonuocmoi.ToString(), sodienmoi.ToString(), ngayketthuc.ToString(), tien, hoadon.ToString());
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region xóa hóa đơn
        public void DeleteHoaDon(int ID_HoaDon)
        {
            string query = "UPDATE HoaDon SET DelFlg = 1 WHERE ID_HoaDon = '" + ID_HoaDon.ToString() + "';";
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region get hóa đơn
        /*public DataTable GetAllHoaDon()
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from HoaDon where DelFlg = 0").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<HoaDon> GetAllHoaDon()
        {
            List<HoaDon> list = new List<HoaDon>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from HoaDon where DelFlg = 0").Rows)
            {
                list.Add(new HoaDon(Convert.ToInt32(i["ID_HoaDon"].ToString()), Convert.ToInt32(i["ID_PhongTro"].ToString()),
                    Convert.ToInt32(i["SoDienCu"].ToString()), Convert.ToInt32(i["SoNuocCu"].ToString()), Convert.ToInt32(i["SoDienMoi"].ToString()),
                    Convert.ToInt32(i["SoNuocMoi"].ToString()), Convert.ToInt32(i["ThanhTien"].ToString()), Convert.ToDateTime(i["NgayBatDau"].ToString()),
                    Convert.ToDateTime(i["NgayKetThuc"].ToString()), i["TrangThai"].ToString()));
            }
            return list;
        }
        /*public DataTable GetHoaDonByID_PhongTro(int ID_phongtro)
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from HoaDon where DelFlg = 0 and ID_PhongTro = '" + ID_phongtro + "'").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<HoaDon> GetHoaDonByID_PhongTro(int ID_phongtro)
        {
            List<HoaDon> list = new List<HoaDon>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from HoaDon where DelFlg = 0 and ID_PhongTro = '" + ID_phongtro + "'").Rows)
            {
                list.Add(new HoaDon(Convert.ToInt32(i["ID_HoaDon"].ToString()), Convert.ToInt32(i["ID_PhongTro"].ToString()),
                    Convert.ToInt32(i["SoDienCu"].ToString()), Convert.ToInt32(i["SoNuocCu"].ToString()), Convert.ToInt32(i["SoDienMoi"].ToString()),
                    Convert.ToInt32(i["SoNuocMoi"].ToString()), Convert.ToInt32(i["ThanhTien"].ToString()), Convert.ToDateTime(i["NgayBatDau"].ToString()),
                    Convert.ToDateTime(i["NgayKetThuc"].ToString()), i["TrangThai"].ToString()));
            }
            return list;
        }
        public List<HoaDon> GetHoaDonByID_HoaDon(int ID_hoadon)
        {
            List<HoaDon> list = new List<HoaDon>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from HoaDon where DelFlg = 0 and ID_HoaDon = '" + ID_hoadon + "'").Rows)
            {
                list.Add(new HoaDon(Convert.ToInt32(i["ID_HoaDon"].ToString()), Convert.ToInt32(i["ID_PhongTro"].ToString()),
                    Convert.ToInt32(i["SoDienCu"].ToString()), Convert.ToInt32(i["SoNuocCu"].ToString()), Convert.ToInt32(i["SoDienMoi"].ToString()),
                    Convert.ToInt32(i["SoNuocMoi"].ToString()), Convert.ToInt32(i["ThanhTien"].ToString()), Convert.ToDateTime(i["NgayBatDau"].ToString()),
                    Convert.ToDateTime(i["NgayKetThuc"].ToString()), i["TrangThai"].ToString()));
            }
            return list;
        }
        /*public DataTable GetDataTableByDate(DateTime date)
        {
            // get những hóa đơn có ngày bắt đầu sau ngày chỉ định
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from HoaDon where DelFlg = 0 and NgayBatDau >= '" + date.ToString("yyyy-MM-dd HH:mm:ss") + "'").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<HoaDon> GetDataTableByDate(DateTime date)
        {
            // get những hóa đơn có ngày bắt đầu sau ngày chỉ định
            List<HoaDon> list = new List<HoaDon>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from HoaDon where DelFlg = 0 and NgayBatDau >= '" + date.ToString("yyyy-MM-dd HH:mm:ss") + "'").Rows)
            {
                list.Add(new HoaDon(Convert.ToInt32(i["ID_HoaDon"].ToString()), Convert.ToInt32(i["ID_PhongTro"].ToString()),
                    Convert.ToInt32(i["SoDienCu"].ToString()), Convert.ToInt32(i["SoNuocCu"].ToString()), Convert.ToInt32(i["SoDienMoi"].ToString()),
                    Convert.ToInt32(i["SoNuocMoi"].ToString()), Convert.ToInt32(i["ThanhTien"].ToString()), Convert.ToDateTime(i["NgayBatDau"].ToString()),
                    Convert.ToDateTime(i["NgayKetThuc"].ToString()), i["TrangThai"].ToString()));
            }
            return list;
        }
        /*// get hóa đơn phòng ID_Phongtro gần nhất
        public DataTable GetRecentHoaDonByID_PhongTro(int ID_phongtro)
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select top 1 * from HoaDon where DelFlg = 0 and ID_PhongTro = '" + ID_phongtro.ToString() + "' order by NgayKetThuc DESC").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        // get hóa đơn phòng ID_Phongtro gần nhất
        public List<HoaDon> GetRecentHoaDonByID_PhongTro(int ID_phongtro)
        {
            List<HoaDon> list = new List<HoaDon>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select top 1 * from HoaDon where DelFlg = 0 and ID_PhongTro = '" + ID_phongtro.ToString() + "' order by NgayKetThuc DESC").Rows)
            {
                list.Add(new HoaDon(Convert.ToInt32(i["ID_HoaDon"].ToString()), Convert.ToInt32(i["ID_PhongTro"].ToString()),
                    Convert.ToInt32(i["SoDienCu"].ToString()), Convert.ToInt32(i["SoNuocCu"].ToString()), Convert.ToInt32(i["SoDienMoi"].ToString()),
                    Convert.ToInt32(i["SoNuocMoi"].ToString()), Convert.ToInt32(i["ThanhTien"].ToString()), Convert.ToDateTime(i["NgayBatDau"].ToString()),
                    Convert.ToDateTime(i["NgayKetThuc"].ToString()), i["TrangThai"].ToString()));
            }
            return list;
        }
        #endregion
    }
}
