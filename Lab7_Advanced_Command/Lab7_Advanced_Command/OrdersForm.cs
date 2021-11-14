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
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }
         private void LoadForm()
        {
            string connectionString = "server = DESKTOP-EH06V9H; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM Bills";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();

            sqlConnection.Open();

            //Lấy dữ liệu từ csdl đưa vào database
            adapter.Fill(dt);

            SetColumnsHeaderText(dt);

            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadForm();
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

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-EH06V9H; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Bills_GetByDate @ngay";

            cmd.Parameters.Add("@ngay", SqlDbType.SmallDateTime);

            cmd.Parameters["@ngay"].Value = dtpStart.Value.ToShortDateString();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvBills.DataSource = dt;
            //Mở kết nối
            conn.Open();

            
        }

        private void dgvBills_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvBills.Rows[e.RowIndex];
            int invoiceID = Convert.ToInt32(row.Cells[0].Value);
            string query = "SELECT * FROM BillDetails WHERE InvoiceID = " + invoiceID;
            OrderDetailsForm billDetailsForm = new OrderDetailsForm();
            billDetailsForm.Show(this);
            billDetailsForm.LoadForm(query);
        }
    }
}
