select * from TaiKhoan;
select * from PhongTro;

update DuyetThuePhong set ThoiGianTraPhong = 0 where ID_DuyetThuePhong = 23;
update KhachHang set ID_PhongTro = 9 where ID_KhachHang = 23;
update HoaDon set TrangThai = N'Chưa thanh toán' where ID_HoaDon = 34;
update PhongTro set SoNguoiO = 1, SoThangNo = 1 where ID_PhongTro = 9;

delete KhachHang where ID_KhachHang = 31;
delete HoaDon where ID_HoaDon > 34;
update PhongTro set SoThangNo = 0 where ID_PhongTro = 6;