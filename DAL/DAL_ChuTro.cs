using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ChuTro
    {
        /*private int _ID_ChuTro;
        private string _Ten;
        private string _SDT;
        private string _DiaChi;
        private string _CCCD;
        private string _Email;
        private int _DelFlg;
        private int _FlagInsert;*/
        #region thêm chủ trọ
        public void AddChuTro(ChuTro chutro)
        {
            string query = string.Format("insert into ChuTro values (N'{0}', '{1}', N'{2}', '{3}', '{4}', 0, 0)",
                                        chutro.Ten, chutro.SDT, chutro.DiaChi, chutro.CCCD, chutro.Email);
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region sửa chủ trọ
        public void UpdateChuTro(ChuTro chutro)
        {
            string query = string.Format("update ChuTro set Ten = N'{0}', SDT = '{1}', DiaChi = N'{2}', CCCD = '{3}', Email = '{4}', FlagInsert = 1 where ID_ChuTro = '{5}'",
                                        chutro.Ten, chutro.SDT, chutro.DiaChi, chutro.CCCD, chutro.Email, chutro.ID_ChuTro.ToString());
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region xóa chủ trọ
        public void DeleteChuTro(int ID_Chutro)
        {
            string query = "UPDATE ChuTro SET DelFlg = 1 WHERE ID_ChuTro = '" + ID_Chutro.ToString() + "';";
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region get chủ trọ
        /*public DataTable GetAllChuTro()
        {
            DataTable dt = new DataTable();
            foreach(DataRow i in DataProvider.instance.GetRecord("select * from ChuTro where DelFlg = 0").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<ChuTro> GetAllChuTro()
        {
            List<ChuTro> list = new List<ChuTro>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from ChuTro where DelFlg = 0").Rows)
            {
                list.Add(new ChuTro(Convert.ToInt32(i["ID_ChuTro"].ToString()), i["Ten"].ToString(), i["SDT"].ToString(), i["DiaChi"].ToString(), i["CCCD"].ToString(), i["Email"].ToString()));
            }
            return list;
        }
        /*public DataTable GetChuTro(int ID_Chutro) 
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from ChuTro where DelFlg = 0 and ID_ChuTro = '" + ID_Chutro.ToString() + "'").Rows )
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<ChuTro> GetChuTro(int ID_Chutro)
        {
            List<ChuTro> list = new List<ChuTro>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from ChuTro where DelFlg = 0 and ID_ChuTro = '" + ID_Chutro.ToString() + "'").Rows)
            {
                list.Add(new ChuTro(Convert.ToInt32(i["ID_ChuTro"].ToString()), i["Ten"].ToString(), i["SDT"].ToString(), i["DiaChi"].ToString(), i["CCCD"].ToString(), i["Email"].ToString()));
            }
            return list;
        }
        /*public DataTable GetRecentChuTro()
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select top 1 * from ChuTro where DelFlg = 0 order by ID_ChuTro DESC").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        // get chủ trọ được đăng kí mới nhất
        public List<ChuTro> GetRecentChuTro()
        {
            List<ChuTro> list = new List<ChuTro>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select top 1 * from ChuTro where DelFlg = 0 order by ID_ChuTro DESC").Rows)
            {
                list.Add(new ChuTro(Convert.ToInt32(i["ID_ChuTro"].ToString()), i["Ten"].ToString(), i["SDT"].ToString(), i["DiaChi"].ToString(), i["CCCD"].ToString(), i["Email"].ToString()));
            }
            return list;
        }
        #endregion
    }
}
