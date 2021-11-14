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
    public partial class RoleDetailsForm : Form
    {
        public RoleDetailsForm()
        {
            InitializeComponent();
        }
        public void LoadForm()
        {

            this.Text = "Danh sách vai trò";
            string connectionString = "server= DESKTOP-EH06V9H; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT *  FROM Role";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            //Mở kết nối
            conn.Open();

            //Lấy dữ liệu từ csdl đưa vào DataTable
            da.Fill(dt);
            SetColumnsHeaderText(dt);

            conn.Close();
            conn.Dispose();
        }

        private void RoleDetailsForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void SetColumnsHeaderText(DataTable dt)
        {
            dgvRoleDetails.DataSource = dt;
            dgvRoleDetails.Columns[0].HeaderText = "ID";
            dgvRoleDetails.Columns[1].HeaderText = "Tên vai trò";
            dgvRoleDetails.Columns[2].HeaderText = "Đường dẫn";
            dgvRoleDetails.Columns[3].HeaderText = "Ghi chú";

            int count = dgvRoleDetails.Columns.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                dgvRoleDetails.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=DESKTOP-EH06V9H ;database=RestaurantManagement;Integrated Security=True;";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE InsertRole @id OUTPUT, @roleName, @path, @notes";

                //Thêm tham số vào đối tượng Command
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@roleName", SqlDbType.NVarChar, 200);
                cmd.Parameters.Add("@path", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;

                ////Truyền giá trị vào thủ tục qua tham số
                cmd.Parameters["@roleName"].Value = txtRoleName.Text;
                cmd.Parameters["@path"].Value = txtPath.Text;
                cmd.Parameters["@notes"].Value = txtNotes.Text;


                //Mở kết nối
                conn.Open();
                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    MessageBox.Show("Thêm vai trò thành công", "Message");
                    LoadForm();
                }
                else
                {
                    MessageBox.Show("Thêm vai trò không thành công", "Message");
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

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=DESKTOP-EH06V9H ;database=RestaurantManagement;Integrated Security=True;";
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "EXECUTE UpdateRole @id, @roleName, @path, @notes";

                //Thêm tham số vào đối tượng Command
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@roleName", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@path", SqlDbType.NVarChar, 2000);
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 1000);


                //Truyền giá trị vào thủ tục qua tham số
                if (dgvRoleDetails.SelectedRows.Count <= 0) return;
                cmd.Parameters["@id"].Value = txtID.Text;
                cmd.Parameters["@roleName"].Value = txtRoleName.Text;
                cmd.Parameters["@path"].Value = txtPath.Text;
                cmd.Parameters["@notes"].Value = txtNotes.Text;

                conn.Open();

                int numRowAffected = cmd.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    MessageBox.Show("Cập nhật vai trò thành công", "Message");
                    this.LoadForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật vai trò không thành công");
                }

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

        private void dgvRoleDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvRoleDetails.CurrentRow.Index;
            if (index != null)
            {
                txtID.Text = dgvRoleDetails.Rows[index].Cells["ID"].Value.ToString();
                txtRoleName.Text = dgvRoleDetails.Rows[index].Cells["RoleName"].Value.ToString();
                txtPath.Text = dgvRoleDetails.Rows[index].Cells["Path"].Value.ToString();
                txtNotes.Text = dgvRoleDetails.Rows[index].Cells["Notes"].Value.ToString();

                btnUpdate.Enabled = true;
            }
        }
    }
}
