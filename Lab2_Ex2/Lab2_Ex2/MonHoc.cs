using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_Ex2
{
    public class MonHoc
    {
        public int Id { get; set; }
        public string TenMH { get; set; }
        public int SoTC { get; set; }
        public MonHoc()
        {
        }
        public MonHoc(string ten)
        {
            this.TenMH = ten;
        }
        public MonHoc(int id, string ten, int tc)
        {
            this.Id = id;
            this.TenMH = ten;
            this.SoTC = tc;
        }
        public override string ToString()
        {
            return TenMH;
        }
    }
}
