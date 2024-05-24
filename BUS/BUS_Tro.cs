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
    public class BUS_Tro
    {
        #region thêm
        public void AddTro(Tro tro)
        {
            DAL_Tro dal = new DAL_Tro();
            dal.AddTro(tro);
        }
        #endregion
        #region sửa
        public void UpdateTro(Tro tro)
        {
            DAL_Tro dal = new DAL_Tro();
            dal.UpdateTro(tro);
        }
        #endregion
        #region xóa
        public void DeleteTro(int ID_tro)
        {
            DAL_Tro dal = new DAL_Tro();
            dal.DeleteTro(ID_tro);
        }
        public void DeleteTroByID_ChuTro(int ID_chutro)
        {
            DAL_Tro dal = new DAL_Tro();
            dal.DeleteTroByID_ChuTro(ID_chutro);
        }
        #endregion
        #region get
        public List<Tro> GetAllTro()
        {
            List<Tro> dt = new List<Tro>();
            DAL_Tro dal = new DAL_Tro();
            foreach (Tro i in dal.GetAllTro())
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<Tro> GetTroByID_Tro(int ID_tro)
        {
            List<Tro> dt = new List<Tro>();
            DAL_Tro dal = new DAL_Tro();
            foreach (Tro i in dal.GetTroByID_Tro(ID_tro))
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<Tro> GetTroByID_ChuTro(int ID_chutro)
        {
            List<Tro> dt = new List<Tro>();
            DAL_Tro dal = new DAL_Tro();
            foreach (Tro i in dal.GetTroByID_ChuTro(ID_chutro))
            {
                dt.Add(i);
            }
            return dt;
        }
        #endregion
    }
}
