
IF DB_ID(N'QuanLyDieuPhoiVanChuyen_HIVE') IS NULL
BEGIN
    CREATE DATABASE QuanLyDieuPhoiVanChuyen_HIVE;
END;
GO

USE QuanLyDieuPhoiVanChuyen_HIVE;
GO
USE QuanLyDieuPhoiVanChuyen_HIVE;
GO
/* =========================
   XÓA TRIGGER NẾU ĐÃ TỒN TẠI
========================= */

IF OBJECT_ID(N'dbo.TRG_LenhDieuPhoi_KhongTrungTaiXe', N'TR') IS NOT NULL
    DROP TRIGGER dbo.TRG_LenhDieuPhoi_KhongTrungTaiXe;

IF OBJECT_ID(N'dbo.TRG_LenhDieuPhoi_KhongTrungPhuongTien', N'TR') IS NOT NULL
    DROP TRIGGER dbo.TRG_LenhDieuPhoi_KhongTrungPhuongTien;

IF OBJECT_ID(N'dbo.TRG_PhieuThanhToanVC_KhachHangTrungDon', N'TR') IS NOT NULL
    DROP TRIGGER dbo.TRG_PhieuThanhToanVC_KhachHangTrungDon;

IF OBJECT_ID(N'dbo.TRG_HoaDonVanChuyen_KhachHangTrungPhieuTT', N'TR') IS NOT NULL
    DROP TRIGGER dbo.TRG_HoaDonVanChuyen_KhachHangTrungPhieuTT;

IF OBJECT_ID(N'dbo.TRG_ChiTietHDVC_CapNhatTongTienHoaDon', N'TR') IS NOT NULL
    DROP TRIGGER dbo.TRG_ChiTietHDVC_CapNhatTongTienHoaDon;


/* =========
   XÓA BẢNG 
============ */

DROP TABLE IF EXISTS dbo.ChiTietHDVC;
DROP TABLE IF EXISTS dbo.HoaDonVanChuyen;
DROP TABLE IF EXISTS dbo.LoaiPhiVanChuyen;

DROP TABLE IF EXISTS dbo.PhieuThanhToanVC;
DROP TABLE IF EXISTS dbo.PhieuPhatSinhVC;
DROP TABLE IF EXISTS dbo.LichSuTrangThaiDon;
DROP TABLE IF EXISTS dbo.LenhDieuPhoi;
DROP TABLE IF EXISTS dbo.ChiTietDVC;
DROP TABLE IF EXISTS dbo.DonVanChuyen;

DROP TABLE IF EXISTS dbo.LoaiHangHoa;
DROP TABLE IF EXISTS dbo.PhuongTien;
DROP TABLE IF EXISTS dbo.LoaiPhuongTien;

DROP TABLE IF EXISTS dbo.KhachHang;
DROP TABLE IF EXISTS dbo.LoaiKhachHang;

DROP TABLE IF EXISTS dbo.PhanQuyen;
DROP TABLE IF EXISTS dbo.Quyen;
DROP TABLE IF EXISTS dbo.TaiKhoan;
DROP TABLE IF EXISTS dbo.VaiTroHeThong;
DROP TABLE IF EXISTS dbo.NhanVien;
DROP TABLE IF EXISTS dbo.ChucVu;
/* =========================
   1. BẢNG DANH MỤC VÀ NHÂN SỰ
========================= */

CREATE TABLE ChucVu (
    MaCV NVARCHAR(10) NOT NULL,
    TenCV NVARCHAR(100) NOT NULL,
    MoTaCV NVARCHAR(255) NULL,

    CONSTRAINT PK_ChucVu PRIMARY KEY (MaCV)
);
GO

CREATE TABLE NhanVien (
    MaNV NVARCHAR(10) NOT NULL,
    HoTenNV NVARCHAR(100) NOT NULL,
    CCCDNV CHAR(12) NOT NULL,
    SDTNV CHAR(10) NOT NULL,
    EmailNV NVARCHAR(255) NULL,
    TrangThaiLV NVARCHAR(30) NOT NULL,
    SoBangLai NVARCHAR(20) NULL,
    HangBangLai NVARCHAR(20) NULL,
    NgayHHBangLai DATE NULL,
    MaCV NVARCHAR(10) NOT NULL,

    CONSTRAINT PK_NhanVien PRIMARY KEY (MaNV),

    CONSTRAINT FK_NhanVien_ChucVu
        FOREIGN KEY (MaCV) REFERENCES ChucVu(MaCV),

    CONSTRAINT UQ_NhanVien_CCCDNV UNIQUE (CCCDNV),

    CONSTRAINT CK_NhanVien_CCCDNV
        CHECK (CCCDNV NOT LIKE '%[^0-9]%' AND LEN(CCCDNV) = 12),

    CONSTRAINT CK_NhanVien_SDTNV
        CHECK (SDTNV NOT LIKE '%[^0-9]%' AND LEN(SDTNV) = 10),

    CONSTRAINT CK_NhanVien_EmailNV
        CHECK (EmailNV IS NULL OR EmailNV LIKE '%_@_%._%'),

    CONSTRAINT CK_NhanVien_TrangThaiLV
        CHECK (TrangThaiLV IN (N'Đang làm việc', N'Nghỉ việc'))
);
GO

CREATE TABLE VaiTroHeThong (
    MaVT NVARCHAR(10) NOT NULL,
    TenVT NVARCHAR(100) NOT NULL,
    MoTaVT NVARCHAR(255) NULL,

    CONSTRAINT PK_VaiTroHeThong PRIMARY KEY (MaVT)
);
GO

CREATE TABLE TaiKhoan (
    MaTK NVARCHAR(10) NOT NULL,
    TenDangNhap NVARCHAR(255) NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL,
    TrangThaiTK NVARCHAR(30) NOT NULL,
    MaVT NVARCHAR(10) NOT NULL,
    MaNV NVARCHAR(10) NOT NULL,

    CONSTRAINT PK_TaiKhoan PRIMARY KEY (MaTK),

    CONSTRAINT FK_TaiKhoan_VaiTroHeThong
        FOREIGN KEY (MaVT) REFERENCES VaiTroHeThong(MaVT),

    CONSTRAINT FK_TaiKhoan_NhanVien
        FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),

    CONSTRAINT UQ_TaiKhoan_TenDangNhap UNIQUE (TenDangNhap),

    CONSTRAINT UQ_TaiKhoan_MaNV UNIQUE (MaNV),

    CONSTRAINT CK_TaiKhoan_TrangThaiTK
        CHECK (TrangThaiTK IN (N'Đang hoạt động', N'Bị khóa'))
);
GO


/* =========================
   BẢNG QUYỀN
========================= */

CREATE TABLE Quyen (
    MaQuyen NVARCHAR(10) NOT NULL,
    LoaiQuyen NVARCHAR(50) NOT NULL,
    TenQuyen NVARCHAR(100) NOT NULL,
    MoTaQuyen NVARCHAR(255) NULL,

    CONSTRAINT PK_Quyen PRIMARY KEY (MaQuyen),

    CONSTRAINT UQ_Quyen_Loai_Ten
        UNIQUE (LoaiQuyen, TenQuyen),

    CONSTRAINT CK_Quyen_LoaiQuyen
        CHECK (LoaiQuyen IN (
            N'Xem',
            N'Thêm',
            N'Sửa',
            N'Xóa',
            N'Hủy',
            N'Cập nhật',
            N'Phân quyền',
            N'Báo cáo',
            N'Xuất'
        ))
);
GO

/* =========================
   BẢNG PHÂN QUYỀN
   Có thể phân quyền theo vai trò hoặc theo tài khoản riêng
========================= */

CREATE TABLE PhanQuyen (
    MaPQ NVARCHAR(10) NOT NULL,
    GhiChuPQ NVARCHAR(255) NULL,
    NgayCapPQ DATE NOT NULL,
    TrangThaiPQ NVARCHAR(30) NOT NULL,
    LoaiPQ NVARCHAR(30) NOT NULL,
    MaVT NVARCHAR(10) NULL,
    MaTK NVARCHAR(10) NULL,
    MaQuyen NVARCHAR(10) NOT NULL,

    CONSTRAINT PK_PhanQuyen PRIMARY KEY (MaPQ),

    CONSTRAINT FK_PhanQuyen_VaiTroHeThong
        FOREIGN KEY (MaVT) REFERENCES VaiTroHeThong(MaVT),

    CONSTRAINT FK_PhanQuyen_TaiKhoan
        FOREIGN KEY (MaTK) REFERENCES TaiKhoan(MaTK),

    CONSTRAINT FK_PhanQuyen_Quyen
        FOREIGN KEY (MaQuyen) REFERENCES Quyen(MaQuyen),

    CONSTRAINT CK_PhanQuyen_TrangThaiPQ
        CHECK (TrangThaiPQ IN (N'Hoạt động', N'Ngừng áp dụng')),

    CONSTRAINT CK_PhanQuyen_LoaiPQ
        CHECK (LoaiPQ IN (N'Cấp quyền', N'Thu hồi quyền')),

    CONSTRAINT CK_PhanQuyen_DoiTuong
        CHECK (
            (MaVT IS NOT NULL AND MaTK IS NULL)
            OR
            (MaVT IS NULL AND MaTK IS NOT NULL)
        )
);
GO

/* =========================
   RÀNG BUỘC KHÔNG TRÙNG PHÂN QUYỀN ĐANG HOẠT ĐỘNG
========================= */

CREATE UNIQUE INDEX UQ_PhanQuyen_VaiTro_Quyen_HoatDong
ON PhanQuyen (MaVT, MaQuyen)
WHERE MaVT IS NOT NULL AND TrangThaiPQ = N'Hoạt động';
GO

CREATE UNIQUE INDEX UQ_PhanQuyen_TaiKhoan_Quyen_HoatDong
ON PhanQuyen (MaTK, MaQuyen)
WHERE MaTK IS NOT NULL AND TrangThaiPQ = N'Hoạt động';
GO


/* =========================
   2. BẢNG KHÁCH HÀNG, PHƯƠNG TIỆN, HÀNG HÓA
========================= */

CREATE TABLE LoaiKhachHang (
    MaLoaiKH NVARCHAR(10) NOT NULL,
    TenLoaiKH NVARCHAR(100) NOT NULL,
    MoTaLoaiKH NVARCHAR(255) NULL,

    CONSTRAINT PK_LoaiKhachHang PRIMARY KEY (MaLoaiKH)
);
GO

CREATE TABLE KhachHang (
    MaKH NVARCHAR(10) NOT NULL,
    TenKH NVARCHAR(100) NOT NULL,
    SDTKH CHAR(10) NOT NULL,
    EmailKH NVARCHAR(255) NULL,
    DiaChiKH NVARCHAR(255) NOT NULL,
    MST NVARCHAR(20) NULL,
    TrangThaiSuDung NVARCHAR(30) NOT NULL,
    MaLoaiKH NVARCHAR(10) NOT NULL,

    CONSTRAINT PK_KhachHang PRIMARY KEY (MaKH),

    CONSTRAINT FK_KhachHang_LoaiKhachHang
        FOREIGN KEY (MaLoaiKH) REFERENCES LoaiKhachHang(MaLoaiKH),

    CONSTRAINT CK_KhachHang_SDTKH
        CHECK (SDTKH NOT LIKE '%[^0-9]%' AND LEN(SDTKH) = 10),

    CONSTRAINT CK_KhachHang_EmailKH
        CHECK (EmailKH IS NULL OR EmailKH LIKE '%_@_%._%'),

    CONSTRAINT CK_KhachHang_MST
        CHECK (
            MST IS NULL
            OR (MST NOT LIKE '%[^0-9]%' AND LEN(MST) BETWEEN 10 AND 14)
        ),

    CONSTRAINT CK_KhachHang_TrangThaiSuDung
        CHECK (TrangThaiSuDung IN (N'Đang sử dụng', N'Ngừng sử dụng'))
);
GO

CREATE UNIQUE INDEX UQ_KhachHang_MST
ON KhachHang(MST)
WHERE MST IS NOT NULL;
GO

CREATE TABLE LoaiPhuongTien (
    MaLoaiPT NVARCHAR(10) NOT NULL,
    TenLoaiPT NVARCHAR(100) NOT NULL,
    MoTaLoaiPT NVARCHAR(255) NULL,

    CONSTRAINT PK_LoaiPhuongTien PRIMARY KEY (MaLoaiPT)
);
GO

CREATE TABLE PhuongTien (
    MaPT NVARCHAR(10) NOT NULL,
    BienSoXe NVARCHAR(20) NOT NULL,
    TaiTrong DECIMAL(10,2) NOT NULL,
    TinhTrangPT NVARCHAR(30) NOT NULL,
    MaLoaiPT NVARCHAR(10) NOT NULL,

    CONSTRAINT PK_PhuongTien PRIMARY KEY (MaPT),

    CONSTRAINT FK_PhuongTien_LoaiPhuongTien
        FOREIGN KEY (MaLoaiPT) REFERENCES LoaiPhuongTien(MaLoaiPT),

    CONSTRAINT UQ_PhuongTien_BienSoXe UNIQUE (BienSoXe),

    CONSTRAINT CK_PhuongTien_TaiTrong
        CHECK (TaiTrong > 0),

    CONSTRAINT CK_PhuongTien_TinhTrangPT
        CHECK (TinhTrangPT IN (N'Sẵn sàng', N'Đang vận chuyển', N'Bảo trì'))
);
GO

CREATE TABLE LoaiHangHoa (
    MaLoaiHH NVARCHAR(10) NOT NULL,
    TenLoaiHH NVARCHAR(100) NOT NULL,
    MoTaLoaiHH NVARCHAR(255) NULL,

    CONSTRAINT PK_LoaiHangHoa PRIMARY KEY (MaLoaiHH)
);
GO

/* =========================
   3. BẢNG ĐƠN VẬN CHUYỂN
========================= */

CREATE TABLE DonVanChuyen (
    MaDonVC NVARCHAR(10) NOT NULL,
    DiaChiLayHang NVARCHAR(255) NOT NULL,
    DiaChiGiao NVARCHAR(255) NOT NULL,
    TenNguoiNhan NVARCHAR(100) NOT NULL,
    SDTNguoiNhan CHAR(10) NOT NULL,
    TGNhanDuKien DATETIME NOT NULL,
    TGGiaoDuKien DATETIME NOT NULL,
    PhiVC DECIMAL(18,2) NOT NULL,
    YeuCauDacBiet NVARCHAR(255) NULL,
    TrangThaiDon NVARCHAR(30) NOT NULL,
    NgayTao DATETIME NOT NULL DEFAULT GETDATE(),
    MaKH NVARCHAR(10) NOT NULL,
    MaNV NVARCHAR(10) NOT NULL,

    CONSTRAINT PK_DonVanChuyen PRIMARY KEY (MaDonVC),

    CONSTRAINT FK_DonVanChuyen_KhachHang
        FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),

    CONSTRAINT FK_DonVanChuyen_NhanVien
        FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),

    CONSTRAINT CK_DonVanChuyen_SDTNguoiNhan
        CHECK (SDTNguoiNhan NOT LIKE '%[^0-9]%' AND LEN(SDTNguoiNhan) = 10),

    CONSTRAINT CK_DonVanChuyen_PhiVC
        CHECK (PhiVC >= 0),

    CONSTRAINT CK_DonVanChuyen_ThoiGianDuKien
        CHECK (TGGiaoDuKien >= TGNhanDuKien),

    CONSTRAINT CK_DonVanChuyen_TrangThaiDon
        CHECK (TrangThaiDon IN (
            N'Mới tạo',
            N'Đang điều phối',
            N'Đang vận chuyển',
            N'Hoàn thành',
            N'Đã hủy'
        ))
);
GO

CREATE TABLE ChiTietDVC (
    MaDonVC NVARCHAR(10) NOT NULL,
    MaLoaiHH NVARCHAR(10) NOT NULL,
    KhoiLuong DECIMAL(10,2) NOT NULL,
    SoKien INT NOT NULL,
    DonViTinh NVARCHAR(50) NOT NULL,
    MoTaHH NVARCHAR(255) NULL,

    CONSTRAINT PK_ChiTietDVC PRIMARY KEY (MaDonVC, MaLoaiHH),

    CONSTRAINT FK_ChiTietDVC_DonVanChuyen
        FOREIGN KEY (MaDonVC) REFERENCES DonVanChuyen(MaDonVC),

    CONSTRAINT FK_ChiTietDVC_LoaiHangHoa
        FOREIGN KEY (MaLoaiHH) REFERENCES LoaiHangHoa(MaLoaiHH),

    CONSTRAINT CK_ChiTietDVC_KhoiLuong
        CHECK (KhoiLuong > 0),

    CONSTRAINT CK_ChiTietDVC_SoKien
        CHECK (SoKien > 0)
);
GO

/* =========================
   4. BẢNG ĐIỀU PHỐI VÀ THEO DÕI VẬN CHUYỂN
========================= */

CREATE TABLE LenhDieuPhoi (
    MaLenhDP NVARCHAR(10) NOT NULL,
    TGLapLenh DATETIME NOT NULL DEFAULT GETDATE(),
    TGPhanCong DATETIME NULL,
    TrangThaiLenh NVARCHAR(30) NOT NULL,
    TGXacNhan DATETIME NULL,
    LyDoTuChoi NVARCHAR(255) NULL,
    MaDonVC NVARCHAR(10) NOT NULL,
    MaNV NVARCHAR(10) NOT NULL,
    MaPT NVARCHAR(10) NOT NULL,

    CONSTRAINT PK_LenhDieuPhoi PRIMARY KEY (MaLenhDP),

    CONSTRAINT FK_LenhDieuPhoi_DonVanChuyen
        FOREIGN KEY (MaDonVC) REFERENCES DonVanChuyen(MaDonVC),

    CONSTRAINT FK_LenhDieuPhoi_NhanVien
        FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),

    CONSTRAINT FK_LenhDieuPhoi_PhuongTien
        FOREIGN KEY (MaPT) REFERENCES PhuongTien(MaPT),

    CONSTRAINT CK_LenhDieuPhoi_TrangThaiLenh
        CHECK (TrangThaiLenh IN (
            N'Chờ xác nhận',
            N'Đã tiếp nhận',
            N'Từ chối',
            N'Đang thực hiện',
            N'Hoàn thành',
            N'Đã hủy'
        )),

    CONSTRAINT CK_LenhDieuPhoi_TGPhanCong
        CHECK (TGPhanCong IS NULL OR TGPhanCong >= TGLapLenh),

    CONSTRAINT CK_LenhDieuPhoi_TGXacNhan
        CHECK (
            TGXacNhan IS NULL
            OR (TGPhanCong IS NOT NULL AND TGXacNhan >= TGPhanCong)
        ),

    CONSTRAINT CK_LenhDieuPhoi_LyDoTuChoi
        CHECK (
            TrangThaiLenh <> N'Từ chối'
            OR (LyDoTuChoi IS NOT NULL AND LEN(LyDoTuChoi) > 0)
        )
);
GO

CREATE TABLE LichSuTrangThaiDon (
    MaLichSu NVARCHAR(10) NOT NULL,
    TrangThaiCu NVARCHAR(30) NOT NULL,
    TrangThaiMoi NVARCHAR(30) NOT NULL,
    TGCapNhat DATETIME NOT NULL DEFAULT GETDATE(),
    GhiChu NVARCHAR(255) NULL,
    MaDonVC NVARCHAR(10) NOT NULL,
    MaNV NVARCHAR(10) NOT NULL,

    CONSTRAINT PK_LichSuTrangThaiDon 
        PRIMARY KEY (MaLichSu),

    CONSTRAINT FK_LichSuTrangThaiDon_DonVanChuyen
        FOREIGN KEY (MaDonVC) 
        REFERENCES DonVanChuyen(MaDonVC),

    CONSTRAINT FK_LichSuTrangThaiDon_NhanVien
        FOREIGN KEY (MaNV) 
        REFERENCES NhanVien(MaNV),

    CONSTRAINT CK_LichSuTrangThaiDon_TrangThaiCu
        CHECK (TrangThaiCu IN (
            N'Mới tạo',
            N'Đang điều phối',
            N'Đã phân công',
            N'Đã nhận chuyến',
            N'Đang đến điểm nhận',
            N'Đã nhận hàng',
            N'Đang giao hàng',
            N'Hoàn thành',
            N'Đã hủy'
        )),

    CONSTRAINT CK_LichSuTrangThaiDon_TrangThaiMoi
        CHECK (TrangThaiMoi IN (
            N'Mới tạo',
            N'Đang điều phối',
            N'Đã phân công',
            N'Đã nhận chuyến',
            N'Đang đến điểm nhận',
            N'Đã nhận hàng',
            N'Đang giao hàng',
            N'Hoàn thành',
            N'Đã hủy'
        )),

    CONSTRAINT CK_LichSuTrangThaiDon_KhacTrangThai
        CHECK (TrangThaiCu <> TrangThaiMoi)
);
GO
GO

CREATE TABLE PhieuPhatSinhVC (
    MaPhieuPS NVARCHAR(10) NOT NULL,
    TGPhatSinh DATETIME NOT NULL DEFAULT GETDATE(),
    NoiDungPhatSinh NVARCHAR(255) NOT NULL,
    HuongXuLy NVARCHAR(255) NULL,
    KetQuaXuLy NVARCHAR(255) NULL,
    TrangThaiXuLy NVARCHAR(30) NOT NULL,
    MaDonVC NVARCHAR(10) NOT NULL,
    MaLenhDP NVARCHAR(10) NOT NULL,
    MaNV NVARCHAR(10) NOT NULL,

    CONSTRAINT PK_PhieuPhatSinhVC PRIMARY KEY (MaPhieuPS),

    CONSTRAINT FK_PhieuPhatSinhVC_DonVanChuyen
        FOREIGN KEY (MaDonVC) REFERENCES DonVanChuyen(MaDonVC),

    CONSTRAINT FK_PhieuPhatSinhVC_LenhDieuPhoi
        FOREIGN KEY (MaLenhDP) REFERENCES LenhDieuPhoi(MaLenhDP),

    CONSTRAINT FK_PhieuPhatSinhVC_NhanVien
        FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),

    CONSTRAINT CK_PhieuPhatSinhVC_TrangThaiXuLy
        CHECK (TrangThaiXuLy IN (N'Chưa xử lý', N'Đang xử lý', N'Đã xử lý'))
);
GO

/* =========================
   5. BẢNG THANH TOÁN VÀ HÓA ĐƠN
========================= */

CREATE TABLE PhieuThanhToanVC (
    MaPhieuTT NVARCHAR(10) NOT NULL,
    SoTienTT DECIMAL(18,2) NOT NULL,
    HinhThucTT NVARCHAR(50) NOT NULL,
    NgayTT DATETIME NOT NULL DEFAULT GETDATE(),
    TrangThaiTT NVARCHAR(30) NOT NULL,
    MaGiaoDich NVARCHAR(50) NULL,
    MaDonVC NVARCHAR(10) NOT NULL,
    MaNV NVARCHAR(10) NOT NULL,
    MaKH NVARCHAR(10) NOT NULL,

    CONSTRAINT PK_PhieuThanhToanVC PRIMARY KEY (MaPhieuTT),

    CONSTRAINT FK_PhieuThanhToanVC_DonVanChuyen
        FOREIGN KEY (MaDonVC) REFERENCES DonVanChuyen(MaDonVC),

    CONSTRAINT FK_PhieuThanhToanVC_NhanVien
        FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),

    CONSTRAINT FK_PhieuThanhToanVC_KhachHang
        FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),

    CONSTRAINT CK_PhieuThanhToanVC_SoTienTT
        CHECK (SoTienTT > 0),

    CONSTRAINT CK_PhieuThanhToanVC_HinhThucTT
        CHECK (HinhThucTT IN (N'Tiền mặt', N'Chuyển khoản')),

    CONSTRAINT CK_PhieuThanhToanVC_TrangThaiTT
        CHECK (TrangThaiTT IN (
            N'Chưa thanh toán',
            N'Thanh toán một phần',
            N'Đã thanh toán'
        )),

    CONSTRAINT CK_PhieuThanhToanVC_MaGiaoDich
        CHECK (
            HinhThucTT <> N'Chuyển khoản'
            OR (MaGiaoDich IS NOT NULL AND LEN(MaGiaoDich) > 0)
        )
);
GO

CREATE UNIQUE INDEX UQ_PhieuThanhToanVC_MaGiaoDich
ON PhieuThanhToanVC(MaGiaoDich)
WHERE MaGiaoDich IS NOT NULL;
GO

CREATE TABLE HoaDonVanChuyen (
    MaHD NVARCHAR(10) NOT NULL,
    NgayPhatHanh DATETIME NOT NULL DEFAULT GETDATE(),
    TongTienTruocThue DECIMAL(18,2) NOT NULL DEFAULT 0,
    ThueVAT DECIMAL(5,2) NOT NULL DEFAULT 0,
    TongTienSauThue AS
        CAST(ROUND(TongTienTruocThue * (1 + ThueVAT / 100.0), 2) AS DECIMAL(18,2)) PERSISTED,
    TrangThaiHD NVARCHAR(30) NOT NULL,
    MaPhieuTT NVARCHAR(10) NOT NULL,
    MaNV NVARCHAR(10) NOT NULL,
    MaKH NVARCHAR(10) NOT NULL,

    CONSTRAINT PK_HoaDonVanChuyen PRIMARY KEY (MaHD),

    CONSTRAINT FK_HoaDonVanChuyen_PhieuThanhToanVC
        FOREIGN KEY (MaPhieuTT) REFERENCES PhieuThanhToanVC(MaPhieuTT),

    CONSTRAINT FK_HoaDonVanChuyen_NhanVien
        FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),

    CONSTRAINT FK_HoaDonVanChuyen_KhachHang
        FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),

    CONSTRAINT CK_HoaDonVanChuyen_TongTienTruocThue
        CHECK (TongTienTruocThue >= 0),

    CONSTRAINT CK_HoaDonVanChuyen_ThueVAT
        CHECK (ThueVAT >= 0 AND ThueVAT <= 100),

    CONSTRAINT CK_HoaDonVanChuyen_TrangThaiHD
        CHECK (TrangThaiHD IN (N'Đã phát hành', N'Đã hủy'))
);
GO

CREATE TABLE LoaiPhiVanChuyen (
    MaLoaiPhi NVARCHAR(10) NOT NULL,
    TenLoaiPhi NVARCHAR(100) NOT NULL,
    MoTaLoaiPhi NVARCHAR(255) NULL,

    CONSTRAINT PK_LoaiPhiVanChuyen PRIMARY KEY (MaLoaiPhi)
);
GO

CREATE TABLE ChiTietHDVC (
    MaHD NVARCHAR(10) NOT NULL,
    MaLoaiPhi NVARCHAR(10) NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    ThanhTien AS CAST(SoLuong * DonGia AS DECIMAL(18,2)) PERSISTED,

    CONSTRAINT PK_ChiTietHDVC PRIMARY KEY (MaHD, MaLoaiPhi),

    CONSTRAINT FK_ChiTietHDVC_HoaDonVanChuyen
        FOREIGN KEY (MaHD) REFERENCES HoaDonVanChuyen(MaHD),

    CONSTRAINT FK_ChiTietHDVC_LoaiPhiVanChuyen
        FOREIGN KEY (MaLoaiPhi) REFERENCES LoaiPhiVanChuyen(MaLoaiPhi),

    CONSTRAINT CK_ChiTietHDVC_SoLuong
        CHECK (SoLuong > 0),

    CONSTRAINT CK_ChiTietHDVC_DonGia
        CHECK (DonGia >= 0)
);
GO

/* =========================
   6. TRIGGER RÀNG BUỘC LIÊN BỘ - LIÊN THUỘC TÍNH
========================= */

CREATE TRIGGER TRG_LenhDieuPhoi_KhongTrungTaiXe
ON LenhDieuPhoi
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM LenhDieuPhoi l1
        JOIN LenhDieuPhoi l2
            ON l1.MaLenhDP <> l2.MaLenhDP
            AND l1.MaNV = l2.MaNV
            AND l1.TGPhanCong = l2.TGPhanCong
        WHERE l1.TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')
          AND l2.TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')
          AND l1.TGPhanCong IS NOT NULL
    )
    BEGIN
        RAISERROR (N'Tài xế đã có lệnh điều phối đang hoạt động tại thời điểm phân công này.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

CREATE TRIGGER TRG_LenhDieuPhoi_KhongTrungPhuongTien
ON LenhDieuPhoi
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM LenhDieuPhoi l1
        JOIN LenhDieuPhoi l2
            ON l1.MaLenhDP <> l2.MaLenhDP
            AND l1.MaPT = l2.MaPT
            AND l1.TGPhanCong = l2.TGPhanCong
        WHERE l1.TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')
          AND l2.TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')
          AND l1.TGPhanCong IS NOT NULL
    )
    BEGIN
        RAISERROR (N'Phương tiện đã có lệnh điều phối đang hoạt động tại thời điểm phân công này.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

/* =========================
   7. TRIGGER RÀNG BUỘC LIÊN BỘ - LIÊN QUAN HỆ
========================= */

CREATE TRIGGER TRG_PhieuThanhToanVC_KhachHangTrungDon
ON PhieuThanhToanVC
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN DonVanChuyen dvc
            ON i.MaDonVC = dvc.MaDonVC
        WHERE i.MaKH <> dvc.MaKH
    )
    BEGIN
        RAISERROR (N'Khách hàng trên phiếu thanh toán phải trùng với khách hàng của đơn vận chuyển.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

CREATE TRIGGER TRG_HoaDonVanChuyen_KhachHangTrungPhieuTT
ON HoaDonVanChuyen
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN PhieuThanhToanVC ptt
            ON i.MaPhieuTT = ptt.MaPhieuTT
        WHERE i.MaKH <> ptt.MaKH
    )
    BEGIN
        RAISERROR (N'Khách hàng trên hóa đơn phải trùng với khách hàng của phiếu thanh toán.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

CREATE TRIGGER TRG_ChiTietHDVC_CapNhatTongTienHoaDon
ON ChiTietHDVC
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    ;WITH HoaDonBiAnhHuong AS (
        SELECT MaHD FROM inserted
        UNION
        SELECT MaHD FROM deleted
    ),
    TongChiTiet AS (
        SELECT 
            h.MaHD,
            ISNULL(SUM(ct.ThanhTien), 0) AS TongTien
        FROM HoaDonBiAnhHuong h
        LEFT JOIN ChiTietHDVC ct
            ON h.MaHD = ct.MaHD
        GROUP BY h.MaHD
    )
    UPDATE hd
    SET hd.TongTienTruocThue = t.TongTien
    FROM HoaDonVanChuyen hd
    JOIN TongChiTiet t
        ON hd.MaHD = t.MaHD;
END;
GO
/* =========================
   DỮ LIỆU MẪU NHÓM 1
   NHÂN SỰ - TÀI KHOẢN - PHÂN QUYỀN
========================= */

/* =========================
   1. CHỨC VỤ
========================= */

INSERT INTO ChucVu (MaCV, TenCV, MoTaCV)
VALUES
(N'CV001', N'Điều phối viên', N'Nhân viên phụ trách tiếp nhận, lập đơn và điều phối vận chuyển.'),
(N'CV002', N'Tài xế', N'Nhân viên trực tiếp thực hiện vận chuyển hàng hóa.'),
(N'CV003', N'Kế toán', N'Nhân viên phụ trách thanh toán, hóa đơn và đối chiếu doanh thu.'),
(N'CV004', N'Quản lý', N'Nhân viên theo dõi, kiểm tra và quản lý hoạt động vận hành.'),
(N'CV005', N'Quản trị viên', N'Nhân viên quản trị tài khoản, vai trò và phân quyền hệ thống.');


/* =========================
   2. VAI TRÒ HỆ THỐNG
========================= */

INSERT INTO VaiTroHeThong (MaVT, TenVT, MoTaVT)
VALUES
(N'VT001', N'Điều phối viên', N'Sử dụng các chức năng lập đơn, điều phối tài xế và phương tiện.'),
(N'VT002', N'Tài xế', N'Sử dụng các chức năng xem nhiệm vụ, cập nhật trạng thái và ghi nhận phát sinh.'),
(N'VT003', N'Kế toán', N'Sử dụng các chức năng thanh toán, hóa đơn và đối chiếu doanh thu.'),
(N'VT004', N'Quản lý', N'Sử dụng các chức năng theo dõi hoạt động vận hành và xem báo cáo.'),
(N'VT005', N'Quản trị viên', N'Sử dụng các chức năng quản trị tài khoản, vai trò và phân quyền.');



/* =========================
   4. NHÂN VIÊN
========================= */

INSERT INTO NhanVien (
    MaNV, HoTenNV, CCCDNV, SDTNV, EmailNV, TrangThaiLV,
    SoBangLai, HangBangLai, NgayHHBangLai, MaCV
)
VALUES
/* Điều phối viên */
(N'NV001', N'Nguyễn Minh Anh', '079483625914', '0907314826', N'anh.nguyen@hive.vn', N'Đang làm việc', NULL, NULL, NULL, N'CV001'),
(N'NV002', N'Trần Thu Ngân', '075294816037', '0938462715', N'ngan.tran@hive.vn', N'Đang làm việc', NULL, NULL, NULL, N'CV001'),
(N'NV003', N'Lê Quốc Bảo', '077639184502', '0865724913', N'bao.le@hive.vn', N'Đang làm việc', NULL, NULL, NULL, N'CV001'),
(N'NV004', N'Phạm Hoàng My', '080528739164', '0916847352', N'my.pham@hive.vn', N'Đang làm việc', NULL, NULL, NULL, N'CV001'),

/* Tài xế */
(N'NV005', N'Nguyễn Văn Long', '079315846209', '0982357146', N'long.nguyen@hive.vn', N'Đang làm việc', N'BLX837261', N'C', '2028-12-31', N'CV002'),
(N'NV006', N'Trần Quốc Huy', '077482915630', '0974812635', N'huy.tran@hive.vn', N'Đang làm việc', N'BLX526914', N'C', '2029-06-30', N'CV002'),
(N'NV007', N'Lê Hoàng Nam', '075918374620', '0947261835', N'nam.le@hive.vn', N'Đang làm việc', N'BLX749205', N'C', '2028-10-15', N'CV002'),
(N'NV008', N'Phạm Thanh Tùng', '083641529708', '0883529471', N'tung.pham@hive.vn', N'Đang làm việc', N'BLX318642', N'C', '2029-03-20', N'CV002'),
(N'NV009', N'Võ Minh Khang', '080294735816', '0964182735', N'khang.vo@hive.vn', N'Đang làm việc', N'BLX694731', N'C', '2028-08-25', N'CV002'),
(N'NV010', N'Đặng Gia Hưng', '079628413950', '0927358416', N'hung.dang@hive.vn', N'Đang làm việc', N'BLX582947', N'C', '2029-01-18', N'CV002'),
(N'NV011', N'Bùi Anh Tuấn', '077935281406', '0859463271', N'tuan.bui@hive.vn', N'Đang làm việc', N'BLX461823', N'C', '2028-11-12', N'CV002'),
(N'NV012', N'Huỳnh Công Đạt', '075624890317', '0904827361', N'dat.huynh@hive.vn', N'Đang làm việc', N'BLX735984', N'C', '2029-05-05', N'CV002'),
(N'NV013', N'Ngô Văn Phúc', '083729165408', '0935726184', N'phuc.ngo@hive.vn', N'Đang làm việc', N'BLX290638', N'C', '2028-09-09', N'CV002'),
(N'NV014', N'Đỗ Minh Quân', '080463917285', '0896417253', N'quan.do@hive.vn', N'Đang làm việc', N'BLX814572', N'C', '2029-07-21', N'CV002'),
(N'NV015', N'Nguyễn Hữu Tài', '079847261593', '0972635841', N'tai.nguyen@hive.vn', N'Đang làm việc', N'BLX673219', N'C', '2028-06-16', N'CV002'),
(N'NV016', N'Trịnh Văn Sơn', '077261958374', '0917354286', N'son.trinh@hive.vn', N'Đang làm việc', N'BLX942670', N'C', '2029-04-10', N'CV002'),
(N'NV017', N'Phan Đức Mạnh', '075839472061', '0862947153', N'manh.phan@hive.vn', N'Đang làm việc', N'BLX385126', N'C', '2028-05-28', N'CV002'),
(N'NV018', N'Hoàng Nhật Minh', '083104759628', '0945186723', N'minh.hoang@hive.vn', N'Đang làm việc', N'BLX729461', N'C', '2029-09-14', N'CV002'),
(N'NV019', N'Vũ Thành Đạt', '080715293846', '0984726153', N'dat.vu@hive.vn', N'Đang làm việc', N'BLX516308', N'C', '2028-12-05', N'CV002'),
(N'NV020', N'Cao Xuân Trường', '079260384715', '0925847613', N'truong.cao@hive.vn', N'Đang làm việc', N'BLX803572', N'C', '2029-08-19', N'CV002'),
(N'NV021', N'Mai Văn Bình', '077594183620', '0884732615', N'binh.mai@hive.vn', N'Đang làm việc', N'BLX247916', N'C', '2028-07-07', N'CV002'),
(N'NV022', N'Lý Quốc Việt', '075371649280', '0967253841', N'viet.ly@hive.vn', N'Đang làm việc', N'BLX691438', N'C', '2029-02-24', N'CV002'),
(N'NV023', N'Đinh Văn Hải', '083826150947', '0906374825', N'hai.dinh@hive.vn', N'Đang làm việc', N'BLX430785', N'C', '2028-04-30', N'CV002'),
(N'NV024', N'Nguyễn Chí Kiên', '080192746538', '0931847625', N'kien.nguyen@hive.vn', N'Đang làm việc', N'BLX958214', N'C', '2029-10-11', N'CV002'),

/* Kế toán */
(N'NV025', N'Phạm Thu Hà', '079638251407', '0975318624', N'ha.pham@hive.vn', N'Đang làm việc', NULL, NULL, NULL, N'CV003'),
(N'NV026', N'Lê Ngọc Mai', '077416928350', '0914285736', N'mai.le@hive.vn', N'Đang làm việc', NULL, NULL, NULL, N'CV003'),
(N'NV027', N'Trần Khánh Linh', '075284617903', '0867392514', N'linh.tran@hive.vn', N'Đang làm việc', NULL, NULL, NULL, N'CV003'),

/* Quản lý */
(N'NV028', N'Võ Thanh Tùng', '083519274608', '0986314725', N'tung.vo@hive.vn', N'Đang làm việc', NULL, NULL, NULL, N'CV004'),
(N'NV029', N'Nguyễn Hải Yến', '080647392185', '0942736158', N'yen.nguyen@hive.vn', N'Đang làm việc', NULL, NULL, NULL, N'CV004'),

/* Quản trị viên */
(N'NV030', N'Đặng Gia Bảo', '079725148396', '0908463725', N'bao.dang@hive.vn', N'Đang làm việc', NULL, NULL, NULL, N'CV005');


/* =========================
   5. TÀI KHOẢN
========================= */

INSERT INTO TaiKhoan (
    MaTK, TenDangNhap, MatKhau, TrangThaiTK, MaVT, MaNV
)
VALUES
/* Tài khoản điều phối viên */
(N'TK001', N'dp_anh482',  N'Hive@DP4826', N'Đang hoạt động', N'VT001', N'NV001'),
(N'TK002', N'dp_ngan736', N'Hive@DP7365', N'Đang hoạt động', N'VT001', N'NV002'),
(N'TK003', N'dp_bao519',  N'Hive@DP5194', N'Đang hoạt động', N'VT001', N'NV003'),
(N'TK004', N'dp_my864',   N'Hive@DP8642', N'Đang hoạt động', N'VT001', N'NV004'),

/* Tài khoản tài xế */
(N'TK005', N'tx_long735',   N'Hive@TX7351', N'Đang hoạt động', N'VT002', N'NV005'),
(N'TK006', N'tx_huy428',    N'Hive@TX4286', N'Đang hoạt động', N'VT002', N'NV006'),
(N'TK007', N'tx_nam916',    N'Hive@TX9163', N'Đang hoạt động', N'VT002', N'NV007'),
(N'TK008', N'tx_tung274',   N'Hive@TX2749', N'Đang hoạt động', N'VT002', N'NV008'),
(N'TK009', N'tx_khang681',  N'Hive@TX6815', N'Đang hoạt động', N'VT002', N'NV009'),
(N'TK010', N'tx_hung349',   N'Hive@TX3497', N'Đang hoạt động', N'VT002', N'NV010'),
(N'TK011', N'tx_tuan825',   N'Hive@TX8254', N'Đang hoạt động', N'VT002', N'NV011'),
(N'TK012', N'tx_dat507',    N'Hive@TX5078', N'Đang hoạt động', N'VT002', N'NV012'),
(N'TK013', N'tx_phuc639',   N'Hive@TX6392', N'Đang hoạt động', N'VT002', N'NV013'),
(N'TK014', N'tx_quan174',   N'Hive@TX1746', N'Đang hoạt động', N'VT002', N'NV014'),
(N'TK015', N'tx_tai593',    N'Hive@TX5938', N'Đang hoạt động', N'VT002', N'NV015'),
(N'TK016', N'tx_son742',    N'Hive@TX7425', N'Đang hoạt động', N'VT002', N'NV016'),
(N'TK017', N'tx_manh386',   N'Hive@TX3861', N'Đang hoạt động', N'VT002', N'NV017'),
(N'TK018', N'tx_minh927',   N'Hive@TX9274', N'Đang hoạt động', N'VT002', N'NV018'),
(N'TK019', N'tx_dat614',    N'Hive@TX6149', N'Đang hoạt động', N'VT002', N'NV019'),
(N'TK020', N'tx_truong258', N'Hive@TX2587', N'Đang hoạt động', N'VT002', N'NV020'),
(N'TK021', N'tx_binh471',   N'Hive@TX4713', N'Đang hoạt động', N'VT002', N'NV021'),
(N'TK022', N'tx_viet836',   N'Hive@TX8362', N'Đang hoạt động', N'VT002', N'NV022'),
(N'TK023', N'tx_hai695',    N'Hive@TX6954', N'Đang hoạt động', N'VT002', N'NV023'),
(N'TK024', N'tx_kien319',   N'Hive@TX3198', N'Đang hoạt động', N'VT002', N'NV024'),

/* Tài khoản kế toán */
(N'TK025', N'kt_ha624',    N'Hive@KT6247', N'Đang hoạt động', N'VT003', N'NV025'),
(N'TK026', N'kt_mai913',   N'Hive@KT9135', N'Đang hoạt động', N'VT003', N'NV026'),
(N'TK027', N'kt_linh478',  N'Hive@KT4782', N'Đang hoạt động', N'VT003', N'NV027'),

/* Tài khoản quản lý */
(N'TK028', N'ql_tung752',  N'Hive@QL7526', N'Đang hoạt động', N'VT004', N'NV028'),
(N'TK029', N'ql_yen381',   N'Hive@QL3819', N'Đang hoạt động', N'VT004', N'NV029'),

/* Tài khoản quản trị viên */
(N'TK030', N'ad_bao946',   N'Hive@AD9463', N'Đang hoạt động', N'VT005', N'NV030');

/* =========================
   QUYỀN CHỨC NĂNG
========================= */

/* =========================
   DỮ LIỆU MẪU BẢNG QUYEN
   Quyền được tách theo bảng và thao tác
========================= */

INSERT INTO Quyen (
    MaQuyen, LoaiQuyen, TenQuyen, MoTaQuyen
)
VALUES
/* Chức vụ */
(N'Q001', N'Xem', N'ChucVu', N'Cho phép xem danh sách chức vụ.'),
(N'Q002', N'Thêm', N'ChucVu', N'Cho phép thêm chức vụ.'),
(N'Q003', N'Sửa', N'ChucVu', N'Cho phép sửa chức vụ.'),

/* Nhân viên */
(N'Q004', N'Xem', N'NhanVien', N'Cho phép xem thông tin nhân viên.'),
(N'Q005', N'Thêm', N'NhanVien', N'Cho phép thêm nhân viên.'),
(N'Q006', N'Sửa', N'NhanVien', N'Cho phép sửa thông tin nhân viên.'),

/* Tài khoản */
(N'Q007', N'Xem', N'TaiKhoan', N'Cho phép xem tài khoản người dùng.'),
(N'Q008', N'Thêm', N'TaiKhoan', N'Cho phép thêm tài khoản người dùng.'),
(N'Q009', N'Sửa', N'TaiKhoan', N'Cho phép sửa tài khoản người dùng.'),
(N'Q010', N'Cập nhật', N'TaiKhoan', N'Cho phép cập nhật trạng thái tài khoản.'),

/* Vai trò hệ thống */
(N'Q011', N'Xem', N'VaiTroHeThong', N'Cho phép xem vai trò hệ thống.'),
(N'Q012', N'Thêm', N'VaiTroHeThong', N'Cho phép thêm vai trò hệ thống.'),
(N'Q013', N'Sửa', N'VaiTroHeThong', N'Cho phép sửa vai trò hệ thống.'),

/* Quyền */
(N'Q014', N'Xem', N'Quyen', N'Cho phép xem danh sách quyền.'),
(N'Q015', N'Thêm', N'Quyen', N'Cho phép thêm quyền.'),
(N'Q016', N'Sửa', N'Quyen', N'Cho phép sửa quyền.'),

/* Phân quyền */
(N'Q017', N'Xem', N'PhanQuyen', N'Cho phép xem thông tin phân quyền.'),
(N'Q018', N'Thêm', N'PhanQuyen', N'Cho phép thêm bản ghi phân quyền.'),
(N'Q019', N'Sửa', N'PhanQuyen', N'Cho phép sửa trạng thái phân quyền.'),
(N'Q020', N'Phân quyền', N'PhanQuyen', N'Cho phép cấp hoặc thu hồi quyền.'),

/* Loại khách hàng */
(N'Q021', N'Xem', N'LoaiKhachHang', N'Cho phép xem loại khách hàng.'),
(N'Q022', N'Thêm', N'LoaiKhachHang', N'Cho phép thêm loại khách hàng.'),
(N'Q023', N'Sửa', N'LoaiKhachHang', N'Cho phép sửa loại khách hàng.'),

/* Khách hàng */
(N'Q024', N'Xem', N'KhachHang', N'Cho phép xem thông tin khách hàng.'),
(N'Q025', N'Thêm', N'KhachHang', N'Cho phép thêm khách hàng.'),
(N'Q026', N'Sửa', N'KhachHang', N'Cho phép sửa thông tin khách hàng.'),

/* Loại phương tiện */
(N'Q027', N'Xem', N'LoaiPhuongTien', N'Cho phép xem loại phương tiện.'),
(N'Q028', N'Thêm', N'LoaiPhuongTien', N'Cho phép thêm loại phương tiện.'),
(N'Q029', N'Sửa', N'LoaiPhuongTien', N'Cho phép sửa loại phương tiện.'),

/* Phương tiện */
(N'Q030', N'Xem', N'PhuongTien', N'Cho phép xem thông tin phương tiện.'),
(N'Q031', N'Thêm', N'PhuongTien', N'Cho phép thêm phương tiện.'),
(N'Q032', N'Sửa', N'PhuongTien', N'Cho phép sửa thông tin phương tiện.'),

/* Loại hàng hóa */
(N'Q033', N'Xem', N'LoaiHangHoa', N'Cho phép xem loại hàng hóa.'),
(N'Q034', N'Thêm', N'LoaiHangHoa', N'Cho phép thêm loại hàng hóa.'),
(N'Q035', N'Sửa', N'LoaiHangHoa', N'Cho phép sửa loại hàng hóa.'),

/* Đơn vận chuyển */
(N'Q036', N'Xem', N'DonVanChuyen', N'Cho phép xem đơn vận chuyển.'),
(N'Q037', N'Thêm', N'DonVanChuyen', N'Cho phép thêm đơn vận chuyển.'),
(N'Q038', N'Sửa', N'DonVanChuyen', N'Cho phép sửa đơn vận chuyển.'),
(N'Q039', N'Hủy', N'DonVanChuyen', N'Cho phép hủy đơn vận chuyển.'),

/* Chi tiết đơn vận chuyển */
(N'Q040', N'Xem', N'ChiTietDVC', N'Cho phép xem chi tiết đơn vận chuyển.'),
(N'Q041', N'Thêm', N'ChiTietDVC', N'Cho phép thêm chi tiết đơn vận chuyển.'),
(N'Q042', N'Sửa', N'ChiTietDVC', N'Cho phép sửa chi tiết đơn vận chuyển.'),
(N'Q043', N'Xóa', N'ChiTietDVC', N'Cho phép xóa chi tiết đơn vận chuyển.'),

/* Lệnh điều phối */
(N'Q044', N'Xem', N'LenhDieuPhoi', N'Cho phép xem lệnh điều phối.'),
(N'Q045', N'Thêm', N'LenhDieuPhoi', N'Cho phép lập lệnh điều phối.'),
(N'Q046', N'Sửa', N'LenhDieuPhoi', N'Cho phép sửa lệnh điều phối.'),
(N'Q047', N'Cập nhật', N'LenhDieuPhoi', N'Cho phép cập nhật trạng thái lệnh điều phối.'),

/* Lịch sử trạng thái đơn */
(N'Q048', N'Xem', N'LichSuTrangThaiDon', N'Cho phép xem lịch sử trạng thái đơn vận chuyển.'),

/* Phiếu phát sinh vận chuyển */
(N'Q049', N'Xem', N'PhieuPhatSinhVC', N'Cho phép xem phiếu phát sinh vận chuyển.'),
(N'Q050', N'Thêm', N'PhieuPhatSinhVC', N'Cho phép ghi nhận phát sinh vận chuyển.'),
(N'Q051', N'Sửa', N'PhieuPhatSinhVC', N'Cho phép sửa phiếu phát sinh vận chuyển.'),

/* Phiếu thanh toán */
(N'Q052', N'Xem', N'PhieuThanhToanVC', N'Cho phép xem phiếu thanh toán vận chuyển.'),
(N'Q053', N'Thêm', N'PhieuThanhToanVC', N'Cho phép thêm phiếu thanh toán vận chuyển.'),
(N'Q054', N'Sửa', N'PhieuThanhToanVC', N'Cho phép sửa phiếu thanh toán vận chuyển.'),

/* Hóa đơn vận chuyển */
(N'Q055', N'Xem', N'HoaDonVanChuyen', N'Cho phép xem hóa đơn vận chuyển.'),
(N'Q056', N'Thêm', N'HoaDonVanChuyen', N'Cho phép lập hóa đơn vận chuyển.'),
(N'Q057', N'Sửa', N'HoaDonVanChuyen', N'Cho phép sửa hóa đơn vận chuyển.'),
(N'Q058', N'Xuất', N'HoaDonVanChuyen', N'Cho phép xuất hóa đơn vận chuyển.'),

/* Loại phí vận chuyển */
(N'Q059', N'Xem', N'LoaiPhiVanChuyen', N'Cho phép xem loại phí vận chuyển.'),
(N'Q060', N'Thêm', N'LoaiPhiVanChuyen', N'Cho phép thêm loại phí vận chuyển.'),
(N'Q061', N'Sửa', N'LoaiPhiVanChuyen', N'Cho phép sửa loại phí vận chuyển.'),

/* Chi tiết hóa đơn */
(N'Q062', N'Xem', N'ChiTietHDVC', N'Cho phép xem chi tiết hóa đơn vận chuyển.'),
(N'Q063', N'Thêm', N'ChiTietHDVC', N'Cho phép thêm chi tiết hóa đơn vận chuyển.'),
(N'Q064', N'Sửa', N'ChiTietHDVC', N'Cho phép sửa chi tiết hóa đơn vận chuyển.'),
(N'Q065', N'Xóa', N'ChiTietHDVC', N'Cho phép xóa chi tiết hóa đơn vận chuyển.'),

/* Báo cáo */
(N'Q066', N'Báo cáo', N'DonVanChuyen', N'Cho phép xem báo cáo đơn vận chuyển.'),
(N'Q067', N'Báo cáo', N'DoanhThu', N'Cho phép xem báo cáo doanh thu.');


/* =========================
   DỮ LIỆU MẪU BẢNG PHANQUYEN
   Có phân quyền theo vai trò và phân quyền riêng theo tài khoản
========================= */

;WITH DuLieuPQ AS (
    SELECT *
    FROM (VALUES
        /* Vai trò điều phối viên - VT001 */
        (1,  N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q021', N'Cấp quyền', N'Điều phối viên được xem loại khách hàng'),
        (2,  N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q024', N'Cấp quyền', N'Điều phối viên được xem khách hàng'),
        (3,  N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q025', N'Cấp quyền', N'Điều phối viên được thêm khách hàng'),
        (4,  N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q026', N'Cấp quyền', N'Điều phối viên được sửa khách hàng'),
        (5,  N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q027', N'Cấp quyền', N'Điều phối viên được xem loại phương tiện'),
        (6,  N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q030', N'Cấp quyền', N'Điều phối viên được xem phương tiện'),
        (7,  N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q033', N'Cấp quyền', N'Điều phối viên được xem loại hàng hóa'),
        (8,  N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q036', N'Cấp quyền', N'Điều phối viên được xem đơn vận chuyển'),
        (9,  N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q037', N'Cấp quyền', N'Điều phối viên được thêm đơn vận chuyển'),
        (10, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q038', N'Cấp quyền', N'Điều phối viên được sửa đơn vận chuyển'),
        (11, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q039', N'Cấp quyền', N'Điều phối viên được hủy đơn vận chuyển'),
        (12, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q040', N'Cấp quyền', N'Điều phối viên được xem chi tiết đơn vận chuyển'),
        (13, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q041', N'Cấp quyền', N'Điều phối viên được thêm chi tiết đơn vận chuyển'),
        (14, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q042', N'Cấp quyền', N'Điều phối viên được sửa chi tiết đơn vận chuyển'),
        (15, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q043', N'Cấp quyền', N'Điều phối viên được xóa chi tiết đơn vận chuyển'),
        (16, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q044', N'Cấp quyền', N'Điều phối viên được xem lệnh điều phối'),
        (17, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q045', N'Cấp quyền', N'Điều phối viên được lập lệnh điều phối'),
        (18, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q046', N'Cấp quyền', N'Điều phối viên được sửa lệnh điều phối'),
        (19, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q047', N'Cấp quyền', N'Điều phối viên được cập nhật lệnh điều phối'),
        (20, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q048', N'Cấp quyền', N'Điều phối viên được xem lịch sử trạng thái đơn'),
        (21, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q049', N'Cấp quyền', N'Điều phối viên được xem phiếu phát sinh'),
        (22, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q050', N'Cấp quyền', N'Điều phối viên được thêm phiếu phát sinh'),
        (23, N'VT001', CAST(NULL AS NVARCHAR(10)), N'Q051', N'Cấp quyền', N'Điều phối viên được sửa phiếu phát sinh'),

        /* Vai trò tài xế - VT002 */
        (24, N'VT002', CAST(NULL AS NVARCHAR(10)), N'Q036', N'Cấp quyền', N'Tài xế được xem đơn vận chuyển'),
        (25, N'VT002', CAST(NULL AS NVARCHAR(10)), N'Q040', N'Cấp quyền', N'Tài xế được xem chi tiết đơn vận chuyển'),
        (26, N'VT002', CAST(NULL AS NVARCHAR(10)), N'Q044', N'Cấp quyền', N'Tài xế được xem lệnh điều phối'),
        (27, N'VT002', CAST(NULL AS NVARCHAR(10)), N'Q047', N'Cấp quyền', N'Tài xế được cập nhật trạng thái lệnh điều phối'),
        (28, N'VT002', CAST(NULL AS NVARCHAR(10)), N'Q048', N'Cấp quyền', N'Tài xế được xem lịch sử trạng thái đơn'),
        (29, N'VT002', CAST(NULL AS NVARCHAR(10)), N'Q049', N'Cấp quyền', N'Tài xế được xem phiếu phát sinh'),
        (30, N'VT002', CAST(NULL AS NVARCHAR(10)), N'Q050', N'Cấp quyền', N'Tài xế được ghi nhận phát sinh vận chuyển'),

        /* Vai trò kế toán - VT003 */
        (31, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q024', N'Cấp quyền', N'Kế toán được xem khách hàng'),
        (32, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q036', N'Cấp quyền', N'Kế toán được xem đơn vận chuyển'),
        (33, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q040', N'Cấp quyền', N'Kế toán được xem chi tiết đơn vận chuyển'),
        (34, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q052', N'Cấp quyền', N'Kế toán được xem phiếu thanh toán'),
        (35, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q053', N'Cấp quyền', N'Kế toán được thêm phiếu thanh toán'),
        (36, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q054', N'Cấp quyền', N'Kế toán được sửa phiếu thanh toán'),
        (37, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q055', N'Cấp quyền', N'Kế toán được xem hóa đơn'),
        (38, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q056', N'Cấp quyền', N'Kế toán được lập hóa đơn'),
        (39, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q057', N'Cấp quyền', N'Kế toán được sửa hóa đơn'),
        (40, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q058', N'Cấp quyền', N'Kế toán được xuất hóa đơn'),
        (41, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q059', N'Cấp quyền', N'Kế toán được xem loại phí vận chuyển'),
        (42, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q062', N'Cấp quyền', N'Kế toán được xem chi tiết hóa đơn'),
        (43, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q063', N'Cấp quyền', N'Kế toán được thêm chi tiết hóa đơn'),
        (44, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q064', N'Cấp quyền', N'Kế toán được sửa chi tiết hóa đơn'),
        (45, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q065', N'Cấp quyền', N'Kế toán được xóa chi tiết hóa đơn'),
        (46, N'VT003', CAST(NULL AS NVARCHAR(10)), N'Q067', N'Cấp quyền', N'Kế toán được xem báo cáo doanh thu'),

        /* Vai trò quản lý - VT004 */
        (47, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q001', N'Cấp quyền', N'Quản lý được xem chức vụ'),
        (48, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q004', N'Cấp quyền', N'Quản lý được xem nhân viên'),
        (49, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q007', N'Cấp quyền', N'Quản lý được xem tài khoản'),
        (50, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q011', N'Cấp quyền', N'Quản lý được xem vai trò hệ thống'),
        (51, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q014', N'Cấp quyền', N'Quản lý được xem quyền'),
        (52, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q017', N'Cấp quyền', N'Quản lý được xem phân quyền'),
        (53, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q021', N'Cấp quyền', N'Quản lý được xem loại khách hàng'),
        (54, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q024', N'Cấp quyền', N'Quản lý được xem khách hàng'),
        (55, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q027', N'Cấp quyền', N'Quản lý được xem loại phương tiện'),
        (56, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q030', N'Cấp quyền', N'Quản lý được xem phương tiện'),
        (57, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q033', N'Cấp quyền', N'Quản lý được xem loại hàng hóa'),
        (58, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q036', N'Cấp quyền', N'Quản lý được xem đơn vận chuyển'),
        (59, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q040', N'Cấp quyền', N'Quản lý được xem chi tiết đơn vận chuyển'),
        (60, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q044', N'Cấp quyền', N'Quản lý được xem lệnh điều phối'),
        (61, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q048', N'Cấp quyền', N'Quản lý được xem lịch sử trạng thái đơn'),
        (62, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q049', N'Cấp quyền', N'Quản lý được xem phiếu phát sinh'),
        (63, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q052', N'Cấp quyền', N'Quản lý được xem phiếu thanh toán'),
        (64, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q055', N'Cấp quyền', N'Quản lý được xem hóa đơn'),
        (65, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q059', N'Cấp quyền', N'Quản lý được xem loại phí vận chuyển'),
        (66, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q062', N'Cấp quyền', N'Quản lý được xem chi tiết hóa đơn'),
        (67, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q066', N'Cấp quyền', N'Quản lý được xem báo cáo đơn vận chuyển'),
        (68, N'VT004', CAST(NULL AS NVARCHAR(10)), N'Q067', N'Cấp quyền', N'Quản lý được xem báo cáo doanh thu'),

        /* Phân quyền riêng theo tài khoản */
        (200, NULL, N'TK005', N'Q024', N'Cấp quyền', N'Cấp riêng quyền xem khách hàng cho tài khoản tài xế TK005'),
        (201, NULL, N'TK005', N'Q030', N'Cấp quyền', N'Cấp riêng quyền xem phương tiện cho tài khoản tài xế TK005'),
        (202, NULL, N'TK006', N'Q024', N'Cấp quyền', N'Cấp riêng quyền xem khách hàng cho tài khoản tài xế TK006'),
        (203, NULL, N'TK025', N'Q054', N'Thu hồi quyền', N'Thu hồi riêng quyền sửa phiếu thanh toán của tài khoản TK025'),
        (204, NULL, N'TK026', N'Q058', N'Thu hồi quyền', N'Thu hồi riêng quyền xuất hóa đơn của tài khoản TK026'),
        (205, NULL, N'TK029', N'Q067', N'Thu hồi quyền', N'Thu hồi riêng quyền xem báo cáo doanh thu của tài khoản TK029')
    ) AS v(ThuTu, MaVT, MaTK, MaQuyen, LoaiPQ, GhiChuPQ)

    UNION ALL

    /* Vai trò quản trị viên - VT005: được cấp toàn bộ quyền */
    SELECT 
        500 + CAST(RIGHT(MaQuyen, 3) AS INT) AS ThuTu,
        N'VT005' AS MaVT,
        CAST(NULL AS NVARCHAR(10)) AS MaTK,
        MaQuyen,
        N'Cấp quyền' AS LoaiPQ,
        N'Quyền mặc định cho quản trị viên' AS GhiChuPQ
    FROM Quyen
)

INSERT INTO PhanQuyen (
    MaPQ, GhiChuPQ, NgayCapPQ, TrangThaiPQ, LoaiPQ,
    MaVT, MaTK, MaQuyen
)
SELECT
    N'PQ' + RIGHT(N'000' + CAST(ROW_NUMBER() OVER (ORDER BY ThuTu, MaVT, MaTK, MaQuyen) AS NVARCHAR(10)), 3) AS MaPQ,
    GhiChuPQ,
    '2026-06-01' AS NgayCapPQ,
    N'Hoạt động' AS TrangThaiPQ,
    LoaiPQ,
    MaVT,
    MaTK,
    MaQuyen
FROM DuLieuPQ;


/* =========================
   DỮ LIỆU MẪU NHÓM 2
   KHÁCH HÀNG - PHƯƠNG TIỆN - HÀNG HÓA
========================= */

/* =========================
   1. LOẠI KHÁCH HÀNG
========================= */

INSERT INTO LoaiKhachHang (MaLoaiKH, TenLoaiKH, MoTaLoaiKH)
VALUES
(N'LKH001', N'Khách hàng cá nhân', N'Khách hàng sử dụng dịch vụ vận chuyển với nhu cầu cá nhân.'),
(N'LKH002', N'Khách hàng doanh nghiệp', N'Khách hàng là công ty, cửa hàng hoặc đơn vị kinh doanh có nhu cầu vận chuyển thường xuyên.'),
(N'LKH003', N'Khách hàng hợp đồng', N'Khách hàng có thỏa thuận hợp tác hoặc sử dụng dịch vụ vận chuyển định kỳ.');


/* =========================
   2. KHÁCH HÀNG

========================= */


INSERT INTO KhachHang (
    MaKH, TenKH, SDTKH, EmailKH, DiaChiKH, MST, TrangThaiSuDung, MaLoaiKH
)
VALUES
/* Khách hàng cá nhân */
(N'KH001', N'Nguyễn Thị Thanh Hương', '0902847163', N'huong.nguyen@gmail.com', N'P. Bình Thạnh, TP.HCM', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH002', N'Trần Văn Khải', '0937152846', N'khai.tran@gmail.com', N'P. Thủ Đức, TP.HCM', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH003', N'Lê Minh Châu', '0864927513', N'chau.le@gmail.com', N'P. Tân Sơn Hòa, TP.HCM', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH004', N'Phạm Quốc Dũng', '0976381524', N'dung.pham@gmail.com', N'P. Trấn Biên, TP. Đồng Nai', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH005', N'Võ Ngọc Lan', '0915728463', N'lan.vo@gmail.com', N'P. Dĩ An, TP.HCM', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH006', N'Đặng Hoàng Phúc', '0884267195', N'phuc.dang@gmail.com', N'X. Đức Hòa, Tây Ninh', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH007', N'Bùi Thị Mỹ Linh', '0948172635', N'linh.bui@gmail.com', N'P. Gò Vấp, TP.HCM', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH008', N'Huỳnh Gia Bảo', '0906384712', N'bao.huynh@gmail.com', N'P. Thuận An, TP.HCM', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH009', N'Ngô Thanh Tâm', '0962758134', N'tam.ngo@gmail.com', N'P. Tân An, Tây Ninh', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH010', N'Đỗ Quang Huy', '0857394621', N'huy.do@gmail.com', N'P. Trung Mỹ Tây, TP.HCM', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH011', N'Lâm Bảo Trân', '0926845173', N'tran.lam@gmail.com', N'P. Phú Nhuận, TP.HCM', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH012', N'Trương Minh Khoa', '0984617253', N'khoa.truong@gmail.com', N'P. Thủ Dầu Một, TP.HCM', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH013', N'Hoàng Kim Ngân', '0907358462', N'ngan.hoang@gmail.com', N'X. Long Thành, TP. Đồng Nai', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH014', N'Phan Anh Kiệt', '0935827416', N'kiet.phan@gmail.com', N'P. Chánh Hưng, TP.HCM', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH015', N'Cao Thị Thu Trang', '0974265813', N'trang.cao@gmail.com', N'P. Lái Thiêu, TP.HCM', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH016', N'Mai Đức Thịnh', '0867352941', N'thinh.mai@gmail.com', N'X. Bình Chánh, TP.HCM', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH017', N'Đinh Ngọc Vy', '0918462735', N'vy.dinh@gmail.com', N'P. Long Khánh, TP. Đồng Nai', NULL, N'Đang sử dụng', N'LKH001'),
(N'KH018', N'Vũ Thành Nhân', '0885726491', N'nhan.vu@gmail.com', N'P. Tân Phú, TP.HCM', NULL, N'Ngừng sử dụng', N'LKH001'),

/* Khách hàng doanh nghiệp */
(N'KH019', N'Công ty TNHH Minh Phát Logistics', '0283815726', N'contact@minhphatlogistics.vn', N'P. Tân Hưng, TP.HCM', N'0314829576', N'Đang sử dụng', N'LKH002'),
(N'KH020', N'Công ty Cổ phần Thương mại An Khang', '0274396285', N'info@ankhangtrade.vn', N'P. Thủ Dầu Một, TP.HCM', N'3702948165', N'Đang sử dụng', N'LKH002'),
(N'KH021', N'Công ty TNHH Sản xuất Đại Nam', '0251628374', N'admin@dainammanufacturing.vn', N'P. Biên Hòa, TP. Đồng Nai', N'3605194827', N'Đang sử dụng', N'LKH002'),
(N'KH022', N'Công ty TNHH Thực phẩm Hưng Thịnh', '0283628194', N'sales@hungthinhfood.vn', N'P. Bình Tân, TP.HCM', N'0316847295', N'Đang sử dụng', N'LKH002'),
(N'KH023', N'Công ty Cổ phần Nội thất Gia Minh', '0283972516', N'contact@giaminhfurniture.vn', N'X. Bình Chánh, TP.HCM', N'0315726384', N'Đang sử dụng', N'LKH002'),
(N'KH024', N'Công ty TNHH Điện tử Nam Việt', '0274651837', N'info@namvietelectronic.vn', N'P. Dĩ An, TP.HCM', N'3706382519', N'Đang sử dụng', N'LKH002'),
(N'KH025', N'Công ty TNHH Bao bì Hoàng Gia', '0251736482', N'admin@hoanggiapack.vn', N'X. Long Thành, TP. Đồng Nai', N'3608274159', N'Đang sử dụng', N'LKH002'),
(N'KH026', N'Công ty Cổ phần May mặc Thiên Phúc', '0283847261', N'contact@thienphucgarment.vn', N'P. Tân Phú, TP.HCM', N'0312957468', N'Ngừng sử dụng', N'LKH002'),

/* Khách hàng hợp đồng */
(N'KH027', N'Siêu thị Mini An Phú', '0905163827', N'anphumart@gmail.com', N'P. Thủ Đức, TP.HCM', N'0317592846', N'Đang sử dụng', N'LKH003'),
(N'KH028', N'Cửa hàng Điện máy Hòa Bình', '0936842715', N'hoabinhdienmay@gmail.com', N'P. Tam Hiệp, TP. Đồng Nai', N'3602847195', N'Đang sử dụng', N'LKH003'),
(N'KH029', N'Kho hàng Gia Lộc', '0972516384', N'gialocwarehouse@gmail.com', N'P. Chánh Hưng, TP.HCM', N'0315847296', N'Đang sử dụng', N'LKH003'),
(N'KH030', N'Chuỗi cửa hàng Mẹ và Bé Bảo An', '0916385274', N'baoanstore@gmail.com', N'P. Dĩ An, TP.HCM', N'3704928165', N'Đang sử dụng', N'LKH003'),
(N'KH031', N'Cửa hàng Nội thất Mộc Xanh', '0867294153', N'mocxanhfurniture@gmail.com', N'X. Nhà Bè, TP.HCM', N'0312958174', N'Đang sử dụng', N'LKH003'),
(N'KH032', N'Đại lý Sữa Minh Tâm', '0946257183', N'minhtamdairy@gmail.com', N'P. Bình Tân, TP.HCM', N'0316842517', N'Đang sử dụng', N'LKH003'),
(N'KH033', N'Cửa hàng Thực phẩm Sạch GreenHome', '0908472615', N'greenhomefood@gmail.com', N'P. Bình Hòa, TP.HCM', N'3706384192', N'Đang sử dụng', N'LKH003'),
(N'KH034', N'Nhà sách Ánh Dương', '0984637251', N'anhduongbook@gmail.com', N'P. Chợ Lớn, TP.HCM', N'0318261947', N'Đang sử dụng', N'LKH003'),
(N'KH035', N'Đại lý Gạch men Phúc Lộc', '0925718463', N'phucloctiles@gmail.com', N'X. Long Thành, TP. Đồng Nai', N'3609472615', N'Đang sử dụng', N'LKH003'),
(N'KH036', N'Cửa hàng Thời trang Vân Anh', '0856384927', N'vananhfashion@gmail.com', N'P. Tân Phú, TP.HCM', N'0314729685', N'Đang sử dụng', N'LKH003'),
(N'KH037', N'Kho phân phối Bình An', '0962847513', N'binhanwarehouse@gmail.com', N'P. Tân An, Tây Ninh', N'1105274938', N'Đang sử dụng', N'LKH003'),
(N'KH038', N'Cửa hàng Gia dụng Hạnh Phúc', '0907351846', N'hanhphucgiadung@gmail.com', N'P. Bình Phú, TP.HCM', N'0316382947', N'Đang sử dụng', N'LKH003'),
(N'KH039', N'Đại lý Nước uống Thiên Thanh', '0935274168', N'thienthanhwater@gmail.com', N'P. Phú Lợi, TP.HCM', N'3708164925', N'Đang sử dụng', N'LKH003'),
(N'KH040', N'Cửa hàng Máy tính Nhật Minh', '0978462513', N'nhatminhpc@gmail.com', N'P. Long Khánh, TP. Đồng Nai', N'3602957481', N'Đang sử dụng', N'LKH003');

/* =========================
   3. LOẠI PHƯƠNG TIỆN
========================= */

INSERT INTO LoaiPhuongTien (MaLoaiPT, TenLoaiPT, MoTaLoaiPT)
VALUES
(N'LPT001', N'Xe tải 500kg', N'Phương tiện phù hợp với đơn hàng nhỏ, hàng nhẹ và giao trong nội thành.'),
(N'LPT002', N'Xe tải 1 tấn', N'Phương tiện dùng cho đơn hàng vừa, giao nội thành hoặc liên tỉnh gần.'),
(N'LPT003', N'Xe tải 2 tấn', N'Phương tiện phù hợp với hàng hóa có khối lượng trung bình.'),
(N'LPT004', N'Xe tải 5 tấn', N'Phương tiện dùng cho hàng nặng, hàng cồng kềnh hoặc vận chuyển liên tỉnh.'),
(N'LPT005', N'Xe container', N'Phương tiện dùng cho lô hàng lớn hoặc vận chuyển đường dài.');


/* =========================
   4. PHƯƠNG TIỆN
========================= */

INSERT INTO PhuongTien (
    MaPT, BienSoXe, TaiTrong, TinhTrangPT, MaLoaiPT
)
VALUES
/* Xe tải 500kg */
(N'PT001', N'51C-482.73', 500.00, N'Sẵn sàng', N'LPT001'),
(N'PT002', N'51C-739.26', 500.00, N'Sẵn sàng', N'LPT001'),
(N'PT003', N'60C-284.91', 500.00, N'Đang vận chuyển', N'LPT001'),
(N'PT004', N'61C-573.84', 500.00, N'Sẵn sàng', N'LPT001'),
(N'PT005', N'62C-816.37', 500.00, N'Bảo trì', N'LPT001'),

/* Xe tải 1 tấn */
(N'PT006', N'51D-628.45', 1000.00, N'Sẵn sàng', N'LPT002'),
(N'PT007', N'51D-194.76', 1000.00, N'Đang vận chuyển', N'LPT002'),
(N'PT008', N'60D-735.28', 1000.00, N'Sẵn sàng', N'LPT002'),
(N'PT009', N'61D-482.19', 1000.00, N'Sẵn sàng', N'LPT002'),
(N'PT010', N'62D-951.63', 1000.00, N'Sẵn sàng', N'LPT002'),
(N'PT011', N'51D-376.82', 1000.00, N'Bảo trì', N'LPT002'),

/* Xe tải 2 tấn */
(N'PT012', N'51E-648.27', 2000.00, N'Sẵn sàng', N'LPT003'),
(N'PT013', N'60E-291.74', 2000.00, N'Sẵn sàng', N'LPT003'),
(N'PT014', N'61E-837.15', 2000.00, N'Đang vận chuyển', N'LPT003'),
(N'PT015', N'62E-459.36', 2000.00, N'Sẵn sàng', N'LPT003'),
(N'PT016', N'51E-724.98', 2000.00, N'Sẵn sàng', N'LPT003'),
(N'PT017', N'60E-583.41', 2000.00, N'Sẵn sàng', N'LPT003'),
(N'PT018', N'61E-936.52', 2000.00, N'Bảo trì', N'LPT003'),

/* Xe tải 5 tấn */
(N'PT019', N'51F-274.69', 5000.00, N'Sẵn sàng', N'LPT004'),
(N'PT020', N'60F-819.43', 5000.00, N'Sẵn sàng', N'LPT004'),
(N'PT021', N'61F-536.72', 5000.00, N'Đang vận chuyển', N'LPT004'),
(N'PT022', N'62F-481.95', 5000.00, N'Sẵn sàng', N'LPT004'),
(N'PT023', N'51F-693.28', 5000.00, N'Sẵn sàng', N'LPT004'),
(N'PT024', N'60F-752.84', 5000.00, N'Sẵn sàng', N'LPT004'),
(N'PT025', N'61F-348.16', 5000.00, N'Bảo trì', N'LPT004'),

/* Xe container */
(N'PT026', N'51R-927.35', 15000.00, N'Sẵn sàng', N'LPT005'),
(N'PT027', N'60R-518.74', 15000.00, N'Sẵn sàng', N'LPT005'),
(N'PT028', N'61R-284.69', 15000.00, N'Đang vận chuyển', N'LPT005'),
(N'PT029', N'62R-739.51', 15000.00, N'Sẵn sàng', N'LPT005'),
(N'PT030', N'51R-846.27', 15000.00, N'Sẵn sàng', N'LPT005');


/* =========================
   5. LOẠI HÀNG HÓA
========================= */

INSERT INTO LoaiHangHoa (MaLoaiHH, TenLoaiHH, MoTaLoaiHH)
VALUES
(N'LHH001', N'Hàng tiêu dùng', N'Các mặt hàng tiêu dùng thông thường, đóng gói dễ vận chuyển.'),
(N'LHH002', N'Thực phẩm khô', N'Hàng thực phẩm khô, không yêu cầu bảo quản lạnh trong quá trình vận chuyển.'),
(N'LHH003', N'Hàng điện tử', N'Các mặt hàng điện tử cần được bảo quản và vận chuyển cẩn thận.'),
(N'LHH004', N'Hàng dễ vỡ', N'Các mặt hàng thủy tinh, gốm sứ hoặc sản phẩm có nguy cơ hư hỏng cao.'),
(N'LHH005', N'Hàng cồng kềnh', N'Hàng hóa có kích thước lớn, cần phương tiện phù hợp khi vận chuyển.'),
(N'LHH006', N'Hàng may mặc', N'Quần áo, vải vóc và các sản phẩm may mặc đóng kiện.'),
(N'LHH007', N'Văn phòng phẩm', N'Sách, giấy, hồ sơ và các sản phẩm văn phòng phẩm.'),
(N'LHH008', N'Vật liệu xây dựng', N'Các loại vật liệu xây dựng như gạch, thép, thiết bị và phụ kiện công trình.');

/* =========================
   DỮ LIỆU MẪU NHÓM 3
   ĐƠN VẬN CHUYỂN - CHI TIẾT ĐƠN - LỆNH ĐIỀU PHỐI
========================= */


/* =========================
   1. ĐƠN VẬN CHUYỂN

========================= */

INSERT INTO DonVanChuyen (
    MaDonVC, DiaChiLayHang, DiaChiGiao, TenNguoiNhan, SDTNguoiNhan,
    TGNhanDuKien, TGGiaoDuKien, PhiVC, YeuCauDacBiet,
    TrangThaiDon, NgayTao, MaKH, MaNV
)
VALUES
(N'DVC001', N'P. Bình Thạnh, TP.HCM', N'P. Thủ Đức, TP.HCM', N'Nguyễn Hoàng Phúc', '0905824716', '2026-06-02 08:00:00', '2026-06-02 11:30:00', 180000.00, N'Gọi trước khi giao hàng.', N'Hoàn thành', '2026-06-01 15:20:00', N'KH001', N'NV001'),
(N'DVC002', N'P. Tân Sơn Hòa, TP.HCM', N'P. Gò Vấp, TP.HCM', N'Trần Minh Khoa', '0937462815', '2026-06-02 09:00:00', '2026-06-02 12:00:00', 160000.00, NULL, N'Hoàn thành', '2026-06-01 16:10:00', N'KH002', N'NV002'),
(N'DVC003', N'P. Tân Hưng, TP.HCM', N'P. Bình Tân, TP.HCM', N'Lê Thị Kim Ngân', '0865274913', '2026-06-03 08:30:00', '2026-06-03 13:00:00', 220000.00, N'Hàng dễ vỡ, cần xếp riêng.', N'Hoàn thành', '2026-06-02 10:15:00', N'KH003', N'NV003'),
(N'DVC004', N'P. Biên Hòa, TP. Đồng Nai', N'P. Trung Mỹ Tây, TP.HCM', N'Phạm Quốc Hưng', '0972846153', '2026-06-03 10:00:00', '2026-06-03 17:00:00', 650000.00, NULL, N'Hoàn thành', '2026-06-02 11:40:00', N'KH004', N'NV004'),
(N'DVC005', N'P. Dĩ An, TP.HCM', N'P. Tân Phú, TP.HCM', N'Võ Minh Tâm', '0916382745', '2026-06-04 08:00:00', '2026-06-04 15:00:00', 520000.00, N'Nhận hàng tại kho bảo vệ.', N'Hoàn thành', '2026-06-03 09:25:00', N'KH005', N'NV001'),
(N'DVC006', N'X. Đức Hòa, Tây Ninh', N'X. Bình Chánh, TP.HCM', N'Đặng Văn Lâm', '0885173462', '2026-06-04 09:30:00', '2026-06-04 16:00:00', 580000.00, NULL, N'Hoàn thành', '2026-06-03 13:05:00', N'KH006', N'NV002'),
(N'DVC007', N'P. Gò Vấp, TP.HCM', N'P. Chợ Lớn, TP.HCM', N'Bùi Ngọc Hân', '0942516387', '2026-06-05 08:00:00', '2026-06-05 11:00:00', 150000.00, NULL, N'Hoàn thành', '2026-06-04 14:30:00', N'KH007', N'NV003'),
(N'DVC008', N'P. Thuận An, TP.HCM', N'P. Thủ Đức, TP.HCM', N'Huỳnh Gia Khánh', '0907461825', '2026-06-05 10:00:00', '2026-06-05 16:30:00', 540000.00, N'Giao trong giờ hành chính.', N'Hoàn thành', '2026-06-04 15:45:00', N'KH008', N'NV004'),
(N'DVC009', N'P. Tân An, Tây Ninh', N'P. Chánh Hưng, TP.HCM', N'Ngô Thanh Sơn', '0963847512', '2026-06-06 07:30:00', '2026-06-06 15:30:00', 720000.00, NULL, N'Hoàn thành', '2026-06-05 09:15:00', N'KH009', N'NV001'),
(N'DVC010', N'P. Trung Mỹ Tây, TP.HCM', N'P. Dĩ An, TP.HCM', N'Đỗ Hoàng Nam', '0856724913', '2026-06-06 09:00:00', '2026-06-06 14:30:00', 430000.00, NULL, N'Hoàn thành', '2026-06-05 10:40:00', N'KH010', N'NV002'),

(N'DVC011', N'P. Phú Nhuận, TP.HCM', N'P. Tân Sơn Hòa, TP.HCM', N'Lâm Thu Uyên', '0925716843', '2026-06-07 08:00:00', '2026-06-07 11:30:00', 170000.00, NULL, N'Hoàn thành', '2026-06-06 08:55:00', N'KH011', N'NV003'),
(N'DVC012', N'P. Thủ Dầu Một, TP.HCM', N'P. Biên Hòa, TP. Đồng Nai', N'Trương Hoàng Minh', '0987352416', '2026-06-07 09:30:00', '2026-06-07 17:30:00', 850000.00, N'Hàng nặng, cần xe nâng tại điểm nhận.', N'Hoàn thành', '2026-06-06 11:25:00', N'KH012', N'NV004'),
(N'DVC013', N'X. Long Thành, TP. Đồng Nai', N'P. Tân Hưng, TP.HCM', N'Hoàng Gia Bảo', '0904637285', '2026-06-08 08:30:00', '2026-06-08 15:00:00', 630000.00, NULL, N'Hoàn thành', '2026-06-07 13:30:00', N'KH013', N'NV001'),
(N'DVC014', N'P. Chánh Hưng, TP.HCM', N'P. Bình Tân, TP.HCM', N'Phan Đức Anh', '0936284715', '2026-06-08 09:00:00', '2026-06-08 12:30:00', 190000.00, NULL, N'Hoàn thành', '2026-06-07 15:00:00', N'KH014', N'NV002'),
(N'DVC015', N'P. Thuận An, TP.HCM', N'P. Tân Phú, TP.HCM', N'Cao Minh Quân', '0973852614', '2026-06-09 08:00:00', '2026-06-09 14:30:00', 520000.00, N'Hàng đóng thùng, không để ướt.', N'Hoàn thành', '2026-06-08 09:10:00', N'KH015', N'NV003'),
(N'DVC016', N'X. Bình Chánh, TP.HCM', N'P. Tân An, Tây Ninh', N'Mai Hoàng Duy', '0862947351', '2026-06-09 10:00:00', '2026-06-09 17:00:00', 610000.00, NULL, N'Hoàn thành', '2026-06-08 10:45:00', N'KH016', N'NV004'),
(N'DVC017', N'P. Long Khánh, TP. Đồng Nai', N'P. Biên Hòa, TP. Đồng Nai', N'Đinh Khánh Vy', '0917253846', '2026-06-10 07:30:00', '2026-06-10 13:30:00', 500000.00, NULL, N'Hoàn thành', '2026-06-09 14:20:00', N'KH017', N'NV001'),
(N'DVC018', N'P. Tân Hưng, TP.HCM', N'P. Thuận An, TP.HCM', N'Nguyễn Quốc Việt', '0905726184', '2026-06-10 09:00:00', '2026-06-10 15:30:00', 560000.00, NULL, N'Hoàn thành', '2026-06-09 15:35:00', N'KH019', N'NV002'),
(N'DVC019', N'P. Thủ Dầu Một, TP.HCM', N'P. Bình Thạnh, TP.HCM', N'Trần Anh Tuấn', '0936845271', '2026-06-11 08:00:00', '2026-06-11 16:00:00', 690000.00, N'Có phụ xe hỗ trợ bốc xếp.', N'Hoàn thành', '2026-06-10 08:40:00', N'KH020', N'NV003'),
(N'DVC020', N'P. Biên Hòa, TP. Đồng Nai', N'P. Dĩ An, TP.HCM', N'Lê Đức Mạnh', '0867351842', '2026-06-11 10:00:00', '2026-06-11 17:30:00', 780000.00, NULL, N'Hoàn thành', '2026-06-10 11:30:00', N'KH021', N'NV004'),

(N'DVC021', N'P. Bình Tân, TP.HCM', N'P. Thủ Đức, TP.HCM', N'Phạm Văn Hòa', '0975384261', '2026-06-12 08:00:00', '2026-06-12 13:00:00', 280000.00, NULL, N'Hoàn thành', '2026-06-11 09:05:00', N'KH022', N'NV001'),
(N'DVC022', N'X. Bình Chánh, TP.HCM', N'X. Long Thành, TP. Đồng Nai', N'Võ Minh Nhật', '0918462537', '2026-06-12 09:30:00', '2026-06-12 17:00:00', 760000.00, N'Hàng cồng kềnh, cần cố định dây chằng.', N'Hoàn thành', '2026-06-11 14:25:00', N'KH023', N'NV002'),
(N'DVC023', N'P. Dĩ An, TP.HCM', N'P. Chợ Lớn, TP.HCM', N'Đặng Quang Huy', '0886251743', '2026-06-13 08:30:00', '2026-06-13 14:30:00', 510000.00, NULL, N'Hoàn thành', '2026-06-12 10:50:00', N'KH024', N'NV003'),
(N'DVC024', N'X. Long Thành, TP. Đồng Nai', N'P. Tân Phú, TP.HCM', N'Bùi Hoàng Khang', '0947163825', '2026-06-13 09:00:00', '2026-06-13 16:30:00', 700000.00, NULL, N'Hoàn thành', '2026-06-12 15:10:00', N'KH025', N'NV004'),

(N'DVC025', N'P. Thủ Đức, TP.HCM', N'P. Biên Hòa, TP. Đồng Nai', N'Huỳnh Minh Khôi', '0906284715', '2026-06-14 08:00:00', '2026-06-14 15:30:00', 640000.00, N'Cập nhật khi đến điểm giao.', N'Đang vận chuyển', '2026-06-13 09:20:00', N'KH027', N'NV001'),
(N'DVC026', N'P. Biên Hòa, TP. Đồng Nai', N'P. Chánh Hưng, TP.HCM', N'Ngô Gia Hân', '0967352814', '2026-06-14 09:00:00', '2026-06-14 17:00:00', 690000.00, NULL, N'Đang vận chuyển', '2026-06-13 11:35:00', N'KH028', N'NV002'),
(N'DVC027', N'P. Chánh Hưng, TP.HCM', N'P. Dĩ An, TP.HCM', N'Đỗ Thành Nhân', '0854716293', '2026-06-15 08:30:00', '2026-06-15 14:30:00', 490000.00, NULL, N'Đang vận chuyển', '2026-06-14 08:50:00', N'KH029', N'NV003'),
(N'DVC028', N'P. Dĩ An, TP.HCM', N'P. Bình Tân, TP.HCM', N'Nguyễn Bảo An', '0935276841', '2026-06-15 09:30:00', '2026-06-15 16:00:00', 530000.00, N'Hàng giao cho cửa hàng, có ký nhận.', N'Đang vận chuyển', '2026-06-14 10:40:00', N'KH030', N'NV004'),
(N'DVC029', N'X. Nhà Bè, TP.HCM', N'P. Tân Hưng, TP.HCM', N'Lê Hoàng Phúc', '0864185732', '2026-06-16 08:00:00', '2026-06-16 12:00:00', 230000.00, NULL, N'Đang vận chuyển', '2026-06-15 09:30:00', N'KH031', N'NV001'),
(N'DVC030', N'P. Bình Tân, TP.HCM', N'P. Thuận An, TP.HCM', N'Phạm Minh Đức', '0972846315', '2026-06-16 10:00:00', '2026-06-16 16:30:00', 550000.00, NULL, N'Đang vận chuyển', '2026-06-15 13:25:00', N'KH032', N'NV002'),
(N'DVC031', N'P. Thuận An, TP.HCM', N'P. Tân An, Tây Ninh', N'Võ Thanh Bình', '0915638472', '2026-06-17 08:30:00', '2026-06-17 18:00:00', 980000.00, N'Tuyến liên tỉnh gần, cần kiểm tra chứng từ.', N'Đang vận chuyển', '2026-06-16 11:15:00', N'KH033', N'NV003'),

(N'DVC032', N'P. Chợ Lớn, TP.HCM', N'P. Phú Nhuận, TP.HCM', N'Đặng Minh Châu', '0884726195', '2026-06-17 09:00:00', '2026-06-17 13:00:00', 210000.00, NULL, N'Đang điều phối', '2026-06-16 14:30:00', N'KH034', N'NV004'),
(N'DVC033', N'X. Long Thành, TP. Đồng Nai', N'P. Thủ Đức, TP.HCM', N'Bùi Quốc Huy', '0948352617', '2026-06-18 08:00:00', '2026-06-18 15:00:00', 660000.00, NULL, N'Đang điều phối', '2026-06-17 09:40:00', N'KH035', N'NV001'),
(N'DVC034', N'P. Tân Phú, TP.HCM', N'P. Dĩ An, TP.HCM', N'Huỳnh Thanh Tùng', '0905728461', '2026-06-18 09:00:00', '2026-06-18 15:30:00', 520000.00, N'Hàng cần giao đúng hẹn.', N'Đang điều phối', '2026-06-17 10:35:00', N'KH036', N'NV002'),
(N'DVC035', N'P. Tân An, Tây Ninh', N'X. Bình Chánh, TP.HCM', N'Ngô Bảo Trâm', '0962845173', '2026-06-19 08:30:00', '2026-06-19 16:00:00', 620000.00, NULL, N'Đang điều phối', '2026-06-18 08:45:00', N'KH037', N'NV003'),
(N'DVC036', N'P. Bình Phú, TP.HCM', N'P. Tân Sơn Hòa, TP.HCM', N'Đỗ Phương Nam', '0857362491', '2026-06-19 09:30:00', '2026-06-19 13:00:00', 180000.00, NULL, N'Đang điều phối', '2026-06-18 12:20:00', N'KH038', N'NV004'),
(N'DVC037', N'P. Phú Lợi, TP.HCM', N'P. Bình Thạnh, TP.HCM', N'Lê Khánh Toàn', '0936418527', '2026-06-20 08:00:00', '2026-06-20 16:00:00', 700000.00, NULL, N'Đang điều phối', '2026-06-19 09:10:00', N'KH039', N'NV001'),

(N'DVC038', N'P. Long Khánh, TP. Đồng Nai', N'P. Trung Mỹ Tây, TP.HCM', N'Nguyễn Thành Đạt', '0975182463', '2026-06-20 09:00:00', '2026-06-20 17:30:00', 820000.00, N'Khách yêu cầu hủy do đổi lịch.', N'Đã hủy', '2026-06-19 10:00:00', N'KH040', N'NV002'),
(N'DVC039', N'P. Biên Hòa, TP. Đồng Nai', N'P. Tân Hưng, TP.HCM', N'Trần Gia Lộc', '0865729314', '2026-06-21 08:00:00', '2026-06-21 15:00:00', 680000.00, N'Không liên hệ được người nhận.', N'Đã hủy', '2026-06-20 09:25:00', N'KH019', N'NV003'),
(N'DVC040', N'P. Bình Tân, TP.HCM', N'P. Tân An, Tây Ninh', N'Phạm Ngọc Hà', '0918352746', '2026-06-21 09:30:00', '2026-06-21 17:30:00', 740000.00, N'Khách thay đổi phương án vận chuyển.', N'Đã hủy', '2026-06-20 13:10:00', N'KH020', N'NV004');


/* =========================
   2. CHI TIẾT ĐƠN VẬN CHUYỂN
 
========================= */

INSERT INTO ChiTietDVC (
    MaDonVC, MaLoaiHH, KhoiLuong, SoKien, DonViTinh, MoTaHH
)
VALUES
(N'DVC001', N'LHH001', 35.50, 5, N'Thùng', N'Hàng tiêu dùng đóng thùng carton.'),
(N'DVC001', N'LHH007', 18.00, 3, N'Thùng', N'Văn phòng phẩm giao nội thành.'),
(N'DVC002', N'LHH006', 42.00, 6, N'Kiện', N'Hàng may mặc đóng kiện.'),
(N'DVC003', N'LHH004', 28.50, 4, N'Thùng', N'Hàng dễ vỡ cần xếp riêng.'),
(N'DVC003', N'LHH001', 20.00, 2, N'Thùng', N'Hàng tiêu dùng đi kèm.'),
(N'DVC004', N'LHH005', 320.00, 8, N'Kiện', N'Hàng cồng kềnh vận chuyển liên tỉnh gần.'),
(N'DVC005', N'LHH003', 75.00, 5, N'Thùng', N'Thiết bị điện tử đóng hộp.'),
(N'DVC005', N'LHH004', 22.00, 2, N'Thùng', N'Linh kiện dễ vỡ.'),
(N'DVC006', N'LHH002', 180.00, 12, N'Thùng', N'Thực phẩm khô đóng thùng.'),
(N'DVC007', N'LHH007', 26.00, 4, N'Thùng', N'Sách và giấy văn phòng.'),
(N'DVC008', N'LHH001', 95.00, 9, N'Thùng', N'Hàng tiêu dùng cho cửa hàng.'),
(N'DVC008', N'LHH006', 60.00, 5, N'Kiện', N'Quần áo đóng kiện.'),
(N'DVC009', N'LHH008', 850.00, 20, N'Bao', N'Vật liệu xây dựng đóng bao.'),
(N'DVC010', N'LHH003', 110.00, 6, N'Thùng', N'Hàng điện tử cần bảo quản.'),
(N'DVC010', N'LHH007', 25.00, 3, N'Thùng', N'Hồ sơ và văn phòng phẩm.'),

(N'DVC011', N'LHH006', 38.00, 5, N'Kiện', N'Hàng may mặc giao nội thành.'),
(N'DVC012', N'LHH008', 1200.00, 25, N'Kiện', N'Vật liệu xây dựng khối lượng lớn.'),
(N'DVC012', N'LHH005', 240.00, 4, N'Kiện', N'Thiết bị cồng kềnh.'),
(N'DVC013', N'LHH002', 210.00, 15, N'Thùng', N'Nông sản khô đóng thùng.'),
(N'DVC014', N'LHH001', 50.00, 7, N'Thùng', N'Hàng tiêu dùng giao cửa hàng.'),
(N'DVC015', N'LHH003', 82.00, 6, N'Thùng', N'Thiết bị điện tử nhỏ.'),
(N'DVC015', N'LHH004', 35.00, 3, N'Thùng', N'Hàng dễ vỡ đi kèm.'),
(N'DVC016', N'LHH002', 260.00, 18, N'Thùng', N'Thực phẩm khô giao đại lý.'),
(N'DVC017', N'LHH005', 300.00, 6, N'Kiện', N'Hàng cồng kềnh vận chuyển nội tỉnh.'),
(N'DVC018', N'LHH006', 180.00, 12, N'Kiện', N'Hàng may mặc đóng kiện.'),
(N'DVC018', N'LHH001', 75.00, 6, N'Thùng', N'Hàng tiêu dùng đi kèm.'),
(N'DVC019', N'LHH008', 980.00, 22, N'Kiện', N'Vật liệu xây dựng.'),
(N'DVC020', N'LHH005', 450.00, 10, N'Kiện', N'Thiết bị công nghiệp cồng kềnh.'),
(N'DVC020', N'LHH003', 90.00, 5, N'Thùng', N'Linh kiện điện tử.'),

(N'DVC021', N'LHH001', 120.00, 10, N'Thùng', N'Hàng tiêu dùng đóng gói.'),
(N'DVC022', N'LHH005', 600.00, 12, N'Kiện', N'Nội thất cồng kềnh.'),
(N'DVC022', N'LHH004', 45.00, 4, N'Thùng', N'Đồ trang trí dễ vỡ.'),
(N'DVC023', N'LHH003', 150.00, 8, N'Thùng', N'Hàng điện tử.'),
(N'DVC024', N'LHH008', 760.00, 18, N'Kiện', N'Thép và phụ kiện công trình.'),
(N'DVC024', N'LHH005', 180.00, 4, N'Kiện', N'Thiết bị xây dựng cồng kềnh.'),
(N'DVC025', N'LHH001', 140.00, 12, N'Thùng', N'Hàng tiêu dùng giao siêu thị mini.'),
(N'DVC026', N'LHH003', 95.00, 7, N'Thùng', N'Điện máy đóng thùng.'),
(N'DVC026', N'LHH004', 40.00, 4, N'Thùng', N'Linh kiện dễ vỡ.'),
(N'DVC027', N'LHH005', 380.00, 8, N'Kiện', N'Hàng kho cồng kềnh.'),
(N'DVC028', N'LHH001', 160.00, 14, N'Thùng', N'Hàng mẹ và bé.'),
(N'DVC028', N'LHH002', 70.00, 6, N'Thùng', N'Thực phẩm khô đi kèm.'),
(N'DVC029', N'LHH005', 290.00, 5, N'Kiện', N'Nội thất gỗ.'),
(N'DVC030', N'LHH002', 310.00, 20, N'Thùng', N'Sữa và thực phẩm khô.'),
(N'DVC030', N'LHH001', 80.00, 7, N'Thùng', N'Hàng tiêu dùng đi kèm.'),

(N'DVC031', N'LHH002', 420.00, 25, N'Thùng', N'Thực phẩm sạch đóng thùng.'),
(N'DVC032', N'LHH007', 90.00, 15, N'Thùng', N'Sách và văn phòng phẩm.'),
(N'DVC033', N'LHH008', 950.00, 28, N'Kiện', N'Gạch men và vật liệu xây dựng.'),
(N'DVC033', N'LHH005', 160.00, 3, N'Kiện', N'Kệ trưng bày cồng kềnh.'),
(N'DVC034', N'LHH006', 130.00, 10, N'Kiện', N'Hàng thời trang đóng kiện.'),
(N'DVC035', N'LHH001', 260.00, 18, N'Thùng', N'Hàng tiêu dùng cho kho phân phối.'),
(N'DVC035', N'LHH002', 140.00, 10, N'Thùng', N'Thực phẩm khô đi kèm.'),
(N'DVC036', N'LHH001', 75.00, 7, N'Thùng', N'Hàng gia dụng.'),
(N'DVC037', N'LHH002', 360.00, 24, N'Thùng', N'Nước uống đóng thùng.'),
(N'DVC037', N'LHH001', 90.00, 6, N'Thùng', N'Hàng tiêu dùng đi kèm.'),
(N'DVC038', N'LHH003', 120.00, 8, N'Thùng', N'Máy tính và thiết bị phụ kiện.'),
(N'DVC039', N'LHH002', 280.00, 18, N'Thùng', N'Hàng khô đóng thùng.'),
(N'DVC039', N'LHH004', 35.00, 3, N'Thùng', N'Hàng dễ vỡ.'),
(N'DVC040', N'LHH001', 300.00, 20, N'Thùng', N'Hàng tiêu dùng vận chuyển liên tỉnh gần.'),
(N'DVC040', N'LHH007', 55.00, 6, N'Thùng', N'Chứng từ và vật tư văn phòng đi kèm.');


/* =========================
   3. LỆNH ĐIỀU PHỐI
 
========================= */

INSERT INTO LenhDieuPhoi (
    MaLenhDP, TGLapLenh, TGPhanCong, TrangThaiLenh,
    TGXacNhan, LyDoTuChoi, MaDonVC, MaNV, MaPT
)
VALUES
(N'LDP001', '2026-06-01 16:00:00', '2026-06-02 07:30:00', N'Hoàn thành', '2026-06-02 07:45:00', NULL, N'DVC001', N'NV005', N'PT001'),
(N'LDP002', '2026-06-01 16:30:00', '2026-06-02 08:30:00', N'Hoàn thành', '2026-06-02 08:45:00', NULL, N'DVC002', N'NV006', N'PT002'),
(N'LDP003', '2026-06-02 11:00:00', '2026-06-03 08:00:00', N'Hoàn thành', '2026-06-03 08:15:00', NULL, N'DVC003', N'NV007', N'PT003'),
(N'LDP004', '2026-06-02 12:20:00', '2026-06-03 09:30:00', N'Hoàn thành', '2026-06-03 09:45:00', NULL, N'DVC004', N'NV008', N'PT012'),
(N'LDP005', '2026-06-03 10:00:00', '2026-06-04 07:30:00', N'Hoàn thành', '2026-06-04 07:45:00', NULL, N'DVC005', N'NV009', N'PT006'),
(N'LDP006', '2026-06-03 13:40:00', '2026-06-04 09:00:00', N'Hoàn thành', '2026-06-04 09:15:00', NULL, N'DVC006', N'NV010', N'PT013'),
(N'LDP007', '2026-06-04 15:00:00', '2026-06-05 07:30:00', N'Hoàn thành', '2026-06-05 07:42:00', NULL, N'DVC007', N'NV011', N'PT004'),
(N'LDP008', '2026-06-04 16:10:00', '2026-06-05 09:30:00', N'Hoàn thành', '2026-06-05 09:45:00', NULL, N'DVC008', N'NV012', N'PT008'),
(N'LDP009', '2026-06-05 10:00:00', '2026-06-06 07:00:00', N'Hoàn thành', '2026-06-06 07:20:00', NULL, N'DVC009', N'NV013', N'PT019'),
(N'LDP010', '2026-06-05 11:10:00', '2026-06-06 08:30:00', N'Hoàn thành', '2026-06-06 08:45:00', NULL, N'DVC010', N'NV014', N'PT009'),

(N'LDP011', '2026-06-06 09:30:00', '2026-06-07 07:30:00', N'Hoàn thành', '2026-06-07 07:50:00', NULL, N'DVC011', N'NV015', N'PT010'),
(N'LDP012', '2026-06-06 12:00:00', '2026-06-07 09:00:00', N'Hoàn thành', '2026-06-07 09:20:00', NULL, N'DVC012', N'NV016', N'PT020'),
(N'LDP013', '2026-06-07 14:00:00', '2026-06-08 08:00:00', N'Hoàn thành', '2026-06-08 08:15:00', NULL, N'DVC013', N'NV017', N'PT014'),
(N'LDP014', '2026-06-07 15:30:00', '2026-06-08 08:30:00', N'Hoàn thành', '2026-06-08 08:45:00', NULL, N'DVC014', N'NV018', N'PT015'),
(N'LDP015', '2026-06-08 10:00:00', '2026-06-09 07:30:00', N'Hoàn thành', '2026-06-09 07:45:00', NULL, N'DVC015', N'NV019', N'PT016'),
(N'LDP016', '2026-06-08 11:30:00', '2026-06-09 09:30:00', N'Hoàn thành', '2026-06-09 09:50:00', NULL, N'DVC016', N'NV020', N'PT021'),
(N'LDP017', '2026-06-09 15:00:00', '2026-06-10 07:00:00', N'Hoàn thành', '2026-06-10 07:20:00', NULL, N'DVC017', N'NV021', N'PT017'),
(N'LDP018', '2026-06-09 16:00:00', '2026-06-10 08:30:00', N'Hoàn thành', '2026-06-10 08:45:00', NULL, N'DVC018', N'NV022', N'PT022'),
(N'LDP019', '2026-06-10 09:30:00', '2026-06-11 07:30:00', N'Hoàn thành', '2026-06-11 07:45:00', NULL, N'DVC019', N'NV023', N'PT023'),
(N'LDP020', '2026-06-10 12:00:00', '2026-06-11 09:30:00', N'Hoàn thành', '2026-06-11 09:45:00', NULL, N'DVC020', N'NV024', N'PT024'),

(N'LDP021', '2026-06-11 09:30:00', '2026-06-12 07:30:00', N'Hoàn thành', '2026-06-12 07:45:00', NULL, N'DVC021', N'NV005', N'PT006'),
(N'LDP022', '2026-06-11 15:00:00', '2026-06-12 09:00:00', N'Hoàn thành', '2026-06-12 09:15:00', NULL, N'DVC022', N'NV006', N'PT026'),
(N'LDP023', '2026-06-12 11:30:00', '2026-06-13 08:00:00', N'Hoàn thành', '2026-06-13 08:15:00', NULL, N'DVC023', N'NV007', N'PT007'),
(N'LDP024', '2026-06-12 16:00:00', '2026-06-13 08:30:00', N'Hoàn thành', '2026-06-13 08:45:00', NULL, N'DVC024', N'NV008', N'PT027'),

(N'LDP025', '2026-06-13 10:00:00', '2026-06-14 07:30:00', N'Đang thực hiện', '2026-06-14 07:45:00', NULL, N'DVC025', N'NV009', N'PT028'),
(N'LDP026', '2026-06-13 12:00:00', '2026-06-14 08:30:00', N'Đang thực hiện', '2026-06-14 08:45:00', NULL, N'DVC026', N'NV010', N'PT029'),
(N'LDP027', '2026-06-14 09:30:00', '2026-06-15 08:00:00', N'Đang thực hiện', '2026-06-15 08:20:00', NULL, N'DVC027', N'NV011', N'PT008'),
(N'LDP028', '2026-06-14 11:00:00', '2026-06-15 09:00:00', N'Đang thực hiện', '2026-06-15 09:15:00', NULL, N'DVC028', N'NV012', N'PT030'),
(N'LDP029', '2026-06-15 10:00:00', '2026-06-16 07:30:00', N'Đang thực hiện', '2026-06-16 07:45:00', NULL, N'DVC029', N'NV013', N'PT001'),
(N'LDP030', '2026-06-15 14:00:00', '2026-06-16 09:30:00', N'Đang thực hiện', '2026-06-16 09:45:00', NULL, N'DVC030', N'NV014', N'PT009'),
(N'LDP031', '2026-06-16 12:00:00', '2026-06-17 08:00:00', N'Đang thực hiện', '2026-06-17 08:15:00', NULL, N'DVC031', N'NV015', N'PT019'),

(N'LDP032', '2026-06-16 15:00:00', '2026-06-17 08:30:00', N'Đã tiếp nhận', '2026-06-17 08:45:00', NULL, N'DVC032', N'NV016', N'PT002'),
(N'LDP033', '2026-06-17 10:00:00', '2026-06-18 07:30:00', N'Đã tiếp nhận', '2026-06-18 07:45:00', NULL, N'DVC033', N'NV017', N'PT020'),
(N'LDP034', '2026-06-17 11:30:00', '2026-06-18 08:30:00', N'Đã tiếp nhận', '2026-06-18 08:45:00', NULL, N'DVC034', N'NV018', N'PT010'),
(N'LDP035', '2026-06-18 09:30:00', '2026-06-19 08:00:00', N'Chờ xác nhận', NULL, NULL, N'DVC035', N'NV019', N'PT013'),
(N'LDP036', '2026-06-18 13:00:00', '2026-06-19 09:00:00', N'Chờ xác nhận', NULL, NULL, N'DVC036', N'NV020', N'PT004'),
(N'LDP037', '2026-06-19 10:00:00', '2026-06-20 07:30:00', N'Chờ xác nhận', NULL, NULL, N'DVC037', N'NV021', N'PT021'),

(N'LDP038', '2026-06-19 11:00:00', '2026-06-20 08:30:00', N'Đã hủy', NULL, NULL, N'DVC038', N'NV022', N'PT024'),
(N'LDP039', '2026-06-20 10:00:00', '2026-06-21 07:30:00', N'Từ chối', '2026-06-21 07:50:00', N'Tài xế báo xe gặp sự cố kỹ thuật.', N'DVC039', N'NV023', N'PT012'),
(N'LDP040', '2026-06-20 14:00:00', '2026-06-21 09:00:00', N'Đã hủy', NULL, NULL, N'DVC040', N'NV024', N'PT016');


/* =========================
   DỮ LIỆU MẪU NHÓM 4
   LỊCH SỬ TRẠNG THÁI ĐƠN - PHIẾU PHÁT SINH VẬN CHUYỂN
========================= */


/* =========================
   1. LỊCH SỬ TRẠNG THÁI ĐƠN
   Tự sinh dữ liệu dựa trên trạng thái của DonVanChuyen
========================= */

DECLARE @SoBatDau INT;

SELECT @SoBatDau = ISNULL(
    MAX(TRY_CAST(SUBSTRING(MaLichSu, 3, 10) AS INT)),
    0
)
FROM LichSuTrangThaiDon
WHERE MaLichSu LIKE N'LS%';

;WITH DuLieuLS AS (
    /* Bước 1: Chuyển đơn sang điều phối */
    SELECT
        1 AS ThuTu,
        MaDonVC,
        N'Mới tạo' AS TrangThaiCu,
        N'Đang điều phối' AS TrangThaiMoi,
        DATEADD(MINUTE, 30, NgayTao) AS TGCapNhat,
        N'Đơn được chuyển sang bước điều phối tài xế và phương tiện.' AS GhiChu,
        MaNV
    FROM DonVanChuyen
    WHERE TrangThaiDon IN (N'Đang điều phối', N'Đang vận chuyển', N'Hoàn thành', N'Đã hủy')

    UNION ALL

    /* Bước 2: Đã phân công tài xế và phương tiện */
    SELECT
        2 AS ThuTu,
        dvc.MaDonVC,
        N'Đang điều phối' AS TrangThaiCu,
        N'Đã phân công' AS TrangThaiMoi,
        ISNULL(ldp.TGPhanCong, DATEADD(MINUTE, 45, dvc.NgayTao)) AS TGCapNhat,
        N'Tài xế và phương tiện đã được phân công thực hiện đơn vận chuyển.' AS GhiChu,
        dvc.MaNV
    FROM DonVanChuyen dvc
    JOIN LenhDieuPhoi ldp ON dvc.MaDonVC = ldp.MaDonVC
    WHERE ldp.TrangThaiLenh IN (
        N'Chờ xác nhận',
        N'Đã tiếp nhận',
        N'Từ chối',
        N'Đang thực hiện',
        N'Hoàn thành',
        N'Đã hủy'
    )

    UNION ALL

    /* Bước 3: Tài xế nhận chuyến */
    SELECT
        3 AS ThuTu,
        dvc.MaDonVC,
        N'Đã phân công' AS TrangThaiCu,
        N'Đã nhận chuyến' AS TrangThaiMoi,
        ldp.TGXacNhan AS TGCapNhat,
        N'Tài xế đã xác nhận tiếp nhận nhiệm vụ vận chuyển.' AS GhiChu,
        ldp.MaNV
    FROM DonVanChuyen dvc
    JOIN LenhDieuPhoi ldp ON dvc.MaDonVC = ldp.MaDonVC
    WHERE ldp.TGXacNhan IS NOT NULL
      AND ldp.TrangThaiLenh IN (N'Đã tiếp nhận', N'Đang thực hiện', N'Hoàn thành')

    UNION ALL

    /* Bước 4: Đang đến điểm nhận */
    SELECT
        4 AS ThuTu,
        dvc.MaDonVC,
        N'Đã nhận chuyến' AS TrangThaiCu,
        N'Đang đến điểm nhận' AS TrangThaiMoi,
        DATEADD(MINUTE, -60, dvc.TGNhanDuKien) AS TGCapNhat,
        N'Tài xế bắt đầu di chuyển đến địa điểm nhận hàng.' AS GhiChu,
        ldp.MaNV
    FROM DonVanChuyen dvc
    JOIN LenhDieuPhoi ldp ON dvc.MaDonVC = ldp.MaDonVC
    WHERE dvc.TrangThaiDon IN (N'Đang vận chuyển', N'Hoàn thành')
      AND ldp.TrangThaiLenh IN (N'Đã tiếp nhận', N'Đang thực hiện', N'Hoàn thành')

    UNION ALL

    /* Bước 5: Đã nhận hàng */
    SELECT
        5 AS ThuTu,
        dvc.MaDonVC,
        N'Đang đến điểm nhận' AS TrangThaiCu,
        N'Đã nhận hàng' AS TrangThaiMoi,
        dvc.TGNhanDuKien AS TGCapNhat,
        N'Tài xế đã nhận hàng tại địa điểm nhận hàng.' AS GhiChu,
        ldp.MaNV
    FROM DonVanChuyen dvc
    JOIN LenhDieuPhoi ldp ON dvc.MaDonVC = ldp.MaDonVC
    WHERE dvc.TrangThaiDon IN (N'Đang vận chuyển', N'Hoàn thành')
      AND ldp.TrangThaiLenh IN (N'Đã tiếp nhận', N'Đang thực hiện', N'Hoàn thành')

    UNION ALL

    /* Bước 6: Đang giao hàng */
    SELECT
        6 AS ThuTu,
        dvc.MaDonVC,
        N'Đã nhận hàng' AS TrangThaiCu,
        N'Đang giao hàng' AS TrangThaiMoi,
        DATEADD(MINUTE, 30, dvc.TGNhanDuKien) AS TGCapNhat,
        N'Tài xế đang vận chuyển hàng hóa đến địa điểm giao hàng.' AS GhiChu,
        ldp.MaNV
    FROM DonVanChuyen dvc
    JOIN LenhDieuPhoi ldp ON dvc.MaDonVC = ldp.MaDonVC
    WHERE dvc.TrangThaiDon IN (N'Đang vận chuyển', N'Hoàn thành')
      AND ldp.TrangThaiLenh IN (N'Đã tiếp nhận', N'Đang thực hiện', N'Hoàn thành')

    UNION ALL

    /* Bước 7: Hoàn thành */
    SELECT
        7 AS ThuTu,
        dvc.MaDonVC,
        N'Đang giao hàng' AS TrangThaiCu,
        N'Hoàn thành' AS TrangThaiMoi,
        dvc.TGGiaoDuKien AS TGCapNhat,
        N'Đơn vận chuyển được xác nhận hoàn tất trên hệ thống.' AS GhiChu,
        ldp.MaNV
    FROM DonVanChuyen dvc
    JOIN LenhDieuPhoi ldp ON dvc.MaDonVC = ldp.MaDonVC
    WHERE dvc.TrangThaiDon = N'Hoàn thành'
      AND ldp.TrangThaiLenh = N'Hoàn thành'

    UNION ALL

    /* Trường hợp đơn bị hủy */
    SELECT
        8 AS ThuTu,
        MaDonVC,
        N'Đang điều phối' AS TrangThaiCu,
        N'Đã hủy' AS TrangThaiMoi,
        DATEADD(HOUR, 2, NgayTao) AS TGCapNhat,
        N'Đơn vận chuyển đã được hủy do khách thay đổi nhu cầu hoặc phát sinh không thể tiếp tục.' AS GhiChu,
        MaNV
    FROM DonVanChuyen
    WHERE TrangThaiDon = N'Đã hủy'
)

INSERT INTO LichSuTrangThaiDon (
    MaLichSu,
    TrangThaiCu,
    TrangThaiMoi,
    TGCapNhat,
    GhiChu,
    MaDonVC,
    MaNV
)
SELECT
    N'LS' + RIGHT(N'00000' + CAST(@SoBatDau + ROW_NUMBER() OVER (ORDER BY MaDonVC, ThuTu) AS NVARCHAR(10)), 5) AS MaLichSu,
    TrangThaiCu,
    TrangThaiMoi,
    TGCapNhat,
    GhiChu,
    MaDonVC,
    MaNV
FROM DuLieuLS
WHERE TGCapNhat IS NOT NULL;

/* =========================
   2. PHIẾU PHÁT SINH VẬN CHUYỂN

========================= */

INSERT INTO PhieuPhatSinhVC (
    MaPhieuPS, TGPhatSinh, NoiDungPhatSinh, HuongXuLy,
    KetQuaXuLy, TrangThaiXuLy, MaDonVC, MaLenhDP, MaNV
)
VALUES
(N'PS001', '2026-06-03 10:20:00', N'Hàng dễ vỡ cần kiểm tra lại khi giao.', N'Tài xế liên hệ người nhận để kiểm tra tình trạng hàng.', N'Hàng được giao đầy đủ, không phát sinh hư hỏng.', N'Đã xử lý', N'DVC003', N'LDP003', N'NV007'),
(N'PS002', '2026-06-04 12:15:00', N'Khách yêu cầu thay đổi giờ nhận hàng.', N'Điều phối viên xác nhận lại thời gian giao với tài xế.', N'Đơn được giao theo thời gian mới.', N'Đã xử lý', N'DVC005', N'LDP005', N'NV009'),
(N'PS003', '2026-06-04 13:40:00', N'Tuyến đường bị ùn tắc trong quá trình giao hàng.', N'Tài xế cập nhật tình hình và đổi sang tuyến đường khác.', N'Đơn được giao trong ngày.', N'Đã xử lý', N'DVC006', N'LDP006', N'NV010'),
(N'PS004', '2026-06-06 09:10:00', N'Điểm nhận thiếu người hỗ trợ bốc xếp.', N'Điều phối viên liên hệ khách hàng bố trí thêm nhân sự.', N'Hàng được bốc xếp và vận chuyển bình thường.', N'Đã xử lý', N'DVC009', N'LDP009', N'NV013'),
(N'PS005', '2026-06-07 10:30:00', N'Hàng nặng cần kiểm tra thiết bị nâng tại điểm nhận.', N'Tài xế xác nhận với kho trước khi nhận hàng.', N'Việc nhận hàng hoàn tất sau khi kho bố trí xe nâng.', N'Đã xử lý', N'DVC012', N'LDP012', N'NV016'),
(N'PS006', '2026-06-09 09:25:00', N'Một số thùng hàng có dấu hiệu bị ướt bên ngoài.', N'Tài xế tách riêng thùng hàng và báo lại điều phối viên.', N'Khách xác nhận hàng bên trong không bị ảnh hưởng.', N'Đã xử lý', N'DVC015', N'LDP015', N'NV019'),
(N'PS007', '2026-06-09 15:20:00', N'Khách yêu cầu giao hàng vào cuối giờ chiều.', N'Điều phối viên điều chỉnh thời điểm giao phù hợp.', N'Đơn được giao đúng yêu cầu của khách.', N'Đã xử lý', N'DVC016', N'LDP016', N'NV020'),
(N'PS008', '2026-06-11 08:35:00', N'Phụ xe hỗ trợ bốc xếp đến trễ.', N'Điều phối viên liên hệ nhân sự hỗ trợ thay thế.', N'Việc bốc xếp hoàn tất và không ảnh hưởng đến giao hàng.', N'Đã xử lý', N'DVC019', N'LDP019', N'NV023'),
(N'PS009', '2026-06-11 11:45:00', N'Cần kiểm tra lại mã hàng trước khi giao.', N'Tài xế đối chiếu thông tin hàng hóa với phiếu giao.', N'Thông tin hàng hóa khớp với đơn vận chuyển.', N'Đã xử lý', N'DVC020', N'LDP020', N'NV024'),
(N'PS010', '2026-06-12 10:10:00', N'Hàng cồng kềnh cần bổ sung dây chằng.', N'Tài xế sử dụng dây chằng bổ sung trước khi di chuyển.', N'Hàng được cố định an toàn trong quá trình vận chuyển.', N'Đã xử lý', N'DVC022', N'LDP022', N'NV006'),

(N'PS011', '2026-06-13 13:25:00', N'Tuyến đường giao hàng bị chậm do mật độ xe cao.', N'Tài xế thông báo thời gian giao dự kiến cho khách.', N'Khách đồng ý thời gian giao mới.', N'Đã xử lý', N'DVC024', N'LDP024', N'NV008'),
(N'PS012', '2026-06-14 11:00:00', N'Người nhận yêu cầu hẹn lại thời điểm giao.', N'Điều phối viên liên hệ khách để xác nhận thời gian mới.', NULL, N'Đang xử lý', N'DVC025', N'LDP025', N'NV009'),
(N'PS013', '2026-06-14 14:20:00', N'Thời tiết mưa lớn ảnh hưởng đến việc giao hàng.', N'Tài xế tạm dừng và cập nhật lại tiến độ cho điều phối viên.', NULL, N'Đang xử lý', N'DVC026', N'LDP026', N'NV010'),
(N'PS014', '2026-06-15 09:30:00', N'Kho chưa chuẩn bị đủ chứng từ giao hàng.', N'Điều phối viên yêu cầu khách bổ sung chứng từ.', NULL, N'Đang xử lý', N'DVC027', N'LDP027', N'NV011'),
(N'PS015', '2026-06-15 10:40:00', N'Cửa hàng yêu cầu ký nhận riêng từng kiện hàng.', N'Tài xế ghi chú lại yêu cầu khi giao hàng.', NULL, N'Đang xử lý', N'DVC028', N'LDP028', N'NV012'),
(N'PS016', '2026-06-16 08:50:00', N'Xe vào điểm nhận hàng chậm hơn dự kiến.', N'Tài xế báo lại điều phối viên và cập nhật thời gian nhận.', NULL, N'Đang xử lý', N'DVC029', N'LDP029', N'NV013'),
(N'PS017', '2026-06-16 11:15:00', N'Khách yêu cầu kiểm đếm hàng trước khi giao.', N'Tài xế phối hợp với kho để kiểm đếm số kiện.', NULL, N'Đang xử lý', N'DVC030', N'LDP030', N'NV014'),
(N'PS018', '2026-06-17 09:45:00', N'Tuyến giao liên tỉnh cần kiểm tra lại chứng từ.', N'Điều phối viên kiểm tra thông tin đơn và chứng từ liên quan.', NULL, N'Đang xử lý', N'DVC031', N'LDP031', N'NV015'),
(N'PS019', '2026-06-17 10:20:00', N'Chưa xác nhận được điểm giao hàng cuối cùng.', N'Điều phối viên liên hệ khách hàng để xác nhận địa chỉ giao.', NULL, N'Chưa xử lý', N'DVC032', N'LDP032', N'NV016'),
(N'PS020', '2026-06-18 09:10:00', N'Phương tiện dự kiến chưa sẵn sàng.', N'Điều phối viên kiểm tra phương tiện thay thế.', NULL, N'Đang xử lý', N'DVC033', N'LDP033', N'NV017'),

(N'PS021', '2026-06-18 10:45:00', N'Khách yêu cầu giao hàng đúng khung giờ đã hẹn.', N'Điều phối viên ưu tiên lịch giao cho đơn này.', NULL, N'Đang xử lý', N'DVC034', N'LDP034', N'NV018'),
(N'PS022', '2026-06-19 09:00:00', N'Chưa đủ thông tin người nhận hàng.', N'Điều phối viên liên hệ khách để bổ sung thông tin.', NULL, N'Chưa xử lý', N'DVC035', N'LDP035', N'NV019'),
(N'PS023', '2026-06-19 10:25:00', N'Khách yêu cầu giao hàng vào buổi sáng.', N'Điều phối viên điều chỉnh lại thời gian phân công.', NULL, N'Đang xử lý', N'DVC036', N'LDP036', N'NV020'),
(N'PS024', '2026-06-20 08:15:00', N'Cần kiểm tra lại số kiện trước khi nhận hàng.', N'Tài xế yêu cầu kho xác nhận lại số kiện.', NULL, N'Chưa xử lý', N'DVC037', N'LDP037', N'NV021'),
(N'PS025', '2026-06-20 09:20:00', N'Khách yêu cầu hủy đơn do đổi lịch vận chuyển.', N'Điều phối viên xác nhận yêu cầu hủy với khách.', N'Đơn và lệnh điều phối được hủy.', N'Đã xử lý', N'DVC038', N'LDP038', N'NV022'),
(N'PS026', '2026-06-21 08:00:00', N'Tài xế báo phương tiện gặp sự cố kỹ thuật.', N'Điều phối viên ghi nhận và dừng thực hiện đơn.', N'Đơn bị hủy do không thể tiếp tục vận chuyển.', N'Đã xử lý', N'DVC039', N'LDP039', N'NV023'),
(N'PS027', '2026-06-21 09:40:00', N'Khách thay đổi phương án vận chuyển.', N'Điều phối viên xác nhận lại với khách và hủy đơn.', N'Đơn vận chuyển được hủy theo yêu cầu khách.', N'Đã xử lý', N'DVC040', N'LDP040', N'NV024'),
(N'PS028', '2026-06-02 10:15:00', N'Người nhận không nghe máy ở lần liên hệ đầu.', N'Tài xế liên hệ lại sau 15 phút.', N'Người nhận xác nhận và nhận hàng thành công.', N'Đã xử lý', N'DVC001', N'LDP001', N'NV005'),
(N'PS029', '2026-06-05 10:35:00', N'Điểm giao thiếu người nhận hàng.', N'Tài xế chờ xác minh thông tin từ khách.', N'Khách cử người nhận thay và ký nhận hàng.', N'Đã xử lý', N'DVC007', N'LDP007', N'NV011'),
(N'PS030', '2026-06-10 13:20:00', N'Hàng cần giao trong giờ hành chính.', N'Điều phối viên nhắc tài xế ưu tiên thời gian giao.', N'Hàng được giao trong khung giờ yêu cầu.', N'Đã xử lý', N'DVC018', N'LDP018', N'NV022');


/* =========================
   DỮ LIỆU MẪU NHÓM 5
   LOẠI PHÍ - THANH TOÁN - HÓA ĐƠN - CHI TIẾT HÓA ĐƠN
========================= */


/* Nếu đã chạy nhầm dữ liệu nhóm 5 trước đó thì xóa theo thứ tự này */
DELETE FROM ChiTietHDVC;
DELETE FROM HoaDonVanChuyen;
DELETE FROM PhieuThanhToanVC;
DELETE FROM LoaiPhiVanChuyen;


/* =========================
   1. LOẠI PHÍ VẬN CHUYỂN
========================= */

INSERT INTO LoaiPhiVanChuyen (
    MaLoaiPhi, TenLoaiPhi, MoTaLoaiPhi
)
VALUES
(N'LP001', N'Phí vận chuyển chính', N'Khoản phí chính của dịch vụ vận chuyển.'),
(N'LP002', N'Phụ phí bốc xếp', N'Khoản phí phát sinh khi cần hỗ trợ bốc xếp hàng hóa.'),
(N'LP003', N'Phụ phí chờ hàng', N'Khoản phí phát sinh khi tài xế phải chờ nhận hoặc giao hàng.'),
(N'LP004', N'Phụ phí giao ngoài giờ', N'Khoản phí phát sinh khi giao hàng ngoài khung giờ thông thường.'),
(N'LP005', N'Phụ phí hàng cồng kềnh', N'Khoản phí áp dụng cho hàng hóa có kích thước lớn hoặc khó sắp xếp.'),
(N'LP006', N'Phụ phí đường dài', N'Khoản phí áp dụng cho tuyến vận chuyển có quãng đường dài.'),
(N'LP007', N'Phụ phí phát sinh', N'Khoản phí phát sinh thêm trong quá trình vận chuyển.'),
(N'LP008', N'Phí hoàn chứng từ', N'Khoản phí liên quan đến việc hoàn trả hoặc xử lý chứng từ giao nhận.');


/* =========================
   2. DỮ LIỆU TRUNG GIAN

========================= */

USE QuanLyDieuPhoiVanChuyen_HIVE;
GO

DROP TABLE IF EXISTS #DuLieuNhom5;

CREATE TABLE #DuLieuNhom5 (
    STT INT,
    MaPhieuTT NVARCHAR(10),
    MaDonVC NVARCHAR(10),
    NgayTT DATETIME,
    HinhThucTT NVARCHAR(50),
    MaGiaoDich NVARCHAR(50) NULL,
    MaNVTT NVARCHAR(10),
    MaHD NVARCHAR(10),
    NgayPhatHanh DATETIME,
    MaNVHD NVARCHAR(10),
    PhiChinh DECIMAL(18,2),
    MaLoaiPhiPhu NVARCHAR(10),
    PhiPhu DECIMAL(18,2)
);

INSERT INTO #DuLieuNhom5 (
    STT, MaPhieuTT, MaDonVC, NgayTT, HinhThucTT, MaGiaoDich, MaNVTT,
    MaHD, NgayPhatHanh, MaNVHD, PhiChinh, MaLoaiPhiPhu, PhiPhu
)
VALUES
(1,  N'PTT001', N'DVC001', CONVERT(DATETIME, '2026-06-02T16:20:00', 126), N'Chuyển khoản', N'GD250602001', N'NV025', N'HD001', CONVERT(DATETIME, '2026-06-02T16:45:00', 126), N'NV025', 850000,  N'LP002', 50000),
(2,  N'PTT002', N'DVC002', CONVERT(DATETIME, '2026-06-03T11:30:00', 126), N'Tiền mặt', NULL, N'NV026', N'HD002', CONVERT(DATETIME, '2026-06-03T11:55:00', 126), N'NV026', 1250000, N'LP006', 100000),
(3,  N'PTT003', N'DVC003', CONVERT(DATETIME, '2026-06-03T15:40:00', 126), N'Chuyển khoản', N'GD250603003', N'NV027', N'HD003', CONVERT(DATETIME, '2026-06-03T16:05:00', 126), N'NV027', 780000,  N'LP008', 30000),
(4,  N'PTT004', N'DVC004', CONVERT(DATETIME, '2026-06-04T10:20:00', 126), N'Chuyển khoản', N'GD250604004', N'NV025', N'HD004', CONVERT(DATETIME, '2026-06-04T10:50:00', 126), N'NV025', 950000,  N'LP003', 70000),
(5,  N'PTT005', N'DVC005', CONVERT(DATETIME, '2026-06-04T17:15:00', 126), N'Tiền mặt', NULL, N'NV026', N'HD005', CONVERT(DATETIME, '2026-06-04T17:40:00', 126), N'NV026', 1400000, N'LP005', 120000),
(6,  N'PTT006', N'DVC006', CONVERT(DATETIME, '2026-06-05T14:30:00', 126), N'Chuyển khoản', N'GD250605006', N'NV027', N'HD006', CONVERT(DATETIME, '2026-06-05T15:00:00', 126), N'NV027', 1100000, N'LP002', 80000),
(7,  N'PTT007', N'DVC007', CONVERT(DATETIME, '2026-06-05T16:10:00', 126), N'Chuyển khoản', N'GD250605007', N'NV025', N'HD007', CONVERT(DATETIME, '2026-06-05T16:35:00', 126), N'NV025', 680000,  N'LP008', 40000),
(8,  N'PTT008', N'DVC008', CONVERT(DATETIME, '2026-06-06T12:45:00', 126), N'Tiền mặt', NULL, N'NV026', N'HD008', CONVERT(DATETIME, '2026-06-06T13:10:00', 126), N'NV026', 1550000, N'LP006', 150000),
(9,  N'PTT009', N'DVC009', CONVERT(DATETIME, '2026-06-06T15:30:00', 126), N'Chuyển khoản', N'GD250606009', N'NV027', N'HD009', CONVERT(DATETIME, '2026-06-06T15:55:00', 126), N'NV027', 1020000, N'LP003', 60000),
(10, N'PTT010', N'DVC010', CONVERT(DATETIME, '2026-06-07T10:40:00', 126), N'Chuyển khoản', N'GD250607010', N'NV025', N'HD010', CONVERT(DATETIME, '2026-06-07T11:05:00', 126), N'NV025', 890000,  N'LP002', 50000),
(11, N'PTT011', N'DVC011', CONVERT(DATETIME, '2026-06-07T14:20:00', 126), N'Tiền mặt', NULL, N'NV026', N'HD011', CONVERT(DATETIME, '2026-06-07T14:45:00', 126), N'NV026', 1320000, N'LP006', 90000),
(12, N'PTT012', N'DVC012', CONVERT(DATETIME, '2026-06-08T11:50:00', 126), N'Chuyển khoản', N'GD250608012', N'NV027', N'HD012', CONVERT(DATETIME, '2026-06-08T12:15:00', 126), N'NV027', 760000,  N'LP008', 30000),
(13, N'PTT013', N'DVC013', CONVERT(DATETIME, '2026-06-08T16:00:00', 126), N'Chuyển khoản', N'GD250608013', N'NV025', N'HD013', CONVERT(DATETIME, '2026-06-08T16:25:00', 126), N'NV025', 980000, N'LP003', 70000),
(14, N'PTT014', N'DVC014', CONVERT(DATETIME, '2026-06-09T10:35:00', 126), N'Tiền mặt', NULL, N'NV026', N'HD014', CONVERT(DATETIME, '2026-06-09T11:00:00', 126), N'NV026', 1180000, N'LP002', 80000),
(15, N'PTT015', N'DVC015', CONVERT(DATETIME, '2026-06-09T15:15:00', 126), N'Chuyển khoản', N'GD250609015', N'NV027', N'HD015', CONVERT(DATETIME, '2026-06-09T15:40:00', 126), N'NV027', 1450000, N'LP005', 130000),
(16, N'PTT016', N'DVC016', CONVERT(DATETIME, '2026-06-10T11:25:00', 126), N'Chuyển khoản', N'GD250610016', N'NV025', N'HD016', CONVERT(DATETIME, '2026-06-10T11:50:00', 126), N'NV025', 910000, N'LP003', 60000),
(17, N'PTT017', N'DVC017', CONVERT(DATETIME, '2026-06-10T16:30:00', 126), N'Tiền mặt', NULL, N'NV026', N'HD017', CONVERT(DATETIME, '2026-06-10T16:55:00', 126), N'NV026', 1230000, N'LP006', 90000),
(18, N'PTT018', N'DVC018', CONVERT(DATETIME, '2026-06-11T10:20:00', 126), N'Chuyển khoản', N'GD250611018', N'NV027', N'HD018', CONVERT(DATETIME, '2026-06-11T10:45:00', 126), N'NV027', 870000, N'LP008', 40000),
(19, N'PTT019', N'DVC019', CONVERT(DATETIME, '2026-06-11T14:40:00', 126), N'Chuyển khoản', N'GD250611019', N'NV025', N'HD019', CONVERT(DATETIME, '2026-06-11T15:05:00', 126), N'NV025', 1600000, N'LP006', 150000),
(20, N'PTT020', N'DVC020', CONVERT(DATETIME, '2026-06-12T09:50:00', 126), N'Tiền mặt', NULL, N'NV026', N'HD020', CONVERT(DATETIME, '2026-06-12T10:15:00', 126), N'NV026', 1040000, N'LP004', 70000),
(21, N'PTT021', N'DVC021', CONVERT(DATETIME, '2026-06-12T15:25:00', 126), N'Chuyển khoản', N'GD250612021', N'NV027', N'HD021', CONVERT(DATETIME, '2026-06-12T15:50:00', 126), N'NV027', 720000, N'LP008', 30000),
(22, N'PTT022', N'DVC022', CONVERT(DATETIME, '2026-06-13T11:10:00', 126), N'Chuyển khoản', N'GD250613022', N'NV025', N'HD022', CONVERT(DATETIME, '2026-06-13T11:35:00', 126), N'NV025', 1360000, N'LP005', 100000),
(23, N'PTT023', N'DVC023', CONVERT(DATETIME, '2026-06-13T16:20:00', 126), N'Tiền mặt', NULL, N'NV026', N'HD023', CONVERT(DATETIME, '2026-06-13T16:45:00', 126), N'NV026', 990000, N'LP003', 60000),
(24, N'PTT024', N'DVC024', CONVERT(DATETIME, '2026-06-14T10:30:00', 126), N'Chuyển khoản', N'GD250614024', N'NV027', N'HD024', CONVERT(DATETIME, '2026-06-14T10:55:00', 126), N'NV027', 1150000, N'LP002', 80000);

/* =========================
   3. PHIẾU THANH TOÁN VẬN CHUYỂN
   Có MaKH lấy từ DonVanChuyen
========================= */
/* =========================
   ĐOẠN 4. PHIẾU THANH TOÁN VẬN CHUYỂN
   Chỉ tạo phiếu cho đơn vận chuyển đã Hoàn thành
========================= */

INSERT INTO PhieuThanhToanVC (
    MaPhieuTT,
    SoTienTT,
    HinhThucTT,
    NgayTT,
    TrangThaiTT,
    MaGiaoDich,
    MaDonVC,
    MaNV,
    MaKH
)
SELECT
    dl.MaPhieuTT,
    CAST(ROUND((dl.PhiChinh + dl.PhiPhu) * 1.08, 2) AS DECIMAL(18,2)) AS SoTienTT,
    dl.HinhThucTT,
    dl.NgayTT,
    N'Đã thanh toán' AS TrangThaiTT,
    dl.MaGiaoDich,
    dl.MaDonVC,
    dl.MaNVTT,
    dvc.MaKH
FROM #DuLieuNhom5 dl
JOIN DonVanChuyen dvc
    ON dl.MaDonVC = dvc.MaDonVC
WHERE dvc.TrangThaiDon = N'Hoàn thành'
  AND NOT EXISTS (
        SELECT 1
        FROM PhieuThanhToanVC p
        WHERE p.MaPhieuTT = dl.MaPhieuTT
           OR p.MaDonVC = dl.MaDonVC
  );
  SELECT
    p.MaPhieuTT,
    p.MaDonVC,
    d.TrangThaiDon,
    kh.TenKH,
    p.SoTienTT,
    p.HinhThucTT,
    p.NgayTT,
    p.TrangThaiTT,
    p.MaGiaoDich
FROM PhieuThanhToanVC p
JOIN DonVanChuyen d
    ON p.MaDonVC = d.MaDonVC
JOIN KhachHang kh
    ON p.MaKH = kh.MaKH
ORDER BY p.MaPhieuTT;
/* =========================
   4. HÓA ĐƠN VẬN CHUYỂN
   Không insert TongTienSauThue vì đây là cột computed
========================= */
/* =========================
   ĐOẠN 5. HÓA ĐƠN VẬN CHUYỂN
   Chỉ tạo hóa đơn cho phiếu thanh toán hợp lệ
========================= */

INSERT INTO HoaDonVanChuyen (
    MaHD,
    NgayPhatHanh,
    TongTienTruocThue,
    ThueVAT,
    TrangThaiHD,
    MaPhieuTT,
    MaNV,
    MaKH
)
SELECT
    dl.MaHD,
    dl.NgayPhatHanh,
    dl.PhiChinh + dl.PhiPhu AS TongTienTruocThue,
    8.00 AS ThueVAT,
    N'Đã phát hành' AS TrangThaiHD,
    dl.MaPhieuTT,
    dl.MaNVHD,
    ptt.MaKH
FROM #DuLieuNhom5 dl
JOIN PhieuThanhToanVC ptt
    ON dl.MaPhieuTT = ptt.MaPhieuTT
JOIN DonVanChuyen dvc
    ON ptt.MaDonVC = dvc.MaDonVC
WHERE dvc.TrangThaiDon = N'Hoàn thành'
  AND NOT EXISTS (
        SELECT 1
        FROM HoaDonVanChuyen hd
        WHERE hd.MaHD = dl.MaHD
           OR hd.MaPhieuTT = dl.MaPhieuTT
  );
  INSERT INTO ChiTietHDVC (
    MaHD,
    MaLoaiPhi,
    SoLuong,
    DonGia
)
SELECT
    hd.MaHD,
    N'LP001' AS MaLoaiPhi,
    1 AS SoLuong,
    hd.TongTienTruocThue AS DonGia
FROM HoaDonVanChuyen hd
JOIN PhieuThanhToanVC p
    ON hd.MaPhieuTT = p.MaPhieuTT
JOIN DonVanChuyen d
    ON p.MaDonVC = d.MaDonVC
WHERE d.TrangThaiDon = N'Hoàn thành'
  AND NOT EXISTS (
        SELECT 1
        FROM ChiTietHDVC ct
        WHERE ct.MaHD = hd.MaHD
          AND ct.MaLoaiPhi = N'LP001'
  );
  
USE QuanLyDieuPhoiVanChuyen_HIVE;
GO


USE QuanLyDieuPhoiVanChuyen_HIVE;
GO

BEGIN TRY
    BEGIN TRANSACTION;

    /* =====================================================
       1. LẤY HOẶC TẠO 5 NHÂN VIÊN + TÀI KHOẢN TEST
    ===================================================== */

    DECLARE @NV_DieuPhoi NVARCHAR(10);
    DECLARE @NV_TaiXe NVARCHAR(10);
    DECLARE @NV_KeToan NVARCHAR(10);
    DECLARE @NV_QuanLy NVARCHAR(10);
    DECLARE @NV_Admin NVARCHAR(10);

    SELECT @NV_DieuPhoi = MaNV FROM TaiKhoan WHERE TenDangNhap = N'dieuphoivien';
    SELECT @NV_TaiXe    = MaNV FROM TaiKhoan WHERE TenDangNhap = N'taixe';
    SELECT @NV_KeToan   = MaNV FROM TaiKhoan WHERE TenDangNhap = N'ketoan';
    SELECT @NV_QuanLy   = MaNV FROM TaiKhoan WHERE TenDangNhap = N'quanly';
    SELECT @NV_Admin    = MaNV FROM TaiKhoan WHERE TenDangNhap = N'admin';


    /* Điều phối viên test */
    IF @NV_DieuPhoi IS NULL
    BEGIN
        SET @NV_DieuPhoi = N'NV901';

        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = @NV_DieuPhoi)
        BEGIN
            INSERT INTO NhanVien (
                MaNV, HoTenNV, CCCDNV, SDTNV, EmailNV, TrangThaiLV,
                SoBangLai, HangBangLai, NgayHHBangLai, MaCV
            )
            VALUES (
                @NV_DieuPhoi, N'Test Điều phối viên', '090000000901', '0900000901',
                N'test.dieuphoi@hive.vn', N'Đang làm việc',
                NULL, NULL, NULL, N'CV001'
            );
        END;

        IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = N'dieuphoivien')
           AND NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE MaNV = @NV_DieuPhoi)
        BEGIN
            INSERT INTO TaiKhoan (
                MaTK, TenDangNhap, MatKhau, TrangThaiTK, MaVT, MaNV
            )
            VALUES (
                N'TK901', N'dieuphoivien', N'123', N'Đang hoạt động', N'VT001', @NV_DieuPhoi
            );
        END;
    END;


    /* Tài xế test */
    IF @NV_TaiXe IS NULL
    BEGIN
        SET @NV_TaiXe = N'NV902';

        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = @NV_TaiXe)
        BEGIN
            INSERT INTO NhanVien (
                MaNV, HoTenNV, CCCDNV, SDTNV, EmailNV, TrangThaiLV,
                SoBangLai, HangBangLai, NgayHHBangLai, MaCV
            )
            VALUES (
                @NV_TaiXe, N'Test Tài xế', '090000000902', '0900000902',
                N'test.taixe@hive.vn', N'Đang làm việc',
                N'BLXTEST902', N'C', '2030-12-31', N'CV002'
            );
        END;

        IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = N'taixe')
           AND NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE MaNV = @NV_TaiXe)
        BEGIN
            INSERT INTO TaiKhoan (
                MaTK, TenDangNhap, MatKhau, TrangThaiTK, MaVT, MaNV
            )
            VALUES (
                N'TK902', N'taixe', N'123', N'Đang hoạt động', N'VT002', @NV_TaiXe
            );
        END;
    END;


    /* Kế toán test */
    IF @NV_KeToan IS NULL
    BEGIN
        SET @NV_KeToan = N'NV903';

        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = @NV_KeToan)
        BEGIN
            INSERT INTO NhanVien (
                MaNV, HoTenNV, CCCDNV, SDTNV, EmailNV, TrangThaiLV,
                SoBangLai, HangBangLai, NgayHHBangLai, MaCV
            )
            VALUES (
                @NV_KeToan, N'Test Kế toán', '090000000903', '0900000903',
                N'test.ketoan@hive.vn', N'Đang làm việc',
                NULL, NULL, NULL, N'CV003'
            );
        END;

        IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = N'ketoan')
           AND NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE MaNV = @NV_KeToan)
        BEGIN
            INSERT INTO TaiKhoan (
                MaTK, TenDangNhap, MatKhau, TrangThaiTK, MaVT, MaNV
            )
            VALUES (
                N'TK903', N'ketoan', N'123', N'Đang hoạt động', N'VT003', @NV_KeToan
            );
        END;
    END;


    /* Quản lý test */
    IF @NV_QuanLy IS NULL
    BEGIN
        SET @NV_QuanLy = N'NV904';

        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = @NV_QuanLy)
        BEGIN
            INSERT INTO NhanVien (
                MaNV, HoTenNV, CCCDNV, SDTNV, EmailNV, TrangThaiLV,
                SoBangLai, HangBangLai, NgayHHBangLai, MaCV
            )
            VALUES (
                @NV_QuanLy, N'Test Quản lý', '090000000904', '0900000904',
                N'test.quanly@hive.vn', N'Đang làm việc',
                NULL, NULL, NULL, N'CV004'
            );
        END;

        IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = N'quanly')
           AND NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE MaNV = @NV_QuanLy)
        BEGIN
            INSERT INTO TaiKhoan (
                MaTK, TenDangNhap, MatKhau, TrangThaiTK, MaVT, MaNV
            )
            VALUES (
                N'TK904', N'quanly', N'123', N'Đang hoạt động', N'VT004', @NV_QuanLy
            );
        END;
    END;


    /* Quản trị viên test */
    IF @NV_Admin IS NULL
    BEGIN
        SET @NV_Admin = N'NV905';

        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = @NV_Admin)
        BEGIN
            INSERT INTO NhanVien (
                MaNV, HoTenNV, CCCDNV, SDTNV, EmailNV, TrangThaiLV,
                SoBangLai, HangBangLai, NgayHHBangLai, MaCV
            )
            VALUES (
                @NV_Admin, N'Test Quản trị viên', '090000000905', '0900000905',
                N'test.admin@hive.vn', N'Đang làm việc',
                NULL, NULL, NULL, N'CV005'
            );
        END;

        IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = N'admin')
           AND NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE MaNV = @NV_Admin)
        BEGIN
            INSERT INTO TaiKhoan (
                MaTK, TenDangNhap, MatKhau, TrangThaiTK, MaVT, MaNV
            )
            VALUES (
                N'TK905', N'admin', N'123', N'Đang hoạt động', N'VT005', @NV_Admin
            );
        END;
    END;


    /* =====================================================
       2. DỮ LIỆU DANH MỤC BỔ SUNG ĐỂ TEST
    ===================================================== */

    IF NOT EXISTS (SELECT 1 FROM LoaiKhachHang WHERE MaLoaiKH = N'LKH901')
    BEGIN
        INSERT INTO LoaiKhachHang (MaLoaiKH, TenLoaiKH, MoTaLoaiKH)
        VALUES (N'LKH901', N'Khách hàng test', N'Loại khách hàng dùng để test luồng nghiệp vụ.');
    END;

    IF NOT EXISTS (SELECT 1 FROM KhachHang WHERE MaKH = N'KH901')
    BEGIN
        INSERT INTO KhachHang (
            MaKH, TenKH, SDTKH, EmailKH, DiaChiKH, MST, TrangThaiSuDung, MaLoaiKH
        )
        VALUES (
            N'KH901', N'Công ty Test HIVE', '0900001901',
            N'khachhang.test@hive.vn', N'P. Bình Thạnh, TP.HCM',
            N'0900001901', N'Đang sử dụng', N'LKH901'
        );
    END;

    IF NOT EXISTS (SELECT 1 FROM LoaiHangHoa WHERE MaLoaiHH = N'LHH901')
    BEGIN
        INSERT INTO LoaiHangHoa (MaLoaiHH, TenLoaiHH, MoTaLoaiHH)
        VALUES (N'LHH901', N'Hàng hóa test', N'Hàng hóa dùng để test đơn vận chuyển.');
    END;

    IF NOT EXISTS (SELECT 1 FROM LoaiPhuongTien WHERE MaLoaiPT = N'LPT901')
    BEGIN
        INSERT INTO LoaiPhuongTien (MaLoaiPT, TenLoaiPT, MoTaLoaiPT)
        VALUES (N'LPT901', N'Xe tải test', N'Loại phương tiện dùng để test điều phối.');
    END;

    IF NOT EXISTS (SELECT 1 FROM PhuongTien WHERE MaPT = N'PT901')
    BEGIN
        INSERT INTO PhuongTien (MaPT, BienSoXe, TaiTrong, TinhTrangPT, MaLoaiPT)
        VALUES (N'PT901', N'TEST-901', 1500.00, N'Sẵn sàng', N'LPT901');
    END;

    IF NOT EXISTS (SELECT 1 FROM PhuongTien WHERE MaPT = N'PT902')
    BEGIN
        INSERT INTO PhuongTien (MaPT, BienSoXe, TaiTrong, TinhTrangPT, MaLoaiPT)
        VALUES (N'PT902', N'TEST-902', 2500.00, N'Sẵn sàng', N'LPT901');
    END;

    IF NOT EXISTS (SELECT 1 FROM LoaiPhiVanChuyen WHERE MaLoaiPhi = N'LP001')
    BEGIN
        INSERT INTO LoaiPhiVanChuyen (MaLoaiPhi, TenLoaiPhi, MoTaLoaiPhi)
        VALUES (N'LP001', N'Phí vận chuyển chính', N'Khoản phí vận chuyển chính trên hóa đơn.');
    END;


    /* =====================================================
       3. ĐƠN VẬN CHUYỂN TEST CHO ĐIỀU PHỐI - TÀI XẾ - KẾ TOÁN
    ===================================================== */

    /* Đơn mới tạo: dùng để điều phối viên test lập/chuyển điều phối */
    IF NOT EXISTS (SELECT 1 FROM DonVanChuyen WHERE MaDonVC = N'DVC901')
    BEGIN
        INSERT INTO DonVanChuyen (
            MaDonVC, DiaChiLayHang, DiaChiGiao, TenNguoiNhan, SDTNguoiNhan,
            TGNhanDuKien, TGGiaoDuKien, PhiVC, YeuCauDacBiet,
            TrangThaiDon, NgayTao, MaKH, MaNV
        )
        VALUES (
            N'DVC901', N'Kho Test HIVE, TP.HCM', N'P. Tân Bình, TP.HCM',
            N'Người nhận Test 1', '0900002901',
            '2026-06-21T08:00:00', '2026-06-21T10:00:00',
            500000, N'Đơn mới để test lập điều phối.',
            N'Mới tạo', '2026-06-21T07:30:00', N'KH901', @NV_DieuPhoi
        );
    END;

    /* Đơn đang điều phối: dùng để tài xế test tiếp nhận/từ chối */
    IF NOT EXISTS (SELECT 1 FROM DonVanChuyen WHERE MaDonVC = N'DVC902')
    BEGIN
        INSERT INTO DonVanChuyen (
            MaDonVC, DiaChiLayHang, DiaChiGiao, TenNguoiNhan, SDTNguoiNhan,
            TGNhanDuKien, TGGiaoDuKien, PhiVC, YeuCauDacBiet,
            TrangThaiDon, NgayTao, MaKH, MaNV
        )
        VALUES (
            N'DVC902', N'Kho Test HIVE, TP.HCM', N'P. Gò Vấp, TP.HCM',
            N'Người nhận Test 2', '0900002902',
            '2026-06-21T09:00:00', '2026-06-21T11:30:00',
            620000, N'Đơn chờ tài xế xác nhận.',
            N'Đang điều phối', '2026-06-21T08:20:00', N'KH901', @NV_DieuPhoi
        );
    END;

    /* Đơn đang vận chuyển: dùng để tài xế test cập nhật trạng thái và phát sinh */
    IF NOT EXISTS (SELECT 1 FROM DonVanChuyen WHERE MaDonVC = N'DVC903')
    BEGIN
        INSERT INTO DonVanChuyen (
            MaDonVC, DiaChiLayHang, DiaChiGiao, TenNguoiNhan, SDTNguoiNhan,
            TGNhanDuKien, TGGiaoDuKien, PhiVC, YeuCauDacBiet,
            TrangThaiDon, NgayTao, MaKH, MaNV
        )
        VALUES (
            N'DVC903', N'Kho Test HIVE, TP.HCM', N'P. Thủ Đức, TP.HCM',
            N'Người nhận Test 3', '0900002903',
            '2026-06-21T10:00:00', '2026-06-21T13:00:00',
            700000, N'Đơn đang vận chuyển để test cập nhật trạng thái.',
            N'Đang vận chuyển', '2026-06-21T09:15:00', N'KH901', @NV_DieuPhoi
        );
    END;

    /* Đơn hoàn thành chưa thanh toán: dùng để kế toán test lập phiếu thanh toán */
    IF NOT EXISTS (SELECT 1 FROM DonVanChuyen WHERE MaDonVC = N'DVC904')
    BEGIN
        INSERT INTO DonVanChuyen (
            MaDonVC, DiaChiLayHang, DiaChiGiao, TenNguoiNhan, SDTNguoiNhan,
            TGNhanDuKien, TGGiaoDuKien, PhiVC, YeuCauDacBiet,
            TrangThaiDon, NgayTao, MaKH, MaNV
        )
        VALUES (
            N'DVC904', N'Kho Test HIVE, TP.HCM', N'P. Dĩ An, TP.HCM',
            N'Người nhận Test 4', '0900002904',
            '2026-06-21T08:30:00', '2026-06-21T12:00:00',
            800000, N'Đơn hoàn thành nhưng chưa thanh toán.',
            N'Hoàn thành', '2026-06-21T08:00:00', N'KH901', @NV_DieuPhoi
        );
    END;

    /* Đơn đã thanh toán chưa xuất hóa đơn: dùng để kế toán test phát hành hóa đơn */
    IF NOT EXISTS (SELECT 1 FROM DonVanChuyen WHERE MaDonVC = N'DVC905')
    BEGIN
        INSERT INTO DonVanChuyen (
            MaDonVC, DiaChiLayHang, DiaChiGiao, TenNguoiNhan, SDTNguoiNhan,
            TGNhanDuKien, TGGiaoDuKien, PhiVC, YeuCauDacBiet,
            TrangThaiDon, NgayTao, MaKH, MaNV
        )
        VALUES (
            N'DVC905', N'Kho Test HIVE, TP.HCM', N'P. Trấn Biên, TP. Đồng Nai',
            N'Người nhận Test 5', '0900002905',
            '2026-06-21T09:00:00', '2026-06-21T14:00:00',
            750000, N'Đơn đã thanh toán nhưng chưa xuất hóa đơn.',
            N'Hoàn thành', '2026-06-21T08:40:00', N'KH901', @NV_DieuPhoi
        );
    END;

    /* Đơn đã có hóa đơn: dùng để test danh sách hóa đơn và báo cáo */
    IF NOT EXISTS (SELECT 1 FROM DonVanChuyen WHERE MaDonVC = N'DVC906')
    BEGIN
        INSERT INTO DonVanChuyen (
            MaDonVC, DiaChiLayHang, DiaChiGiao, TenNguoiNhan, SDTNguoiNhan,
            TGNhanDuKien, TGGiaoDuKien, PhiVC, YeuCauDacBiet,
            TrangThaiDon, NgayTao, MaKH, MaNV
        )
        VALUES (
            N'DVC906', N'Kho Test HIVE, TP.HCM', N'P. Tân An, Tây Ninh',
            N'Người nhận Test 6', '0900002906',
            '2026-06-21T10:00:00', '2026-06-21T15:00:00',
            850000, N'Đơn đã có thanh toán và hóa đơn.',
            N'Hoàn thành', '2026-06-21T09:00:00', N'KH901', @NV_DieuPhoi
        );
    END;


    /* Chi tiết hàng hóa cho các đơn test */
    INSERT INTO ChiTietDVC (
        MaDonVC, MaLoaiHH, KhoiLuong, SoKien, DonViTinh, MoTaHH
    )
    SELECT MaDonVC, N'LHH901', KhoiLuong, SoKien, N'Kiện', MoTa
    FROM (
        VALUES
        (N'DVC901', 25.00, 2, N'Hàng test cho đơn mới tạo'),
        (N'DVC902', 30.00, 3, N'Hàng test cho đơn đang điều phối'),
        (N'DVC903', 45.00, 4, N'Hàng test cho đơn đang vận chuyển'),
        (N'DVC904', 50.00, 5, N'Hàng test cho đơn hoàn thành chưa thanh toán'),
        (N'DVC905', 60.00, 6, N'Hàng test cho đơn chờ xuất hóa đơn'),
        (N'DVC906', 70.00, 7, N'Hàng test cho đơn đã có hóa đơn')
    ) AS x(MaDonVC, KhoiLuong, SoKien, MoTa)
    WHERE NOT EXISTS (
        SELECT 1
        FROM ChiTietDVC ct
        WHERE ct.MaDonVC = x.MaDonVC
          AND ct.MaLoaiHH = N'LHH901'
    );


    /* =====================================================
       4. LỆNH ĐIỀU PHỐI + LỊCH SỬ + PHÁT SINH
    ===================================================== */

    IF NOT EXISTS (SELECT 1 FROM LenhDieuPhoi WHERE MaLenhDP = N'LDP901')
    BEGIN
        INSERT INTO LenhDieuPhoi (
            MaLenhDP, TGLapLenh, TGPhanCong, TrangThaiLenh,
            TGXacNhan, LyDoTuChoi, MaDonVC, MaNV, MaPT
        )
        VALUES (
            N'LDP901', '2026-06-21T08:30:00', '2026-06-21T09:00:00',
            N'Đã hủy', NULL, NULL, N'DVC902', @NV_TaiXe, N'PT901'
        );
    END;

    IF NOT EXISTS (SELECT 1 FROM LenhDieuPhoi WHERE MaLenhDP = N'LDP902')
    BEGIN
        INSERT INTO LenhDieuPhoi (
            MaLenhDP, TGLapLenh, TGPhanCong, TrangThaiLenh,
            TGXacNhan, LyDoTuChoi, MaDonVC, MaNV, MaPT
        )
        VALUES (
            N'LDP902', '2026-06-21T09:20:00', '2026-06-21T09:45:00',
            N'Đã hủy', '2026-06-21T09:55:00', NULL, N'DVC903', @NV_TaiXe, N'PT902'
        );
    END;

    IF NOT EXISTS (SELECT 1 FROM LenhDieuPhoi WHERE MaLenhDP = N'LDP903')
    BEGIN
        INSERT INTO LenhDieuPhoi (
            MaLenhDP, TGLapLenh, TGPhanCong, TrangThaiLenh,
            TGXacNhan, LyDoTuChoi, MaDonVC, MaNV, MaPT
        )
        VALUES (
            N'LDP903', '2026-06-21T08:10:00', '2026-06-21T08:30:00',
            N'Hoàn thành', '2026-06-21T08:40:00', NULL, N'DVC904', @NV_TaiXe, N'PT901'
        );
    END;

    IF NOT EXISTS (SELECT 1 FROM LenhDieuPhoi WHERE MaLenhDP = N'LDP904')
    BEGIN
        INSERT INTO LenhDieuPhoi (
            MaLenhDP, TGLapLenh, TGPhanCong, TrangThaiLenh,
            TGXacNhan, LyDoTuChoi, MaDonVC, MaNV, MaPT
        )
        VALUES (
            N'LDP904', '2026-06-21T08:45:00', '2026-06-21T09:05:00',
            N'Hoàn thành', '2026-06-21T09:15:00', NULL, N'DVC905', @NV_TaiXe, N'PT902'
        );
    END;

    IF NOT EXISTS (SELECT 1 FROM LenhDieuPhoi WHERE MaLenhDP = N'LDP905')
    BEGIN
        INSERT INTO LenhDieuPhoi (
            MaLenhDP, TGLapLenh, TGPhanCong, TrangThaiLenh,
            TGXacNhan, LyDoTuChoi, MaDonVC, MaNV, MaPT
        )
        VALUES (
            N'LDP905', '2026-06-21T09:10:00', '2026-06-21T09:30:00',
            N'Hoàn thành', '2026-06-21T09:40:00', NULL, N'DVC906', @NV_TaiXe, N'PT901'
        );
    END;


    /* Lịch sử trạng thái đơn test */
    INSERT INTO LichSuTrangThaiDon (
        MaLichSu, TrangThaiCu, TrangThaiMoi, TGCapNhat, GhiChu, MaDonVC, MaNV
    )
    SELECT MaLichSu, TrangThaiCu, TrangThaiMoi, TGCapNhat, GhiChu, MaDonVC, MaNV
    FROM (
        VALUES
        (N'LS901', N'Mới tạo', N'Đang điều phối', '2026-06-21T08:25:00', N'Điều phối viên chuyển đơn sang điều phối.', N'DVC902', @NV_DieuPhoi),
        (N'LS902', N'Đang điều phối', N'Đã phân công', '2026-06-21T09:00:00', N'Đã phân công tài xế test.', N'DVC902', @NV_DieuPhoi),
        (N'LS903', N'Đã phân công', N'Đã nhận chuyến', '2026-06-21T09:55:00', N'Tài xế test đã tiếp nhận chuyến.', N'DVC903', @NV_TaiXe),
        (N'LS904', N'Đã nhận chuyến', N'Đang giao hàng', '2026-06-21T11:00:00', N'Tài xế test đang giao hàng.', N'DVC903', @NV_TaiXe),
        (N'LS905', N'Đang giao hàng', N'Hoàn thành', '2026-06-21T12:00:00', N'Đơn hoàn thành, chờ kế toán thanh toán.', N'DVC904', @NV_TaiXe),
        (N'LS906', N'Đang giao hàng', N'Hoàn thành', '2026-06-21T13:00:00', N'Đơn hoàn thành và đã thanh toán.', N'DVC905', @NV_TaiXe),
        (N'LS907', N'Đang giao hàng', N'Hoàn thành', '2026-06-21T14:00:00', N'Đơn hoàn thành và đã có hóa đơn.', N'DVC906', @NV_TaiXe)
    ) AS x(MaLichSu, TrangThaiCu, TrangThaiMoi, TGCapNhat, GhiChu, MaDonVC, MaNV)
    WHERE NOT EXISTS (
        SELECT 1
        FROM LichSuTrangThaiDon ls
        WHERE ls.MaLichSu = x.MaLichSu
    );


    /* Phát sinh do tài xế lập: dùng để test tài xế chỉ sửa phát sinh của mình */
    IF NOT EXISTS (SELECT 1 FROM PhieuPhatSinhVC WHERE MaPhieuPS = N'PSS901')
    BEGIN
        INSERT INTO PhieuPhatSinhVC (
            MaPhieuPS, TGPhatSinh, NoiDungPhatSinh, HuongXuLy,
            KetQuaXuLy, TrangThaiXuLy, MaDonVC, MaLenhDP, MaNV
        )
        VALUES (
            N'PSS901', '2026-06-21T10:30:00',
            N'Tài xế test báo khách yêu cầu đổi thời gian giao.',
            NULL, NULL, N'Chưa xử lý',
            N'DVC903', N'LDP902', @NV_TaiXe
        );
    END;

    /* Phát sinh do điều phối viên lập: dùng để test quyền xem/xử lý của điều phối */
    IF NOT EXISTS (SELECT 1 FROM PhieuPhatSinhVC WHERE MaPhieuPS = N'PSS902')
    BEGIN
        INSERT INTO PhieuPhatSinhVC (
            MaPhieuPS, TGPhatSinh, NoiDungPhatSinh, HuongXuLy,
            KetQuaXuLy, TrangThaiXuLy, MaDonVC, MaLenhDP, MaNV
        )
        VALUES (
            N'PSS902', '2026-06-21T10:45:00',
            N'Điều phối viên ghi nhận cần xác nhận lại địa chỉ giao.',
            N'Liên hệ khách hàng để xác nhận địa chỉ.',
            NULL, N'Đang xử lý',
            N'DVC903', N'LDP902', @NV_DieuPhoi
        );
    END;

    DELETE FROM PhanQuyen 
WHERE MaVT = 'VT004' 
  AND MaQuyen IN ('Q007', 'Q017');

    /* =====================================================
       5. THANH TOÁN - HÓA ĐƠN TEST CHO KẾ TOÁN
    ===================================================== */

    /* PTT901: đã thanh toán nhưng chưa có hóa đơn */
    IF NOT EXISTS (SELECT 1 FROM PhieuThanhToanVC WHERE MaPhieuTT = N'PTT901')
       AND NOT EXISTS (SELECT 1 FROM PhieuThanhToanVC WHERE MaDonVC = N'DVC905')
    BEGIN
        INSERT INTO PhieuThanhToanVC (
            MaPhieuTT, SoTienTT, HinhThucTT, NgayTT,
            TrangThaiTT, MaGiaoDich, MaDonVC, MaNV, MaKH
        )
        VALUES (
            N'PTT901', 810000.00, N'Chuyển khoản', '2026-06-21T15:00:00',
            N'Đã thanh toán', N'GDTEST901', N'DVC905', @NV_KeToan, N'KH901'
        );
    END;

    /* PTT902 + HD901: đã thanh toán và đã xuất hóa đơn */
    IF NOT EXISTS (SELECT 1 FROM PhieuThanhToanVC WHERE MaPhieuTT = N'PTT902')
       AND NOT EXISTS (SELECT 1 FROM PhieuThanhToanVC WHERE MaDonVC = N'DVC906')
    BEGIN
        INSERT INTO PhieuThanhToanVC (
            MaPhieuTT, SoTienTT, HinhThucTT, NgayTT,
            TrangThaiTT, MaGiaoDich, MaDonVC, MaNV, MaKH
        )
        VALUES (
            N'PTT902', 918000.00, N'Chuyển khoản', '2026-06-21T16:00:00',
            N'Đã thanh toán', N'GDTEST902', N'DVC906', @NV_KeToan, N'KH901'
        );
    END;

    IF NOT EXISTS (SELECT 1 FROM HoaDonVanChuyen WHERE MaHD = N'HD901')
       AND NOT EXISTS (SELECT 1 FROM HoaDonVanChuyen WHERE MaPhieuTT = N'PTT902')
    BEGIN
        INSERT INTO HoaDonVanChuyen (
            MaHD, NgayPhatHanh, TongTienTruocThue, ThueVAT,
            TrangThaiHD, MaPhieuTT, MaNV, MaKH
        )
        VALUES (
            N'HD901', '2026-06-21T16:20:00',
            850000.00, 8.00, N'Đã phát hành',
            N'PTT902', @NV_KeToan, N'KH901'
        );
    END;

    IF EXISTS (SELECT 1 FROM HoaDonVanChuyen WHERE MaHD = N'HD901')
       AND NOT EXISTS (
            SELECT 1
            FROM ChiTietHDVC
            WHERE MaHD = N'HD901'
              AND MaLoaiPhi = N'LP001'
       )
    BEGIN
        INSERT INTO ChiTietHDVC (
            MaHD, MaLoaiPhi, SoLuong, DonGia
        )
        VALUES (
            N'HD901', N'LP001', 1, 850000.00
        );
    END;


    COMMIT TRANSACTION;
    PRINT N'Đã tạo xong bộ dữ liệu test liên kết cho 5 vai trò.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    PRINT N'Lỗi khi tạo dữ liệu test.';
    PRINT ERROR_MESSAGE();
END CATCH;
GO
SELECT
    tk.MaTK,
    tk.TenDangNhap,
    tk.MatKhau,
    tk.TrangThaiTK,
    nv.MaNV,
    nv.HoTenNV,
    cv.TenCV,
    vt.TenVT
FROM TaiKhoan tk
JOIN NhanVien nv ON tk.MaNV = nv.MaNV
JOIN ChucVu cv ON nv.MaCV = cv.MaCV
JOIN VaiTroHeThong vt ON tk.MaVT = vt.MaVT
WHERE tk.TenDangNhap IN
(
    N'dieuphoivien',
    N'taixe',
    N'ketoan',
    N'quanly',
    N'admin'
)
ORDER BY tk.MaTK;

/* =====================================================
   DỮ LIỆU MẪU: TỰ ĐỘNG SINH ĐƠN HÀNG & HÓA ĐƠN TRONG 6 THÁNG
   (Dùng để test tính năng Báo cáo Doanh thu)
===================================================== */
DECLARE @i INT = 100;
DECLARE @MaDVC NVARCHAR(10);
DECLARE @MaPTT NVARCHAR(10);
DECLARE @NgayRandom DATETIME;
DECLARE @KhachHang NVARCHAR(10);
DECLARE @NhanVien NVARCHAR(10) = 'NV002';
DECLARE @TienRandom DECIMAL(18,2);

WHILE @i <= 150
BEGIN
    SET @MaDVC = 'DVC' + CAST(@i AS NVARCHAR);
    SET @MaPTT = 'PTT' + CAST(@i AS NVARCHAR);
    
    -- Random ngày trong vòng 6 tháng đầu năm 2026
    SET @NgayRandom = DATEADD(day, ABS(CHECKSUM(NEWID()) % 170), '2026-01-01');
    
    -- Random khách hàng (giả sử KH001 tới KH005)
    SET @KhachHang = 'KH00' + CAST((ABS(CHECKSUM(NEWID()) % 5) + 1) AS NVARCHAR);
    
    -- Random doanh thu từ 1tr đến 10tr
    SET @TienRandom = (ABS(CHECKSUM(NEWID()) % 90) + 10) * 100000;
    
    IF NOT EXISTS (SELECT 1 FROM DonVanChuyen WHERE MaDonVC = @MaDVC)
    BEGIN
        INSERT INTO DonVanChuyen (
            MaDonVC, DiaChiLayHang, DiaChiGiao, TenNguoiNhan, SDTNguoiNhan,
            TGNhanDuKien, TGGiaoDuKien, PhiVC, YeuCauDacBiet, TrangThaiDon,
            NgayTao, MaKH, MaNV
        )
        VALUES (
            @MaDVC, N'Kho lấy mẫu', N'Kho giao mẫu', N'Người nhận ảo', '0900000000',
            @NgayRandom, DATEADD(day, 2, @NgayRandom), @TienRandom, NULL, N'Hoàn thành',
            @NgayRandom, @KhachHang, @NhanVien
        );
    END

    IF NOT EXISTS (SELECT 1 FROM PhieuThanhToanVC WHERE MaPhieuTT = @MaPTT)
    BEGIN
        INSERT INTO PhieuThanhToanVC (
            MaPhieuTT, SoTienTT, HinhThucTT, NgayTT, TrangThaiTT,
            MaGiaoDich, MaDonVC, MaNV, MaKH
        )
        VALUES (
            @MaPTT, @TienRandom, N'Tiền mặt', DATEADD(day, 3, @NgayRandom), N'Đã thanh toán',
            NULL, @MaDVC, @NhanVien, @KhachHang
        );
    END
    
    DECLARE @MaHD NVARCHAR(10) = 'HD' + CAST(@i AS NVARCHAR);
    IF NOT EXISTS (SELECT 1 FROM HoaDonVanChuyen WHERE MaHD = @MaHD)
    BEGIN
        INSERT INTO HoaDonVanChuyen (
            MaHD, NgayPhatHanh, TongTienTruocThue, ThueVAT, TrangThaiHD, MaPhieuTT, MaNV, MaKH
        )
        VALUES (
            @MaHD, DATEADD(day, 4, @NgayRandom), @TienRandom, 8.00, N'Đã phát hành', @MaPTT, @NhanVien, @KhachHang
        );
    END
    
    SET @i = @i + 1;
END
GO
