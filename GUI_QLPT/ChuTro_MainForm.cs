using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace GUI_QLPT
{

    public partial class ChuTro_MainForm : Form
    {
        #region khai báo danh sách biến thành viên hàm 
        static private int ID_chutro;
        static private int ID_khachhang;
        static private int ID_hoadon;
        static private int ID_phongtro;
        static private int ID_tro;
        // more
        #endregion
        public ChuTro_MainForm()
        {
            this.InitializeComponent();
        }
        // nhận giá trị từ login
        public ChuTro_MainForm(int ID_ChuTro)
        {
            this.InitializeComponent();
            ID_chutro = ID_ChuTro;
        }
        #region khởi tạo màn hình
        private void ChuTro_MainForm_Load(object sender, EventArgs e)
        {
            #region tab1: phòng
            // khởi tạo combobox tìm kiếm trọ
            this.InitComboboxTimKiemTro1();
            // khởi tạo combobox trạng thái phòng
            this.InitComboboxTrangThaiPhong1();
            // khởi tạo combobox trạng thái phí
            this.InitComboboxTrangThaiPhi1();
            // khởi tạo label thông thông tin số phòng(còn trống, đã cho thuê, chưa thu phí)
            this.InitLabel1();
            // khởi tạo DataGridView danh sách phòng trọ ban đầu (GetAll)
            this.InitDataGridView1();

            //MessageBox.Show(labelSoPhongTrong1.Text);
            #endregion
            #region tab2: khách hàng
            // khóa các textbox
            InitLockTextBox2();
            // khởi tạo combobxo danh sách trọ
            InitComboboxTimKiemTro2();
            // khởi tạo DataGridView danh sách các khách hàng đã thuê trọ
            InitDataGridView2();

            #endregion
            #region tab3: dịch vụ điện nước
            // khóa các textbox
            InitLockTextBox3();
            // khởi tạo combobox danh sách trọ (2 combobox)
            InitComboboxTimKiemTro3();
            // khởi tạo combobox các trạng thái phí (1 combobox)
            InitComboboxTrangThaiPhong3();
            // khởi tạo DataGridView danh sách khách hàng đã thuê trọ
            InitDataGridView3();
            #endregion
            #region tab4: tính tiền/ trả phòng
            // khóa các textbox
            InitLockTextbox4();
            // khởi tạo combobox danh sách trọ
            InitComboboxTimKiemTro4();
            // khởi tạo combobox trạng thái phí
            InitComboboxTrangThaiPhi4();
            // khởi tạo DataGridView danh sách phòng trọ
            InitDataGridView4();
            #endregion
            #region tab5: báo cáo
            // khóa các textbox
            InitLockTextBox5();
            // khởi tạo combobox danh sách trọ
            InitComboboxTimKiemTro5();
            // khóa các combobox trạng thái phí
            InitComboboxTrangThaiPhi5();
            // khóa DataGridView danh sách hóa đơn
            InitDataGridView5();
            #endregion
            #region tab6: quản lí tài khoản cá nhân chủ trọ
            // khóa các textbox
            InitLockTextbox6();
            // lấy thông tin chủ trọ
            InitGetChuTro6();
            // lấy thông tin tài khoản chủ trọ
            InitGetTaiKhoan6();
            #endregion
            #region tab7: duyệt thuê phòng tư yêu cầu khách hàng
            // khóa các textbox
            InitLockTextBox7();
            // khởi tạo combobox danh sách trọ
            InitComboboxTimKiemTro7();
            // khởi tạo combobox trạng thái phòng
            InitComboboxTrangThaiPhong7();
            // khởi tạo DataGridView danh sách các yêu cầu thuê phòng 
            InitDataGridView7();
            #endregion
            #region tab8: quản lí trọ - thêm, cập nhật, xóa trọ/ phòng trọ
            // khóa các textbox
            InitLockTextbox8();
            // khởi tạo combobox danh sách trọ (2 combobox)
            InitComboboxTimKiemTro8();
            #endregion
        }
        #endregion

        #region tab1: phòng

        #region khởi tạo combobox tìm kiếm trọ
        private void InitComboboxTimKiemTro1()
        {
            List<Tro> list_tro = new List<Tro>();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            var dsTro = new BindingList<KeyValuePair<int, string>>();
            dsTro.Add(new KeyValuePair<int, string>(0, "--Trọ--"));
            foreach (Tro i in list_tro)
            {
                dsTro.Add(new KeyValuePair<int, string>(i.ID_Tro, i.Ten));
                //cbTro1.Items.Add(i.Ten);
            }
            this.cbTro1.DataSource = dsTro;
            this.cbTro1.ValueMember = "Key";
            this.cbTro1.DisplayMember = "Value";
            this.cbTro1.SelectedIndex = 0;
        }
        #endregion
        #region khởi tạo combobox trạng thái phòng
        private void InitComboboxTrangThaiPhong1()
        {
            var trangThaiPhong = new BindingList<KeyValuePair<int, string>>();
            //cbTrangThaiPhong1.Items.Clear();
            trangThaiPhong.Add(new KeyValuePair<int, string>(0, "--Trạng thái phòng--"));
            trangThaiPhong.Add(new KeyValuePair<int, string>(1, "Đang cho thuê"));
            trangThaiPhong.Add(new KeyValuePair<int, string>(2, "Đã cho thuê"));
            trangThaiPhong.Add(new KeyValuePair<int, string>(3, "Sửa chữa"));
            this.cbTrangThaiPhong1.DataSource = trangThaiPhong;
            this.cbTrangThaiPhong1.ValueMember = "Key";
            this.cbTrangThaiPhong1.DisplayMember = "Value";
            this.cbTrangThaiPhong1.SelectedIndex = 0;
        }
        #endregion
        #region khởi tạo combobox trạng thái phí
        private void InitComboboxTrangThaiPhi1()
        {
            var trangThaiPhi = new BindingList<KeyValuePair<int, string>>();
            trangThaiPhi.Add(new KeyValuePair<int, string>(0, "--Trạng thái phí--"));
            trangThaiPhi.Add(new KeyValuePair<int, string>(1, "Đã thanh toán"));
            trangThaiPhi.Add(new KeyValuePair<int, string>(2, "Chưa thanh toán"));
            this.cbTrangThaiPhi1.DataSource = trangThaiPhi;
            this.cbTrangThaiPhi1.ValueMember = "Key";
            this.cbTrangThaiPhi1.DisplayMember = "Value";
            this.cbTrangThaiPhi1.SelectedIndex = 0;
        }
        #endregion
        #region khởi tạo label thông thông tin số phòng (còn trống, đã cho thuê, chưa thu phí)
        private void InitLabel1()
        {
            int soPhongdachoThue = 0;
            int soPhongchuaThuPhi = 0;
            int soPhongTrong = 0;
            List<PhongTro> list_pt = new List<PhongTro>();
            List<Tro> list_tro = new List<Tro>();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            List<PhongTro> tmp = new List<PhongTro>();
            foreach (Tro tro in list_tro)
            {
                tmp = bus_pt.GetPhongTroByID_Tro(tro.ID_Tro);
                list_pt.AddRange(tmp);
            }
            foreach (PhongTro i in list_pt)
            {
                if (i.TrangThaiPhong == "Đang cho thuê")
                    soPhongTrong++;
                else if (i.TrangThaiPhong == "Đã cho thuê")
                    soPhongdachoThue++;
                if (i.SoThangNo > 0)
                    soPhongchuaThuPhi++;
            }
            labelSoPhongChoThue1.Text = soPhongdachoThue.ToString();
            labelSoPhongChuaThuPhi1.Text = soPhongchuaThuPhi.ToString();
            labelSoPhongTrong1.Text = soPhongTrong.ToString();
        }
        #endregion
        #region khởi tạo DataGridView danh sách phòng trọ ban đầu (GetAll)
        private void InitDataGridView1()
        {
            List<PhongTro> list_pt = new List<PhongTro>();
            List<Tro> list_tro = new List<Tro>();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            List<PhongTro> tmp = new List<PhongTro>();
            foreach (Tro tro in list_tro)
            {
                tmp = bus_pt.GetPhongTroByID_Tro(tro.ID_Tro);
                list_pt.AddRange(tmp);
            }
            dataGridViewPhong.DataSource = list_pt;
            SetDataGridViewPhong();
        }
        #endregion
        #region Tìm kiếm phòng trọ
        private bool IsSubstring(string mainString, string subString)
        {
            // Kiểm tra nếu subString có trong mainString mà không phân biệt hoa thường
            return mainString.IndexOf(subString, StringComparison.OrdinalIgnoreCase) >= 0;
        }
        private void btnSearch1_Click(object sender, EventArgs e)
        {
            int id_tro = Convert.ToInt32(cbTro1.SelectedValue);
            string trangthaiphong = cbTrangThaiPhong1.Text;
            string trangthaiphi = cbTrangThaiPhi1.Text;
            //MessageBox.Show(trangthaiphong + ", " + trangthaiphi);
            List<PhongTro> list_pt = new List<PhongTro>();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            List<PhongTro> tmp = new List<PhongTro>();
            var itemList = cbTro1.DataSource as BindingList<KeyValuePair<int, string>>;
            if (Convert.ToInt32(cbTro1.SelectedValue) == 0)
            {
                foreach (KeyValuePair<int, string> i in itemList)
                {
                    if (i.Key > 0)
                    {
                        tmp = bus_pt.GetPhongTro1(i.Key, trangthaiphong, trangthaiphi);
                        list_pt.AddRange(tmp);
                    }
                }
            }
            else list_pt = bus_pt.GetPhongTro1(id_tro, trangthaiphong, trangthaiphi);
            List<PhongTro> list = new List<PhongTro>();
            foreach (PhongTro i in list_pt)
            {
                if (IsSubstring(i.Ten, txtTenPhong1.Text))
                {
                    list.Add(i);
                }
            }
            dataGridViewPhong.DataSource = list;
            SetDataGridViewPhong();
        }
        #endregion
        #region định dạng DataGridView
        private void SetDataGridViewPhong()
        {
            DataTable NewDT = new DataTable();
            NewDT.Columns.Add("ID_PhongTro");
            NewDT.Columns.Add("Ten");
            NewDT.Columns.Add("ID_Tro");
            NewDT.Columns.Add("TienPhong");
            NewDT.Columns.Add("GiaDien");
            NewDT.Columns.Add("GiaNuoc");
            NewDT.Columns.Add("SoNguoiToiDa");
            NewDT.Columns.Add("SoNguoiO");
            NewDT.Columns.Add("TrangThaiPhong");
            NewDT.Columns.Add("SoThangNo");
            NewDT.Columns.Add("DelFlg");
            NewDT.Columns.Add("FlagInsert");
            NewDT.Columns.Add("STT");
            NewDT.Columns.Add("TenTro");
            NewDT.Columns.Add("SoNguoi");

            int index = 0;
            foreach(DataGridViewRow i in dataGridViewPhong.Rows)
            {
                BUS_Tro bus = new BUS_Tro();
                DataRow newRow = NewDT.NewRow();
                newRow["ID_PhongTro"] = i.Cells["ID_PhongTro"].Value;
                newRow["Ten"] = i.Cells["Ten"].Value;
                newRow["ID_Tro"] = i.Cells["ID_Tro"].Value;
                newRow["TienPhong"] = i.Cells["TienPhong"].Value;
                newRow["GiaDien"] = i.Cells["GiaDien"].Value;
                newRow["GiaNuoc"] = i.Cells["GiaNuoc"].Value;
                newRow["SoNguoiToiDa"] = i.Cells["SoNguoiToiDa"].Value;
                newRow["SoNguoiO"] = i.Cells["SoNguoiO"].Value;
                newRow["TrangThaiPhong"] = i.Cells["TrangThaiPhong"].Value;
                newRow["SoThangNo"] = i.Cells["SoThangNo"].Value;
                newRow["DelFlg"] = i.Cells["DelFlg"].Value;
                newRow["FlagInsert"] = i.Cells["FlagInsert"].Value;
                newRow["STT"] = ++index;
                newRow["TenTro"] = (bus.GetTroByID_Tro(Convert.ToInt32(i.Cells["ID_Tro"].Value.ToString())))[0].Ten;
                newRow["SoNguoi"] = $"{i.Cells["SoNguoiO"].Value} / {i.Cells["SoNguoiToiDa"].Value}";
                NewDT.Rows.Add(newRow);
            }
            dataGridViewPhong.DataSource = NewDT;
            dataGridViewPhong.Columns["STT"].HeaderText = "STT";
            dataGridViewPhong.Columns["Ten"].HeaderText = "Phòng";
            dataGridViewPhong.Columns["TenTro"].HeaderText = "Trọ";
            dataGridViewPhong.Columns["TienPhong"].HeaderText = "Tiền phòng";
            dataGridViewPhong.Columns["GiaDien"].HeaderText = "Giá điện";
            dataGridViewPhong.Columns["GiaNuoc"].HeaderText = "Giá nước";
            dataGridViewPhong.Columns["SoNguoi"].HeaderText = "Số người ở";
            dataGridViewPhong.Columns["TrangThaiPhong"].HeaderText = "Trạng thái";

            dataGridViewPhong.Columns["STT"].DisplayIndex = 0;
            dataGridViewPhong.Columns["Ten"].DisplayIndex = 1;
            dataGridViewPhong.Columns["TenTro"].DisplayIndex = 2;
            dataGridViewPhong.Columns["TienPhong"].DisplayIndex = 3;
            dataGridViewPhong.Columns["GiaDien"].DisplayIndex = 4;
            dataGridViewPhong.Columns["GiaNuoc"].DisplayIndex = 5;
            dataGridViewPhong.Columns["SoNguoi"].DisplayIndex = 6;
            dataGridViewPhong.Columns["TrangThaiPhong"].DisplayIndex = 7;

            dataGridViewPhong.Columns["ID_PhongTro"].Visible = false;
            dataGridViewPhong.Columns["ID_Tro"].Visible = false;
            dataGridViewPhong.Columns["SoNguoiToiDa"].Visible = false;
            dataGridViewPhong.Columns["SoNguoiO"].Visible = false;
            dataGridViewPhong.Columns["SoThangNo"].Visible = false;
            dataGridViewPhong.Columns["DelFlg"].Visible = false;
            dataGridViewPhong.Columns["FlagInsert"].Visible = false;

        }
        #endregion
        #region tạo mã phòng thuê               ---> chưa xong
        private void btnTaoMaPhong1_Click(object sender, EventArgs e)
        {
            int id_phongtro = 0;
            if (dataGridViewPhong.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridViewPhong.SelectedRows)
                {
                    id_phongtro = Convert.ToInt32(i.Cells["ID_PhongTro"].Value.ToString());
                    if (i.Cells["TrangThaiPhong"].Value.ToString() != "Đang cho thuê")
                    {
                        MessageBox.Show("Phòng được chọn đang trạng thái đã cho thuê, vui lòng chọn phòng khác");
                    }
                    else
                    {
                        // tạo mã phòng
                        bool check = false;
                        int randomNumber = 0;
                        BUS_DuyetThuePhong bus = new BUS_DuyetThuePhong();
                        List<DuyetThuePhong> list = new List<DuyetThuePhong>();
                        while (!check) // trong khi mã xác nhận còn trùng với mã khác
                        {
                            Random random = new Random();
                            randomNumber = random.Next(100000, 1000000);
                            list = bus.GetDuyetThuePhongByMaXacNhan(randomNumber);
                            if (list.Count == 0)
                                check = true;
                        }
                        /*string query = string.Format("insert into DuyetThuePhong values ('{0}', '{1}', '{2}', '{3}', '{4}', 0, 0, 0)"
                        , id_phongtro.ToString(), 0, randomNumber.ToString(),
                                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        MessageBox.Show(query);*/
                        bus.AddDuyetThuePhong(new DuyetThuePhong(0, id_phongtro, 0, randomNumber, DateTime.Now, DateTime.Now, Convert.ToDateTime("1900-01-01 00:00:00")));
                        //MessageBox.Show(randomNumber.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng cần tạo mã phòng");
            }

        }
        #endregion
        #endregion

        #region tab2: khách hàng
        #region khóa các textbox
        private void InitLockTextBox2()
        {
            txtCCCD2.Enabled = false;
            txtTenKhachHang2.Enabled = false;
            txtSdt2.Enabled = false;
            txtNgheNghiep2.Enabled = false;
            txtGia2.Enabled = false;
            txtEmail2.Enabled = false;
            cbTenPhong2.Enabled = false;
            dateTimeBatDauThue2.Enabled = false;
            buttonCapNhat2.Visible = false;
            buttonHuy2.Visible = false;
            txtTro2.Visible = false;
            txtPhong2.Visible = false;
            cbTro2.Visible = true;
            cbTenPhong2.Visible = true;
        }
        #endregion
        #region khởi tạo combobxo danh sách trọ
        private void InitComboboxTimKiemTro2()
        {
            List<Tro> list_tro = new List<Tro>();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            var dsTro = new BindingList<KeyValuePair<int, string>>();
            dsTro.Add(new KeyValuePair<int, string>(0, "--Trọ--"));
            foreach (Tro i in list_tro)
            {
                dsTro.Add(new KeyValuePair<int, string>(i.ID_Tro, i.Ten));
                //cbTro1.Items.Add(i.Ten);
            }
            this.cbTro2.DataSource = dsTro;
            this.cbTro2.ValueMember = "Key";
            this.cbTro2.DisplayMember = "Value";
            this.cbTro2.SelectedIndex = 0;
        }
        #endregion
        #region khởi tạo DataGridView danh sách các khách hàng đã thuê trọ
        private void InitDataGridView2()
        {
            List<PhongTro> list_pt = new List<PhongTro>();
            List<Tro> list_tro = new List<Tro>();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            List<PhongTro> tmp = new List<PhongTro>();
            foreach (Tro tro in list_tro)
            {
                tmp = bus_pt.GetPhongTroByID_Tro(tro.ID_Tro);
                list_pt.AddRange(tmp);
            }
            List<KhachHang> list_kh = new List<KhachHang>();
            List<KhachHang> list = new List<KhachHang>();
            BUS_KhachHang bus_kh = new BUS_KhachHang();
            foreach (PhongTro i in list_pt)
            {
                list = bus_kh.GetKhachHangByID_PhongTro(i.ID_PhongTro);
                list_kh.AddRange(list);
            }
            dataGridViewKhachHang.DataSource = list_kh;
            SetDataGridViewKhachHang();
        }
        #endregion
        #region tìm kiếm
        private void btnSearch2_Click(object sender, EventArgs e)
        {
            int id_tro = Convert.ToInt32(cbTro2.SelectedValue);
            List<PhongTro> list_pt = new List<PhongTro>();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            List<PhongTro> tmp = new List<PhongTro>();
            var itemList = cbTro2.DataSource as BindingList<KeyValuePair<int, string>>;
            if (Convert.ToInt32(cbTro2.SelectedValue) == 0)
            {
                foreach (KeyValuePair<int, string> i in itemList)
                {
                    if (i.Key > 0)
                    {
                        tmp = bus_pt.GetPhongTroByID_Tro(i.Key);
                        list_pt.AddRange(tmp);
                    }
                }
            }
            else list_pt = bus_pt.GetPhongTroByID_Tro(id_tro);

            List<KhachHang> list_kh = new List<KhachHang>();
            List<KhachHang> list_tmp = new List<KhachHang>();
            BUS_KhachHang bus_kh = new BUS_KhachHang();
            foreach (PhongTro i in list_pt)
            {
                list_tmp = bus_kh.GetKhachHangByID_PhongTro(i.ID_PhongTro);
                list_kh.AddRange(list_tmp);
            }


            List<KhachHang> list = new List<KhachHang>();
            foreach (KhachHang i in list_kh)
            {
                if (IsSubstring(i.Ten, txtTimKiemKH2.Text))
                {
                    list.Add(i);
                }
            }
            dataGridViewKhachHang.DataSource = list;
            SetDataGridViewKhachHang();
        }
        #endregion
        #region reset tab
        private void btnReset2_Click(object sender, EventArgs e)
        {
            InitLockTextBox2();
            InitComboboxTimKiemTro2();
            InitDataGridView2();
            // reset lại nội dung textbox
            txtTenKhachHang2.Text = "";
            txtCCCD2.Text = "";
            txtSdt2.Text = "";
            txtNgheNghiep2.Text = "";
            txtGia2.Text = "";
            dateTimeBatDauThue2.Text = DateTime.Now.ToString();
            txtTimKiemKH2.Text = "";
            txtEmail2.Text = "";
            buttonCapNhat2.Visible = false;
            cbTro2.Enabled = true;
        }
        #endregion
        #region thêm mới khách hàng khi không có tài khoản (không tạo tài khoản)
        private void UnlockText2()
        {
            txtCCCD2.Enabled = true;
            txtTenKhachHang2.Enabled = true;
            txtSdt2.Enabled = true;
            txtNgheNghiep2.Enabled = true;
            txtEmail2.Enabled = true;
            cbTenPhong2.Enabled = true;
            dateTimeBatDauThue2.Enabled = true;
            buttonCapNhat2.Visible = true;
            buttonHuy2.Visible = true;
        }
        private void cbTro2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTenKhachHang2.Enabled == true)
            {
                var dspTro = new BindingList<KeyValuePair<int, string>>();
                dspTro.Add(new KeyValuePair<int, string>(0, "--Phòng trọ--"));
                if (Convert.ToInt32(cbTro2.SelectedValue) > 0)
                {
                    int id_tro = Convert.ToInt32(cbTro2.SelectedValue);
                    List<PhongTro> list = new List<PhongTro>();
                    BUS_PhongTro bus = new BUS_PhongTro();
                    list = bus.GetPhongTroByID_Tro(id_tro);
                    foreach (PhongTro i in list)
                    {
                        dspTro.Add(new KeyValuePair<int, string>(i.ID_PhongTro, i.Ten));
                        //cbTro1.Items.Add(i.Ten);
                    }
                }
                this.cbTenPhong2.DataSource = dspTro;
                this.cbTenPhong2.ValueMember = "Key";
                this.cbTenPhong2.DisplayMember = "Value";
                this.cbTenPhong2.SelectedIndex = 0;
            }
        }
        private void cbTenPhong2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PhongTro> list = new List<PhongTro>();
            BUS_PhongTro bus = new BUS_PhongTro();
            if (cbTenPhong2.Items.Count > 1 && Convert.ToInt32(cbTenPhong2.SelectedValue) > 0)
            {
                list = bus.GetPhongTroByID_PhongTro(Convert.ToInt32(cbTenPhong2.SelectedValue));
                if (list.Count > 0)
                {
                    txtGia2.Text = list[0].TienPhong.ToString();
                }
                else
                {
                    txtGia2.Text = "";
                }
                //MessageBox.Show(cbTenPhong2.SelectedValue.ToString());
            }
            else
            {
                txtGia2.Text = "";
            }
        }
        // xác nhận thêm/ cập nhật
        private void btnThem2_Click(object sender, EventArgs e)
        {
            btnReset2_Click(sender, e);
            UnlockText2();
            cbTro2_SelectedIndexChanged(sender, e);
        }
        // hủy xác nhận
        private void buttonHuy2_Click(object sender, EventArgs e)
        {
            btnReset2_Click(sender, e);
        }
        #endregion
        #region định dạng DataGridView
        private void SetDataGridViewKhachHang()
        {
            DataTable NewDT = new DataTable();
            NewDT.Columns.Add("ID_KhachHang");
            NewDT.Columns.Add("Ten");
            NewDT.Columns.Add("CCCD");
            NewDT.Columns.Add("SDT");
            NewDT.Columns.Add("Email");
            NewDT.Columns.Add("NgheNghiep");
            NewDT.Columns.Add("ID_PhongTro");
            NewDT.Columns.Add("DelFlg");
            NewDT.Columns.Add("FlagInsert");
            NewDT.Columns.Add("TenPhong");
            NewDT.Columns.Add("ID_Tro");
            NewDT.Columns.Add("TenTro");
            NewDT.Columns.Add("STT");

            int index = 0;
            foreach (DataGridViewRow i in dataGridViewKhachHang.Rows)
            {
                BUS_Tro bus = new BUS_Tro();
                BUS_PhongTro bus_pt = new BUS_PhongTro();
                DataRow newRow = NewDT.NewRow();
                newRow["ID_KhachHang"] = i.Cells["ID_KhachHang"].Value;
                newRow["Ten"] = i.Cells["Ten"].Value;
                newRow["CCCD"] = i.Cells["CCCD"].Value;
                newRow["SDT"] = i.Cells["SDT"].Value;
                newRow["Email"] = i.Cells["Email"].Value;
                newRow["NgheNghiep"] = i.Cells["NgheNghiep"].Value;
                newRow["ID_PhongTro"] = i.Cells["ID_PhongTro"].Value;
                newRow["DelFlg"] = i.Cells["DelFlg"].Value;
                newRow["FlagInsert"] = i.Cells["FlagInsert"].Value;
                newRow["TenPhong"] = bus_pt.GetPhongTroByID_PhongTro(Convert.ToInt32(i.Cells["ID_PhongTro"].Value))[0].Ten;
                newRow["ID_Tro"] = bus_pt.GetPhongTroByID_PhongTro(Convert.ToInt32(i.Cells["ID_PhongTro"].Value))[0].ID_Tro;
                newRow["TenTro"] = bus.GetTroByID_Tro(Convert.ToInt32(newRow["ID_Tro"]))[0].Ten;
                newRow["STT"] = ++index;
                NewDT.Rows.Add(newRow);
            }
            dataGridViewKhachHang.DataSource = NewDT;
            dataGridViewKhachHang.Columns["STT"].HeaderText = "STT";
            dataGridViewKhachHang.Columns["Ten"].HeaderText = "Khách hàng";
            dataGridViewKhachHang.Columns["TenPhong"].HeaderText = "Phòng";
            dataGridViewKhachHang.Columns["TenTro"].HeaderText = "Trọ";
            dataGridViewKhachHang.Columns["CCCD"].HeaderText = "CCCD";
            dataGridViewKhachHang.Columns["SDT"].HeaderText = "SDT";
            dataGridViewKhachHang.Columns["Email"].HeaderText = "Email";
            dataGridViewKhachHang.Columns["NgheNghiep"].HeaderText = "Nghề nghiệp";

            dataGridViewKhachHang.Columns["STT"].DisplayIndex = 0;
            dataGridViewKhachHang.Columns["Ten"].DisplayIndex = 1;
            dataGridViewKhachHang.Columns["TenPhong"].DisplayIndex = 2;
            dataGridViewKhachHang.Columns["TenTro"].DisplayIndex = 3;
            dataGridViewKhachHang.Columns["CCCD"].DisplayIndex = 4;
            dataGridViewKhachHang.Columns["SDT"].DisplayIndex = 5;
            dataGridViewKhachHang.Columns["Email"].DisplayIndex = 6;
            dataGridViewKhachHang.Columns["NgheNghiep"].DisplayIndex = 7;

            dataGridViewKhachHang.Columns["ID_PhongTro"].Visible = false;
            dataGridViewKhachHang.Columns["ID_Tro"].Visible = false;
            dataGridViewKhachHang.Columns["ID_KhachHang"].Visible = false;
            dataGridViewKhachHang.Columns["DelFlg"].Visible = false;
            dataGridViewKhachHang.Columns["FlagInsert"].Visible = false;
        }
        #endregion
        #region thêm mới khách hàng/ cập nhật thông tin khách hàng
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
        private void buttonCapNhat2_Click(object sender, EventArgs e)
        {
            //nếu thêm tài khoản (cbTro2.visible == true)
            //--> thêm khách hàng, thêm duyệt thuê phòng(mã xác nhận  = 0, thời gian kích hoạt = thời gian xác nhạn = datetime.now), chỉnh sửa phòng(ID_khachhang)
            // nếu cập nhật (txtTro2.visible == true) --> cập nhật khách hàng
            if (cbTro2.Visible == true)
            {
                //MessageBox.Show(cbTenPhong2.SelectedValue.ToString());
                // thực hiện thêm mới khách hàng (không có tài khoản)
                List<PhongTro> list = new List<PhongTro>();
                BUS_PhongTro bus_pt = new BUS_PhongTro();
                if (CheckValid() && Convert.ToInt32(cbTenPhong2.SelectedValue) > 0)
                {

                    list = bus_pt.GetPhongTroByID_PhongTro(Convert.ToInt32(cbTenPhong2.SelectedValue));
                    if (list.Count > 0 && list[0].TrangThaiPhong == "Đang cho thuê")
                    {
                        // do something
                        BUS_KhachHang bus_kh = new BUS_KhachHang();
                        // thêm mới khách hàng
                        bus_kh.AddKhachHang(new KhachHang(0, txtTenKhachHang2.Text, txtCCCD2.Text, txtSdt2.Text, txtEmail2.Text, txtNgheNghiep2.Text, Convert.ToInt32(cbTenPhong2.SelectedValue)));
                        BUS_DuyetThuePhong bus_dtp = new BUS_DuyetThuePhong();
                        int id_khachhang = bus_kh.GetRecentKhachHang()[0].ID_KhachHang;
                        // thêm duyệt thuê phòng
                        bus_dtp.AddDuyetThuePhong(new DuyetThuePhong(0, Convert.ToInt32(cbTenPhong2.SelectedValue), id_khachhang, 0, DateTime.Now, DateTime.Now, Convert.ToDateTime("1900-01-01 00:00:00")));
                        //list = bus_pt.GetPhongTroByID_PhongTro(Convert.ToInt32(cbTenPhong2.SelectedValue));
                        list[0].SoNguoiO = list[0].SoNguoiO + 1;
                        if (list[0].SoNguoiO == list[0].SoNguoiToiDa)
                            list[0].TrangThaiPhong = "Đã cho thuê";
                        //  thay đổi số nguồi ở , không thay đổi trạng thái trừ khi phòng đầy
                        bus_pt.UpdatePhongTro(list[0]);

                    }
                    else
                    {
                        MessageBox.Show("Phòng được chọn không trong trạng thái 'Đã cho thuê', vui lòng chọn phòng khác hoặc thay đổi trạng thái phòng");
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin khách hàng chưa đúng, vui lòng nhập lại");
                }
            }
            else
            {
                // thực hiện cập nhật thông tin khách hàng đang thuê trọ
                List<KhachHang> list = new List<KhachHang>();
                BUS_KhachHang bus = new BUS_KhachHang();
                list = bus.GetKhachHangByID_KhachHang(ID_khachhang);
                list[0].Ten = txtTenKhachHang2.Text;
                list[0].CCCD = txtCCCD2.Text;
                list[0].SDT = txtSdt2.Text;
                list[0].NgheNghiep = txtNgheNghiep2.Text;
                list[0].Email = txtEmail2.Text;
                bus.UpDateKhachHang(list[0]);
                MessageBox.Show("Cập nhật thông tin khách hàng thành công");
            }
            ChuTro_MainForm_Load(sender, e);
        }
        #endregion
        #region khách hàng trả phòng
        private int TinhTien(int TienPhong, int GiaDien, int GiaNuoc, int SoDien, int SoNuoc)
        {
            return TienPhong + GiaDien * SoDien + GiaNuoc * SoNuoc;
        }
        private void btnXoa2_Click(object sender, EventArgs e)
        {
            // chỉnh sửa duyệt thuê phòng (thời gian trả phòng), hóa đơn(thanh toán tháng cuối), phòng trọ(id_khachhang, so nguoi o), khách hàng (id_phong)
            // kiểm tra phòng trọ còn tháng nợ hay không, thu tiênf nếu có nợ
            int id_khachhang = ID_khachhang;
            MessageBox.Show("Hãy chắc chắn bạn đã tạo hóa đơn tháng này trước khi khách hàng trả phòng, mọi hóa đơn sẽ được tự động chuyển sang trạng thái 'Đã thanh toán' sau khi trả phòng.");

            List<KhachHang> list = new List<KhachHang>();
            BUS_KhachHang bus = new BUS_KhachHang();
            list = bus.GetKhachHangByID_KhachHang(id_khachhang);    // thông tin khách hàng
            List<PhongTro> list_pt = new List<PhongTro>();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            list_pt = bus_pt.GetPhongTroByID_PhongTro(list[0].ID_PhongTro); // thông tin phòng trọ
            List<HoaDon> list_hd = new List<HoaDon>();
            BUS_HoaDon bus_hd = new BUS_HoaDon();
            list_hd = bus_hd.GetHoaDonByID_PhongTro(list_pt[0].ID_PhongTro); // thông tin các hóa đơn
            List<DuyetThuePhong> list_dtp = new List<DuyetThuePhong>();
            BUS_DuyetThuePhong bus_dtp = new BUS_DuyetThuePhong();
            list_dtp = bus_dtp.GetRecentDuyetThuePhongByID_KhachHang(id_khachhang);  // thông tin duyệt thuê phòng

            bus.UpDateID_PhongTro(list[0]);                                                 // xóa id phòng
            int stn = (list_pt[0].SoNguoiO == 1) ? 0 : (list_pt[0].SoThangNo);
            //MessageBox.Show(stn.ToString() + ", " + (list_pt[0].SoNguoiO - 1).ToString());
            bus_pt.UpdateSoNguoiO(list_pt[0].ID_PhongTro, stn, list_pt[0].SoNguoiO - 1);  //  số người -1
            int TongTienThanhToan = 0;
            if (list_pt[0].SoNguoiO == 1 && list_pt[0].SoThangNo == 1)                    // hoàn thành đóng tiền nếu như tất cả trả phòng
            {
                foreach (HoaDon i in list_hd)
                {
                    if (i.TrangThai == "Chưa thanh toán")
                    {
                        TongTienThanhToan += TinhTien(list_pt[0].TienPhong, list_pt[0].GiaDien, list_pt[0].GiaNuoc,
                                                    i.SoDienMoi - i.SoDienCu, i.SoNuocMoi - i.SoNuocCu);
                    }
                    bus_hd.UpdateHoaDon(i.ID_HoaDon);   // cập nhật trạng thái đã thanh toán cho các hóa đơn
                }
                MessageBox.Show("Số tiền được khách thuê trả là " + TongTienThanhToan.ToString());
            }
            list_dtp[0].ThoiGianTraPhong = DateTime.Now;
            bus_dtp.UpdateDuyetThuePhong(list_dtp[0]);                             // gán thời gian trả phòng

            ChuTro_MainForm_Load(sender, e);
        }
        #endregion
        #region sự kiện chọn khách hàng trong dataGridView
        private void dataGridViewKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id_khachhang = 0;
            if (dataGridViewKhachHang.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow i in dataGridViewKhachHang.SelectedRows)
                {
                    id_khachhang = Convert.ToInt32(i.Cells["ID_KhachHang"].Value.ToString());
                }
                UnlockText2();
                cbTenPhong2.Visible = false;
                cbTro2.Visible = false;
                txtPhong2.Visible = true;
                txtTro2.Visible = true;
                txtPhong2.Enabled = false;
                txtTro2.Enabled = false;
                dateTimeBatDauThue2.Enabled = false;

                List<KhachHang> list = new List<KhachHang>();
                BUS_KhachHang bus = new BUS_KhachHang();
                list = bus.GetKhachHangByID_KhachHang(id_khachhang);
                txtTenKhachHang2.Text = list[0].Ten;
                txtCCCD2.Text = list[0].CCCD;
                txtSdt2.Text = list[0].SDT;
                txtNgheNghiep2.Text = list[0].NgheNghiep;
                txtEmail2.Text = list[0].Email;

                List<PhongTro> list_pt = new List<PhongTro>();
                BUS_PhongTro bus_pt = new BUS_PhongTro();
                list_pt = bus_pt.GetPhongTroByID_PhongTro(list[0].ID_PhongTro);
                txtPhong2.Text = list_pt[0].Ten;
                txtGia2.Text = list_pt[0].TienPhong.ToString();

                List<Tro> list_tro = new List<Tro>();
                BUS_Tro bus_tro = new BUS_Tro();
                list_tro = bus_tro.GetTroByID_Tro(list_pt[0].ID_Tro);
                txtTro2.Text = list_tro[0].Ten;

                List<DuyetThuePhong> list_dtp = new List<DuyetThuePhong>();
                BUS_DuyetThuePhong bus_dtp = new BUS_DuyetThuePhong();
                list_dtp = bus_dtp.GetRecentDuyetThuePhongByID_KhachHang(id_khachhang);
                //MessageBox.Show(list_dtp.Count.ToString());
                dateTimeBatDauThue2.Text = list_dtp[0].ThoiGianXacNhan.ToString();
                ID_khachhang = id_khachhang;
            }
            else
            {
                MessageBox.Show("bạn chỉ chọn 1 khách hàng để thay đổi/ xem thông tin");
            }
        }
        #endregion
        #endregion

        #region tab3: dịch vụ điện nước
        #region khóa các textbox
        private void InitLockTextBox3()
        {
            // groupbox1
            cbPhong31.Enabled = false;
            // groupbox2
            cbPhong32.Enabled = false;
            //txtChiSoDienCu3.Enabled = false;
            //txtChiSoDienMoi3.Enabled = false;
            //txtChiSoNuocCu3.Enabled = false;
            //txtChiSoNuocMoi3.Enabled = false;
            //dateTimeNgayBatDau32.Enabled = false;
            //dateTimeNgayKetThuc32.Enabled = false;
            txtTro3.Visible = false;
            txtPhong3.Visible = false;
        }
        #endregion
        #region khởi tạo combobox danh sách trọ (2 combobox)
        private void InitComboboxTimKiemTro3()
        {
            List<Tro> list_tro = new List<Tro>();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            var dsTro1 = new BindingList<KeyValuePair<int, string>>();
            var dsTro2 = new BindingList<KeyValuePair<int, string>>();
            dsTro1.Add(new KeyValuePair<int, string>(0, "--Trọ--"));
            dsTro2.Add(new KeyValuePair<int, string>(0, "--Trọ--"));
            foreach (Tro i in list_tro)
            {
                dsTro1.Add(new KeyValuePair<int, string>(i.ID_Tro, i.Ten));
                dsTro2.Add(new KeyValuePair<int, string>(i.ID_Tro, i.Ten));
                //cbTro1.Items.Add(i.Ten);
            }
            // combobox trọ thuộc groupbox 1
            this.cbTro31.DataSource = dsTro1;
            this.cbTro31.ValueMember = "Key";
            this.cbTro31.DisplayMember = "Value";
            this.cbTro31.SelectedIndex = 0;
            // combobox trọ thuộc groupbox 2
            this.cbTro32.DataSource = dsTro2;
            this.cbTro32.ValueMember = "Key";
            this.cbTro32.DisplayMember = "Value";
            this.cbTro32.SelectedIndex = 0;
        }
        #endregion
        #region khởi tạo combobox các trạng thái phí (1 combobox)
        private void InitComboboxTrangThaiPhong3()
        {
            var trangThaiPhi = new BindingList<KeyValuePair<int, string>>();
            trangThaiPhi.Add(new KeyValuePair<int, string>(0, "--Trạng thái phí--"));
            trangThaiPhi.Add(new KeyValuePair<int, string>(1, "Đã thanh toán"));
            trangThaiPhi.Add(new KeyValuePair<int, string>(2, "Chưa thanh toán"));
            this.cbTrangThaiPhong3.DataSource = trangThaiPhi;
            this.cbTrangThaiPhong3.ValueMember = "Key";
            this.cbTrangThaiPhong3.DisplayMember = "Value";
            this.cbTrangThaiPhong3.SelectedIndex = 0;
        }
        #endregion
        #region khởi tạo DataGridView danh sách hóa đơn
        private void InitDataGridView3()
        {
            List<PhongTro> list_pt = new List<PhongTro>();
            List<Tro> list_tro = new List<Tro>();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            List<PhongTro> tmp = new List<PhongTro>();
            foreach (Tro tro in list_tro)
            {
                tmp = bus_pt.GetPhongTroByID_Tro(tro.ID_Tro);
                list_pt.AddRange(tmp);
            }
            List<HoaDon> list_hd = new List<HoaDon>();
            BUS_HoaDon bus_hd = new BUS_HoaDon();
            List<HoaDon> list = new List<HoaDon>();
            foreach (PhongTro i in list_pt)
            {
                list = bus_hd.GetHoaDonByID_PhongTro(i.ID_PhongTro);
                list_hd.AddRange(list);
            }
            dataGridViewDichVuDIenNuoc.DataSource = list_hd;
            SetDataGridViewDienNuoc();
        }
        #endregion
        #region tìm kiếm thông tin điện nước
        private void cbTro31_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dspTro = new BindingList<KeyValuePair<int, string>>();
            dspTro.Add(new KeyValuePair<int, string>(0, "--Phòng trọ--"));
            if (Convert.ToInt32(cbTro31.SelectedValue) > 0)
            {
                int id_tro = Convert.ToInt32(cbTro31.SelectedValue);
                List<PhongTro> list = new List<PhongTro>();
                BUS_PhongTro bus = new BUS_PhongTro();
                list = bus.GetPhongTroByID_Tro(id_tro);
                foreach (PhongTro i in list)
                {
                    dspTro.Add(new KeyValuePair<int, string>(i.ID_PhongTro, i.Ten));
                    //cbTro1.Items.Add(i.Ten);
                }
            }
            this.cbPhong31.DataSource = dspTro;
            this.cbPhong31.ValueMember = "Key";
            this.cbPhong31.DisplayMember = "Value";
            this.cbPhong31.SelectedIndex = 0;
            this.cbPhong31.Enabled = true;
        }

        private void btnSearch3_Click(object sender, EventArgs e)
        {
            List<PhongTro> list_pt = new List<PhongTro>();
            List<Tro> list_tro = new List<Tro>();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            BUS_Tro bus_tro = new BUS_Tro();
            if (Convert.ToInt32(cbTro31.SelectedValue) == 0)
            {
                list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            }
            else
            {
                list_tro = bus_tro.GetTroByID_Tro(Convert.ToInt32(cbTro31.SelectedValue));
            }
            //MessageBox.Show("1: " + list_tro.Count.ToString());
            List<PhongTro> tmp = new List<PhongTro>();
            if (Convert.ToInt32(cbPhong31.SelectedValue) == 0)
            {
                foreach (Tro tro in list_tro)
                {
                    tmp = bus_pt.GetPhongTroByID_Tro(tro.ID_Tro);
                    list_pt.AddRange(tmp);
                }
            }
            else
            {
                list_pt = bus_pt.GetPhongTroByID_PhongTro(Convert.ToInt32(cbPhong31.SelectedValue));
            }
            //MessageBox.Show("2: " + list_pt.Count.ToString());
            List<HoaDon> list_hd = new List<HoaDon>();
            BUS_HoaDon bus_hd = new BUS_HoaDon();
            List<HoaDon> list = new List<HoaDon>();
            foreach (PhongTro i in list_pt)
            {
                list = bus_hd.GetHoaDonByID_PhongTro(i.ID_PhongTro);
                list_hd.AddRange(list);
            }
            string trangthai = ((KeyValuePair<int, string>)cbTrangThaiPhong3.SelectedItem).Value.ToString();
            List<HoaDon> list_hoadon = new List<HoaDon>();
            foreach (HoaDon i in list_hd)
            {
                if ((i.TrangThai == trangthai || trangthai == "--Trạng thái phí--") && i.NgayBatDau >= dateTimeNgayBatDau31.Value)
                {
                    list_hoadon.Add(i);
                }
            }
            dataGridViewDichVuDIenNuoc.DataSource = list_hoadon;
            SetDataGridViewDienNuoc();
        }
        #endregion
        #region thêm/ sửa hóa đơn
        private void cbTro32_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dspTro = new BindingList<KeyValuePair<int, string>>();
            dspTro.Add(new KeyValuePair<int, string>(0, "--Phòng trọ--"));
            if (Convert.ToInt32(cbTro32.SelectedValue) > 0)
            {
                int id_tro = Convert.ToInt32(cbTro32.SelectedValue);
                List<PhongTro> list = new List<PhongTro>();
                BUS_PhongTro bus = new BUS_PhongTro();
                list = bus.GetPhongTroByID_Tro(id_tro);
                foreach (PhongTro i in list)
                {
                    dspTro.Add(new KeyValuePair<int, string>(i.ID_PhongTro, i.Ten));
                    //cbTro1.Items.Add(i.Ten);
                }
            }
            this.cbPhong32.DataSource = dspTro;
            this.cbPhong32.ValueMember = "Key";
            this.cbPhong32.DisplayMember = "Value";
            this.cbPhong32.SelectedIndex = 0;
            this.cbPhong32.Enabled = true;
        }
        private void cbPhong32_SelectedIndexChanged(object sender, EventArgs e)  //?
        {
            if (cbPhong32.Items.Count > 1 && Convert.ToInt32(cbPhong32.SelectedValue) > 0) // chọn được phòng
            {
                List<HoaDon> list = new List<HoaDon>();
                BUS_HoaDon bus = new BUS_HoaDon();
                list = bus.GetRecentHoaDonByID_PhongTro(Convert.ToInt32(cbPhong32.SelectedValue));
                if (list.Count > 0)
                {
                    txtChiSoDienCu3.Text = list[0].SoDienMoi.ToString();
                    txtChiSoNuocCu3.Text = list[0].SoNuocMoi.ToString();
                    dateTimeNgayBatDau32.Text = list[0].NgayKetThuc.ToString();
                }
                else
                {
                    txtChiSoDienCu3.Text = "0";
                    txtChiSoNuocCu3.Text = "0";
                }
            }
        }
        static bool CheckDateRange(DateTime startDate, DateTime endDate, int minDays, int maxDays)
        {
            // Tính khoảng cách giữa hai ngày
            TimeSpan difference = endDate - startDate;
            int daysDifference = (int)difference.TotalDays;

            // Kiểm tra xem khoảng cách có nằm trong khoảng [minDays, maxDays] hay không
            return daysDifference >= minDays && daysDifference <= maxDays;
        }
        private bool CheckValidDienNuoc()
        {
            // kiểm tra các trường có bị bỏ trống không
            // kiểm tra trường số nhập đúng định dạng không (cũ <= mới)
            // tương tự với thời gian (cũ < mới)
            if ((cbPhong32.Items.Count < 2 || Convert.ToInt32(cbPhong32.SelectedValue) == 0) && cbPhong32.Enabled == true)
                return false;
            if (txtChiSoDienCu3.Text == "" || txtChiSoDienMoi3.Text == "")
                return false;
            if (txtChiSoNuocCu3.Text == "" || txtChiSoNuocMoi3.Text == "")
                return false;
            if (Convert.ToInt32(txtChiSoDienCu3.Text) > Convert.ToInt32(txtChiSoDienMoi3.Text))
                return false;
            if (Convert.ToInt32(txtChiSoNuocCu3.Text) > Convert.ToInt32(txtChiSoNuocMoi3.Text))
                return false;
            if (!CheckDateRange(Convert.ToDateTime(dateTimeNgayBatDau32.Text), Convert.ToDateTime(dateTimeNgayKetThuc32.Text), 20, 40))
                return false;
            return true;
        }
        private void btnSave3_Click(object sender, EventArgs e)
        {
            // nếu nhuư cập nhật (txtPhong3.visible = true) --> cập nhật lại trong HoaDon
            // nếu thêm mới hóa đơn (cbPhong32.visible = true) --> thêm mới hóa đơn
            BUS_HoaDon bus = new BUS_HoaDon();
            if (txtPhong3.Visible == true && CheckValidDienNuoc())
            {
                //MessageBox.Show(ID_hoadon.ToString());
                BUS_PhongTro bus_pt = new BUS_PhongTro();
                List<PhongTro> list_pt = new List<PhongTro>();
                list_pt = bus_pt.GetPhongTroByID_PhongTro(ID_phongtro);
                int tien = TinhTien(list_pt[0].TienPhong, list_pt[0].GiaDien, list_pt[0].GiaNuoc, Convert.ToInt32(txtChiSoDienMoi3.Text) - Convert.ToInt32(txtChiSoDienCu3.Text), Convert.ToInt32(txtChiSoNuocMoi3.Text) - Convert.ToInt32(txtChiSoNuocCu3.Text));
                bus.UpdateThongTinHoaDon(ID_hoadon, Convert.ToInt32(txtChiSoDienMoi3.Text),
                    Convert.ToInt32(txtChiSoNuocMoi3.Text), Convert.ToDateTime(dateTimeNgayKetThuc32.Text), tien);
                InitDataGridView3();
                btnCancel3_Click(sender, e);
                ChuTro_MainForm_Load(sender, e);
            }
            else if (cbPhong32.Visible == true && CheckValidDienNuoc())
            {
                BUS_PhongTro bus_pt = new BUS_PhongTro();
                List<PhongTro> list_pt = new List<PhongTro>();
                list_pt = bus_pt.GetPhongTroByID_PhongTro(Convert.ToInt32(cbPhong32.SelectedValue));
                bus.AddHoaDon(new HoaDon(0, list_pt[0].ID_PhongTro, Convert.ToInt32(txtChiSoDienCu3.Text), Convert.ToInt32(txtChiSoNuocCu3.Text),
                    Convert.ToInt32(txtChiSoDienMoi3.Text), Convert.ToInt32(txtChiSoNuocMoi3.Text),
                    TinhTien(list_pt[0].TienPhong, list_pt[0].GiaDien, list_pt[0].GiaNuoc, Convert.ToInt32(txtChiSoDienMoi3.Text) - Convert.ToInt32(txtChiSoDienCu3.Text), Convert.ToInt32(txtChiSoNuocMoi3.Text) - Convert.ToInt32(txtChiSoNuocCu3.Text)),
                    Convert.ToDateTime(dateTimeNgayBatDau32.Text), Convert.ToDateTime(dateTimeNgayKetThuc32.Text), "Chưa thanh toán"));
                // số tháng nợ tăng lên:
                bus_pt.UpdateSoThangNo(list_pt[0].ID_PhongTro, 1);
                InitDataGridView3();
                btnCancel3_Click(sender, e);
                ChuTro_MainForm_Load(sender, e);
            }
            else
            {
                MessageBox.Show("kiểm tra lại thông tin đã nhập");
            }
        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            txtPhong3.Text = "";
            txtTro3.Text = "";
            txtPhong3.Visible = false;
            txtTro3.Visible = false;
            cbPhong32.Visible = true;
            cbTro32.Visible = true;
            txtChiSoDienCu3.Text = "";
            txtChiSoDienMoi3.Text = "";
            txtChiSoNuocCu3.Text = "";
            txtChiSoNuocMoi3.Text = "";
            txtChiSoDienCu3.Enabled = true;
            txtChiSoNuocCu3.Enabled = true;
            txtChiSoDienMoi3.Enabled = true;
            txtChiSoNuocMoi3.Enabled = true;
            dateTimeNgayKetThuc32.Enabled = true;
            dateTimeNgayBatDau32.Enabled = true;
            InitLockTextBox3();
        }
        #endregion
        #region show hóa đơn
        private void dataGridViewDichVuDIenNuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // khóa các textbox
            cbPhong32.Visible = false;
            cbTro32.Visible = false;
            txtPhong3.Visible = true;
            txtTro3.Visible = true;
            // đưa thông tin lên group box
            BUS_HoaDon bus_hd = new BUS_HoaDon();
            List<HoaDon> list_hd = new List<HoaDon>();
            if (dataGridViewDichVuDIenNuoc.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow i in dataGridViewDichVuDIenNuoc.SelectedRows)
                {
                    ID_hoadon = Convert.ToInt32(i.Cells["ID_HoaDon"].Value.ToString());
                }
                list_hd = bus_hd.GetHoaDonByID_HoaDon(ID_hoadon);
                txtChiSoDienCu3.Text = list_hd[0].SoDienCu.ToString();
                txtChiSoDienMoi3.Text = list_hd[0].SoDienMoi.ToString();
                txtChiSoNuocCu3.Text = list_hd[0].SoNuocCu.ToString();
                txtChiSoNuocMoi3.Text = list_hd[0].SoNuocMoi.ToString();
                txtChiSoDienCu3.Enabled = false;
                txtChiSoNuocCu3.Enabled = false;
                txtChiSoDienMoi3.Enabled = true;
                txtChiSoNuocMoi3.Enabled = true;
                dateTimeNgayKetThuc32.Enabled = true;
                dateTimeNgayBatDau32.Text = list_hd[0].NgayBatDau.ToString();
                dateTimeNgayKetThuc32.Text = list_hd[0].NgayKetThuc.ToString();
                BUS_PhongTro bus_pt = new BUS_PhongTro();
                List<PhongTro> list_pt = new List<PhongTro>();
                list_pt = bus_pt.GetPhongTroByID_PhongTro(list_hd[0].ID_PhongTro);
                txtPhong3.Text = list_pt[0].Ten;
                ID_phongtro = list_pt[0].ID_PhongTro;
                ID_tro = list_pt[0].ID_Tro;
                BUS_Tro bus_tro = new BUS_Tro();
                List<Tro> list_tro = new List<Tro>();
                list_tro = bus_tro.GetTroByID_Tro(list_pt[0].ID_Tro);
                txtTro3.Text = list_tro[0].Ten;
                txtTro3.Enabled = false;
                txtPhong3.Enabled = false;
                dateTimeNgayBatDau32.Enabled = false;

                // kiểm tra hóa đơn có phải là hóa đơn gần nhất của phòng đó không
                list_hd = bus_hd.GetRecentHoaDonByID_PhongTro(list_pt[0].ID_PhongTro);
                if (ID_hoadon != list_hd[0].ID_HoaDon || list_hd[0].TrangThai == "Đã thanh toán")       // không phải hóa đơn gần nhất hoặc đã thanh toán
                {
                    txtChiSoDienMoi3.Enabled = false;
                    txtChiSoNuocMoi3.Enabled = false;
                    dateTimeNgayKetThuc32.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("vui lòng chỉ chọn 1 dòng duy nhất");
            }
        }
        #endregion
        #region định dạng DataGridView
        private void SetDataGridViewDienNuoc()
        {
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
            foreach (DataGridViewRow i in dataGridViewDichVuDIenNuoc.Rows)
            {
                BUS_PhongTro bus = new BUS_PhongTro();
                DataRow newRow = NewDT.NewRow();
                newRow["ID_HoaDon"] = i.Cells["ID_HoaDon"].Value;
                newRow["STT"] = ++index;   // new
                newRow["ID_PhongTro"] = i.Cells["ID_PhongTro"].Value;
                newRow["TenPhong"] = bus.GetPhongTroByID_PhongTro(Convert.ToInt32(i.Cells["ID_PhongTro"].Value))[0].Ten; // new
                newRow["SoDienCu"] = i.Cells["SoDienCu"].Value;
                newRow["SoNuocCu"] = i.Cells["SoNuocCu"].Value;
                newRow["SoDienMoi"] = i.Cells["SoDienMoi"].Value;
                newRow["SoNuocMoi"] = i.Cells["SoNuocMoi"].Value;
                newRow["Dien"] = $"{i.Cells["SoDienCu"].Value} -> {i.Cells["SoDienMoi"].Value}"; // new
                newRow["Nuoc"] = $"{i.Cells["SoNuocCu"].Value} -> {i.Cells["SoNuocMoi"].Value}"; // new
                newRow["ThanhTien"] = i.Cells["ThanhTien"].Value;
                newRow["NgayBatDau"] = i.Cells["NgayBatDau"].Value;
                newRow["NgayKetThuc"] = i.Cells["NgayBatDau"].Value;
                newRow["TrangThai"] = i.Cells["TrangThai"].Value;
                newRow["DelFlg"] = i.Cells["DelFlg"].Value;
                newRow["FlagInsert"] = i.Cells["FlagInsert"].Value;
                NewDT.Rows.Add(newRow);
            }
            dataGridViewDichVuDIenNuoc.DataSource = NewDT;
            dataGridViewDichVuDIenNuoc.Columns["STT"].HeaderText = "STT";
            dataGridViewDichVuDIenNuoc.Columns["TenPhong"].HeaderText = "Phòng";
            dataGridViewDichVuDIenNuoc.Columns["Dien"].HeaderText = "Điện";
            dataGridViewDichVuDIenNuoc.Columns["Nuoc"].HeaderText = "Nước";
            dataGridViewDichVuDIenNuoc.Columns["ThanhTien"].HeaderText = "Tổng tiền";
            dataGridViewDichVuDIenNuoc.Columns["NgayBatDau"].HeaderText = "Ngày đầu";
            dataGridViewDichVuDIenNuoc.Columns["NgayKetThuc"].HeaderText = "Ngày cuối";
            dataGridViewDichVuDIenNuoc.Columns["TrangThai"].HeaderText = "Trạng thái";

            dataGridViewDichVuDIenNuoc.Columns["STT"].DisplayIndex = 0;
            dataGridViewDichVuDIenNuoc.Columns["TenPhong"].DisplayIndex = 1;
            dataGridViewDichVuDIenNuoc.Columns["Dien"].DisplayIndex = 2;
            dataGridViewDichVuDIenNuoc.Columns["Nuoc"].DisplayIndex = 3;
            dataGridViewDichVuDIenNuoc.Columns["ThanhTien"].DisplayIndex = 4;
            dataGridViewDichVuDIenNuoc.Columns["NgayBatDau"].DisplayIndex = 5;
            dataGridViewDichVuDIenNuoc.Columns["NgayKetThuc"].DisplayIndex = 6;
            dataGridViewDichVuDIenNuoc.Columns["TrangThai"].DisplayIndex = 7;

            dataGridViewDichVuDIenNuoc.Columns["ID_HoaDon"].Visible = false;
            dataGridViewDichVuDIenNuoc.Columns["ID_PhongTro"].Visible = false;
            dataGridViewDichVuDIenNuoc.Columns["SoDienCu"].Visible = false;
            dataGridViewDichVuDIenNuoc.Columns["SoNuocCu"].Visible = false;
            dataGridViewDichVuDIenNuoc.Columns["SoDienMoi"].Visible = false;
            dataGridViewDichVuDIenNuoc.Columns["SoNuocMoi"].Visible = false;
            dataGridViewDichVuDIenNuoc.Columns["DelFlg"].Visible = false;
            dataGridViewDichVuDIenNuoc.Columns["FlagInsert"].Visible = false;
        }

        #endregion
        #endregion

        #region tab4: tính tiền/ trả phòng
        #region khóa các textbox
        private void InitLockTextbox4()
        {
            cbPhong4.Enabled = false;
        }
        #endregion
        #region khởi tạo combobox danh sách trọ
        private void InitComboboxTimKiemTro4()
        {
            List<Tro> list_tro = new List<Tro>();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            var dsTro = new BindingList<KeyValuePair<int, string>>();
            dsTro.Add(new KeyValuePair<int, string>(0, "--Trọ--"));
            foreach (Tro i in list_tro)
            {
                dsTro.Add(new KeyValuePair<int, string>(i.ID_Tro, i.Ten));
                //cbTro1.Items.Add(i.Ten);
            }
            this.cbTro4.DataSource = dsTro;
            this.cbTro4.ValueMember = "Key";
            this.cbTro4.DisplayMember = "Value";
            this.cbTro4.SelectedIndex = 0;
        }
        #endregion
        #region khởi tạo combobox trạng thái phí
        private void InitComboboxTrangThaiPhi4()
        {
            var trangThaiPhi = new BindingList<KeyValuePair<int, string>>();
            trangThaiPhi.Add(new KeyValuePair<int, string>(0, "--Trạng thái phí--"));
            trangThaiPhi.Add(new KeyValuePair<int, string>(1, "Đã thanh toán"));
            trangThaiPhi.Add(new KeyValuePair<int, string>(2, "Chưa thanh toán"));
            this.cbTrangThaiPhong4.DataSource = trangThaiPhi;
            this.cbTrangThaiPhong4.ValueMember = "Key";
            this.cbTrangThaiPhong4.DisplayMember = "Value";
            this.cbTrangThaiPhong4.SelectedIndex = 0;
        }
        #endregion
        #region khởi tạo DataGridView danh sách phòng trọ
        private void InitDataGridView4()
        {
            List<PhongTro> list_pt = new List<PhongTro>();
            List<Tro> list_tro = new List<Tro>();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            List<PhongTro> tmp = new List<PhongTro>();
            foreach (Tro tro in list_tro)
            {
                tmp = bus_pt.GetPhongTroByID_Tro(tro.ID_Tro);
                list_pt.AddRange(tmp);
            }
            dataGridViewTinhTienTraPhong.DataSource = list_pt;
            SetDataGridViewTinhTienTraPhong();
        }
        #endregion
        #region định dạng DataGridView
        private void SetDataGridViewTinhTienTraPhong()
        {
            DataTable NewDT = new DataTable();
            NewDT.Columns.Add("ID_PhongTro");
            NewDT.Columns.Add("Ten");
            NewDT.Columns.Add("ID_Tro");
            NewDT.Columns.Add("TienPhong");
            NewDT.Columns.Add("GiaDien");
            NewDT.Columns.Add("GiaNuoc");
            NewDT.Columns.Add("SoNguoiToiDa");
            NewDT.Columns.Add("SoNguoiO");
            NewDT.Columns.Add("TrangThaiPhong");
            NewDT.Columns.Add("SoThangNo");
            NewDT.Columns.Add("DelFlg");
            NewDT.Columns.Add("FlagInsert");
            NewDT.Columns.Add("STT");
            NewDT.Columns.Add("TenTro");
            NewDT.Columns.Add("SoNguoi");
            
            int index = 0;
            foreach (DataGridViewRow i in dataGridViewTinhTienTraPhong.Rows)
            {
                BUS_Tro bus = new BUS_Tro();
                DataRow newRow = NewDT.NewRow();
                newRow["ID_PhongTro"] = i.Cells["ID_PhongTro"].Value;
                newRow["Ten"] = i.Cells["Ten"].Value;
                newRow["ID_Tro"] = i.Cells["ID_Tro"].Value;
                newRow["TienPhong"] = i.Cells["TienPhong"].Value;
                newRow["GiaDien"] = i.Cells["GiaDien"].Value;
                newRow["GiaNuoc"] = i.Cells["GiaNuoc"].Value;
                newRow["SoNguoiToiDa"] = i.Cells["SoNguoiToiDa"].Value;
                newRow["SoNguoiO"] = i.Cells["SoNguoiO"].Value;
                newRow["TrangThaiPhong"] = i.Cells["TrangThaiPhong"].Value;
                newRow["SoThangNo"] = i.Cells["SoThangNo"].Value;
                newRow["DelFlg"] = i.Cells["DelFlg"].Value;
                newRow["FlagInsert"] = i.Cells["FlagInsert"].Value;
                newRow["STT"] = ++index;
                newRow["TenTro"] = (bus.GetTroByID_Tro(Convert.ToInt32(i.Cells["ID_Tro"].Value.ToString())))[0].Ten;
                newRow["SoNguoi"] = $"{i.Cells["SoNguoiO"].Value} / {i.Cells["SoNguoiToiDa"].Value}";
                NewDT.Rows.Add(newRow);
            }
            dataGridViewTinhTienTraPhong.DataSource = NewDT;
            dataGridViewTinhTienTraPhong.Columns["STT"].HeaderText = "STT";
            dataGridViewTinhTienTraPhong.Columns["Ten"].HeaderText = "Phòng";
            dataGridViewTinhTienTraPhong.Columns["TenTro"].HeaderText = "Trọ";
            dataGridViewTinhTienTraPhong.Columns["TienPhong"].HeaderText = "Tiền phòng";
            dataGridViewTinhTienTraPhong.Columns["GiaDien"].HeaderText = "Giá điện";
            dataGridViewTinhTienTraPhong.Columns["GiaNuoc"].HeaderText = "Giá nước";
            dataGridViewTinhTienTraPhong.Columns["SoNguoi"].HeaderText = "Số người ở";
            dataGridViewTinhTienTraPhong.Columns["TrangThaiPhong"].HeaderText = "Trạng thái";

            dataGridViewTinhTienTraPhong.Columns["STT"].DisplayIndex = 0;
            dataGridViewTinhTienTraPhong.Columns["Ten"].DisplayIndex = 1;
            dataGridViewTinhTienTraPhong.Columns["TenTro"].DisplayIndex = 2;
            dataGridViewTinhTienTraPhong.Columns["TienPhong"].DisplayIndex = 3;
            dataGridViewTinhTienTraPhong.Columns["GiaDien"].DisplayIndex = 4;
            dataGridViewTinhTienTraPhong.Columns["GiaNuoc"].DisplayIndex = 5;
            dataGridViewTinhTienTraPhong.Columns["SoNguoi"].DisplayIndex = 6;
            dataGridViewTinhTienTraPhong.Columns["TrangThaiPhong"].DisplayIndex = 7;

            dataGridViewTinhTienTraPhong.Columns["ID_PhongTro"].Visible = false;
            dataGridViewTinhTienTraPhong.Columns["ID_Tro"].Visible = false;
            dataGridViewTinhTienTraPhong.Columns["SoNguoiToiDa"].Visible = false;
            dataGridViewTinhTienTraPhong.Columns["SoNguoiO"].Visible = false;
            dataGridViewTinhTienTraPhong.Columns["SoThangNo"].Visible = false;
            dataGridViewTinhTienTraPhong.Columns["DelFlg"].Visible = false;
            dataGridViewTinhTienTraPhong.Columns["FlagInsert"].Visible = false;

        }
        #endregion
        #region tìm kiếm phòng trọ
        private void cbTro4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dspTro = new BindingList<KeyValuePair<int, string>>();
            dspTro.Add(new KeyValuePair<int, string>(0, "--Phòng trọ--"));
            if (Convert.ToInt32(cbTro4.SelectedValue) > 0)
            {
                int id_tro = Convert.ToInt32(cbTro4.SelectedValue);
                List<PhongTro> list = new List<PhongTro>();
                BUS_PhongTro bus = new BUS_PhongTro();
                list = bus.GetPhongTroByID_Tro(id_tro);
                foreach (PhongTro i in list)
                {
                    dspTro.Add(new KeyValuePair<int, string>(i.ID_PhongTro, i.Ten));
                    //cbTro1.Items.Add(i.Ten);
                }
            }
            this.cbPhong4.DataSource = dspTro;
            this.cbPhong4.ValueMember = "Key";
            this.cbPhong4.DisplayMember = "Value";
            this.cbPhong4.SelectedIndex = 0;
            this.cbPhong4.Enabled = true;
        }
        private void btnSearch4_Click(object sender, EventArgs e)
        {
            List<PhongTro> list_pt = new List<PhongTro>();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            List<Tro> list_tro = new List<Tro>();
            BUS_Tro bus_tro = new BUS_Tro();
            if (Convert.ToInt32(cbTro4.SelectedValue) == 0)
            {
                list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            }
            else
            {
                list_tro = bus_tro.GetTroByID_Tro(Convert.ToInt32(cbTro4.SelectedValue));
            }
            List<PhongTro> list = new List<PhongTro>();
            foreach (Tro i in list_tro)
            {
                // MessageBox.Show("'" + ((KeyValuePair<int, string>)(cbTrangThaiPhong4.SelectedItem)).Value.ToString() + "'");
                list = bus_pt.GetPhongTro3(i.ID_Tro, Convert.ToInt32(cbPhong4.SelectedValue), ((KeyValuePair<int, string>)(cbTrangThaiPhong4.SelectedItem)).Value.ToString());
                list_pt.AddRange(list);
            }
            dataGridViewTinhTienTraPhong.DataSource = list_pt;
            SetDataGridViewTinhTienTraPhong();
        }
        #endregion
        #region thanh toán toàn bộ tiền phòng
        private void btnTinhTien4_Click(object sender, EventArgs e)
        {
            List<HoaDon> list = new List<HoaDon>();
            BUS_HoaDon bus_hd = new BUS_HoaDon();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            int id_phongtro = 0;
            if (dataGridViewTinhTienTraPhong.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridViewTinhTienTraPhong.SelectedRows)
                {
                    id_phongtro = Convert.ToInt32(i.Cells["ID_PhongTro"].Value.ToString());
                }
                list = bus_hd.GetHoaDonByID_PhongTro(id_phongtro);
                int tongtien = 0;
                foreach (HoaDon i in list)
                {
                    if (i.TrangThai == "Chưa thanh toán")
                    {
                        tongtien += i.ThanhTien;
                        bus_pt.UpdateSoThangNo(id_phongtro, -1);
                        bus_hd.UpdateHoaDon(i.ID_HoaDon);
                    }
                }
                MessageBox.Show("số tiền được thanh toán ở phòng trọ " + id_phongtro + " là :" + tongtien);
            }
            btnSearch4_Click(sender, e);
        }
        #endregion
        #region trả phòng (toàn bộ khách phòng trả)
        private void btnTraPhong4_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion

        #region tab5: báo cáo
        #region khóa các textbox
        private void InitLockTextBox5()
        {
            cbPhong5.Enabled = false;
        }
        #endregion
        #region khởi tạo combobox danh sách trọ
        private void InitComboboxTimKiemTro5()
        {
            List<Tro> list_tro = new List<Tro>();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            var dsTro = new BindingList<KeyValuePair<int, string>>();
            dsTro.Add(new KeyValuePair<int, string>(0, "--Trọ--"));
            foreach (Tro i in list_tro)
            {
                dsTro.Add(new KeyValuePair<int, string>(i.ID_Tro, i.Ten));
                //cbTro1.Items.Add(i.Ten);
            }
            this.cbTro5.DataSource = dsTro;
            this.cbTro5.ValueMember = "Key";
            this.cbTro5.DisplayMember = "Value";
            this.cbTro5.SelectedIndex = 0;
        }
        #endregion
        #region khóa các combobox trạng thái phí
        private void InitComboboxTrangThaiPhi5()
        {
            var trangThaiPhi = new BindingList<KeyValuePair<int, string>>();
            trangThaiPhi.Add(new KeyValuePair<int, string>(0, "--Trạng thái phí--"));
            trangThaiPhi.Add(new KeyValuePair<int, string>(1, "Đã thanh toán"));
            trangThaiPhi.Add(new KeyValuePair<int, string>(2, "Chưa thanh toán"));
            this.cbTrangThaiPhong5.DataSource = trangThaiPhi;
            this.cbTrangThaiPhong5.ValueMember = "Key";
            this.cbTrangThaiPhong5.DisplayMember = "Value";
            this.cbTrangThaiPhong5.SelectedIndex = 0;
        }
        #endregion
        #region khóa DataGridView danh sách hóa đơn
        private void InitDataGridView5()
        {
            List<PhongTro> list_pt = new List<PhongTro>();
            List<Tro> list_tro = new List<Tro>();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            List<PhongTro> tmp = new List<PhongTro>();
            foreach (Tro tro in list_tro)
            {
                tmp = bus_pt.GetPhongTroByID_Tro(tro.ID_Tro);
                list_pt.AddRange(tmp);
            }
            List<HoaDon> list_hd = new List<HoaDon>();
            BUS_HoaDon bus_hd = new BUS_HoaDon();
            List<HoaDon> list = new List<HoaDon>();
            foreach (PhongTro i in list_pt)
            {
                list = bus_hd.GetHoaDonByID_PhongTro(i.ID_PhongTro);
                list_hd.AddRange(list);
            }
            dataGridViewBaoCao.DataSource = list_hd;

        }
        #endregion
        #region khởi tạo combobox danh sách phòng thuê
        private void cbTro5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dspTro = new BindingList<KeyValuePair<int, string>>();
            dspTro.Add(new KeyValuePair<int, string>(0, "--Phòng trọ--"));
            if (Convert.ToInt32(cbTro5.SelectedValue) > 0)
            {
                int id_tro = Convert.ToInt32(cbTro5.SelectedValue);
                List<PhongTro> list = new List<PhongTro>();
                BUS_PhongTro bus = new BUS_PhongTro();
                list = bus.GetPhongTroByID_Tro(id_tro);
                foreach (PhongTro i in list)
                {
                    dspTro.Add(new KeyValuePair<int, string>(i.ID_PhongTro, i.Ten));
                    //cbTro1.Items.Add(i.Ten);
                }
            }
            this.cbPhong5.DataSource = dspTro;
            this.cbPhong5.ValueMember = "Key";
            this.cbPhong5.DisplayMember = "Value";
            this.cbPhong5.SelectedIndex = 0;
            this.cbPhong5.Enabled = true;
        }
        #endregion
        #region xuất excel
        private void btnBaoCao5_Click(object sender, EventArgs e)
        {
            // Tạo ứng dụng Excel mới
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            // Tạo Workbook mới
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);

            // Tạo Worksheet mới
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

            // Xuất tiêu đề cột
            for (int i = 1; i < dataGridViewBaoCao.Columns.Count + 1; i++)
            {
                excelWorksheet.Cells[1, i] = dataGridViewBaoCao.Columns[i - 1].HeaderText;
            }

            // Xuất nội dung hàng
            for (int i = 0; i < dataGridViewBaoCao.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewBaoCao.Columns.Count; j++)
                {
                    excelWorksheet.Cells[i + 2, j + 1] = dataGridViewBaoCao.Rows[i].Cells[j].Value.ToString();
                }
            }

            // Lấy ngày hiện tại và định dạng
            string currentDate = DateTime.Now.ToString("yyyyMMdd");
            string fileName = $"BaoCao_{currentDate}.xls";
            string savePath = $"E:\\{fileName}";

            // Lưu file Excel
            excelWorkbook.SaveAs(savePath, Excel.XlFileFormat.xlWorkbookNormal);

            // Giải phóng tài nguyên
            excelWorkbook.Close();
            excelApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            MessageBox.Show("Dữ liệu đã được xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
        #endregion

        #region tab6: quản lí tài khoản cá nhân chủ trọ
        #region khóa các textbox
        private void InitLockTextbox6()
        {
            // thông tin tài khoản
            txtMaTK6.Enabled = false;
            txtTenTK6.Enabled = false;
            txtQuyen6.Enabled = false;
            txtMatKhau6.Visible = false;
            txtNhapLaiMK6.Visible = false;
            labelMK6.Visible = false;
            labMatKhauMoi6.Visible = false;
            btnCancel61.Visible = false;
            btnOK61.Visible = false;

            // thông tin cá nhân
            txtTenChuTro6.Enabled = false;
            txtEmail6.Enabled = false;
            txtDiaChi6.Enabled = false;
            txtCCCD6.Enabled = false;
            txtSDT6.Enabled = false;
            btnCancel62.Visible = false;
            btnOK62.Visible = false;
        }
        #endregion
        #region lấy thông tin tài khoản chủ trọ
        private void InitGetTaiKhoan6()
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            BUS_TaiKhoan bus = new BUS_TaiKhoan();
            list = bus.GetTaiKhoanByID_TaiKhoan(ID_chutro, "Chủ trọ");
            txtMaTK6.Text = ID_chutro.ToString();
            txtTenTK6.Text = list[0].Username;
            txtQuyen6.Text = "Chủ trọ";
            // txtMatKhau6.Text = list[0].Password;
        }
        #endregion
        #region lấy thông tin chủ trọ
        private void InitGetChuTro6()
        {
            List<ChuTro> list = new List<ChuTro>();
            BUS_ChuTro bus = new BUS_ChuTro();
            list = bus.GetChuTro(ID_chutro);
            txtTenChuTro6.Text = list[0].Ten;
            txtEmail6.Text = list[0].Email;
            txtDiaChi6.Text = list[0].DiaChi;
            txtCCCD6.Text = list[0].CCCD;
            txtSDT6.Text = list[0].SDT;
        }
        #endregion
        #region quản lí tài khoản chủ trọ
        private void btnSuaTK62_Click(object sender, EventArgs e)
        {
            // hiển thị
            labelMK6.Visible = true;
            labMatKhauMoi6.Visible = true;
            txtMatKhau6.Enabled = true;
            txtMatKhau6.Visible = true;
            txtNhapLaiMK6.Enabled = true;
            txtNhapLaiMK6.Visible = true;
            btnCancel61.Visible = true;
            btnOK61.Visible = true;
        }
        private Boolean checkPwd()
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            BUS_TaiKhoan bus = new BUS_TaiKhoan();
            list = bus.GetTaiKhoanByID_TaiKhoan(ID_chutro, "Chủ trọ");
            if (txtMatKhau6.Text == list[0].Password)
                return true;
            return false;
        }
        private void btnOK61_Click(object sender, EventArgs e)
        {
            // kiểm tra mật khẩu cũ, kiểm tra mật khẩu mới --> cập nhật mật khẩu tài khoản
            if (!checkPwd())
            {
                MessageBox.Show(("Mật khẩu cũ không đúng, vui lòng nhập lại"));
            }
            else if (txtNhapLaiMK6.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải tối kiểu 6 kí tự");
            }
            else
            {
                BUS_TaiKhoan bus = new BUS_TaiKhoan();
                bus.UpdateTaiKhoan(new TaiKhoan(ID_chutro, txtTenTK6.Text, txtNhapLaiMK6.Text, "Chủ trọ"));
                MessageBox.Show("Cập nhật mật khẩu mới thành công");
                ChuTro_MainForm_Load(sender, e);
            }

        }
        private void btnCancel61_Click(object sender, EventArgs e)
        {
            txtMatKhau6.Text = "";
            txtNhapLaiMK6.Text = "";
            txtMatKhau6.Visible = false;
            txtNhapLaiMK6.Visible = false;
            btnOK61.Visible = false;
            btnCancel61.Visible = false;
            labelMK6.Visible = false;
            labMatKhauMoi6.Visible = false;
        }
        #endregion
        #region quản lí thông tin chủ trọ
        private void buttonSua62_Click(object sender, EventArgs e)
        {
            // hiển thị
            txtTenChuTro6.Enabled = true;
            txtDiaChi6.Enabled = true;
            txtSDT6.Enabled = true;
            txtEmail6.Enabled = true;
            txtCCCD6.Enabled = true;
            btnCancel62.Visible = true;
            btnOK62.Visible = true;
        }

        private void btnCancel62_Click(object sender, EventArgs e)
        {
            InitGetChuTro6();
            txtTenChuTro6.Enabled = false;
            txtEmail6.Enabled = false;
            txtDiaChi6.Enabled = false;
            txtCCCD6.Enabled = false;
            txtSDT6.Enabled = false;
            btnCancel62.Visible = false;
            btnOK62.Visible = false;
        }
        private Boolean Check(string email, string sdt)
        {
            if (this.VaildSDT(sdt) && this.ValidEmail(email))
                return true;
            else
                return false;
        }
        private void btnOK62_Click(object sender, EventArgs e)
        {
            // kiểm tra số điện thoại, email, cccd --> cập nhật chủ trọ
            if (Check(txtEmail6.Text, txtSDT6.Text))
            {
                BUS_ChuTro bus = new BUS_ChuTro();
                bus.UpdateChuTro(new ChuTro(ID_chutro, txtTenChuTro6.Text, txtSDT6.Text, txtDiaChi6.Text, txtCCCD6.Text, txtEmail6.Text));
                MessageBox.Show("Cập nhật thông tin chủ trọ thành công");
                ChuTro_MainForm_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đã nhập");
            }
        }
        #endregion
        #endregion

        #region tab7: duyệt thuê phòng tư yêu cầu khách hàng
        #region khóa các textbox
        private void InitLockTextBox7()
        {
            cbPhong7.Enabled = false;
            btnKhongDuyet7.Visible = false;
        }

        #endregion
        #region khởi tạo combobox danh sách trọ
        private void InitComboboxTimKiemTro7()
        {
            List<Tro> list_tro = new List<Tro>();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            var dsTro = new BindingList<KeyValuePair<int, string>>();
            dsTro.Add(new KeyValuePair<int, string>(0, "--Trọ--"));
            foreach (Tro i in list_tro)
            {
                dsTro.Add(new KeyValuePair<int, string>(i.ID_Tro, i.Ten));
                //cbTro1.Items.Add(i.Ten);
            }
            this.cbTro7.DataSource = dsTro;
            this.cbTro7.ValueMember = "Key";
            this.cbTro7.DisplayMember = "Value";
            this.cbTro7.SelectedIndex = 0;
        }
        #endregion
        #region khởi tạo combobox trạng thái phòng
        private void InitComboboxTrangThaiPhong7()
        {
            var trangThaiPhong = new BindingList<KeyValuePair<int, string>>();
            //cbTrangThaiPhong1.Items.Clear();
            trangThaiPhong.Add(new KeyValuePair<int, string>(0, "--Trạng thái phòng--"));
            trangThaiPhong.Add(new KeyValuePair<int, string>(1, "Đang cho thuê"));
            trangThaiPhong.Add(new KeyValuePair<int, string>(2, "Đã cho thuê"));
            trangThaiPhong.Add(new KeyValuePair<int, string>(3, "Sửa chữa"));
            this.cbTrangThaiPhong7.DataSource = trangThaiPhong;
            this.cbTrangThaiPhong7.ValueMember = "Key";
            this.cbTrangThaiPhong7.DisplayMember = "Value";
            this.cbTrangThaiPhong7.SelectedIndex = 0;
        }
        #endregion
        #region khởi tạo DataGridView danh sách các yêu cầu thuê phòng 
        private void InitDataGridView7()
        {
            List<PhongTro> list_pt = new List<PhongTro>();
            List<Tro> list_tro = new List<Tro>();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            List<PhongTro> tmp = new List<PhongTro>();
            foreach (Tro tro in list_tro)
            {
                tmp = bus_pt.GetPhongTroByID_Tro(tro.ID_Tro);
                list_pt.AddRange(tmp);
            }
            List<DuyetThuePhong> list_dtp = new List<DuyetThuePhong>();
            List<DuyetThuePhong> list = new List<DuyetThuePhong>();
            BUS_DuyetThuePhong bus_dtp = new BUS_DuyetThuePhong();
            // xóa những duyệt thuê phòng quá hạn mà không có khách hàng nào yêu cầu
            bus_dtp.DeleteDuyetThuePhong();
            // lấy danh sách yêu cầu
            foreach (PhongTro i in list_pt)
            {
                list = bus_dtp.GetDuyetThuePhongByID_Phong(i.ID_PhongTro);
                list_dtp.AddRange(list);
            }
            dataGridViewDuyetThuePhong.DataSource = list_dtp;
        }
        #endregion
        private void cbTro7_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dspTro = new BindingList<KeyValuePair<int, string>>();
            dspTro.Add(new KeyValuePair<int, string>(0, "--Phòng trọ--"));
            if (Convert.ToInt32(cbTro7.SelectedValue) > 0)
            {
                int id_tro = Convert.ToInt32(cbTro7.SelectedValue);
                List<PhongTro> list = new List<PhongTro>();
                BUS_PhongTro bus = new BUS_PhongTro();
                list = bus.GetPhongTroByID_Tro(id_tro);
                foreach (PhongTro i in list)
                {
                    dspTro.Add(new KeyValuePair<int, string>(i.ID_PhongTro, i.Ten));
                    //cbTro1.Items.Add(i.Ten);
                }
            }
            this.cbPhong7.DataSource = dspTro;
            this.cbPhong7.ValueMember = "Key";
            this.cbPhong7.DisplayMember = "Value";
            this.cbPhong7.SelectedIndex = 0;
            this.cbPhong7.Enabled = true;
        }

        private void btnSearch7_Click(object sender, EventArgs e)
        {

        }

        private void btnKhongDuyet7_Click(object sender, EventArgs e)
        {
            // chỉnh sửa duyệt thuê phòng (thời gian trả phòng), hóa đơn(thanh toán tháng cuối), phòng trọ(id_khachhang, so nguoi o), khách hàng (id_phong)
            // kiểm tra phòng trọ còn tháng nợ hay không, thu tiênf nếu có nợ
            foreach (DataGridViewRow i in dataGridViewDuyetThuePhong.SelectedRows)
            {
                ID_khachhang = Convert.ToInt32(i.Cells["ID_KhachHang"].ToString());
            }
            int id_khachhang = ID_khachhang;
            MessageBox.Show("Hãy chắc chắn bạn đã tạo hóa đơn tháng này trước khi khách hàng trả phòng, mọi hóa đơn sẽ được tự động chuyển sang trạng thái 'Đã thanh toán' sau khi trả phòng.");

            List<KhachHang> list = new List<KhachHang>();
            BUS_KhachHang bus = new BUS_KhachHang();
            list = bus.GetKhachHangByID_KhachHang(id_khachhang);    // thông tin khách hàng
            List<PhongTro> list_pt = new List<PhongTro>();
            BUS_PhongTro bus_pt = new BUS_PhongTro();
            list_pt = bus_pt.GetPhongTroByID_PhongTro(list[0].ID_PhongTro); // thông tin phòng trọ
            List<HoaDon> list_hd = new List<HoaDon>();
            BUS_HoaDon bus_hd = new BUS_HoaDon();
            list_hd = bus_hd.GetHoaDonByID_PhongTro(list_pt[0].ID_PhongTro); // thông tin các hóa đơn
            List<DuyetThuePhong> list_dtp = new List<DuyetThuePhong>();
            BUS_DuyetThuePhong bus_dtp = new BUS_DuyetThuePhong();
            list_dtp = bus_dtp.GetRecentDuyetThuePhongByID_KhachHang(id_khachhang);  // thông tin duyệt thuê phòng

            bus.UpDateID_PhongTro(list[0]);                                                 // xóa id phòng
            int stn = (list_pt[0].SoNguoiO == 1) ? 0 : (list_pt[0].SoThangNo);
            //MessageBox.Show(stn.ToString() + ", " + (list_pt[0].SoNguoiO - 1).ToString());
            bus_pt.UpdateSoNguoiO(list_pt[0].ID_PhongTro, stn, list_pt[0].SoNguoiO - 1);  //  số người -1
            int TongTienThanhToan = 0;
            if (list_pt[0].SoNguoiO == 1 && list_pt[0].SoThangNo == 1)                    // hoàn thành đóng tiền nếu như tất cả trả phòng
            {
                foreach (HoaDon i in list_hd)
                {
                    if (i.TrangThai == "Chưa thanh toán")
                    {
                        TongTienThanhToan += TinhTien(list_pt[0].TienPhong, list_pt[0].GiaDien, list_pt[0].GiaNuoc,
                                                    i.SoDienMoi - i.SoDienCu, i.SoNuocMoi - i.SoNuocCu);
                    }
                    bus_hd.UpdateHoaDon(i.ID_HoaDon);   // cập nhật trạng thái đã thanh toán cho các hóa đơn
                }
                MessageBox.Show("Số tiền được khách thuê trả là " + TongTienThanhToan.ToString());
            }
            list_dtp[0].ThoiGianTraPhong = DateTime.Now;
            bus_dtp.UpdateDuyetThuePhong(list_dtp[0]);                             // gán thời gian trả phòng

            ChuTro_MainForm_Load(sender, e);
        }
        #endregion

        #region tab8: quản lí trọ - thêm, cập nhật, xóa trọ/ phòng trọ
        #region khóa các textbox
        private void InitLockTextbox8()
        {
            // trọ
            txtDiaChi8.Enabled = false;
            // phòng trọ
            cbPhong8.Enabled = false;
            txtTrangThaiPhong8.Enabled = false;
            txtSoNguoiThue8.Enabled = false;
            txtSoNguoiToiDa8.Enabled = false;
            txtTienPhong8.Enabled = false;
            txtGiaDien8.Enabled = false;
            txtGiaNuoc8.Enabled = false;
        }
        #endregion
        #region khởi tạo combobox danh sách trọ (2 combobox)
        private void InitComboboxTimKiemTro8()
        {
            List<Tro> list_tro = new List<Tro>();
            BUS_Tro bus_tro = new BUS_Tro();
            list_tro = bus_tro.GetTroByID_ChuTro(ID_chutro);
            var dsTro = new BindingList<KeyValuePair<int, string>>();
            dsTro.Add(new KeyValuePair<int, string>(0, "--Trọ--"));
            foreach (Tro i in list_tro)
            {
                dsTro.Add(new KeyValuePair<int, string>(i.ID_Tro, i.Ten));
                //cbTro1.Items.Add(i.Ten);
            }
            this.cbTro81.DataSource = dsTro;
            this.cbTro81.ValueMember = "Key";
            this.cbTro81.DisplayMember = "Value";
            this.cbTro81.SelectedIndex = 0;
            this.cbTro82.DataSource = dsTro;
            this.cbTro82.ValueMember = "Key";
            this.cbTro82.DisplayMember = "Value";
            this.cbTro82.SelectedIndex = 0;
        }




        #endregion

        #endregion


    }

}
