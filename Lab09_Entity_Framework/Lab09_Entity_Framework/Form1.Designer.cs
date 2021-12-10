
namespace Lab09_Entity_Framework
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnReloadCategory = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnReloadFood = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tvCategory = new System.Windows.Forms.TreeView();
            this.lvFood = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh mục";
            // 
            // btnReloadCategory
            // 
            this.btnReloadCategory.Location = new System.Drawing.Point(261, 12);
            this.btnReloadCategory.Name = "btnReloadCategory";
            this.btnReloadCategory.Size = new System.Drawing.Size(39, 35);
            this.btnReloadCategory.TabIndex = 1;
            this.btnReloadCategory.Text = "R";
            this.toolTip1.SetToolTip(this.btnReloadCategory, "Tải lại danh mục");
            this.btnReloadCategory.UseVisualStyleBackColor = true;
            this.btnReloadCategory.Click += new System.EventHandler(this.btnReloadCategory_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(306, 12);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(39, 35);
            this.btnAddCategory.TabIndex = 2;
            this.btnAddCategory.Text = "+";
            this.toolTip1.SetToolTip(this.btnAddCategory, "Thêm danh mục mới");
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnReloadFood
            // 
            this.btnReloadFood.Location = new System.Drawing.Point(971, 12);
            this.btnReloadFood.Name = "btnReloadFood";
            this.btnReloadFood.Size = new System.Drawing.Size(39, 35);
            this.btnReloadFood.TabIndex = 4;
            this.btnReloadFood.Text = "R";
            this.toolTip1.SetToolTip(this.btnReloadFood, "Tải lại danh sách món ăn");
            this.btnReloadFood.UseVisualStyleBackColor = true;
            this.btnReloadFood.Click += new System.EventHandler(this.btnReloadFood_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1016, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(39, 35);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "--";
            this.toolTip1.SetToolTip(this.btnDelete, "Xóa món ăn được chọn");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(1061, 12);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(39, 35);
            this.btnAddFood.TabIndex = 6;
            this.btnAddFood.Text = "+";
            this.toolTip1.SetToolTip(this.btnAddFood, "Thêm món ăn mới");
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Thực đơn";
            // 
            // tvCategory
            // 
            this.tvCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvCategory.Location = new System.Drawing.Point(13, 53);
            this.tvCategory.Name = "tvCategory";
            this.tvCategory.Size = new System.Drawing.Size(332, 442);
            this.tvCategory.TabIndex = 7;
            this.tvCategory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCategory_AfterSelect);
            this.tvCategory.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvCategory_NodeMouseDoubleClick);
            // 
            // lvFood
            // 
            this.lvFood.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFood.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvFood.FullRowSelect = true;
            this.lvFood.GridLines = true;
            this.lvFood.HideSelection = false;
            this.lvFood.Location = new System.Drawing.Point(355, 53);
            this.lvFood.MultiSelect = false;
            this.lvFood.Name = "lvFood";
            this.lvFood.Size = new System.Drawing.Size(745, 442);
            this.lvFood.TabIndex = 8;
            this.lvFood.UseCompatibleStateImageBehavior = false;
            this.lvFood.View = System.Windows.Forms.View.Details;
            this.lvFood.DoubleClick += new System.EventHandler(this.lvFood_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã số";
            this.columnHeader1.Width = 73;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên đồ ăn/thức uống";
            this.columnHeader2.Width = 173;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn vị tính";
            this.columnHeader3.Width = 106;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Giá bán";
            this.columnHeader4.Width = 106;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nhóm mặt hàng";
            this.columnHeader5.Width = 127;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ghi chú";
            this.columnHeader6.Width = 159;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 504);
            this.Controls.Add(this.lvFood);
            this.Controls.Add(this.tvCategory);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReloadFood);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.btnReloadCategory);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhà hàng";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReloadCategory;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReloadFood;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.TreeView tvCategory;
        private System.Windows.Forms.ListView lvFood;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

