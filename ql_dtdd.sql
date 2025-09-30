create database ql_dtdd
go
use ql_dtdd
go

DROP TABLE GioHang;
DROP TABLE SanPham;
DROP TABLE KhachHang;
DROP TABLE Loai;

create table loai
(
	maloai int,
	tenloai nvarchar(50)
	primary key(maloai)
)

create table sanpham
(
	masp int,
	tensp nvarchar(50),
	duongdan nvarchar(200),
	gia float,
	mota nvarchar(500),
	maloai int,
	primary key(masp),
	foreign key(maloai) references loai(maloai)
)

create table khachhang
(
	makh int,
	hoten nvarchar(50),
	dienthoai varchar(15),
	gioitinh nvarchar(3),
	sothich nvarchar(200),
	email varchar(50),
	matkhau varchar(50)
	primary key(makh)
)


create table giohang
(
	magh int,
	makh int,
	masp int,
	soluong int,
	ngay date
	primary key(magh),
	foreign key(masp) references sanpham(masp),
	foreign key(makh) references khachhang(makh)
)

INSERT INTO Loai (MaLoai, TenLoai) VALUES 
(1, N'Nokia'),
(2, N'SamSung'),
(3, N'Motorola'),
(4, N'LG'),
(5, N'Oppo'),
(6, N'Iphone'),
(7, N'BPhone');

INSERT INTO SanPham (MaSP, TenSP, DuongDan, Gia, MoTa, MaLoai) VALUES 
(1, N'N701', N'1.jpg', 2000000, N'Nâng cấp BN', 1),
(2, N'N72', N'2.jpg', 2100000, N'Nâng cấp BN, 2 màu Đen, Xám', 1),
(3, N'N6030', N'3.jpg', 3000000, N'Nâng cấp BN, Gập', 1),
(4, N'N6200', N'4.jpg', 3200000, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 1),
(5, N'GalaxyA6', N'5.jpg', 5200000, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 2),
(6, N'GalaxyA9', N'6.jpg', 5500000, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 2),
(7, N'GalaxyJ5', N'7.jpg', 6000000, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 2),
(8, N'MotoE5', N'8.jpg', 2300000, N'Unlimited Extra', 3),
(9, N'MotoG7', N'9.jpg', 8000000, N'Unlimited Extra', 3),
(10, N'MotoP30', N'10.jpg', 7900000, N'Unlimited Extra', 3),
(11, N'Iphone4S', N'11.jpg', 3000000, N'Không nâng cấp', 6),
(12, N'Iphone5S', N'12.jpg', 5000000, N'Không nâng cấp', 6),
(13, N'Iphone6p', N'13.jpg', 10000000, N'Không nâng cấp', 6),
(14, N'Iphone7', N'14.jpg', 15000000, N'Không nâng cấp', 6),
(15, N'Iphone8p', N'15.jpg', 20000000, N'Không nâng cấp', 6);

select maloai, tenloai from loai