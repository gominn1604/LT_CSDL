using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab3_Demo
{
    public partial class frmTuyChon : Form
    {
        QuanLySinhVien qlsv = new QuanLySinhVien();
        ListView lv;
        public frmTuyChon(QuanLySinhVien qlsv, ListView lv)
        {
            this.lv = lv;
            this.qlsv = qlsv;
            InitializeComponent();
        }
        public delegate int SoSanh(object a, object b);

        private void btnFind_Click(object sender, EventArgs e)
        {
            SinhVien sv = null;
            Kieu kieu = Kieu.Ma;
            if (rdMASV.Checked)
                kieu = Kieu.Ma;
            if (rdHoTen.Checked)
                kieu = Kieu.Ten;
            if (rdNS.Checked)
                kieu = Kieu.NS;

            switch (kieu)
            {
                case Kieu.Ten:
                    sv = qlsv.DanhSach.Find(x => x.HoTen == txtTimKiem.Text);
                    break;
                case Kieu.Ma:
                    sv = qlsv.DanhSach.Find(x => x.MaSo == txtTimKiem.Text);
                    break;
                case Kieu.NS:
                    sv = qlsv.DanhSach.Find(x => x.NgaySinh == DateTime.Parse(txtTimKiem.Text));
                    break;
                default:
                    break;
            }
            if (txtTimKiem.Text == "")
                MessageBox.Show("Lỗi nhập thông tin", "Hãy nhập thông tin tìm!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ListViewItem item = new ListViewItem(sv.MaSo);
                item.SubItems.Add(sv.HoTen);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.DiaChi);
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.GioiTinh ? "Nam" : "Nữ");
                item.SubItems.Add(String.Join(", ", sv.ChuyenNganh));
                item.SubItems.Add(sv.Hinh);

                lv.Items.Clear();
                lv.Items.Add(item);

                MessageBox.Show("Số sinh viên tìm thấy: " + lv.Items.Count);
                
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            Kieu kieu = Kieu.Ma;
            if (rdHoTen.Checked)
            {
                kieu = Kieu.Ten;
            }   
            else if(rdMASV.Checked)
            {
                kieu = Kieu.Ma;
            }
            else
            {
                kieu = Kieu.NS;
            }

            switch(kieu)
            {
                case Kieu.Ma:
                    qlsv.DanhSach.Sort((x, y) => x.MaSo.CompareTo(y.MaSo));
                    break;
                case Kieu.Ten:
                    qlsv.DanhSach.Sort((x, y) => x.HoTen.CompareTo(y.HoTen));
                    break;
                case Kieu.NS:
                    qlsv.DanhSach.Sort((x, y) => x.NgaySinh.CompareTo(y.NgaySinh));
                    break;
                default:
                    break;
            }    
            lv.Items.Clear();
            foreach (var sv in qlsv.DanhSach)
            {
                ListViewItem item = new ListViewItem(sv.MaSo);
                item.SubItems.Add(sv.HoTen);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.DiaChi);
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.GioiTinh ? "Nam" : "Nữ");
                item.SubItems.Add(String.Join(", ", sv.ChuyenNganh));
                item.SubItems.Add(sv.Hinh);

                lv.Items.Add(item);
            }
            this.Close();
        }
    }
}
