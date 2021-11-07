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
    public partial class BillsForm : Form
    {
        private bool check = false;
        private string query;
        public BillsForm()
        {
            InitializeComponent();
        }
        public void LoadForm()
        {    
            if (check == false)
            {
                query = "SELECT * FROM Bills";
            }    
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
            DataTable dt = new DataTable("Bills");
            da.Fill(dt);

            //Hiển thị danh sách món ăn lên Form
            SetColumnsHeaderText(dt);

            //Đóng kết nối và giải phóng bộ nhớ
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            check = true;
            string timeStart = dtpStart.Value.ToShortDateString(),
                timeEnd = dtpEnd.Value.ToShortDateString();
            query = $"set dateformat dmy select * from Bills where '{timeStart}' <= CHECKOUTDATE and CHECKOUTDATE <= '{timeEnd}'";
            LoadForm();
        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvBills.Rows[e.RowIndex];
            int invoiceID = Convert.ToInt32(row.Cells[0].Value);
            query = "SELECT * FROM BillDetails WHERE InvoiceID = " + invoiceID;
            BillDetailsForm billDetailsForm = new BillDetailsForm();
            billDetailsForm.Show(this);
            billDetailsForm.LoadForm(query);
        }
        private void SetColumnsHeaderText(DataTable dt)
        {
            dgvBills.DataSource = dt;
            dgvBills.Columns[0].HeaderText = "Mã hóa đơn";
            dgvBills.Columns[1].HeaderText = "Tên hóa đơn";
            dgvBills.Columns[2].HeaderText = "Mã bàn";
            dgvBills.Columns[3].HeaderText = "Số lượng";
            dgvBills.Columns[4].HeaderText = "Giảm giá";
            dgvBills.Columns[5].HeaderText = "Thuế";
            dgvBills.Columns[6].HeaderText = "Trạng thái";
            dgvBills.Columns[7].HeaderText = "Ngày trả";
            dgvBills.Columns[8].HeaderText = "Nhân viên thu";

            int count = dgvBills.Columns.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                dgvBills.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }     
        }
    }
}
