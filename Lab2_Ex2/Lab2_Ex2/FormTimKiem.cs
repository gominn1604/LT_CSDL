using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lab2_Ex2.Properties;

namespace Lab2_Ex2
{
    public partial class frmTimKiem : Form
    {
        QuanLyGiaoVien qlgv = new QuanLyGiaoVien();
        public frmTimKiem(QuanLyGiaoVien qlgv)
        {
            this.qlgv = qlgv;
            InitializeComponent();
        }
        public delegate int SoSanh(object a, object b);
        private void frmTimKiem_Load(object sender, EventArgs e)
        {
            lbTimTheoMuc.Text = "Mã GV";
        }

        private void rbTimTheoTen_CheckedChanged(object sender, EventArgs e)
        {
            lbTimTheoMuc.Text = "Họ tên";
        }

        private void rbTimTheoSDT_CheckedChanged(object sender, EventArgs e)
        {
            lbTimTheoMuc.Text = rbTimTheoSDT.Text;
        }

        private void rdTimTheoMaGV_CheckedChanged(object sender, EventArgs e)
        {
            lbTimTheoMuc.Text = rdTimTheoMaGV.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmTBGiaoVien frm = new frmTBGiaoVien();
            frmGiaoVien frmgv = new frmGiaoVien();
            if(txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin!");
            }    
            if(rdTimTheoMaGV.Checked)
            {
                GiaoVien kq = qlgv.Tim(txtTimKiem.Text, delegate (object obj1, object obj2)
                {
                     return (obj2 as GiaoVien).MaSo.CompareTo(obj1.ToString());
                });
                if (kq!=null)
                {
                    frm.SetText(kq.ToString());
                    frm.ShowDialog();
                }
                else
                {
                MessageBox.Show("Không tìm thấy gv có mã số trên!");
                } 
            }    
            else if(rbTimTheoSDT.Checked)
            {
                GiaoVien kq = qlgv.Tim(txtTimKiem.Text, delegate (object obj1, object obj2)
                {
                    return (obj2 as GiaoVien).SoDT.CompareTo(obj1.ToString());
                });
                if(kq!= null)
                {
                    frm.SetText(kq.ToString());
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy giáo viên có sđt trên!");
                }     
            }
            else
            {
                GiaoVien kq = qlgv.Tim(txtTimKiem.Text, delegate (object obj1, object obj2)
                {
                    return (obj2 as GiaoVien).HoTen.CompareTo(obj1.ToString());
                });
                if (kq != null)
                {
                    frm.SetText(kq.ToString());
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy giáo viên có họ tên trên!");
                }
            }                 
        }
    }
}
