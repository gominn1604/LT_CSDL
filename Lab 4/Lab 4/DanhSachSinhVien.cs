using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab_4
{
    public delegate int SoSanh(object sv1, object sv2);
    public class DanhSachSinhVien
    {
        private const string filePath = "dssv.txt";
        public List<SinhVien> DanhSach;
        public DanhSachSinhVien()
        {
            DanhSach = new List<SinhVien>();
        }
        public void Them(SinhVien sv)
        {
            this.DanhSach.Add(sv);
        }
        public SinhVien this[int index]
        {
            get { return DanhSach[index]; }
            set { DanhSach[index] = value; }
        }
        public SinhVien Tim(object obj1, SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien sv in DanhSach)
            {
                if (ss(obj1,sv) == 0)
                {
                    svresult = sv;
                    break;
                }    
            }
            return svresult;
        }
        public bool Sua (SinhVien svsua, object obj1, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.DanhSach.Count - 1;
            for(i=0; i< count;i++)
            {
                if(ss(obj1,this[i])==0)
                {
                    this[i] = svsua;
                    kq = true;
                    break;
                }    
            }
            return kq;
        }
        public void Xoa (object obj1, SoSanh ss)
        {
            int i = DanhSach.Count - 1;
            for (;i>=0;i--)
            {
                if (ss(obj1, this[i]) == 0)
                    this.DanhSach.RemoveAt(i);
            }    
        }
        public void Luu(List<SinhVien> ds)
        {
            
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (var writer = new StreamWriter(stream))
                {
                    foreach (var sv in ds)
                    {
                        writer.WriteLine("{0}*{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}",
                            sv.MSSV, sv.HoTen, sv.GioiTinh ? "1" : "0", sv.NgaySinh.ToString(),
                            sv.Lop, sv.SoDienThoai, sv.Email, sv.DiaChi, sv.Hinh);
                    }
                }
            }
        }
        public void DocTuFile()
        {
            string fileName = "dssv.txt", t;
            string[] s;
            SinhVien sv;
            StreamReader sr = new StreamReader(new FileStream(fileName, FileMode.Open));
            while ((t = sr.ReadLine()) != null)
            {
                s = t.Split('*');
                sv = new SinhVien();
                sv.MSSV = s[0];
                sv.HoTen = s[1];
                sv.GioiTinh = false;
                if (s[2] == "1")
                    sv.GioiTinh = true;
                sv.NgaySinh = DateTime.Parse(s[3]);
                sv.Lop = s[4];
                sv.SoDienThoai = s[5];
                sv.Email = s[6];
                sv.DiaChi = s[7];
                sv.Hinh = s[8];
                this.Them(sv);
            }
            sr.Close();
        }
    }
}
