create database QL_DTDD1
use QL_DTDD1
CREATE TABLE Loai (
    MaLoai INT PRIMARY KEY,
    TenLoai NVARCHAR(50)
);

INSERT INTO Loai (MaLoai, TenLoai) VALUES
(1, N'Nokia'),
(2, N'SamSung'),
(3, N'Motorola'),
(4, N'LG'),
(5, N'Oppo'),
(6, N'iPhone'),
(7, N'BPhone');
CREATE TABLE SanPham (
    MaSP INT not null PRIMARY KEY,
    TenSP NVARCHAR(100),
    DuongDan NVARCHAR(255),
    Gia DECIMAL(12, 2),
    MoTa NVARCHAR(255),
	MaLoai int,
	constraint fk_sanpham_loai foreign key(MaLoai) references loai(MaLoai)
);
delete from SanPham
INSERT INTO SanPham VALUES
(1, N'N701', N'N701.jpg', 2000000, N'Nâng cấp BN', 1),
(2, N'N72', N'N72.jpg', 2100000, N'Nâng cấp BN, 2 màu Đen, Xám', 1),
(3, N'N6030', N'N6030.jpg', 3000000, N'Nâng cấp BN, Gấp', 1),
(4, N'N6200', N'N6200.jpg', 3200000, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 1),
(5, N'GalaxyA6', N'GalaxyA6.jpg', 5200000, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 2),
(6, N'GalaxyA9', N'GalaxyA9.jpg', 5500000, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 2),
(7, N'GalaxyJ5', N'GalaxyJ5.jpg', 6000000, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 2),
(16, N'MotoE5', N'MotoE5.jpg', 2300000, N'Unlimited Extra', 3),
(17, N'MotoG7', N'MotoG7.jpg', 8000000, N'Unlimited Extra', 3),
(18, N'MotoP30', N'MotoP30.jpg', 7900000, N'Unlimited Extra', 3);

INSERT INTO SanPham (MaSP, TenSP, DuongDan, Gia, MoTa, MaLoai) VALUES
(24, N'iPhone4S', N'iPhone4S.jpg', 3000000, N'Không nâng cấp', 6),
(25, N'iPhone5S', N'iPhone5S.jpg', 5000000, N'Không nâng cấp', 6),
(26, N'iPhone6p', N'iPhone6p.jpg', 10000000, N'Không nâng cấp', 6),
(27, N'iPhone7', N'iPhone7.jpg', 15000000, N'Không nâng cấp', 6),
(28, N'iPhone8p', N'iPhone8p.jpg', 20000000, N'Không nâng cấp', 6);

CREATE TABLE KhachHang (
    MaKH INT PRIMARY KEY,
    HoTen NVARCHAR(100),
    DienThoai NVARCHAR(15),
    GioiTinh NVARCHAR(10),
    SoThich NVARCHAR(100),
    Email NVARCHAR(100),
    MatKhau NVARCHAR(100)
);

INSERT INTO KhachHang (MaKH, HoTen, DienThoai, GioiTinh, SoThich, Email, MatKhau) VALUES
(1, N'Nguyen Van A', N'0901234567', N'Nam', N'Đọc sách', N'nva@example.com', N'pass123'),
(2, N'Tran Thi B', N'0912345678', N'Nữ', N'Xem phim', N'ttb@example.com', N'pass456'),
(3, N'Le Van C', N'0923456789', N'Nam', N'Chơi game', N'lvc@example.com', N'pass789');

CREATE TABLE GioHang (
    MaGH INT PRIMARY KEY,
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH),
    MaSP INT,
    SoLuong INT,
    Ngay DATE
);

INSERT INTO GioHang (MaGH, MaKH, MaSP, SoLuong, Ngay) VALUES
(1, 1, 24, 2, '2025-09-27'),
(2, 2, 25, 1, '2025-09-27'),
(3, 3, 26, 3, '2025-09-27');