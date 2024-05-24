using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Tro
    {
        /*private int _ID_Tro;
        private int _ID_ChuTro;
        private string _Ten;
        private string _DiaChi;
        private int _DelFlg;
        private int _FlagInsert;*/
        #region thêm
        public void AddTro(Tro tro)
        {
            string query = string.Format("insert into Tro values ('{0}', N'{1}', N'{2}', 0, 0)", tro.ID_ChuTro, tro.Ten, tro.DiaChi);
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region sửa
        public void UpdateTro(Tro tro)
        {
            string query = string.Format("update Tro set Ten = N'{0}', DiaChi = N'{1}' where ID_Tro = '{2}'", tro.Ten, tro.DiaChi, tro.ID_ChuTro.ToString());
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region xóa
        public void DeleteTro(int ID_tro)
        {
            string query = string.Format("update Tro set DelFlg = 1 where ID_Tro = '{0}'", ID_tro);
            DataProvider.instance.ExecuteDB(query);
        }
        public void DeleteTroByID_ChuTro(int ID_chutro)
        {
            string query = string.Format("update Tro set DelFlg = 1 where ID_ChuTro = '{0}'", ID_chutro);
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region get
        /*public DataTable GetAllTro()
        {
            DataTable dt = new DataTable();
            string query = string.Format("select * from Tro where DelFLg = 0");
            foreach(DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Rows.Add(i); 
            }
            return dt;
        }*/
        public List<Tro> GetAllTro()
        {
            List<Tro> dt = new List<Tro>();
            string query = string.Format("select * from Tro where DelFLg = 0");
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Add(new Tro(Convert.ToInt32(i["ID_Tro"].ToString()), Convert.ToInt32(i["ID_ChuTro"].ToString()), i["Ten"].ToString(), i["DiaChi"].ToString()));
            }
            return dt;
        }
        /*public DataTable GetTroByID_Tro(int ID_tro)
        {
            DataTable dt = new DataTable();
            string query = string.Format("select * from Tro where DelFLg = 0 and ID_Tro = '{0}'", ID_tro.ToString());
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<Tro> GetTroByID_Tro(int ID_tro)
        {
            List<Tro> dt = new List<Tro>();
            string query = string.Format("select * from Tro where DelFLg = 0 and ID_Tro = '{0}'", ID_tro.ToString());
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Add(new Tro(Convert.ToInt32(i["ID_Tro"].ToString()), Convert.ToInt32(i["ID_ChuTro"].ToString()), i["Ten"].ToString(), i["DiaChi"].ToString()));
            }
            return dt;
        }
        /*public DataTable GetTroByID_ChuTro(int ID_chutro)
        {
            DataTable dt = new DataTable();
            string query = string.Format("select * from Tro where DelFLg = 0 and ID_ChuTro = '{0}'", ID_chutro.ToString());
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<Tro> GetTroByID_ChuTro(int ID_chutro)
        {
            List<Tro> dt = new List<Tro>();
            string query = string.Format("select * from Tro where DelFLg = 0 and ID_ChuTro = '{0}'", ID_chutro.ToString());
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Add(new Tro(Convert.ToInt32(i["ID_Tro"].ToString()), Convert.ToInt32(i["ID_ChuTro"].ToString()), i["Ten"].ToString(), i["DiaChi"].ToString()));
            }
            return dt;
        }
        #endregion
    }
}
