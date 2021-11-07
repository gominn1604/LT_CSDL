
namespace Lab6_Basic_Command
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
            this.btnBills = new System.Windows.Forms.Button();
            this.btnFood = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBills
            // 
            this.btnBills.Location = new System.Drawing.Point(12, 77);
            this.btnBills.Name = "btnBills";
            this.btnBills.Size = new System.Drawing.Size(141, 53);
            this.btnBills.TabIndex = 0;
            this.btnBills.Text = "Bills";
            this.btnBills.UseVisualStyleBackColor = true;
            this.btnBills.Click += new System.EventHandler(this.btnBills_Click);
            // 
            // btnFood
            // 
            this.btnFood.Location = new System.Drawing.Point(12, 18);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(141, 53);
            this.btnFood.TabIndex = 1;
            this.btnFood.Text = "Food";
            this.btnFood.UseVisualStyleBackColor = true;
            this.btnFood.Click += new System.EventHandler(this.btnFood_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(12, 136);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(141, 53);
            this.btnAccount.TabIndex = 2;
            this.btnAccount.Text = "Account";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 270);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.btnFood);
            this.Controls.Add(this.btnBills);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBills;
        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Button btnAccount;
    }
}