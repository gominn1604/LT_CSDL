using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lab2_Ex2
{
    public class QuanLyGiaoVien
    {
        List<GiaoVien> dsGiaoVien = new List<GiaoVien>();

        public GiaoVien this[int index]
        {
            get { return dsGiaoVien[index] as GiaoVien; }
            set { dsGiaoVien[index] = value; }
        }
        public delegate int SoSanh(object a, object b);
        public QuanLyGiaoVien()
        {
        }
        public Boolean Them(GiaoVien gv)
        {
            var existed = dsGiaoVien.Exists(x=>x.MaSo == gv.MaSo);
            if(existed)
            {
                return false;
            }    
            else
            { 
                this.dsGiaoVien.Add(gv); 
            }
            return true;
        }
        public GiaoVien Tim(object temp, SoSanh ss)
        {
            GiaoVien giaovien = null;
            foreach (GiaoVien gv in dsGiaoVien)
            {
                if (ss(temp, gv) ==0)
                {
                    giaovien = gv;
                    break;
                }
            }
            return giaovien;
        }
        public void Xoa(object temp, SoSanh ss)
        {
            foreach (var gv in dsGiaoVien)
            {
                if (ss(temp, gv) == 0)
                    this.dsGiaoVien.Remove(gv);
            }
        }
    }
}
