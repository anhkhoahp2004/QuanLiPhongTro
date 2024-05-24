namespace GUI_QLPT
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbQuyen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelDangKy = new System.Windows.Forms.Label();
            this.checkBoxGhiNho = new System.Windows.Forms.CheckBox();
            this.btHuy = new System.Windows.Forms.Button();
            this.btDangNhap = new System.Windows.Forms.Button();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.labMatKhau = new System.Windows.Forms.Label();
            this.labUsername = new System.Windows.Forms.Label();
            this.labDangNhap = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbQuyen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelDangKy);
            this.panel1.Controls.Add(this.checkBoxGhiNho);
            this.panel1.Controls.Add(this.btHuy);
            this.panel1.Controls.Add(this.btDangNhap);
            this.panel1.Controls.Add(this.txtPassWord);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.labMatKhau);
            this.panel1.Controls.Add(this.labUsername);
            this.panel1.Location = new System.Drawing.Point(71, 60);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 300);
            this.panel1.TabIndex = 5;
            // 
            // cbQuyen
            // 
            this.cbQuyen.FormattingEnabled = true;
            this.cbQuyen.Location = new System.Drawing.Point(212, 138);
            this.cbQuyen.Name = "cbQuyen";
            this.cbQuyen.Size = new System.Drawing.Size(241, 24);
            this.cbQuyen.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Quyền";
            // 
            // labelDangKy
            // 
            this.labelDangKy.AutoSize = true;
            this.labelDangKy.Location = new System.Drawing.Point(141, 275);
            this.labelDangKy.Name = "labelDangKy";
            this.labelDangKy.Size = new System.Drawing.Size(214, 16);
            this.labelDangKy.TabIndex = 7;
            this.labelDangKy.Text = "Chưa có tài khoản?  Đăng kí tại đây";
            this.labelDangKy.Click += new System.EventHandler(this.labelDangKy_Click);
            // 
            // checkBoxGhiNho
            // 
            this.checkBoxGhiNho.AutoSize = true;
            this.checkBoxGhiNho.Location = new System.Drawing.Point(187, 177);
            this.checkBoxGhiNho.Name = "checkBoxGhiNho";
            this.checkBoxGhiNho.Size = new System.Drawing.Size(131, 20);
            this.checkBoxGhiNho.TabIndex = 6;
            this.checkBoxGhiNho.Text = "Ghi nhớ tài khoản";
            this.checkBoxGhiNho.UseVisualStyleBackColor = true;
            // 
            // btHuy
            // 
            this.btHuy.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHuy.Location = new System.Drawing.Point(288, 213);
            this.btHuy.Margin = new System.Windows.Forms.Padding(4);
            this.btHuy.Name = "btHuy";
            this.btHuy.Size = new System.Drawing.Size(123, 31);
            this.btHuy.TabIndex = 5;
            this.btHuy.Text = "Hủy";
            this.btHuy.UseVisualStyleBackColor = true;
            this.btHuy.Click += new System.EventHandler(this.btHuy_Click);
            // 
            // btDangNhap
            // 
            this.btDangNhap.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDangNhap.Location = new System.Drawing.Point(96, 213);
            this.btDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.btDangNhap.Name = "btDangNhap";
            this.btDangNhap.Size = new System.Drawing.Size(125, 31);
            this.btDangNhap.TabIndex = 4;
            this.btDangNhap.Text = "Đăng nhập";
            this.btDangNhap.UseVisualStyleBackColor = true;
            this.btDangNhap.Click += new System.EventHandler(this.btDangNhap_Click);
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(212, 88);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(241, 22);
            this.txtPassWord.TabIndex = 3;
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(212, 39);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(241, 22);
            this.txtUserName.TabIndex = 2;
            // 
            // labMatKhau
            // 
            this.labMatKhau.AutoSize = true;
            this.labMatKhau.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMatKhau.Location = new System.Drawing.Point(70, 88);
            this.labMatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labMatKhau.Name = "labMatKhau";
            this.labMatKhau.Size = new System.Drawing.Size(71, 19);
            this.labMatKhau.TabIndex = 1;
            this.labMatKhau.Text = "Mật khẩu";
            // 
            // labUsername
            // 
            this.labUsername.AutoSize = true;
            this.labUsername.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUsername.Location = new System.Drawing.Point(70, 39);
            this.labUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUsername.Name = "labUsername";
            this.labUsername.Size = new System.Drawing.Size(105, 19);
            this.labUsername.TabIndex = 0;
            this.labUsername.Text = "Tên đăng nhập";
            // 
            // labDangNhap
            // 
            this.labDangNhap.AutoSize = true;
            this.labDangNhap.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDangNhap.Location = new System.Drawing.Point(252, 23);
            this.labDangNhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDangNhap.Name = "labDangNhap";
            this.labDangNhap.Size = new System.Drawing.Size(153, 32);
            this.labDangNhap.TabIndex = 4;
            this.labDangNhap.Text = "Đăng nhập";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 383);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labDangNhap);
            this.Name = "Login";
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxGhiNho;
        private System.Windows.Forms.Button btHuy;
        private System.Windows.Forms.Button btDangNhap;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label labMatKhau;
        private System.Windows.Forms.Label labUsername;
        private System.Windows.Forms.Label labDangNhap;
        private System.Windows.Forms.Label labelDangKy;
        private System.Windows.Forms.ComboBox cbQuyen;
        private System.Windows.Forms.Label label2;
    }
}