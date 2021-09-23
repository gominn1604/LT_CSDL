using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4
{
    public class SinhVien
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Hinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string Lop { get; set; }
        public string SoDienThoai { get; set; }

        public SinhVien()
        {
        }
        public SinhVien(string ms, string hoten, string email, string diachi, string hinh, DateTime ngay, bool phai, string lop, string sdt)
        {
            this.MSSV = ms;
            this.HoTen = hoten;
            this.Email = email;
            this.DiaChi = diachi;
            this.Hinh = hinh;
            this.NgaySinh = ngay;
            this.GioiTinh = phai;
            this.Lop = lop;
            this.SoDienThoai = sdt;
        }
    }
}
