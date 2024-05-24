using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PhongTro
    {
        /*private int _ID_PhongTro;
        private string _Ten;
        private int _ID_Tro;
        private int _TienPhong;
        private int _GiaDien;
        private int _GiaNuoc;
        private int _SoNguoiToiDa;  // số người ở tối đa trong 1 phòng 
        private int _SoNguoiO;      // số người ở tại thời điểm hiện tại
        private string _TrangThaiPhong;  // khi khởi tạo --> mặc định là 'Đang cho thuê'
        // 'Đang cho thuê', 'Có người', 'Sửa chữa'
        private int _SoThangNo;
        private int _DelFlg;
        private int _FlagInsert;*/
        #region thêm
        public void AddPhongTro(PhongTro pt)
        {
            string query = string.Format("insert into PhongTro values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', 0, 0, 0)",
                                        pt.Ten, pt.ID_Tro, pt.TienPhong, pt.GiaDien, pt.GiaNuoc, pt.SoNguoiToiDa, pt.SoNguoiO, pt.TrangThaiPhong);
        }
        #endregion
        #region sửa
        public void UpdatePhongTro(PhongTro pt)
        {
            string query = string.Format("update PhongTro set Ten = '{0}', ID_Tro = '{1}', TienPhong = '{2}', GiaDien = '{3}', GiaNuoc = '{4}', SoNguoiToiDa = '{5}', SoNguoiO = '{6}', TrangThaiPhong = '{7}' WHERE ID_PhongTro = '{8}'",
                                        pt.Ten, pt.ID_Tro, pt.TienPhong, pt.GiaDien, pt.GiaNuoc, pt.SoNguoiToiDa, pt.SoNguoiO, pt.TrangThaiPhong, pt.ID_PhongTro);
            DataProvider.instance.ExecuteDB(query);
        }
        // value = 1 --> tăng 2 tháng nợ, value = -1 --> giảm 1 tháng nợ
        public void UpdateSoThangNo(int ID_PhongTro, int value)
        {
            DataRow i = DataProvider.instance.GetRecord("select SoThangNo from PhongTro where DelFlg = 0 and ID_PhongTro = '" + ID_PhongTro + "'").Rows[0];
            int tmp = Convert.ToInt32(i[0]) + value;
            string query = string.Format("update PhongTro set SoThangNo = '{0}' where ID_PhongTro = '{1}'", tmp, ID_PhongTro);
            DataProvider.instance.ExecuteDB(query);
        }
        public void UpdateSoNguoiO(int ID_PhongTro, int stn, int sno)
        {
            string query = string.Format("update PhongTro set SoThangNo = '{0}', SoNguoiO = '{1}' where ID_PhongTro = '{2}'", stn, sno, ID_PhongTro);
            
            DataProvider.instance.ExecuteDB(query);
        }

        #endregion
        #region xóa
        public void DeletePhongTro(int ID_PhongTro)
        {
            string query = "update PhongTro set DelFlg = 1 WHERE ID_PhongTro = '" + ID_PhongTro + "'";
            DataProvider.instance.ExecuteDB(query);
        }
        public void DeletePhongTroByID_Tro(int ID_Tro)
        {
            string query = "update PhongTro set DelFlg = 1 WHERE ID_Tro = '" + ID_Tro + "'";
            DataProvider.instance.ExecuteDB(query);
        }
        #endregion
        #region get
        /*public DataTable GetAllPhongTro()
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from PhongTro where DelFlg = 0").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<PhongTro> GetAllPhongTro()
        {
            List<PhongTro> dt = new List<PhongTro>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from PhongTro where DelFlg = 0").Rows)
            {
                dt.Add(new PhongTro(Convert.ToInt32(i["ID_PhongTro"].ToString()), i["Ten"].ToString(), Convert.ToInt32(i["ID_Tro"].ToString()),
                    Convert.ToInt32(i["TienPhong"].ToString()), Convert.ToInt32(i["GiaDien"].ToString()), Convert.ToInt32(i["GiaNuoc"].ToString()),
                    Convert.ToInt32(i["SoNguoiToiDa"].ToString()), Convert.ToInt32(i["SoNguoiO"].ToString()), i["TrangThaiPhong"].ToString(),
                    Convert.ToInt32(i["SoThangNo"].ToString())));
            }
            return dt;
        }
        /*public DataTable GetPhongTroByID_Tro(int ID_tro) 
        {
            DataTable dt = new DataTable();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from PhongTro where DelFlg = 0 and ID_Tro = '" + ID_tro + "'").Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<PhongTro> GetPhongTroByID_Tro(int ID_tro)
        {
            List<PhongTro> dt = new List<PhongTro>();
            foreach (DataRow i in DataProvider.instance.GetRecord("select * from PhongTro where DelFlg = 0 and ID_Tro = '" + ID_tro + "'").Rows)
            {
                dt.Add(new PhongTro(Convert.ToInt32(i["ID_PhongTro"].ToString()), i["Ten"].ToString(), Convert.ToInt32(i["ID_Tro"].ToString()),
                    Convert.ToInt32(i["TienPhong"].ToString()), Convert.ToInt32(i["GiaDien"].ToString()), Convert.ToInt32(i["GiaNuoc"].ToString()),
                    Convert.ToInt32(i["SoNguoiToiDa"].ToString()), Convert.ToInt32(i["SoNguoiO"].ToString()), i["TrangThaiPhong"].ToString(),
                    Convert.ToInt32(i["SoThangNo"].ToString())));
            }
            return dt;
        }
        /*public DataTable GetPhongTroByID_PhongTro(int ID_phongtro)
        {
            DataTable dt = new DataTable();
            string query = string.Format("select * from PhongTro where DelFlg = 0 and ('{0}' = '0' or ID_PhongTro = '{0}')", ID_phongtro);
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<PhongTro> GetPhongTroByID_PhongTro(int ID_phongtro)
        {
            List<PhongTro> dt = new List<PhongTro>();
            string query = string.Format("select * from PhongTro where DelFlg = 0 and ('{0}' = '0' or ID_PhongTro = '{0}')", ID_phongtro);
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Add(new PhongTro(Convert.ToInt32(i["ID_PhongTro"].ToString()), i["Ten"].ToString(), Convert.ToInt32(i["ID_Tro"].ToString()),
                    Convert.ToInt32(i["TienPhong"].ToString()), Convert.ToInt32(i["GiaDien"].ToString()), Convert.ToInt32(i["GiaNuoc"].ToString()),
                    Convert.ToInt32(i["SoNguoiToiDa"].ToString()), Convert.ToInt32(i["SoNguoiO"].ToString()), i["TrangThaiPhong"].ToString(),
                    Convert.ToInt32(i["SoThangNo"].ToString())));
            }
            return dt;
        }
        /*public DataTable GetPhongTro1(int ID_tro, string trangthaiphong, string trangthaiphi)
            // tìm ra đanh sánh phòng trong trọ ID_tro với trạng thái phòng trangthaiphong và trạng thái phí trangthaiphi
        {
            DataTable dt = new DataTable();
            string query = "";
            if (trangthaiphi == "Đã thanh toán")
                query = string.Format("select * from PhongTro where DelFlg = 0 and ('{0}' = '0' or ID_Tro = '{0}') and ('{1}' = '--Trạng thái phòng--' or TrangThaiPhong = '{1}') and SoThangNo = 0",
                                        ID_tro, trangthaiphong);
            else
                query = string.Format("select * from PhongTro where DelFlg = 0 and ('{0}' = '0' or ID_Tro = '{0}') and ('{1}' = '--Trạng thái phòng--' or TrangThaiPhong = '{1}') and (SoThangNo > 0 or '{2}' = '--Trạng thái phí--')",
                                        ID_tro, trangthaiphong, trangthaiphi);
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<PhongTro> GetPhongTro1(int ID_tro, string trangthaiphong, string trangthaiphi)
        // tìm ra đanh sánh phòng trong trọ ID_tro với trạng thái phòng trangthaiphong và trạng thái phí trangthaiphi
        {
            List<PhongTro> dt = new List<PhongTro>();
            string query = "";
            if (trangthaiphi == "Đã thanh toán")
                query = string.Format("select * from PhongTro where DelFlg = 0 and ('{0}' = '0' or ID_Tro = '{0}') and ('{1}' = '--Trạng thái phòng--' or TrangThaiPhong = N'{1}') and SoThangNo = 0 and SoNguoiO > 0",
                                        ID_tro, trangthaiphong);
            else
                query = string.Format("select * from PhongTro where DelFlg = 0 and ('{0}' = '0' or ID_Tro = '{0}') and ('{1}' = '--Trạng thái phòng--' or TrangThaiPhong = N'{1}') and (SoThangNo > 0 or '{2}' = '--Trạng thái phí--')",
                                        ID_tro, trangthaiphong, trangthaiphi);
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Add(new PhongTro(Convert.ToInt32(i["ID_PhongTro"].ToString()), i["Ten"].ToString(), Convert.ToInt32(i["ID_Tro"].ToString()),
                    Convert.ToInt32(i["TienPhong"].ToString()), Convert.ToInt32(i["GiaDien"].ToString()), Convert.ToInt32(i["GiaNuoc"].ToString()),
                    Convert.ToInt32(i["SoNguoiToiDa"].ToString()), Convert.ToInt32(i["SoNguoiO"].ToString()), i["TrangThaiPhong"].ToString(),
                    Convert.ToInt32(i["SoThangNo"].ToString())));
            }
            return dt;
        }
        /*public DataTable GetPhongTro2(int ID_tro, int ID_phongtro)
        // tìm ra đanh sánh phòng trong trọ ID_tro với mã phòng trọ ID_Phongtro
        {
            DataTable dt = new DataTable();
            string query = string.Format("select * from PhongTro where DelFlg = 0 and ('{0}' = '0' or ID_PhongTro = '{0}') and ('0' = '0' or ID_Tro = '{1}')"
                , ID_phongtro, ID_tro);
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<PhongTro> GetPhongTro2(int ID_tro, int ID_phongtro)
        // tìm ra đanh sánh phòng trong trọ ID_tro với mã phòng trọ ID_Phongtro
        {
            List<PhongTro> dt = new List<PhongTro>();
            string query = string.Format("select * from PhongTro where DelFlg = 0 and ('{0}' = '0' or ID_PhongTro = '{0}') and ('0' = '0' or ID_Tro = '{1}')"
                , ID_phongtro, ID_tro);
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Add(new PhongTro(Convert.ToInt32(i["ID_PhongTro"].ToString()), i["Ten"].ToString(), Convert.ToInt32(i["ID_Tro"].ToString()),
                    Convert.ToInt32(i["TienPhong"].ToString()), Convert.ToInt32(i["GiaDien"].ToString()), Convert.ToInt32(i["GiaNuoc"].ToString()),
                    Convert.ToInt32(i["SoNguoiToiDa"].ToString()), Convert.ToInt32(i["SoNguoiO"].ToString()), i["TrangThaiPhong"].ToString(),
                    Convert.ToInt32(i["SoThangNo"].ToString())));
            }
            return dt;
        }
        /*public DataTable GetPhongTro3(int ID_tro, int ID_phongtro, string trangthaiphong)
        // tìm ra đanh sánh phòng trong trọ ID_tro với mã phòng trọ ID_Phongtro, trạng thái phòng trangthaiphong
        {
            DataTable dt = new DataTable();
            string query = string.Format("select * from PhongTro where DelFlg = 0 and ('{0}' = '0' or ID_PhongTro = '{0}') and ('0' = '0' or ID_Tro = '{1}') and ('{2}' = '--Trạng thái phòng--' or TrangThaiPhong = '{2}')"
                , ID_phongtro, ID_tro, trangthaiphong);
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Rows.Add(i);
            }
            return dt;
        }*/
        public List<PhongTro> GetPhongTro3(int ID_tro, int ID_phongtro, string trangthaiphong)
        // tìm ra đanh sánh phòng trong trọ ID_tro với mã phòng trọ ID_Phongtro, trạng thái phòng trangthaiphong
        {
            List<PhongTro> dt = new List<PhongTro>();
            string q = "";
            if (trangthaiphong == "--Trạng thái phí--")
                q = "";
            if (trangthaiphong == "Chưa thanh toán")
                q = "and SoThangNo > 0";
            if (trangthaiphong == "Đã thanh toán")
                q = "and SoThangNo = 0";
            string query = string.Format("select * from PhongTro where DelFlg = 0 and ('{0}' = '0' or ID_PhongTro = '{0}') and ('{1}' = '0' or ID_Tro = '{1}')" + q
                , ID_phongtro, ID_tro, trangthaiphong);
            foreach (DataRow i in DataProvider.instance.GetRecord(query).Rows)
            {
                dt.Add(new PhongTro(Convert.ToInt32(i["ID_PhongTro"].ToString()), i["Ten"].ToString(), Convert.ToInt32(i["ID_Tro"].ToString()),
                    Convert.ToInt32(i["TienPhong"].ToString()), Convert.ToInt32(i["GiaDien"].ToString()), Convert.ToInt32(i["GiaNuoc"].ToString()),
                    Convert.ToInt32(i["SoNguoiToiDa"].ToString()), Convert.ToInt32(i["SoNguoiO"].ToString()), i["TrangThaiPhong"].ToString(),
                    Convert.ToInt32(i["SoThangNo"].ToString())));
            }
            return dt;
        }
        #endregion
    }
}
