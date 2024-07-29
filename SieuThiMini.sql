CREATE DATABASE SieuThiMini 
GO
USE SieuThiMini
GO	
--	Bảng tài khoản																	
CREATE TABLE TaiKhoan
(
	TaiKhoan VARCHAR(25) PRIMARY KEY,
	MatKhau VARCHAR(25),
	MaNV  VARCHAR(10)  UNIQUE
)
GO	
--Bảng Chức vụ
CREATE TABLE ChucVu
(
	MaCV VARCHAR(10) PRIMARY KEY,
	TenCV NVARCHAR(200)
)
GO	
--Bảng Nhân viên
CREATE TABLE NhanVien
(
	MaNV VARCHAR(10)  PRIMARY KEY,
	TenNV NVARCHAR(50),
	GioiTinh NVARCHAR(10),
	NamSinh DATE,
	SDT_NV VARCHAR(12),
	DiaChi_NV NVARCHAR(200),
	MaCV VARCHAR(10)
)
GO
--Bảng Khách hàng
CREATE TABLE KhachHang
(
	MaKH VARCHAR(10) PRIMARY KEY,
	TenKH NVARCHAR(50),
	SDT_KH VARCHAR(12),
	DiaChi_KH NVARCHAR(200)
)
GO
--Bảng nhà cung cấp
CREATE TABLE NhaCungCap
(
	MaNCC VARCHAR(10) PRIMARY KEY,
	TenNCC NVARCHAR(50),
	DiaChi_NCC NVARCHAR(200)
)
GO
--Bảng loại hàng hoá
CREATE TABLE LoaiHangHoa
(
	MaLoaiHH VARCHAR(10) PRIMARY KEY,
	TenLoaiHH NVARCHAR(200)
)
GO
--Bảng hàng hoá
CREATE TABLE HangHoa
(
	MaHH VARCHAR(10) PRIMARY KEY,
	TenHH NVARCHAR(200),
	DVT VARCHAR(50),
	GiaNhap FLOAT,
	GiaBan FLOAT,
	SoLuong FLOAT,
	MaloaiHH VARCHAR(10),
	MaNCC VARCHAR(10)
)
GO



--Bảng phiếu bán hàng
CREATE TABLE PhieuBanHang
(
	MaBanHang VARCHAR(20) PRIMARY KEY,
	MaNV VARCHAR(10),
	MaKH VARCHAR(10),
	NgayBH DATETIME,
	GhiChu NVARCHAR(200),
	TongTien FLOAT
) 
--Bảng chi tiết bán hàng
CREATE TABLE ChiTietBanHang
(
	MaBanHang VARCHAR(20),
	MaHH VARCHAR(10),
	GiaBan FLOAT,
	SoLuong FLOAT,
	ThanhTien FLOAT,
	PRIMARY KEY(MaBanHang,MaHH)
)

-- Ràng buộc khoá ngoại 
--Bảng Nhân viên
ALTER TABLE dbo.NhanVien
ADD CONSTRAINT Fk_NhanVien_ChucVu FOREIGN KEY(MaCV) REFERENCES dbo.ChucVu(MaCV)

--Bảng tài khoản
ALTER TABLE dbo.TaiKhoan
ADD CONSTRAINT Fk_TaiKhoan_NhanVien FOREIGN KEY(MaNV) REFERENCES dbo.NhanVien(MaNV)

--Bảng Hàng hoá
ALTER TABLE dbo.HangHoa
ADD CONSTRAINT Fk_HangHoa_LoaiHangHoa FOREIGN KEY(MaloaiHH) REFERENCES dbo.LoaiHangHoa(MaLoaiHH)

ALTER TABLE dbo.HangHoa
ADD CONSTRAINT Fk_HangHoa_NhaCungCap FOREIGN KEY(MaNCC) REFERENCES dbo.NhaCungCap(MaNCC)
--Bảng phiếu bán hàng

ALTER TABLE dbo.PhieuBanHang
ADD CONSTRAINT Fk_PhieuBanHang_NhanVien FOREIGN KEY(MaNV) REFERENCES dbo.NhanVien(MaNV)

ALTER TABLE dbo.PhieuBanHang
ADD CONSTRAINT Fk_PhieuBanHang_KhachHang FOREIGN KEY(MaKH) REFERENCES dbo.KhachHang(MaKH)
--Bảng Chi tiết bán hàng

ALTER TABLE dbo.ChiTietBanHang
ADD CONSTRAINT Fk_ChiTietBanHang_BanHang FOREIGN KEY (MaBanHang) REFERENCES dbo.PhieuBanHang(MaBanHang)

ALTER TABLE dbo.ChiTietBanHang
ADD CONSTRAINT Fk_PhieuBanHang_HangHoa FOREIGN KEY(MaHH) REFERENCES dbo.HangHoa(MaHH)


go
--Update số lượng hàng hoá sau khi bán
create trigger UpdateSLHH
on chitietbanhang
for insert
as
begin
	declare @mahh varchar(10)
	set @mahh =(select MaHH from inserted )
	declare @sl int 
	set @sl=(select SoLuong from inserted)
	update hanghoa
	set soluong=(soluong-@sl)
	where mahh=@mahh
end
go
--Cập nhật tổng tiền của bảng phiếu bán hàng
CREATE TRIGGER UpdateTongTien_BanHang
ON ChiTietBanHang
AFTER INSERT, UPDATE
AS
BEGIN
	declare @tongtien float
	SET @tongtien=(SELECT SUM(ThanhTien) FROM dbo.ChiTietBanHang WHERE MaBanHang=(SELECT MaBanHang FROM inserted))
    UPDATE dbo.PhieuBanHang
    SET TongTien =@tongtien
	WHERE MaBanHang=(SELECT MaBanHang FROM inserted)
END; 
go	
--Show report
CREATE PROCEDURE Show_Report
    @MaBanHang VARCHAR(20)
AS
BEGIN
    SELECT
        NV.TenNV AS TenNV,
        CBH.MaBanHang AS MaHD,
        KH.TenKH AS TenKH,
        CBH.NgayBH AS NgayBH,
        CBH.GhiChu AS GhiChu,
        CTH.MaHH AS MaHH,
        HH.TenHH AS TenHH,
        CTH.SoLuong,
        CTH.GiaBan,
        CTH.ThanhTien,
        CBH.TongTien
    FROM
        ChiTietBanHang CTH
    INNER JOIN
        PhieuBanHang CBH ON CTH.MaBanHang = CBH.MaBanHang
    INNER JOIN
        NhanVien NV ON CBH.MaNV = NV.MaNV
    INNER JOIN
        KhachHang KH ON CBH.MaKH = KH.MaKH
    INNER JOIN
        HangHoa HH ON CTH.MaHH = HH.MaHH
    WHERE
        CBH.MaBanHang = @MaBanHang;
END;
go

--Nhập liệu
-- Dữ liệu cho bảng ChucVu
INSERT INTO ChucVu (MaCV, TenCV)
VALUES
    ('CV01', N'Quản lý'),
    ('CV02', N'Nhân viên bán hàng');


-- Dữ liệu cho bảng NhanVien
INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, NamSinh, SDT_NV, DiaChi_NV,MaCV)
VALUES
    ('NV001', N'Nguyễn Văn A', N'Nam', '1990-01-15', '0123456789', N'123 Đường ABC, Quận 1, TP.HCM','CV01'),
    ('NV002', N'Nguyễn Thị B', N'Nữ', '1995-05-20', '0987654321', N'456 Đường XYZ, Quận 2, TP.HCM','CV02'),
    ('NV003', N'Trần Văn C', N'Nam', '1988-11-10', '0369852147', N'789 Đường DEF, Quận 3, TP.HCM','CV02'),
    ('NV004', N'Vũ Thị D', N'Nữ', '1993-07-25', '0912345678', N'321 Đường LMN, Quận 4, TP.HCM','CV02'),
    ('NV005', N'Hoàng Văn E', N'Nam', '1992-03-30', '0765432198', N'654 Đường XYZ, Quận 5, TP.HCM','CV02');
	--Dữ liệu cho bảng TaiKhoan
INSERT INTO TaiKhoan (TaiKhoan, MatKhau, MaNV)
VALUES
    ('123', '123', 'NV001'),
    ('111', '111', 'NV002'),
    ('user003', 'password003', 'NV003'),
    ('user004', 'password004', 'NV004'),
    ('user005', 'password005', 'NV005');
	
-- Dữ liệu cho bảng KhachHang
INSERT INTO KhachHang (MaKH, TenKH, SDT_KH, DiaChi_KH)
VALUES
    ('KH001', N'Nguyễn Văn X', '0123456789', N'123 Đường ABC, Quận 1, TP.HCM'),
    ('KH002', N'Nguyễn Thị Y', '0987654321', N'456 Đường XYZ, Quận 2, TP.HCM'),
    ('KH003', N'Trần Văn Z', '0369852147', N'789 Đường DEF, Quận 3, TP.HCM'),
    ('KH004', N'Vũ Thị M', '0912345678', N'321 Đường LMN, Quận 4, TP.HCM'),
    ('KH005', N'Hoàng Văn N', '0765432198', N'654 Đường XYZ, Quận 5, TP.HCM');

-- Dữ liệu cho bảng NhaCungCap
INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi_NCC)
VALUES
    ('NCC001', N'Công ty A', N'123 Đường ABC, Quận 1, TP.HCM'),
    ('NCC002', N'Công ty B', N'456 Đường XYZ, Quận 2, TP.HCM'),
    ('NCC003', N'Công ty C', N'789 Đường DEF, Quận 3, TP.HCM'),
    ('NCC004', N'Công ty D', N'321 Đường LMN, Quận 4, TP.HCM'),
    ('NCC005', N'Công ty E', N'654 Đường XYZ, Quận 5, TP.HCM');

-- Dữ liệu cho bảng LoaiHangHoa
INSERT INTO LoaiHangHoa (MaLoaiHH, TenLoaiHH)
VALUES
    ('LH001', N'Gia dụng'),
    ('LH002', N'Thực phẩm'),
    ('LH003', N'Chăm sóc sức khoẻ'),
    ('LH004', N'Đồ uống'),
    ('LH005', N'Sách vở'),
    ('LH006', N'Văn phòng phẩm');

-- Dữ liệu cho bảng HangHoa
INSERT INTO HangHoa (MaHH, TenHH, DVT, GiaNhap, GiaBan, SoLuong, MaloaiHH, MaNCC)
VALUES
	('HH001', N'Thịt  bò', N'Kg', 200000, 230000, 50, 'LH002', 'NCC002'),
    ('HH002', N'Thịt heo tươi', N'Kg', 100000, 130000, 50, 'LH002', 'NCC001'),
	('HH003', N'Gạo Sóc Trăng', N'Kg', 50000, 60000, 100, 'LH002', 'NCC003'),
    ('HH004', N'Cà phê rang xay', N'Gram', 120000, 150000, 30, 'LH004', 'NCC001'),
    ('HH005', N'Rau sạch', N'Bó', 30000, 45000, 80, 'LH004', 'NCC002'),
    ('HH006', N'Bánh mì sandwich', N'Cái', 15000, 25000, 120, 'LH002', 'NCC003'),
    ('HH007', N'Sữa tươi', N'Lon', 25000, 35000, 70, 'LH004', 'NCC001'),
    ('HH008', N'Mì gói', N'Gói', 8000, 12000, 200, 'LH002', 'NCC002'),
    ('HH009', N'Nước ngọc Cocacola', N'Chai', 10000, 15000, 150, 'LH004', 'NCC003'),
    ('HH010', N'Thịt gà ta', N'Kg', 90000, 120000, 40, 'LH001', 'NCC002'),
    ('HH011', N'Hạt điều rang muối', N'Gram', 60000, 80000, 60, 'LH002', 'NCC001'),
    ('HH013', N'Nước trái cây', N'Chai', 45000, 60000, 80, 'LH004', 'NCC002');


--Phiếu đổi trả
CREATE TABLE PhieuDoiTra
(
	MaPDT VARCHAR(10) PRIMARY KEY,
	NgayLap DATETIME,
	LyDoDoiTra NVARCHAR(500),
	MaKH VARCHAR(10),
	MaNV VARCHAR(10)
)
--Chi tiết đổi trả
CREATE TABLE ChiTietDoiTra
(
	MaPDT VARCHAR(10),
	MaSP VARCHAR(10),
	SoLuong INT
	PRIMARY KEY(MaPDT,MaSP)
)
GO
--Phiếu nhập hàng
CREATE TABLE PhieuNhapHang
(
	MaPNH VARCHAR(10),
	NgayLap DATETIME,
	ThanhTien FLOAT,
	MaNV VARCHAR(10)
	PRIMARY KEY(MaPNH)
)
--Chi tiết phiếu  nhập
CREATE TABLE ChiTietPhieuNhap
(
	MaPN VARCHAR(10),
	MaSP VARCHAR(10),
	DonGiaNhap FLOAT,
	SoLuong INT,
	PRIMARY KEY(MaPN,MaSP)
)
GO
--Phiếu giao hàng
CREATE TABLE PhieuGiaoHang
(
	MaPGH VARCHAR(10) PRIMARY KEY,
	NgayLap DATETIME,
	ThanhTien FLOAT,
	MaHD VARCHAR(10),
	MaNV VARCHAR(10)
)
GO
--Chi tiết phiếu giao
CREATE TABLE CHiTietPhieuGiaoHang
(
	MaPGH VARCHAR(10),
	MaSP VARCHAR(10),
	SoLuong INT,
	PRIMARY KEY(MaPGH,MaSP)
)
GO
----Khoá ngoại
--Phiếu đổi trả
ALTER TABLE dbo.PhieuDoiTra
ADD CONSTRAINT Fr_PhieuDoiTra_NhanVien FOREIGN KEY(MaNV) REFERENCES dbo.NhanVien(MaNV);
--Chi tiết đổi trả
		-----Phiếu đổi trả
ALTER TABLE dbo.ChiTietDoiTra
ADD CONSTRAINT Fr_ChiTietDoiTra_PhieuDoiTra FOREIGN KEY(MaPDT) REFERENCES dbo.PhieuDoiTra(MaPDT)
		----Sản phẩm
ALTER TABLE dbo.ChiTietDoiTra
ADD CONSTRAINT Fr_ChiTietDoiTra_SanPham FOREIGN KEY(MaSP) REFERENCES dbo.HangHoa(MaHH);
--Phiếu nhập hàng

ALTER TABLE dbo.PhieuNhapHang
ADD CONSTRAINT Fr_PhieuNhapHang_NhanVien FOREIGN KEY(MaNV) REFERENCES dbo.NhanVien(MaNV);
--Chi tiết Phiếu nhập hàng
ALTER TABLE dbo.ChiTietPhieuNhap
ADD CONSTRAINT Fr_ChiTietPhieuNhap_PhieuNhapHang FOREIGN KEY(MaPN) REFERENCES dbo.PhieuNhapHang(MaPNH);

ALTER TABLE dbo.ChiTietPhieuNhap
ADD CONSTRAINT Fr_ChiTietPhieuNhap_SanPham FOREIGN KEY(MaSP) REFERENCES dbo.HangHoa(MaHH);
--Phiếu giao hàng
ALTER TABLE dbo.PhieuGiaoHang
ADD CONSTRAINT Fr_PhieuGiaoHang_NhanVien FOREIGN KEY(MaNV) REFERENCES dbo.NhanVien(MaNV);
--Chi tiết phiếu giao hàng
ALTER TABLE dbo.CHiTietPhieuGiaoHang
ADD CONSTRAINT Fr_CHiTietPhieuGiaoHang_PhieuGiaoHang  FOREIGN KEY(MaPGH) REFERENCES dbo.PhieuGiaoHang(MaPGH);

ALTER TABLE dbo.CHiTietPhieuGiaoHang
ADD CONSTRAINT Fr_CHiTietPhieuGiaoHang_SanPham  FOREIGN KEY(MaSP) REFERENCES dbo.HangHoa(MaHH);


