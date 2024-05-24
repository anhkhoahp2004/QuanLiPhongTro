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
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan dal_tk = new DAL_TaiKhoan();
        #region thêm
        public void AddTaiKhoan(TaiKhoan tk)
        {
            DAL_TaiKhoan dal = new DAL_TaiKhoan();
            dal.AddTaiKhoan(tk);
        }
        #endregion
        #region sửa
        public void UpdateTaiKhoan(TaiKhoan tk)
        {
            DAL_TaiKhoan dal = new DAL_TaiKhoan();
            dal.UpdateTaiKhoan(tk);
        }
        #endregion
        #region xóa
        public void DeleteTaiKhoan(int ID_taikhoan, string Quyen)
        {
            DAL_TaiKhoan dal = new DAL_TaiKhoan();
            dal.DeleteTaiKhoan(ID_taikhoan, Quyen);
        }
        #endregion
        #region get
        public List<TaiKhoan> GetAllTaiKhoan()
        {
            List<TaiKhoan> dt = new List<TaiKhoan>();
            DAL_TaiKhoan dal = new DAL_TaiKhoan();
            foreach (TaiKhoan i in dal.GetAllTaiKhoan())
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<TaiKhoan> GetTaiKhoanByID_TaiKhoan(int ID_taikhoan, string quyen)
        {
            List<TaiKhoan> dt = new List<TaiKhoan>();
            DAL_TaiKhoan dal = new DAL_TaiKhoan();
            foreach (TaiKhoan i in dal.GetTaiKhoanByID_TaiKhoan(ID_taikhoan, quyen))
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<TaiKhoan> GetTaiKhoanByQuyen(string quyen)
        {
            List<TaiKhoan> dt = new List<TaiKhoan>();
            DAL_TaiKhoan dal = new DAL_TaiKhoan();
            foreach (TaiKhoan i in dal.GetTaiKhoanByQuyen(quyen))
            {
                dt.Add(i);
            }
            return dt;
        }
        public List<TaiKhoan> DangNhap(string username, string password, string quyen)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            foreach (TaiKhoan i in dal_tk.DangNhap(username, password, quyen))
            {
                list.Add(new TaiKhoan(i.ID_TaiKhoan, username, password, quyen));
            }
            return list;
        }
        public List<TaiKhoan> GetTaiKhoanByUsername(string username)
        {
            List<TaiKhoan> dt = new List<TaiKhoan>();
            DAL_TaiKhoan dal = new DAL_TaiKhoan();
            foreach (TaiKhoan i in dal.GetTaiKhoanByUsername(username))
            {
                dt.Add(i);
            }
            return dt;
        }
        #endregion
    }
}
