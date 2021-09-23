using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4
{
    public partial class frmQuanLy : Form
    {
        DanhSachSinhVien dssv;
        private bool _checked = false;
        public frmQuanLy()
        {
            InitializeComponent();
        }

        public SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            sv.MSSV = this.mtxtMaSo.Text;
            sv.HoTen = this.txtHoTen.Text;
            sv.Email = this.txtEmail.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            sv.Hinh = this.txtHinh.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            if (rbNu.Checked)
                gt = false;
            sv.GioiTinh = gt;
            sv.Lop = this.cbbLop.Text;
            sv.SoDienThoai = this.mtxtSDT.Text;
            return sv;
        }
        public void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MSSV);
            lvitem.SubItems.Add(sv.HoTen);
            string gt = "Nữ";
            if (sv.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.SoDienThoai);
            lvitem.SubItems.Add(sv.Email);
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.Hinh);
            this.lvDSSV.Items.Add(lvitem);
        }
        public void LoadListView()
        {
            this.lvDSSV.Items.Clear();
            foreach (SinhVien sv in dssv.DanhSach)
            {
                ThemSV(sv);
            }
        }

        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MSSV = lvitem.SubItems[0].Text;
            sv.HoTen = lvitem.SubItems[1].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[2].Text == "Nam")
                sv.GioiTinh = true;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.Lop = lvitem.SubItems[4].Text;
            sv.SoDienThoai = lvitem.SubItems[5].Text;
            sv.Email = lvitem.SubItems[6].Text;
            sv.DiaChi = lvitem.SubItems[7].Text;
            sv.Hinh = lvitem.SubItems[8].Text;
            return sv;
        }

        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMaSo.Text = sv.MSSV;
            this.txtHoTen.Text = sv.HoTen;
            if (sv.GioiTinh)
                this.rbNam.Checked = true;
            else
                this.rbNu.Checked = true;
            this.txtEmail.Text = sv.Email;
            this.txtDiaChi.Text = sv.DiaChi;
            this.txtHinh.Text = sv.Hinh;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.cbbLop.Text = sv.Lop;
            this.mtxtSDT.Text = sv.SoDienThoai;
        }

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            dssv = new DanhSachSinhVien();
            dssv.DocTuFile();
            LoadListView();
                
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open File Image";
            dlg.FileName = "Hãy chọn File";
            dlg.Filter = "Image Files (JPEG, GIF, BMP, etc.)|"
                            + "*.jpg;*.jpeg;*.gif;*.bmp;"
                            + "*.tif;*.tiff;*.png|"
                            + "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|"
                            + "GIF files (*.gif)|*.gif|"
                            + "BMP files (*.bmp)|*.bmp|"
                            + "TIFF files (*.tif;*.tiff)|*.tif;*.tiff|"
                            + "PNG files (*.png)|*.png|"
                            + "All files (*.*)|*.*";

            dlg.InitialDirectory = Environment.CurrentDirectory;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileName = dlg.FileName;
                txtHinh.Text = fileName;
                pbHinh.Load(fileName);

            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtxtMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.txtEmail.Text = "";
            this.txtDiaChi.Text = "";
            this.pbHinh.ImageLocation = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.rbNam.Checked = true;
            this.cbbLop.Text = this.cbbLop.Items[0].ToString();
            this.mtxtSDT.Text = "";
        }

        private void lvDSSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvDSSV.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvDSSV.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }    
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            _checked = true;
            if (_checked == true)
            {
                var s = MessageBox.Show("Bạn có muốn lưu danh sách đã thay đổi không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (s == DialogResult.Yes)
                {
                    dssv.Luu(dssv.DanhSach);
                    Application.Exit();
                }    
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            SinhVien kq = dssv.Tim(sv.MSSV, delegate (object obj1, object obj2)
            {
                return (obj2 as SinhVien).MSSV.CompareTo(obj1.ToString());
            });
            if (kq != null)
            {
                bool kqsua;
                kqsua = dssv.Sua(sv, sv.MSSV, delegate (object obj1, object obj2)
                {
                    return (obj2 as SinhVien).MSSV.CompareTo(obj1.ToString());
                });
                LoadListView();
                MessageBox.Show("Đã sửa thông tin của sinh viên có mã số " + sv.MSSV);
            }
            else
            {
                if (mtxtMaSo.Text == "" || txtHoTen.Text == "" || dtpNgaySinh.Value == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                }    
                else
                {
                    this.dssv.Them(sv);
                    MessageBox.Show("Đã thêm sinh viên có mã số " + sv.MSSV);
                }    
                
            }
            this.LoadListView();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lvDSSV.Items.Count - 1;
            for (i=count;i>=0;i--)
            {
                lvitem = this.lvDSSV.Items[i];
                if (lvitem.Selected)
                    dssv.Xoa(lvitem.SubItems[0].Text, delegate (object obj1, object obj2)
                    {
                        return (obj2 as SinhVien).MSSV.CompareTo(obj1.ToString());
                    });
            }
            this.LoadListView();
        }

        private void tảiLạiDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dssv.DanhSach.Clear();
            dssv.DocTuFile();
            this.LoadListView();
        }
    }
}
