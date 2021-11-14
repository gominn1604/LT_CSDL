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
    public partial class CategoryInfoForm : Form
    {
        public CategoryInfoForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Tạo đối tượng kết nối
                string connectionString = "server = DESKTOP-EH06V9H; database = RestaurantManagement; Integrated Security = true;";
                SqlConnection conn = new SqlConnection(connectionString);

                //Tạo đối tượng thực thi
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE InsertCategory @ID OUTPUT, @name, @type";

                //Thêm tham số vào đối tượng cmd
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@type", SqlDbType.NVarChar, 100);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;

                //Truyền tham số vào đối tượng cmd
                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.Parameters["@type"].Value = txtType.Text;

                //Mở kết nối
                conn.Open();

                int numRowAffacted = cmd.ExecuteNonQuery();

                if (numRowAffacted > 0)
                {
                    string catName = cmd.Parameters["@name"].Value.ToString();
                    MessageBox.Show("Đã thêm thành công nhóm món ăn: " + catName, "Message");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm nhóm món ăn không thành công");
                    this.Close();
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
    }
}
