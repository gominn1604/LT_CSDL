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
    public partial class BillDetailsForm : Form
    {
        public BillDetailsForm()
        {
            InitializeComponent();
        }
        public void LoadForm(string query)
        {
            //Tạo đối tượng kết nối
            string connectionString = "server=DESKTOP-EH06V9H;database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            //Thiết lập truy vấn cho đối tượng thực thi lệnh
            sqlCommand.CommandText = query;

            //Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            //Tạo đối tượng DataAdapter
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

            //Tạo DataTable để chứa dữ liệu
            DataTable dt = new DataTable("BillDetails");
            da.Fill(dt);

            //Hiển thị danh sách món ăn lên Form
            SetColumnsHeaderText(dt);

            //Đóng kết nối và giải phóng bộ nhớ
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }
        private void SetColumnsHeaderText(DataTable dt)
        {
            dgvBillDetails.DataSource = dt;
            dgvBillDetails.Columns[0].HeaderText = "Mã chi tiết hóa đơn";
            dgvBillDetails.Columns[1].HeaderText = "Mã hóa đơn";
            dgvBillDetails.Columns[2].HeaderText = "Mã món ăn";
            dgvBillDetails.Columns[3].HeaderText = "Số lượng";

            int count = dgvBillDetails.Columns.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                dgvBillDetails.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
