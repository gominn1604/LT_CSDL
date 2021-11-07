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
    public partial class AccountManager : Form
    {
        public AccountManager()
        {
            InitializeComponent();
        }
        public void LoadForm()
        {
            //Tạo đối tượng kết nối
            string connectionString = "server=DESKTOP-EH06V9H;database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            //Thiết lập truy vấn cho đối tượng thực thi lệnh
            sqlCommand.CommandText = "SELECT * FROM Account";

            //Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            //Tạo đối tượng DataAdapter
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

            //Tạo DataTable để chứa dữ liệu
            DataTable dt = new DataTable("Account");
            da.Fill(dt);

            //Hiển thị danh sách món ăn lên Form
            SetColumnsHeaderText(dt);

            //Đóng kết nối và giải phóng bộ nhớ
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }

        private void AccountManager_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void SetColumnsHeaderText(DataTable dt)
        {
            dgvAccount.DataSource = dt;
            dgvAccount.Columns[0].HeaderText = "Tên tài khoản";
            dgvAccount.Columns[1].HeaderText = "Mật khẩu";
            dgvAccount.Columns[2].HeaderText = "Họ và tên";
            dgvAccount.Columns[3].HeaderText = "Email";
            dgvAccount.Columns[4].HeaderText = "Số điện thoại";
            dgvAccount.Columns[5].HeaderText = "Ngày khởi tạo";

            int count = dgvAccount.Columns.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                dgvAccount.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
