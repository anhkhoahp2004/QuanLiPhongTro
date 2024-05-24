using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI_QLPT
{
    public partial class KhachThue_MainForm : Form
    {
        #region khai báo danh sách biến thành viên hàm
        static private int ID_khachhang;
        static private int ID_phongtro;
        static private int ID_tro;
        static private int ID_chutro;
        static private bool Update;
        #endregion
        public KhachThue_MainForm()
        {
            InitializeComponent();
        }

        public KhachThue_MainForm(int ID_KhachHang)
        {
            InitializeComponent();
            ID_khachhang = ID_KhachHang;                // lấy id Khách hàng
            BUS_KhachHang bus = new BUS_KhachHang();
            List<KhachHang> list = new List<KhachHang>();
            list = bus.GetKhachHangByID_KhachHang(ID_KhachHang);
            ID_phongtro = list[0].ID_PhongTro;          // lấy id phòng trọ
            Update = (list[0].Ten == "") ? false : true;
            if (ID_phongtro > 0)
            {
                List<PhongTro> list_ptro = new List<PhongTro>();
                BUS_PhongTro bus_ptro = new BUS_PhongTro();
                list_ptro = bus_ptro.GetPhongTroByID_PhongTro(ID_phongtro);
                ID_tro = list_ptro[0].ID_Tro;               // lấy id trọ
                List<Tro> list_tro = new List<Tro>();
                BUS_Tro bus_tro = new BUS_Tro();
                list_tro = bus_tro.GetTroByID_Tro(ID_tro);
                ID_chutro = list_tro[0].ID_ChuTro;          // lấy id chủ trọ
            }
            else
            {
                ID_tro = 0;
                ID_chutro = 0;
            }
        }

        private void KhachThue_MainForm_Load(object sender, EventArgs e)
        {
            // thông báo cập nhật thông tin
            if (!Update)
            {
                MessageBox.Show("Bạn cần cập nhật thông tin đầy đủ sau khi đăng kí");
            }
            #region tab1: Hóa đơn
            // khởi tạo DataGridView hóa đơn
            InitDataGridView1();
            #endregion
            #region tab2: Thông tin cá nhân
            // khóa textbox
            InitLockTextbox2();
            // lấy thông tin cá nhân
            InitGetTaiKhoan2();
            #endregion
            #region tab3: Yêu cầu thuê phòng
            // khóa textbox
            InitLockTextbox3();
            #endregion
            #region tab4: Thông tin phòng thuê
            // khóa textbox
            InitLockTextbox4();
            // lấy thông tin phòng trọ
            InitGetThongTinPhong4();
            #endregion
        }
        #region tab1: Hóa đơn
        #region khởi tạo DataGridView hóa đơn
        private void InitDataGridView1()
        {
            List<DuyetThuePhong> list_dtp = new List<DuyetThuePhong>();
            BUS_DuyetThuePhong bus_dtp = new BUS_DuyetThuePhong();
            list_dtp = bus_dtp.GetDuyetThuePhongByID_KhachHang(ID_khachhang);
            List<HoaDon> list_hd = new List<HoaDon>();
            BUS_HoaDon bus_hd = new BUS_HoaDon();
            List<HoaDon> list = new List<HoaDon>();
            foreach (DuyetThuePhong i in list_dtp)
            {
                list = bus_hd.GetHoaDonByID_PhongTro(i.ID_PhongTro);
                list_hd.AddRange(list);
            }
            dataGridViewHoaDon.DataSource = list_hd;
            // hiển thị
            DataTable NewDT = new DataTable();
            NewDT.Columns.Add("ID_HoaDon");
            NewDT.Columns.Add("STT");   // new
            NewDT.Columns.Add("ID_PhongTro");
            NewDT.Columns.Add("TenPhong"); // new
            NewDT.Columns.Add("SoDienCu");
            NewDT.Columns.Add("SoNuocCu");
            NewDT.Columns.Add("SoDienMoi");
            NewDT.Columns.Add("SoNuocMoi");
            NewDT.Columns.Add("Dien"); // new
            NewDT.Columns.Add("Nuoc"); // new
            NewDT.Columns.Add("ThanhTien");
            NewDT.Columns.Add("NgayBatDau");
            NewDT.Columns.Add("NgayKetThuc");
            NewDT.Columns.Add("TrangThai");
            NewDT.Columns.Add("DelFlg");
            NewDT.Columns.Add("FlagInsert");
            int index = 0;
            foreach (HoaDon i in list_hd)
            {
                BUS_PhongTro bus = new BUS_PhongTro();
                DataRow newRow = NewDT.NewRow();
                newRow["ID_HoaDon"] = i.ID_HoaDon;
                newRow["STT"] = ++index;   // new
                newRow["ID_PhongTro"] = i.ID_PhongTro;
                newRow["TenPhong"] = bus.GetPhongTroByID_PhongTro(i.ID_PhongTro)[0].Ten; // new
                newRow["SoDienCu"] = i.SoDienCu;
                newRow["SoNuocCu"] = i.SoNuocCu;
                newRow["SoDienMoi"] = i.SoDienMoi;
                newRow["SoNuocMoi"] = i.SoNuocMoi;
                newRow["Dien"] = $"{i.SoDienCu} -> {i.SoDienMoi}"; // new
                newRow["Nuoc"] = $"{i.SoNuocCu} -> {i.SoNuocMoi}"; // new
                newRow["ThanhTien"] = i.ThanhTien;
                newRow["NgayBatDau"] = i.NgayBatDau;
                newRow["NgayKetThuc"] = i.NgayKetThuc;
                newRow["TrangThai"] = i.TrangThai;
                newRow["DelFlg"] = i.DelFlg;
                newRow["FlagInsert"] = i.FlagInsert;
                NewDT.Rows.Add(newRow);
            }
            dataGridViewHoaDon.DataSource = NewDT;
            dataGridViewHoaDon.Columns["STT"].HeaderText = "STT";
            dataGridViewHoaDon.Columns["TenPhong"].HeaderText = "Phòng";
            dataGridViewHoaDon.Columns["Dien"].HeaderText = "Điện";
            dataGridViewHoaDon.Columns["Nuoc"].HeaderText = "Nước";
            dataGridViewHoaDon.Columns["ThanhTien"].HeaderText = "Tổng tiền";
            dataGridViewHoaDon.Columns["NgayBatDau"].HeaderText = "Ngày đầu";
            dataGridViewHoaDon.Columns["NgayKetThuc"].HeaderText = "Ngày cuối";
            dataGridViewHoaDon.Columns["TrangThai"].HeaderText = "Trạng thái";

            dataGridViewHoaDon.Columns["STT"].DisplayIndex = 0;
            dataGridViewHoaDon.Columns["TenPhong"].DisplayIndex = 1;
            dataGridViewHoaDon.Columns["Dien"].DisplayIndex = 2;
            dataGridViewHoaDon.Columns["Nuoc"].DisplayIndex = 3;
            dataGridViewHoaDon.Columns["ThanhTien"].DisplayIndex = 4;
            dataGridViewHoaDon.Columns["NgayBatDau"].DisplayIndex = 5;
            dataGridViewHoaDon.Columns["NgayKetThuc"].DisplayIndex = 6;
            dataGridViewHoaDon.Columns["TrangThai"].DisplayIndex = 7;

            dataGridViewHoaDon.Columns["ID_HoaDon"].Visible = false;
            dataGridViewHoaDon.Columns["ID_PhongTro"].Visible = false;
            dataGridViewHoaDon.Columns["SoDienCu"].Visible = false;
            dataGridViewHoaDon.Columns["SoNuocCu"].Visible = false;
            dataGridViewHoaDon.Columns["SoDienMoi"].Visible = false;
            dataGridViewHoaDon.Columns["SoNuocMoi"].Visible = false;
            dataGridViewHoaDon.Columns["DelFlg"].Visible = false;
            dataGridViewHoaDon.Columns["FlagInsert"].Visible = false;

        }
        #endregion
        #endregion

        #region tab2: Thông tin cá nhân
        #region khóa textbox
        private void InitLockTextbox2()
        {
            // tài khoản
            txtMaTK2.Enabled = false;
            txtTenTK2.Enabled = false;
            txtQuyen2.Enabled = false;
            labMatKhauMoi2.Visible = false;
            labelMK2.Visible = false;
            txtMatKhau2.Visible = false;
            txtNhapLaiMK2.Visible = false;
            btnOK2.Visible = false;
            btnCancel2.Visible = false;
            // thông tin cá nhân
            txtTenKhachHang2.Enabled = false;
            txtCCCD2.Enabled = false;
            txtSdt2.Enabled = false;
            txtDiaChi2.Enabled = false;
            txtEmail2.Enabled = false;
            txtNgheNghiep2.Enabled = false;
            buttonOK2.Visible = false;
            buttonCancel2.Visible = false;
        }
        #endregion
        #region khởi tạo dữ liệu
        private void InitGetTaiKhoan2()
        {
            // tài khoản
            List<TaiKhoan> list = new List<TaiKhoan>();
            BUS_TaiKhoan bus = new BUS_TaiKhoan();
            list = bus.GetTaiKhoanByID_TaiKhoan(ID_khachhang, "Khách hàng");
            txtMaTK2.Text = list[0].ID_TaiKhoan.ToString();
            txtTenTK2.Text = list[0].Username;
            txtQuyen2.Text = "Khách hàng";
            // thông tin cá nhân
            List<KhachHang> list2 = new List<KhachHang>();
            BUS_KhachHang bus2 = new BUS_KhachHang();
            list2 = bus2.GetKhachHangByID_KhachHang(ID_khachhang);
            txtTenKhachHang2.Text = list2[0].Ten;
            txtCCCD2.Text = list2[0].CCCD;
            txtSdt2.Text = list2[0].SDT;
            txtEmail2.Text = list2[0].Email;
            txtNgheNghiep2.Text = list2[0].NgheNghiep;
            // txtDiaChi2
            List<Tro> list3 = new List<Tro>();
            BUS_Tro bus3 = new BUS_Tro();
            list3 = bus3.GetTroByID_ChuTro(ID_chutro);
            if (list3.Count > 0)
                txtDiaChi2.Text = list3[0].DiaChi;
        }
        #endregion
        #region quản lí tài khoản cá nhân
        private Boolean checkPwd()
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            BUS_TaiKhoan bus = new BUS_TaiKhoan();
            list = bus.GetTaiKhoanByID_TaiKhoan(ID_khachhang, "Khách hàng");
            if (txtMatKhau2.Text == list[0].Password)
                return true;
            return false;
        }
        private void btnOK2_Click(object sender, EventArgs e)
        {
            // kiểm tra mật khẩu cũ, kiểm tra mật khẩu mới --> cập nhật mật khẩu tài khoản
            if (!checkPwd())
            {
                MessageBox.Show(("Mật khẩu cũ không đúng, vui lòng nhập lại"));
            }
            else if (txtNhapLaiMK2.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải tối kiểu 6 kí tự");
            }
            else
            {
                BUS_TaiKhoan bus = new BUS_TaiKhoan();
                bus.UpdateTaiKhoan(new TaiKhoan(ID_khachhang, txtTenTK2.Text, txtNhapLaiMK2.Text, "Khách hàng"));
                MessageBox.Show("Cập nhật mật khẩu mới thành công");
                txtMatKhau2.Text = "";
                txtNhapLaiMK2.Text = "";
                KhachThue_MainForm_Load(sender, e);
            }
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            InitLockTextbox2();
            txtMatKhau2.Text = "";
            txtNhapLaiMK2.Text = "";
        }

        private void btnSua21_Click(object sender, EventArgs e)
        {
            txtMatKhau2.Visible = true;
            txtMatKhau2.Enabled = true;
            txtNhapLaiMK2.Visible = true;
            txtNhapLaiMK2.Visible = true;
            labelMK2.Visible = true;
            labMatKhauMoi2.Visible = true;
            btnOK2.Visible = true;
            btnCancel2.Visible = true;
        }
        // xóa tài khoản
        private void btnXoaTK2_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region quản lí thông tin cá nhân
        private void buttonSua22_Click(object sender, EventArgs e)
        {
            txtTenKhachHang2.Enabled = true;
            txtCCCD2.Enabled = true;
            txtSdt2.Enabled = true;
            txtNgheNghiep2.Enabled = true;
            txtEmail2.Enabled = true;
            buttonCancel2.Visible = true;
            buttonOK2.Visible = true;
        }
        private bool ValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        private bool VaildSDT(string sdt)
        {
            string pattern = @"^0[0-9]{9}$";
            return Regex.IsMatch(sdt, pattern);
        }
        private bool ValidCCCD(string s)
        {
            if (s.Length != 12)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        private bool CheckValid()
        {
            if (!this.VaildSDT(txtSdt2.Text) || !this.ValidEmail(txtEmail2.Text) || !ValidCCCD(txtCCCD2.Text))
                return false;
            if (txtTenKhachHang2.Text == "" || txtNgheNghiep2.Text == "")
                return false;
            return true;

        }
        private void buttonOK2_Click(object sender, EventArgs e)
        {
            if (CheckValid())
            {
                BUS_KhachHang bus = new BUS_KhachHang();
                bus.UpDateKhachHang(new KhachHang(ID_khachhang, txtTenKhachHang2.Text, txtCCCD2.Text, txtSdt2.Text,
                    txtEmail2.Text, txtNgheNghiep2.Text, ID_phongtro));
                MessageBox.Show("Cập nhật thông tin khách hàng thành công");
                KhachThue_MainForm_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đã nhập");
            }
        }

        private void buttonCancel2_Click(object sender, EventArgs e)
        {
            KhachThue_MainForm_Load(sender, e);

        }
        #endregion
        #endregion

        #region tab3: Yêu cầu thuê phòng
        #region khóa textbox
        private void InitLockTextbox3()
        {
            if (ID_phongtro > 0)         // đã thuê phòng
            {
                labelMessage3.Visible = true;
                txtMaXacNhan3.Enabled = false;
                btnYeuCauThuePhong3.Visible = false;
                buttonCancel3.Visible = false;

            }
            else                        // chưa thuê phòng
            {
                labelMessage3.Visible = false;
                txtMaXacNhan3.Enabled = true;
                btnYeuCauThuePhong3.Visible = true;
                buttonCancel3.Visible = true;
                MessageBox.Show(ID_phongtro.ToString());
            }
        }
        #endregion
        #region yêu cầu thuê phòng
        private void btnYeuCauThuePhong3_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel3_Click(object sender, EventArgs e)
        {
            txtMaXacNhan3.Text = "";
        }
        #endregion
        #endregion

        #region tab4: Thông tin phòng thuê
        #region khóa textbox
        private void InitLockTextbox4()
        {
            txtTro4.Enabled = false;
            txtDiaChi4.Enabled = false;
            txtSoNguoiThue4.Enabled = false;
            txtSoNguoiToiDa4.Enabled = false;
            txtSDT4.Enabled = false;
            txtMaPhongThue4.Enabled = false;
            txtTienPhong4.Enabled = false;
            txtGiaDien4.Enabled = false;
            txtGiaNuoc4.Enabled = false;
        }
        #endregion
        #region lấy thông tin phòng thuê
        private void InitGetThongTinPhong4()
        {
            List<Tro> list1 = new List<Tro>();
            BUS_Tro bus = new BUS_Tro();
            list1 = bus.GetTroByID_Tro(ID_tro);
            if (list1.Count > 0)
            {
                txtTro4.Text = list1[0].Ten;
                txtDiaChi4.Text = list1[0].DiaChi;

                List<PhongTro> list2 = new List<PhongTro>();
                BUS_PhongTro bus2 = new BUS_PhongTro();
                list2 = bus2.GetPhongTroByID_PhongTro(ID_phongtro);
                txtSoNguoiThue4.Text = list2[0].SoNguoiO.ToString();
                txtSoNguoiToiDa4.Text = list2[0].SoNguoiToiDa.ToString();
                txtMaPhongThue4.Text = list2[0].Ten.ToString();
                txtTienPhong4.Text = list2[0].TienPhong.ToString();
                txtGiaDien4.Text = list2[0].GiaDien.ToString();
                txtGiaNuoc4.Text = list2[0].GiaNuoc.ToString();

                List<ChuTro> list3 = new List<ChuTro>();
                BUS_ChuTro bus3 = new BUS_ChuTro();
                list3 = bus3.GetChuTro(ID_chutro);
                txtSDT4.Text = list3[0].SDT;
            }

        }


        #endregion

        #endregion


    }
}
