
namespace Lab2_Ex2
{
    partial class frmTimKiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.rbTimTheoSDT = new System.Windows.Forms.RadioButton();
            this.rbTimTheoTen = new System.Windows.Forms.RadioButton();
            this.rdTimTheoMaGV = new System.Windows.Forms.RadioButton();
            this.lbTimTheoMuc = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.rbTimTheoSDT);
            this.gbTimKiem.Controls.Add(this.rbTimTheoTen);
            this.gbTimKiem.Controls.Add(this.rdTimTheoMaGV);
            this.gbTimKiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbTimKiem.Location = new System.Drawing.Point(26, 36);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Size = new System.Drawing.Size(449, 75);
            this.gbTimKiem.TabIndex = 0;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm theo";
            // 
            // rbTimTheoSDT
            // 
            this.rbTimTheoSDT.AutoSize = true;
            this.rbTimTheoSDT.Location = new System.Drawing.Point(302, 35);
            this.rbTimTheoSDT.Name = "rbTimTheoSDT";
            this.rbTimTheoSDT.Size = new System.Drawing.Size(120, 23);
            this.rbTimTheoSDT.TabIndex = 0;
            this.rbTimTheoSDT.Text = "Số điện thoại";
            this.rbTimTheoSDT.UseVisualStyleBackColor = true;
            this.rbTimTheoSDT.CheckedChanged += new System.EventHandler(this.rbTimTheoSDT_CheckedChanged);
            // 
            // rbTimTheoTen
            // 
            this.rbTimTheoTen.AutoSize = true;
            this.rbTimTheoTen.Location = new System.Drawing.Point(156, 35);
            this.rbTimTheoTen.Name = "rbTimTheoTen";
            this.rbTimTheoTen.Size = new System.Drawing.Size(80, 23);
            this.rbTimTheoTen.TabIndex = 0;
            this.rbTimTheoTen.Text = "Họ Tên";
            this.rbTimTheoTen.UseVisualStyleBackColor = true;
            this.rbTimTheoTen.CheckedChanged += new System.EventHandler(this.rbTimTheoTen_CheckedChanged);
            // 
            // rdTimTheoMaGV
            // 
            this.rdTimTheoMaGV.AutoSize = true;
            this.rdTimTheoMaGV.Checked = true;
            this.rdTimTheoMaGV.Location = new System.Drawing.Point(24, 35);
            this.rdTimTheoMaGV.Name = "rdTimTheoMaGV";
            this.rdTimTheoMaGV.Size = new System.Drawing.Size(79, 23);
            this.rdTimTheoMaGV.TabIndex = 0;
            this.rdTimTheoMaGV.TabStop = true;
            this.rdTimTheoMaGV.Text = "Mã GV";
            this.rdTimTheoMaGV.UseVisualStyleBackColor = true;
            this.rdTimTheoMaGV.CheckedChanged += new System.EventHandler(this.rdTimTheoMaGV_CheckedChanged);
            // 
            // lbTimTheoMuc
            // 
            this.lbTimTheoMuc.AutoSize = true;
            this.lbTimTheoMuc.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTimTheoMuc.Location = new System.Drawing.Point(26, 135);
            this.lbTimTheoMuc.Name = "lbTimTheoMuc";
            this.lbTimTheoMuc.Size = new System.Drawing.Size(58, 19);
            this.lbTimTheoMuc.TabIndex = 1;
            this.lbTimTheoMuc.Text = "Mã GV";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(172, 127);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(185, 27);
            this.txtTimKiem.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOK.Location = new System.Drawing.Point(381, 127);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 29);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 193);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lbTimTheoMuc);
            this.Controls.Add(this.gbTimKiem);
            this.Name = "frmTimKiem";
            this.Text = "Tìm thông tin Giáo Viên";
            this.Load += new System.EventHandler(this.frmTimKiem_Load);
            this.gbTimKiem.ResumeLayout(false);
            this.gbTimKiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.RadioButton rbTimTheoSDT;
        private System.Windows.Forms.RadioButton rbTimTheoTen;
        private System.Windows.Forms.RadioButton rdTimTheoMaGV;
        private System.Windows.Forms.Label lbTimTheoMuc;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnOK;
    }
}