using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_Ex2
{
    public partial class frmGiaoVien : Form
    {
        QuanLyGiaoVien qlgv = new QuanLyGiaoVien();
        public frmGiaoVien()
        {
            InitializeComponent();
        }
        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            string lienhe = "";
            this.linklbLienHe.Links.Add(0, lienhe.Length, lienhe);
            this.cbbMaSo.SelectedItem = this.cbbMaSo.Items[0];
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int i = this.lbDanhSachMonHoc.SelectedItems.Count - 1;
            while(i>=0)
            {
                this.lbMonHocDay.Items.Add(lbDanhSachMonHoc.SelectedItems[i]);
                this.lbDanhSachMonHoc.Items.Remove(lbDanhSachMonHoc.SelectedItems[i]);
                i--;
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = this.lbMonHocDay.SelectedItems.Count - 1;
            while(i>=0)
            {
                this.lbDanhSachMonHoc.Items.Add(lbMonHocDay.SelectedItems[i]);
                this.lbMonHocDay.Items.Remove(lbMonHocDay.SelectedItems[i]);
                i--;
            }    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            this.cbbMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.txtMail.Text = "";
            this.mtxtSoDT.Text = "";
            this.rdNam.Checked = true;

            for (int i = 0; i < chklbNgoaiNgu.Items.Count - 1; i++)
                chklbNgoaiNgu.SetItemChecked(i, false);
            foreach (object ob in this.lbMonHocDay.Items)
                this.lbDanhSachMonHoc.Items.Add(ob);
            this.lbMonHocDay.Items.Clear();
            {

            }
        }

        private void linklbLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = e.Link.LinkData.ToString();
            Process.Start(s);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            frmTBGiaoVien frm = new frmTBGiaoVien();
            frm.SetText(GetGiaoVien().ToString());
            frm.ShowDialog();
        }
        public GiaoVien GetGiaoVien()
        {
            string gt = "Nam";
            if (rdNu.Checked)
                gt = "Nữ";
            GiaoVien gv = new GiaoVien();
            gv.MaSo = this.cbbMaSo.Text;
            gv.GioiTinh = gt;
            gv.HoTen = this.txtHoTen.Text;
            gv.NgaySinh = this.dtpNgaySinh.Value;
            gv.Mail = this.txtMail.Text;
            gv.SoDT = "0633" + this.mtxtSoDT.Text;

            string ngoaingu = "";
            for (int i = 0; i < chklbNgoaiNgu.Items.Count - 1; i++)
                if (chklbNgoaiNgu.GetItemChecked(i))
                    ngoaingu += chklbNgoaiNgu.Items[i] + ";";
            gv.NgoaiNgu = ngoaingu.Split(';');

            DanhMucMonHoc mh = new DanhMucMonHoc();
            foreach (object ob in lbMonHocDay.Items)
                mh.Them(new MonHoc(ob.ToString()));
            gv.dsMonHoc = mh;

            return gv;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var them = GetGiaoVien();
            var exists = qlgv.Them(them);
            if (exists)
            {
                MessageBox.Show("Đã chèn xong!");
            }    
            else
            {
                MessageBox.Show("Đã tồn tại giáo viên có mã số này!");
            }    
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmTimKiem fr = new frmTimKiem(qlgv);
            fr.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
