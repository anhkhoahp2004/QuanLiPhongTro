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
    public class BUS_PhongTro
    {
        #region thêm
        public void AddPhongTro(PhongTro pt)
        {
            DAL_PhongTro dal = new DAL_PhongTro();
            dal.AddPhongTro(pt);
        }
        #endregion
        #region sửa
        public void UpdatePhongTro(PhongTro pt)
        {
            DAL_PhongTro dal = new DAL_PhongTro();
            dal.UpdatePhongTro(pt);
        }
        public void UpdateSoThangNo(int ID_PhongTro, int value)
        {
            DAL_PhongTro dal = new DAL_PhongTro();
            dal.UpdateSoThangNo(ID_PhongTro, value);
        }
        public void UpdateSoNguoiO(int ID_PhongTro, int stn, int sno)
        {
            DAL_PhongTro dal = new DAL_PhongTro();
            dal.UpdateSoNguoiO(ID_PhongTro, stn, sno);
        }
        #endregion
        #region xóa
        public void DeletePhongTro(int ID_PhongTro)
        {
            DAL_PhongTro dal = new DAL_PhongTro();
            dal.DeletePhongTro(ID_PhongTro);
        }
        public void DeletePhongTroByID_Tro(int ID_Tro)
        {
            DAL_PhongTro dal = new DAL_PhongTro();
            dal.DeletePhongTroByID_Tro(ID_Tro);
        }
        #endregion
        #region get
        public List<PhongTro> GetAllPhongTro()
        {
            List<PhongTro> dt = new List<PhongTro>();
            DAL_PhongTro dal = new DAL_PhongTro();
            foreach (PhongTro i in dal.GetAllPhongTro())
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<PhongTro> GetPhongTroByID_Tro(int ID_tro)
        {
            List<PhongTro> dt = new List<PhongTro>();
            DAL_PhongTro dal = new DAL_PhongTro();
            foreach (PhongTro i in dal.GetPhongTroByID_Tro(ID_tro))
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<PhongTro> GetPhongTroByID_PhongTro(int ID_phongtro)
        {
            List<PhongTro> dt = new List<PhongTro>();
            DAL_PhongTro dal = new DAL_PhongTro();
            foreach (PhongTro i in dal.GetPhongTroByID_PhongTro(ID_phongtro))
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<PhongTro> GetPhongTro1(int ID_tro, string trangthaiphong, string trangthaiphi)
        // tìm ra đanh sánh phòng trong trọ ID_tro với trạng thái phòng trangthaiphong và trạng thái phí trangthaiphi
        {
            List<PhongTro> dt = new List<PhongTro>();
            DAL_PhongTro dal = new DAL_PhongTro();
            foreach (PhongTro i in dal.GetPhongTro1(ID_tro, trangthaiphong, trangthaiphi))
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<PhongTro> GetPhongTro2(int ID_tro, int ID_phongtro)
        // tìm ra đanh sánh phòng trong trọ ID_tro với mã phòng trọ ID_Phongtro
        {
            List<PhongTro> dt = new List<PhongTro>();
            DAL_PhongTro dal = new DAL_PhongTro();
            foreach (PhongTro i in dal.GetPhongTro2(ID_tro, ID_phongtro))
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<PhongTro> GetPhongTro3(int ID_tro, int ID_phongtro, string trangthaiphong)
        // tìm ra đanh sánh phòng trong trọ ID_tro với mã phòng trọ ID_Phongtro, trạng thái phòng trangthaiphong
        {
            List<PhongTro> dt = new List<PhongTro>();
            DAL_PhongTro dal = new DAL_PhongTro();
            foreach (PhongTro i in dal.GetPhongTro3(ID_tro, ID_phongtro, trangthaiphong))
            {
                dt.Add(i);
            }
            return dt;
        }
        #endregion
    }
}
