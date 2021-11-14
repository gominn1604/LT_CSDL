using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab7_Advanced_Command
{
    public partial class FoodInfoForm : Form
    {
        public FoodInfoForm()
        {
            InitializeComponent();
        }

        private void FoodInfoForm_Load(object sender, EventArgs e)
        {
            this.InitValues();
        }
        private void InitValues()
        {
            string connectionString = "server = DESKTOP-EH06V9H; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID, Name FROM Category";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            conn.Open();

            //Lấy dữ liệu từ cơ sở dữ liệu đưa vào DB
            adapter.Fill(ds, "Category");

            //Hiển thị nhóm món ăn
            cbbCatName.DataSource = ds.Tables["Category"];
            cbbCatName.DisplayMember = "Name";
            cbbCatName.ValueMember = "ID";

            //Đóng kết nối và giải phóng bộ nhớ
            conn.Close();
            conn.Dispose();
        }
        private void ResetText()
        {
            txtID.ResetText();
            txtName.ResetText();
            cbbCatName.ResetText();
            txtNotes.ResetText();
            txtUnit.ResetText();
            nudPrice.ResetText();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server = DESKTOP-EH06V9H; database = RestaurantManagement; Integrated Security = true;";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE InsertFood @id OUTPUT, @name, @unit, @foodCategoryID, @price, @notes";

                //Thêm tham số vào đối tượng cmd
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@foodCategoryID", SqlDbType.Int);
                cmd.Parameters.Add("@price", SqlDbType.Int);
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;

                //Truyền tham số vào đối tượng cmd
                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.Parameters["@unit"].Value = txtUnit.Text;
                cmd.Parameters["@foodCategoryID"].Value = cbbCatName.SelectedValue;
                cmd.Parameters["@price"].Value = nudPrice.Value;
                cmd.Parameters["@notes"].Value = txtNotes.Text;

                //Mở kết nối
                conn.Open();

                int numRowAffacted = cmd.ExecuteNonQuery();

                if (numRowAffacted > 0)
                {
                    string foodID = cmd.Parameters["@id"].Value.ToString();
                    MessageBox.Show("Đã thêm thành công món ăn có ID = " + foodID, "Message");

                    this.ResetText();
                }    
                else
                {
                    MessageBox.Show("Thêm món ăn không thành công!");
                }

                //Đóng kết nối
                conn.Close();
                conn.Dispose();
            }

            //Bắt lỗi SQL và các lỗi khác
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server = DESKTOP-EH06V9H; database = RestaurantManagement; Integrated Security = true;";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE UpdateFood @id, @name, @unit, @foodCategoryID, @price, @notes";

                //Thêm tham số vào đối tượng cmd
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@foodCategoryID", SqlDbType.Int);
                cmd.Parameters.Add("@price", SqlDbType.Int);
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                //Truyền giá trị vào thủ tục qua tham số
                cmd.Parameters["@id"].Value = int.Parse(txtID.Text);
                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.Parameters["@unit"].Value = txtUnit.Text;
                cmd.Parameters["@foodCategoryID"].Value = cbbCatName.SelectedValue;
                cmd.Parameters["@price"].Value = nudPrice.Value;
                cmd.Parameters["@notes"].Value = txtNotes.Text;

                //Mở kết nối
                conn.Open();

                int numRowAffacted = cmd.ExecuteNonQuery();

                if (numRowAffacted > 0)
                {
                    MessageBox.Show("Cập nhật món ăn thành công", "Message");

                    this.ResetText();
                }    
                else
                {
                    MessageBox.Show("Cập nhật món ăn không thành công");
                }

                //Đóng kết nối
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void DisplayFoodInfo(DataRowView rowView)
        {
            try
            {
                txtID.Text = rowView["ID"].ToString();
                txtName.Text = rowView["Name"].ToString();
                txtUnit.Text = rowView["Unit"].ToString();
                txtNotes.Text = rowView["Notes"].ToString();
                nudPrice.Text = rowView["Price"].ToString();

                cbbCatName.SelectedIndex = -1;

                //Chọn nhóm món ăn tương ứng
                for (int index = 0; index < cbbCatName.Items.Count; index++)
                {
                    DataRowView cat = cbbCatName.Items[index] as DataRowView;
                    if (cat["ID"].ToString() == rowView["FoodCategoryID"].ToString())
                    {
                        cbbCatName.SelectedIndex = index;
                        break;
                    }    
                }       
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
                this.Close();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            CategoryInfoForm categoryInfoForm = new CategoryInfoForm();
            categoryInfoForm.FormClosed += new FormClosedEventHandler(CategoryInfoForm_FormClosed);

            categoryInfoForm.Show(this);

        }

        private void CategoryInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.InitValues();
        }
    }
}
