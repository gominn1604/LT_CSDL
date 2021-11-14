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
    public partial class AccountForm : Form
    {
        public AccountForm()
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

        private void AccountForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server = DESKTOP-EH06V9H; database = RestaurantManagement; Integrated Security = true;";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE InsertAccount @acccountName, @fullName, @email, @dateCreated, @tell, @password";

                //Thêm tham số vào đối tượng cmd
                cmd.Parameters.Add("@acccountName", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@fullName", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@dateCreated", SqlDbType.DateTime);
                cmd.Parameters.Add("@tell", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 1000);

                //Truyền giá trị vào thủ tục qua tham số
                cmd.Parameters["@acccountName"].Value = txtTenTK.Text;
                cmd.Parameters["@fullName"].Value = txtHoTen.Text;
                cmd.Parameters["@email"].Value = txtEmail.Text;
                cmd.Parameters["@dateCreated"].Value = dtpNgayKhoiTao.Value.ToShortDateString();
                cmd.Parameters["@tell"].Value = mtxtPhoneNumber.Text;
                cmd.Parameters["@password"].Value = "123456";

                //Mở kết nối
                conn.Open();

                int numRowAffacted = cmd.ExecuteNonQuery();

                if (numRowAffacted > 0)
                {
                    MessageBox.Show("Thêm tài khoản thành công", "Message");
                    LoadForm();
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản không thành công");
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

        private void ResetText()
        {
            txtHoTen.ResetText();
            txtTenTK.ResetText();
            txtEmail.ResetText();
            mtxtPhoneNumber.ResetText();
            dtpNgayKhoiTao.Value.ToLocalTime();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server = DESKTOP-EH06V9H; database = RestaurantManagement; Integrated Security = true;";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE UpdateAccount @acccountName, @fullName, @email, @dateCreated, @tell";

                //Thêm tham số vào đối tượng cmd
                cmd.Parameters.Add("@acccountName", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@fullName", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@dateCreated", SqlDbType.DateTime);
                cmd.Parameters.Add("@tell", SqlDbType.NVarChar, 20);

                //Truyền giá trị vào thủ tục qua tham số
                cmd.Parameters["@acccountName"].Value = txtTenTK.Text;
                cmd.Parameters["@fullName"].Value = txtHoTen.Text;
                cmd.Parameters["@email"].Value = txtEmail.Text;
                cmd.Parameters["@dateCreated"].Value = dtpNgayKhoiTao.Value.ToShortDateString();
                cmd.Parameters["@tell"].Value = mtxtPhoneNumber.Text;

                //Mở kết nối
                conn.Open();

                int numRowAffacted = cmd.ExecuteNonQuery();

                if (numRowAffacted > 0)
                {
                    MessageBox.Show("Cập nhật thông tin tài khoản thành công", "Message");
                    LoadForm();
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin tài khoản không thành công");
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
        public void DisplayAccountInfo(DataRowView rowView)
        {
                txtTenTK.Text = rowView["AccountName"].ToString();
                txtHoTen.Text = rowView["FullName"].ToString();
                txtEmail.Text = rowView["Email"].ToString();
                dtpNgayKhoiTao.Text = rowView["DateCreated"].ToString();
                mtxtPhoneNumber.Text = rowView["Tell"].ToString();  
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgvAccount.SelectedRows[0];
            DataRowView rowView = selectedRow.DataBoundItem as DataRowView;
            DisplayAccountInfo(rowView);
        }

        private void ctmsViewRoles_Click(object sender, EventArgs e)
        {
            RoleDetailsForm roleDetailsForm = new RoleDetailsForm();
            roleDetailsForm.Show(this);
        }
    }
}
