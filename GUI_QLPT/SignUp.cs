using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI_QLPT
{
    public partial class SignUp : Form
    {
        Login login;
        public SignUp()
        {
            InitializeComponent();
            SetDefault();
        }
        public SignUp(Login l) : this()
        {
            this.login = l;
        }
        #region xử lí giao diện ban đầu
        private void SetDefault()
        {
            this.cbQuyen.Items.Add("Chủ trọ");
            this.cbQuyen.Items.Add("khách hàng");
        }
        #endregion
        #region xử lí sự kiện đăng kí
        private Boolean ValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        private Boolean VaildSDT(string sdt)
        {
            string pattern = @"^0[0-9]{9}$";
            return Regex.IsMatch(sdt, pattern);
        }
        private Boolean Check(string email, string sdt)
        {
            if (this.VaildSDT(sdt) && this.ValidEmail(email))
                return true;
            else
                return false;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = this.txtUserName.Text;
            string password = this.txtPassWord.Text;
            string quyen = this.cbQuyen.Text;
            string email = this.txtEmail.Text;
            string Sdt = this.txtSDT.Text;
            List<TaiKhoan> list_tk = new List<TaiKhoan>();
            BUS_TaiKhoan bus = new BUS_TaiKhoan();
            list_tk = bus.GetTaiKhoanByUsername(username);
            if (username == "" || password == "" || quyen == "" || email == "" || Sdt == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ trường thông tin");
            }
            else if (list_tk.Count > 0) // tồn tại username
            {
                MessageBox.Show("Đã tồn tại tên username");
            }
            else if (Check(email, Sdt))
            {
                MessageBox.Show("Thông tin email hoặc số điện thoại nhập không đúng định dạng");
            }
            else if (quyen == "Chủ trọ")
            {
                BUS_ChuTro bus_ct = new BUS_ChuTro();
                List<ChuTro> list_ct = new List<ChuTro>();
                ChuTro chutro = new ChuTro(0, "", Sdt, "", "", email);
                bus_ct.AddChuTro(chutro);
                list_ct = bus_ct.GetRecentChuTro();                  // hàm lấy ID_TaiKhoan trong ChuTro
                int id = list_ct[0].ID_ChuTro;
                BUS_TaiKhoan bus_tk = new BUS_TaiKhoan();
                TaiKhoan taikhoan = new TaiKhoan(id, username, password, quyen);
                bus_tk.AddTaiKhoan(taikhoan);
                ChuTro_MainForm f = new ChuTro_MainForm(id);
                //Main f = new Main();
                this.Hide();
                f.ShowDialog();
            }
            else if (quyen == "Khách hàng")
            {
                BUS_KhachHang bus_kh = new BUS_KhachHang();
                List<KhachHang> list_kh = new List<KhachHang>();
                KhachHang khachhang = new KhachHang(0, "", "", Sdt, email, "", 0) ;
                bus_kh.AddKhachHang(khachhang);
                list_kh = bus_kh.GetRecentKhachHang();                // hàm lấy ID_TaiKhoan trong KhachThue
                int id = list_kh[0].ID_KhachHang;
                BUS_TaiKhoan bus_tk = new BUS_TaiKhoan();
                TaiKhoan taikhoan = new TaiKhoan(id, username, password, quyen);
                bus_tk.AddTaiKhoan(taikhoan);
                KhachThue_MainForm f = new KhachThue_MainForm(id);
                //Main f = new Main();
                this.Hide();
                f.ShowDialog();
            }
        }
        #endregion
        #region hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.ShowDialog();
        }
        #endregion
    }
}
