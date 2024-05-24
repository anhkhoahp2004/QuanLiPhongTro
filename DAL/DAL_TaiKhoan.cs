using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TaiKhoan
    {
        /*private int _ID_TaiKhoan;
        private string _Username;
        private string _Passwrd;        // Passwrd
        int ID_Quyen                            0           1
        private string _Quyen;          // 'Chủ trọ', 'Khách hàng'
        private int _DelFlg;
        private int _FlagInsert;*/
        #region thêm
        public void AddTaiKhoan(TaiKhoan tk)
        {
            int ms = 0;
            if (tk.Quyen == "Chủ trọ")
                ms = 0;
            else
                ms = 1;
            string query = string.Format("insert into TaiKhoan values ('{0}', '{1}', '{2}', '{3}', N'{4}', 0, 0)",
                                        tk.ID_TaiKhoan, tk.Username, tk.Password, ms.ToString(), tk.Quyen);
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region sửa
        public void UpdateTaiKhoan(TaiKhoan tk)
        {
            string query = string.Format("update TaiKhoan set Passwrd = '{0}' where ID_TaiKhoan = '{1}' and Quyen = N'{2}'",
                                             tk.Password, tk.ID_TaiKhoan, tk.Quyen);
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region xóa
        public void DeleteTaiKhoan(int ID_taikhoan, string Quyen)
        {
            string query = "update TaiKhoan set DelFlg = 1 where ID_TaiKhoan = '" + ID_taikhoan.ToString() + "' and Quyen = '" + Quyen + "'";
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region get
        /*public DataTable GetAllTaiKhoan()
        {
            DataTable dt = new DataTable();
            string query = "select * from TaiKhoan where DelFlg = 0";
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<TaiKhoan> GetAllTaiKhoan()
        {
            List<TaiKhoan> dt = new List<TaiKhoan>();
            string query = "select * from TaiKhoan where DelFlg = 0";
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Add(new TaiKhoan(Convert.ToInt32(i["ID_TaiKhoan"].ToString()), i["Username"].ToString(), i["Passwrd"].ToString(), i["Quyen"].ToString()));
            }
            return dt;
        }
        /*public DataTable GetTaiKhoanByID_TaiKhoan(int ID_taikhoan, string Quyen)
        {
            DataTable dt = new DataTable();
            string query = "select * from TaiKhoan where DelFlg = 0 and ID_TaiKhoan = '" + ID_taikhoan.ToString() + "' and Quyen = N'" + Quyen + "'";
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<TaiKhoan> GetTaiKhoanByID_TaiKhoan(int ID_taikhoan, string Quyen)
        {
            List<TaiKhoan> dt = new List<TaiKhoan>();
            string query = "select * from TaiKhoan where DelFlg = 0 and ID_TaiKhoan = '" + ID_taikhoan.ToString() + "' and Quyen = N'" + Quyen + "'";
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Add(new TaiKhoan(Convert.ToInt32(i["ID_TaiKhoan"].ToString()), i["Username"].ToString(), i["Passwrd"].ToString(), i["Quyen"].ToString()));
            }
            return dt;
        }
        /*public DataTable GetTaiKhoanByQuyen(string quyen)
        {
            DataTable dt = new DataTable();
            string query = "select * from TaiKhoan where DelFlg = 0 and Quyen = '" + quyen + "'";
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<TaiKhoan> GetTaiKhoanByQuyen(string quyen)
        {
            List<TaiKhoan> dt = new List<TaiKhoan>();
            string query = "select * from TaiKhoan where DelFlg = 0 and Quyen = N'" + quyen + "'";
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Add(new TaiKhoan(Convert.ToInt32(i["ID_TaiKhoan"].ToString()), i["Username"].ToString(), i["Passwrd"].ToString(), i["Quyen"].ToString()));
            }
            return dt;
        }
        /*public DataTable GetTaiKhoanByUsername(string username)
        {
            DataTable dt = new DataTable();
            string query = "select * from TaiKhoan where DelFlg = 0 and Username = '" + username + "'";
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<TaiKhoan> GetTaiKhoanByUsername(string username)
        {
            List<TaiKhoan> dt = new List<TaiKhoan>();
            string query = "select * from TaiKhoan where DelFlg = 0 and Username = '" + username + "'";
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Add(new TaiKhoan(Convert.ToInt32(i["ID_TaiKhoan"].ToString()), i["Username"].ToString(), i["Passwrd"].ToString(), i["Quyen"].ToString()));
            }
            return dt;
        }
        public List<TaiKhoan> DangNhap(string username, string password, string quyen)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            string query = string.Format("select * from TaiKhoan where DelFlg = 0 and Username = '{0}' and Passwrd = '{1}' and Quyen = N'{2}'",
                                        username, password, quyen);
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                list.Add(new TaiKhoan(Convert.ToInt32(i["ID_TaiKhoan"].ToString()), username, password, quyen));
            }
            return list;
        }
        #endregion
    }
}
