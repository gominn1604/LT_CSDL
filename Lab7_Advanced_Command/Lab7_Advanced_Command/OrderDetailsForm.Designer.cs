﻿
namespace Lab7_Advanced_Command
{
    partial class OrderDetailsForm
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
            this.dgvBillDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBillDetails
            // 
            this.dgvBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBillDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvBillDetails.Name = "dgvBillDetails";
            this.dgvBillDetails.RowHeadersWidth = 51;
            this.dgvBillDetails.RowTemplate.Height = 29;
            this.dgvBillDetails.Size = new System.Drawing.Size(900, 428);
            this.dgvBillDetails.TabIndex = 1;
            // 
            // OrderDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 428);
            this.Controls.Add(this.dgvBillDetails);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "OrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderDetailsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBillDetails;
    }
}