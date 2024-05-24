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
    public class BUS_ChuTro
    {
        #region thêm chủ trọ
        public void AddChuTro(ChuTro chutro)
        {
            DAL_ChuTro dal = new DAL_ChuTro();
            dal.AddChuTro(chutro);
        }
        #endregion
        #region sửa chủ trọ
        public void UpdateChuTro(ChuTro chutro)
        {
            DAL_ChuTro dal = new DAL_ChuTro();
            dal.UpdateChuTro(chutro);
        }
        #endregion
        #region xóa chủ trọ
        public void DeleteChuTro(int ID_Chutro)
        {
            DAL_ChuTro dal = new DAL_ChuTro();
            dal.DeleteChuTro(ID_Chutro);
        }
        #endregion
        #region get chủ trọ
        public List<ChuTro> GetAllChuTro()
        {
            List<ChuTro> list = new List<ChuTro>();
            DAL_ChuTro dal = new DAL_ChuTro();
            foreach (ChuTro i in dal.GetAllChuTro())
            {
                list.Add(i);
            }
            return list;
        }
        public List<ChuTro> GetChuTro(int ID_Chutro)
        {
            List<ChuTro> list = new List<ChuTro>();
            DAL_ChuTro dal = new DAL_ChuTro();
            foreach (ChuTro i in dal.GetChuTro(ID_Chutro))
            {
                list.Add(i);
            }
            return list;
        }
        public List<ChuTro> GetRecentChuTro()
        {
            List<ChuTro> list = new List<ChuTro>();
            DAL_ChuTro dal = new DAL_ChuTro();
            foreach (ChuTro i in dal.GetRecentChuTro())
            {
                list.Add(i);
            }
            return list;
        }
        #endregion
    }
}
