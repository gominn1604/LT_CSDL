
namespace Lab7_Advanced_Command
{
    partial class AccountForm
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
            this.components = new System.ComponentModel.Container();
            this.dgvAccount = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctmsViewRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.xemNhậtKýHoạtĐộngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenTK = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.mtxtPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.dtpNgayKhoiTao = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAccount
            // 
            this.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccount.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAccount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAccount.Location = new System.Drawing.Point(0, 159);
            this.dgvAccount.Name = "dgvAccount";
            this.dgvAccount.RowHeadersWidth = 51;
            this.dgvAccount.RowTemplate.Height = 29;
            this.dgvAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccount.Size = new System.Drawing.Size(900, 269);
            this.dgvAccount.TabIndex = 0;
            this.dgvAccount.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccount_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctmsViewRoles,
            this.xemNhậtKýHoạtĐộngToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(255, 52);
            // 
            // ctmsViewRoles
            // 
            this.ctmsViewRoles.Name = "ctmsViewRoles";
            this.ctmsViewRoles.Size = new System.Drawing.Size(254, 24);
            this.ctmsViewRoles.Text = "Xem danh sách các vai trò";
            this.ctmsViewRoles.Click += new System.EventHandler(this.ctmsViewRoles_Click);
            // 
            // xemNhậtKýHoạtĐộngToolStripMenuItem
            // 
            this.xemNhậtKýHoạtĐộngToolStripMenuItem.Name = "xemNhậtKýHoạtĐộngToolStripMenuItem";
            this.xemNhậtKýHoạtĐộngToolStripMenuItem.Size = new System.Drawing.Size(254, 24);
            this.xemNhậtKýHoạtĐộngToolStripMenuItem.Text = "Xem nhật ký hoạt động";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ và tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Số điện thoại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(545, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ngày khởi tạo";
            // 
            // txtTenTK
            // 
            this.txtTenTK.Location = new System.Drawing.Point(152, 15);
            this.txtTenTK.Name = "txtTenTK";
            this.txtTenTK.Size = new System.Drawing.Size(339, 27);
            this.txtTenTK.TabIndex = 2;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(152, 48);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(339, 27);
            this.txtHoTen.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(152, 81);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(339, 27);
            this.txtEmail.TabIndex = 2;
            // 
            // mtxtPhoneNumber
            // 
            this.mtxtPhoneNumber.Location = new System.Drawing.Point(664, 15);
            this.mtxtPhoneNumber.Mask = "0000.000.000";
            this.mtxtPhoneNumber.Name = "mtxtPhoneNumber";
            this.mtxtPhoneNumber.Size = new System.Drawing.Size(177, 27);
            this.mtxtPhoneNumber.TabIndex = 3;
            // 
            // dtpNgayKhoiTao
            // 
            this.dtpNgayKhoiTao.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKhoiTao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKhoiTao.Location = new System.Drawing.Point(664, 48);
            this.dtpNgayKhoiTao.Name = "dtpNgayKhoiTao";
            this.dtpNgayKhoiTao.Size = new System.Drawing.Size(177, 27);
            this.dtpNgayKhoiTao.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(559, 124);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(129, 29);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Thêm tài khoản";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(694, 124);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(129, 29);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 428);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtpNgayKhoiTao);
            this.Controls.Add(this.mtxtPhoneNumber);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtTenTK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAccount);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "AccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountForm";
            this.Load += new System.EventHandler(this.AccountForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenTK;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.MaskedTextBox mtxtPhoneNumber;
        private System.Windows.Forms.DateTimePicker dtpNgayKhoiTao;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctmsViewRoles;
        private System.Windows.Forms.ToolStripMenuItem xemNhậtKýHoạtĐộngToolStripMenuItem;
    }
}