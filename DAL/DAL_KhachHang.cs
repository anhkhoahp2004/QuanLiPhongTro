using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhachHang
    {
        /*private int _ID_KhachHang;
        private string _Ten;
        private string _CCCD;
        private string _SDT;
        private string _Email;
        private string _NgheNghiep;
        private int _ID_PhongTro;
        private int _DelFlg;
        private int _FlagInsert;*/
        #region thêm
        // thêm mới khách hàng (với )
        public void AddKhachHang(KhachHang kh)
        {
            string query = "";
            if(kh.ID_PhongTro > 0)
            {
                query = string.Format("insert into KhachHang values (N'{0}', '{1}', '{2}', '{3}', N'{4}', '{5}', 0, 0)",
                                        kh.Ten, kh.CCCD, kh.SDT, kh.Email, kh.NgheNghiep, kh.ID_PhongTro);
            }
            else
            {
                query = string.Format("insert into KhachHang values (N'{0}', '{1}', '{2}', '{3}', N'{4}', null, 0, 0)",
                                        kh.Ten, kh.CCCD, kh.SDT, kh.Email, kh.NgheNghiep); 
            }
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region sửa
        public void UpDateKhachHang(KhachHang kh)
        {
            string query = string.Format("update KhachHang set Ten = N'{0}', CCCD = '{1}', SDT = '{2}', Email = '{3}', NgheNghiep = N'{4}', ID_PhongTro = '{5}' where ID_KhachHang = '{6}'",
                                        kh.Ten, kh.CCCD, kh.SDT, kh.Email, kh.NgheNghiep, kh.ID_PhongTro, kh.ID_KhachHang );
            DataProvider.instance.ExecuteDB(query);
        }
        public void UpDateID_PhongTro(KhachHang kh)
        {
            string query = string.Format("update KhachHang set ID_PhongTro = null where ID_KhachHang = '{0}'", kh.ID_KhachHang);
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region xóa
        public void DeleteKhachHang(int ID_khachhang)
        {
            string query = "update KhachHang set DelFlg = 0 WHERE ID_KhachHang = '" + ID_khachhang + "'";
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region get
        /*public DataTable GetAllKhachHang()
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from KhachHang where DelFlg = 0").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<KhachHang> GetAllKhachHang()
        {
            List<KhachHang> dt = new List<KhachHang>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from KhachHang where DelFlg = 0").Rows)
            {
                dt.Add(new KhachHang(Convert.ToInt32(i["ID_KhachHang"].ToString()), i["Ten"].ToString(), i["CCCD"].ToString(),
                    i["SDT"].ToString(), i["Email"].ToString(), i["NgheNghiep"].ToString(), Convert.ToInt32(i["ID_PhongTro"].ToString())));
            }
            return dt;
        }
        /*public DataTable GetKhachHangByID_KhachHang(int ID_khachhang)
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from KhachHang where DelFlg = 0 and ID_KhachHang = '" + ID_khachhang + "'").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<KhachHang> GetKhachHangByID_KhachHang(int ID_khachhang)
        {
            List<KhachHang> dt = new List<KhachHang>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from KhachHang where DelFlg = 0 and ID_KhachHang = '" + ID_khachhang + "'").Rows)
            {
                int id = 0;
                if (i["ID_PhongTro"].ToString() == "")
                    id = 0;
                else
                    id = Convert.ToInt32(i["ID_PhongTro"].ToString());
                dt.Add(new KhachHang(Convert.ToInt32(i["ID_KhachHang"].ToString()), i["Ten"].ToString(), i["CCCD"].ToString(),
                    i["SDT"].ToString(), i["Email"].ToString(), i["NgheNghiep"].ToString(), id));
            }
            return dt;
        }
        /*public DataTable GetKhachHangByID_PhongTro(int ID_phongtro)
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from KhachHang where DelFlg = 0 and ID_PhongTro = '" + ID_phongtro + "'").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<KhachHang> GetKhachHangByID_PhongTro(int ID_phongtro)
        {
            List<KhachHang> dt = new List<KhachHang>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from KhachHang where DelFlg = 0 and ID_PhongTro = '" + ID_phongtro + "'").Rows)
            {
                dt.Add(new KhachHang(Convert.ToInt32(i["ID_KhachHang"].ToString()), i["Ten"].ToString(), i["CCCD"].ToString(),
                    i["SDT"].ToString(), i["Email"].ToString(), i["NgheNghiep"].ToString(), Convert.ToInt32(i["ID_PhongTro"].ToString())));
            }
            return dt;
        }
        /*public DataTable GetRecentKhachHang()
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select top 1 * from KhachHang where DelFlg = 0 order by ID_KhachHang DESC").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<KhachHang> GetRecentKhachHang()
        {
            List<KhachHang> dt = new List<KhachHang>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select top 1 * from KhachHang where DelFlg = 0 order by ID_KhachHang DESC").Rows)
            {
                dt.Add(new KhachHang(Convert.ToInt32(i["ID_KhachHang"].ToString()), i["Ten"].ToString(), i["CCCD"].ToString(),
                    i["SDT"].ToString(), i["Email"].ToString(), i["NgheNghiep"].ToString(), Convert.ToInt32(i["ID_PhongTro"].ToString())));
            }
            return dt;
        }
        #endregion
    }
}
