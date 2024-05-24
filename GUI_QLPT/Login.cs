using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLPT
{
    public partial class Login : Form
    {
        static private string username;
        static private string password;
        static private string quyen;
        public Login()
        {
            InitializeComponent();
            SetDefault();
        }
        #region Xử lí giao diện ban đầu (chưa xong)
        private void SetDefault()
        {
            this.txtPassWord.Text = "123456@abc";
            this.txtUserName.Text = "vananguyen";
            this.cbQuyen.Items.Clear();
            this.cbQuyen.Items.Add("Chủ trọ");
            this.cbQuyen.Items.Add("Khách hàng");
            // lấy dữ liệu từ ghi nhớ đăng nhập --> txtUserName, txtPassWord, cbQuyen
        }
        #endregion
        #region Sự kiện đăng nhập (chưa xong)
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            username = this.txtUserName.Text;
            password = this.txtPassWord.Text;
            quyen = this.cbQuyen.Text;
            //MessageBox.Show("'" + username + "' '" + password +  "' '" + quyen + "'");
            BUS_TaiKhoan bus = new BUS_TaiKhoan();
            List<TaiKhoan> list = new List<TaiKhoan>();
            //dt = bus.DangNhap(username, password, quyen);
            /*foreach (TaiKhoan i in bus.DangNhap(username, password, quyen))
            {
                MessageBox.Show(i.ID_TaiKhoan.ToString());
            }*/
            list = bus.DangNhap(username, password, quyen);
            if (list.Count > 0 && this.checkBoxGhiNho.Checked)
            {
                // ghi nhớ đăng nhập: xóa ghi nhớ cũ, thêm ghi nhớ mới
            }

            if (list.Count > 0 && quyen == "Chủ trọ")
            {
                ChuTro_MainForm f = new ChuTro_MainForm(list[0].ID_TaiKhoan);  // parameters here
                //Main f = new Main();
                //this.Hide();
                f.ShowDialog();
            }
            else if (list.Count > 0 && quyen == "Khách hàng")
            {
                KhachThue_MainForm f = new KhachThue_MainForm(list[0].ID_TaiKhoan);  // parameters here
                //Main f = new Main();
                //this.Hide();
                f.ShowDialog();
                //MessageBox.Show(dt.Rows[0]["ID_TaiKhoan"].ToString());
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không hợp lệ");
                SetDefault();
            }

        }
        #endregion
        #region Sự kiện huỷ đăng nhập --> thoát khỏi chương trình
        private void btHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát chương trình ??", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        #endregion
        #region Sự kiện chuyển sang giao diện đăng kí
        private void labelDangKy_Click(object sender, EventArgs e)
        {
            SignUp f = new SignUp(this);
            this.Hide();
            f.ShowDialog();
        }
        #endregion
    }
}
