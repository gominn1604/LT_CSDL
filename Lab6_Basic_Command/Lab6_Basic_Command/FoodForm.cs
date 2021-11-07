using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Lab6_Basic_Command
{
    public partial class frmFood : Form
    {
        public frmFood()
        {
            InitializeComponent();
        }

        public void LoadFood(int categoryID)
        {
            //Tạo đối tượng kết nối
            string connectionString = "server=DESKTOP-EH06V9H;database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            //Thiết lập truy vấn cho đối tượng thực thi lệnh
            sqlCommand.CommandText = "SELECT Name FROM Category where ID = " + categoryID;

            //Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            //Gán tên nhóm sản phẩm cho tiêu đề
            string catName = sqlCommand.ExecuteScalar().ToString();
            this.Text = "Danh sách các món ăn thuộc nhóm: " + catName;

            sqlCommand.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = " + categoryID;

            //Tạo đối tượng DataAdapter
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

            //Tạo DataTable để chứa dữ liệu
            DataTable dt = new DataTable("Food");
            da.Fill(dt);

            //Hiển thị danh sách món ăn lên Form
            SetColumnsHeaderText(dt);

            //Đóng kết nối và giải phóng bộ nhớ
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
            txtFoodCateID.Text = categoryID.ToString();
        }
        private string Tim(string ID)
        {
            string kq = "Không";
            int count = dgvFood.Rows.Count - 1;
            for (int i =0;i<count;i++)
            {
                DataGridViewRow row = dgvFood.Rows[i];
                if (row.Cells[0].Value.ToString() == ID)
                {
                    kq = "Có";
                } 
            }
            return kq;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string maMonAn = txtID.Text;
            if (Tim(maMonAn) == "Có")
            {
                //Tạo đối tượng kết nối
                string connectionString = "server=DESKTOP-EH06V9H;database = RestaurantManagement; Integrated Security = true;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Tạo đối tượng thực thi lệnh
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                //Thiết lập truy vấn cho đối tượng thực thi lệnh
                sqlCommand.CommandText = "UPDATE Food SET Name = '" + txtName.Text + "', Unit = '" + txtUnit.Text + "', FoodCategoryID = " + txtFoodCateID.Text + ", Price = " + txtPrice.Text + ", Notes = '" + txtDes.Text + "'" +
                                            " WHERE ID = " + txtID.Text;

                //Mở kết nối đến CSDL
                sqlConnection.Open();

                //Thực thi lệnh bằng phương thức ExecuteReader
                int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

                //Đóng kết nối
                sqlConnection.Close();

                if (numOfRowsEffected == 1)
                {
                    MessageBox.Show("Cập nhật món ăn thành công!");

                    //Tải lại dữ liệu
                    LoadFood(Convert.ToInt32(txtFoodCateID.Text));

                    //Xóa dữ liệu của các ô nhập
                    txtID.Text = "";
                    txtName.Text = "";
                    txtUnit.Text = "";
                    //txtFoodCateID.Text = "";
                    txtPrice.Text = "";
                    txtDes.Text = "";
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra! Không cập nhật thành công.");
                }
            }
            else if (Tim(maMonAn) == "Không")
            {
                //Tạo đối tượng kết nối
                string connectionString = "server=DESKTOP-EH06V9H;database = RestaurantManagement; Integrated Security = true;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Tạo đối tượng thực thi lệnh
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                //Thiết lập truy vấn cho đối tượng thực thi lệnh
                sqlCommand.CommandText = "INSERT INTO Food(Name, Unit, [FoodCategoryID], [Price], Notes)" + "VALUES (N'" + txtName.Text + "','" + txtUnit.Text + "'," + txtFoodCateID.Text + "," + txtPrice.Text + ",'" + txtDes.Text + "')";

                //Mở kết nối đến CSDL
                sqlConnection.Open();

                //Thực thi lệnh bằng phương thức ExecuteReader
                int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

                //Đóng kết nối
                sqlConnection.Close();

                if (numOfRowsEffected == 1)
                {
                    MessageBox.Show("Thêm món ăn thành công!");

                    //Tải lại dữ liệu
                    LoadFood(Convert.ToInt32(txtFoodCateID.Text));

                    //Xóa dữ liệu của các ô nhập
                    txtID.Text = "";
                    txtName.Text = "";
                    txtUnit.Text = "";
                    //txtFoodCateID.Text = "";
                    txtPrice.Text = "";
                    txtDes.Text = "";
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra! Vui lòng thử lại.");
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn món ăn muốn xóa!");
            }
            else
            {
                //Tạo đối tượng kết nối
                string connectionString = "server = DESKTOP-EH06V9H; database = RestaurantManagement; Integrated Security = true;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Tạo đối tượng thực thi lệnh
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                //Thiết lập truy vấn cho đối tượng Command
                sqlCommand.CommandText = "DELETE FROM Food " +
                                        " WHERE ID = " + txtID.Text;

                //Mở kết nối tới cơ sở dữ liệu
                sqlConnection.Open();

                //Thực thi lệnh bằng phương thức ExecuteReader
                int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

                //Đóng kết nối
                sqlConnection.Close();

                if (numOfRowsEffected == 1)
                {
                    DataGridViewRow row = dgvFood.SelectedRows[0];
                    dgvFood.Rows.Remove(row);

                    //Xóa các ô nhập
                    txtID.Text = "";
                    txtName.Text = "";
                    txtUnit.Text = "";
                    txtFoodCateID.Text = "";
                    txtPrice.Text = "";
                    txtDes.Text = "";

                    MessageBox.Show("Xóa món ăn thành công.");
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại.");
                }
            }
        }

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvFood.SelectedRows[0];

            txtID.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtUnit.Text = row.Cells[2].Value.ToString();
            txtFoodCateID.Text = row.Cells[3].Value.ToString();
            txtPrice.Text = row.Cells[4].Value.ToString();
            txtDes.Text = row.Cells[5].Value.ToString();
        }

        private void SetColumnsHeaderText(DataTable dt)
        {
            dgvFood.DataSource = dt;
            dgvFood.Columns[0].HeaderText = "Mã món ăn";
            dgvFood.Columns[1].HeaderText = "Tên món ăn";
            dgvFood.Columns[2].HeaderText = "Đơn vị tính";
            dgvFood.Columns[3].HeaderText = "Mã loại";
            dgvFood.Columns[4].HeaderText = "Đơn giá";
            dgvFood.Columns[5].HeaderText = "Ghi chú";

            int count = dgvFood.Columns.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                dgvFood.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }     
        }
        private void frmFood_Load(object sender, EventArgs e)
        {
        }
    }
}
