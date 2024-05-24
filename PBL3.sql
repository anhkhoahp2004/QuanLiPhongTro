use PBL3;

/* tài khoản */
create table TaiKhoan
(
	ID_TaiKhoan int not null,
	Username nvarchar(MAX),
	Passwrd nvarchar(MAX), /*thiếu o*/
	ID_Quyen int not null, /*thêm ID_Quyen: 0 - Chủ trọ, 1 - Khách hàng*/
	Quyen nvarchar(MAX) not null,
	DelFlg int,
	FlagInsert int
	CONSTRAINT KhoaChinh PRIMARY KEY (ID_TaiKhoan, ID_Quyen)
)
go

/*chủ trọ*/
create table ChuTro
(
	ID_ChuTro int identity(1, 1) primary key not null,
	Ten nvarchar(MAX),
	SDT nvarchar(MAX),
	DiaChi nvarchar(MAX),
	CCCD nvarchar(MAX),
	Email nvarchar(MAX),
	DelFlg int, 
	FlagInsert int
)
go

/*trọ*/
create table Tro
(
	ID_Tro int identity(1, 1) primary key not null,
	ID_ChuTro int foreign key references dbo.ChuTro(ID_ChuTro) not null,
	Ten nvarchar(MAX),
	DiaChi nvarchar(MAX),
	DelFlg int,
	FlagInsert int
)
go
/*Phòng trọ*/
create table PhongTro
(
	ID_PhongTro int identity(1, 1) primary key not null,
	Ten nvarchar(MAX),
	ID_Tro int foreign key references dbo.Tro(ID_Tro) not null,
	TienPhong int,
	GiaDien int,
	GiaNuoc int,
	SoNguoiToiDa int,
	SoNguoiO int,
	TrangThaiPhong nvarchar(MAX),
	SoThangNo int,
	DelFlg int,
	FlagInsert int
)
go
/*khách hàng*/
create table KhachHang
(
	ID_KhachHang int identity(1, 1) primary key not null,
	Ten nvarchar(MAX),
	CCCD nvarchar(MAX),
	SDT nvarchar(MAX),
	Email nvarchar(MAX),
	NgheNghiep nvarchar(MAX),
	ID_PhongTro int foreign key references dbo.PhongTro(ID_PhongTro),
	DelFlg int, 
	FlagInsert int
)
go

/*duyệt thuê phòng*/
 create table DuyetThuePhong
 (
	ID_DuyetThuePhong int identity(1, 1) primary key not null,
	ID_PhongTro int foreign key references dbo.PhongTro(ID_PhongTro) not null,
	ID_KhachHang int foreign key references dbo.KhachHang(ID_KhachHang) not null,
	MaXacNhan int,
	ThoiGianKichHoat DateTime,
	ThoiGianXacNhan DateTime,
	ThoiGianTraPhong DateTIme,
	DelFlg int, 
	FlagInsert int
 )
 go

 /*hóa đơn*/
 create table HoaDon
 (
	ID_HoaDon int identity(1, 1) primary key not null,
	ID_PhongTro int foreign key references dbo.PhongTro(ID_PhongTro) not null,
	SoDienCu int,
	SoNuocCu int,
	SoDienMoi int,
	SoNuocMoi int,
	ThanhTien int,
	NgayBatDau DateTime,
	NgayKetThuc DateTime,
	TrangThai nvarchar(MAX),
	DelFlg int, 
	FlagInsert int
 )
 go

 /*insert*/
 use PBL3;
 insert into dbo.TaiKhoan values
 ('1', 'vananguyen', '123456@abc', '0', N'Chủ trọ', '0', '0'),
 ('2', 'vanbnguyen', '123456@abc', '0', N'Chủ trọ', '0', '0'),
 ('3', 'vancnguyen', '123456@abc', '0', N'Chủ trọ', '0', '0'),
 ('4', 'vandnguyen', '123456@abc', '0', N'Chủ trọ', '0', '0'),
 ('1', 'vanatran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('2', 'vanbtran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('3', 'vanctran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('4', 'vandtran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('5', 'vanetran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('6', 'vanftran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('7', 'vangtran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('8', 'vanhtran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('9', 'vanitran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('10', 'vanktran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('11', 'vanltran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('12', 'vanmtran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('13', 'vanntran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('14', 'vanotran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('15', 'vanptran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('16', 'vanqtran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('17', 'vanrtran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('18', 'vanstran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('19', 'vanttran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('20', 'vanutran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('21', 'vanvtran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('22', 'vanwtran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('23', 'vanxtran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('24', 'vanytran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('25', 'vanztran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('26', 'vanaatran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('27', 'vanabtran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('28', 'vanactran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('29', 'vanadtran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('30', 'vanaetran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('31', 'vanaftran', '123456@abc', '1', N'Khách hàng', '0', '0'),
 ('32', 'vanagtran', '123456@abc', '1', N'Khách hàng', '0', '0')
 use PBL3;
 insert into dbo.ChuTro values
 (N'Nguyễn Văn A', '0987582635', N'192/38 Nguyễn Lương Bằng', '042078000446', 'vana@example.com', '0', '0'),
 (N'Nguyễn Văn B', '0987456852', N'24 Âu Cơ', '043182003521', 'vanb@example.com', '0', '0'),
 (N'Nguyễn Văn C', '0987123456', N'512 Tôn Đức Thắng', '043082002514', 'vanc@example.com', '0', '0'),
 (N'Nguyễn Văn D', '0987784512', N'84 Nguyễn Lương Bằng', '042074001202', 'vand@example.com', '0', '0')
 insert into dbo.Tro values
 ('1', N'192/41 Nguyễn Lương Bằng', N'192/41 Nguyễn Lương Bằng', '0', '0'),
 ('1', N'192/86 Nguyễn Lương Bằng', N'192/86 Nguyễn Lương Bằng', '0', '0'),
 ('2', N'24 Âu Cơ', N'24 Âu Cơ', '0', '0'),
 ('3', N'512 Tôn Đức Thắng', N'512 Tôn Đức Thắng', '0', '0'),
 ('4', N'85 Nguyễn Lương Bằng', N'85 Nguyễn Lương Bằng', '0', '0')

 insert into dbo.PhongTro values
 /*trọ 1*/
 ('101', '1', '1500000', '3500', '20000', '3', '3', N'Đang cho thuê', '0', '0', '0'),
 ('102', '1', '1500000', '3500', '20000', '3', '3', N'Đang cho thuê', '0', '0', '0'),
 ('103', '1', '1500000', '3500', '20000', '3', '3', N'Đang cho thuê', '0', '0', '0'),
 ('104', '1', '1500000', '3500', '20000', '3', '3', N'Đang cho thuê', '0', '0', '0'),
 ('105', '1', '1500000', '3500', '20000', '3', '3', N'Đang cho thuê', '0', '0', '0'),
 ('106', '1', '1500000', '3500', '20000', '3', '3', N'Đang cho thuê', '0', '0', '0'),
 ('107', '1', '1500000', '3500', '20000', '3', '2', N'Đang cho thuê', '0', '0', '0'),
 ('108', '1', '1500000', '3500', '20000', '3', '2', N'Đang cho thuê', '1', '0', '0'),
 ('109', '1', '1500000', '3500', '20000', '3', '1', N'Đang cho thuê', '1', '0', '0'),
 ('110', '1', '1500000', '3500', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 /*trọ 2*/
 ('101', '2', '1500000', '3500', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('102', '2', '1500000', '3500', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('103', '2', '1500000', '3500', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('201', '2', '1500000', '3500', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('202', '2', '1500000', '3500', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('203', '2', '1500000', '3500', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('301', '2', '1500000', '3500', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('302', '2', '1500000', '3500', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('303', '2', '1500000', '3500', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 /*trọ 3*/
 ('101', '3', '1200000', '4000', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('102', '3', '1200000', '4000', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('103', '3', '1200000', '4000', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('201', '3', '1200000', '4000', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('202', '3', '1200000', '4000', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('203', '3', '1200000', '4000', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('301', '3', '1200000', '4000', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('302', '3', '1200000', '4000', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('303', '3', '1200000', '4000', '20000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 /*trọ 4*/
 ('101', '4', '1700000', '3500', '15000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('102', '4', '1700000', '3500', '15000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('103', '4', '1700000', '3500', '15000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('201', '4', '1700000', '3500', '15000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('202', '4', '1700000', '3500', '15000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('203', '4', '1700000', '3500', '15000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('301', '4', '1700000', '3500', '15000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('302', '4', '1700000', '3500', '15000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 ('303', '4', '1700000', '3500', '15000', '3', '0', N'Đang cho thuê', '0', '0', '0'),
 /*trọ 5*/
 ('101', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('102', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('103', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('104', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('105', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('106', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('107', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('108', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('201', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('202', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('203', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('204', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('205', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('206', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('207', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0'),
 ('208', '5', '1000000', '4000', '20000', '2', '0', N'Đang cho thuê', '0', '0', '0')
 insert into dbo.KhachHang values 
 (N'Trần Văn A', '040204006666', '0987458693', 'vana@test.com', N'Sinh viên', '1', '0', '0'), /*#1*/
 (N'Trần Văn B', '040204006667', '0987458694', 'vanb@test.com', N'Sinh viên', '1', '0', '0'),
 (N'Trần Văn E', '040204006670', '0987458697', 'vane@test.com', N'Sinh viên', '1', '0', '0'),
 (N'Trần Văn F', '040204006671', '0987458698', 'vanf@test.com', N'Sinh viên', '2', '0', '0'),
 (N'Trần Văn G', '040204006672', '0987458699', 'vang@test.com', N'Sinh viên', '2', '0', '0'),
 (N'Trần Văn H', '040204006673', '0987458700', 'vanh@test.com', N'Sinh viên', '2', '0', '0'),
 (N'Trần Văn I', '040204006674', '0987458701', 'vani@test.com', N'Sinh viên', '3', '0', '0'),
 (N'Trần Văn K', '040204006675', '0987458702', 'vank@test.com', N'Sinh viên', '3', '0', '0'),
 (N'Trần Văn L', '040204006676', '0987458703', 'vanl@test.com', N'Sinh viên', '3', '0', '0'),
 (N'Trần Văn M', '040204006677', '0987458704', 'vanm@test.com', N'Sinh viên', '4', '0', '0'),
 (N'Trần Văn N', '040204006678', '0987458705', 'vann@test.com', N'Sinh viên', '4', '0', '0'),
 (N'Trần Văn O', '040204006679', '0987458706', 'vano@test.com', N'Sinh viên', '4', '0', '0'),
 (N'Trần Văn P', '040204006680', '0987458707', 'vanp@test.com', N'Sinh viên', '5', '0', '0'),
 (N'Trần Văn Q', '040204006681', '0987458708', 'vanq@test.com', N'Sinh viên', '5', '0', '0'),
 (N'Trần Văn R', '040204006682', '0987458709', 'vanr@test.com', N'Sinh viên', '5', '0', '0'),
 (N'Trần Văn S', '040204006683', '0987458710', 'vans@test.com', N'Sinh viên', '6', '0', '0'),
 (N'Trần Văn T', '040204006684', '0987458711', 'vant@test.com', N'Sinh viên', '6', '0', '0'),
 (N'Trần Văn U', '040204006685', '0987458712', 'vanu@test.com', N'Sinh viên', '6', '0', '0'),
 (N'Trần Văn V', '040204006686', '0987458713', 'vanv@test.com', N'Sinh viên', '7', '0', '0'),
 (N'Trần Văn W', '040204006687', '0987458714', 'vanw@test.com', N'Sinh viên', '7', '0', '0'),
 (N'Trần Văn X', '040204006688', '0987458715', 'vanx@test.com', N'Sinh viên', '8', '0', '0'),
 (N'Trần Văn Y', '040204006689', '0987458716', 'vany@test.com', N'Sinh viên', '8', '0', '0'),
 (N'Trần Văn Z', '040204006690', '0987458717', 'vanz@test.com', N'Sinh viên', '9', '0', '0'),
 (N'Trần Văn AA', '040204006691', '0987458718', 'vanaa@test.com', N'Sinh viên', null, '0', '0'),
 (N'Trần Văn AB', '040204006692', '0987458719', 'vanab@test.com', N'Sinh viên', null, '0', '0'),
 (N'Trần Văn AC', '040204006693', '0987458720', 'vanac@test.com', N'Sinh viên', null, '0', '0'),
 (N'Trần Văn AD', '040204006694', '0987458721', 'vanad@test.com', N'Sinh viên', null, '0', '0'),
 (N'Trần Văn AE', '040204006695', '0987458722', 'vanae@test.com', N'Sinh viên', null, '0', '0'),
 (N'Trần Văn AF', '040204006696', '0987458723', 'vanaf@test.com', N'Sinh viên', null, '0', '0'),
 (N'Trần Văn AG', '040204006697', '0987458724', 'vanag@test.com', N'Sinh viên', null, '0', '0')  /*#32*/

insert into DuyetThuePhong values
('1', '1', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('1', '2', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('1', '3', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('2', '4', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('2', '5', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('2', '6', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('3', '7', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('3', '8', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('3', '9', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('4', '10', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('4', '11', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('4', '12', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('5', '13', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('5', '14', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('5', '15', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('6', '16', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('6', '17', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('6', '18', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('7', '19', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('7', '20', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('8', '21', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('8', '22', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0'),
('9', '23', null, '2024-01-15 15:30:00', '2024-01-15 16:00:00', null, '0', '0')

 insert into HoaDon values
 /*1*/
 ('1', '0', '0', '30', '4', '1685000', '2024-01-15 19:30:00', '2024-02-15 15:30:00', N'Đã thanh toán', '0', '0'),
 ('1', '30', '4', '60', '8', '1685000', '2024-02-15 15:30:00', '2024-03-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('1', '60', '8', '90', '12', '1685000', '2024-03-15 19:30:00', '2024-04-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('1', '90', '12', '120', '16', '1685000', '2024-04-15 19:30:00', '2024-05-13 15:30:00', N'Đã thanh toán', '0', '0'),
 /*2*/
 ('2', '0', '0', '30', '4', '1685000', '2024-01-15 19:30:00', '2024-02-15 15:30:00', N'Đã thanh toán', '0', '0'),
 ('2', '30', '4', '60', '8', '1685000', '2024-02-15 15:30:00', '2024-03-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('2', '60', '8', '90', '12', '1685000', '2024-03-15 19:30:00', '2024-04-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('2', '90', '12', '120', '16', '1685000', '2024-04-15 19:30:00', '2024-05-13 15:30:00', N'Đã thanh toán', '0', '0'),
 /*3*/
 ('3', '0', '0', '30', '4', '1685000', '2024-01-15 19:30:00', '2024-02-15 15:30:00', N'Đã thanh toán', '0', '0'),
 ('3', '30', '4', '60', '8', '1685000', '2024-02-15 15:30:00', '2024-03-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('3', '60', '8', '90', '12', '1685000', '2024-03-15 19:30:00', '2024-04-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('3', '90', '12', '120', '16', '1685000', '2024-04-15 19:30:00', '2024-05-13 15:30:00', N'Đã thanh toán', '0', '0'),
 /*4*/
 ('4', '0', '0', '30', '4', '1685000', '2024-01-15 19:30:00', '2024-02-15 15:30:00', N'Đã thanh toán', '0', '0'),
 ('4', '30', '4', '60', '8', '1685000', '2024-02-15 15:30:00', '2024-03-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('4', '60', '8', '90', '12', '1685000', '2024-03-15 19:30:00', '2024-04-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('4', '90', '12', '120', '16', '1685000', '2024-04-15 19:30:00', '2024-05-13 15:30:00', N'Đã thanh toán', '0', '0'),
 /*5*/
 ('5', '0', '0', '30', '4', '1685000', '2024-01-15 19:30:00', '2024-02-15 15:30:00', N'Đã thanh toán', '0', '0'),
 ('5', '30', '4', '60', '8', '1685000', '2024-02-15 15:30:00', '2024-03-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('5', '60', '8', '90', '12', '1685000', '2024-03-15 19:30:00', '2024-04-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('5', '90', '12', '120', '16', '1685000', '2024-04-15 19:30:00', '2024-05-13 15:30:00', N'Đã thanh toán', '0', '0'),
 /*6*/
 ('6', '0', '0', '30', '4', '1685000', '2024-01-15 19:30:00', '2024-02-15 15:30:00', N'Đã thanh toán', '0', '0'),
 ('6', '30', '4', '60', '8', '1685000', '2024-02-15 15:30:00', '2024-03-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('6', '60', '8', '90', '12', '1685000', '2024-03-15 19:30:00', '2024-04-15 19:30:00', N'Đã thanh toán', '0', '0'),
 /*7*/
 ('7', '0', '0', '30', '4', '1685000', '2024-01-15 19:30:00', '2024-02-15 15:30:00', N'Đã thanh toán', '0', '0'),
 ('7', '30', '4', '60', '8', '1685000', '2024-02-15 15:30:00', '2024-03-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('7', '60', '8', '90', '12', '1685000', '2024-03-15 19:30:00', '2024-04-15 19:30:00', N'Đã thanh toán', '0', '0'),
 /*8*/
 ('8', '0', '0', '30', '4', '1685000', '2024-01-15 19:30:00', '2024-02-15 15:30:00', N'Đã thanh toán', '0', '0'),
 ('8', '30', '4', '60', '8', '1685000', '2024-02-15 15:30:00', '2024-03-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('8', '60', '8', '90', '12', '1685000', '2024-03-15 19:30:00', '2024-04-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('8', '90', '12', '120', '16', '1685000', '2024-04-15 19:30:00', '2024-05-13 15:30:00', N'Chưa thanh toán', '0', '0'),
 /*9*/
 ('9', '0', '0', '30', '4', '1685000', '2024-01-15 19:30:00', '2024-02-15 15:30:00', N'Đã thanh toán', '0', '0'),
 ('9', '30', '4', '60', '8', '1685000', '2024-02-15 15:30:00', '2024-03-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('9', '60', '8', '90', '12', '1685000', '2024-03-15 19:30:00', '2024-04-15 19:30:00', N'Đã thanh toán', '0', '0'),
 ('9', '90', '12', '120', '16', '1685000', '2024-04-15 19:30:00', '2024-05-13 15:30:00', N'Chưa thanh toán', '0', '0')

 /*update*/
 use PBL3;
 update PhongTro set TrangThaiPhong = N'Có người' where ID_PhongTro < 10;
 update PhongTro set TrangThaiPhong = N'Sửa chữa' where ID_Tro = 4;
 update DuyetThuePhong set MaXacNhan = 0 where MaXacNhan = null;
 /*delete*/
 
 delete dbo.DuyetThuePhong;
 delete dbo.HoaDon;
 delete dbo.KhachHang;
 delete dbo.PhongTro;
 delete dbo.TaiKhoan;
 delete dbo.Tro;
 delete dbo.ChuTro;

 /*select*/
 use PBL3;
 select * from dbo.DuyetThuePhong;
 select * from dbo.HoaDon;
 select * from dbo.KhachHang;
 select * from dbo.PhongTro;
 select * from dbo.TaiKhoan;
 select * from dbo.Tro;
 select * from dbo.ChuTro;
  select * from TaiKhoan where DelFlg = 0 and Username = 'vanatran' and Passwrd = '123456@abc' and Quyen ='Khách hàng';