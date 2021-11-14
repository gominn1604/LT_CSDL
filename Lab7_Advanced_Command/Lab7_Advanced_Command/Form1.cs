using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7_Advanced_Command
{
    public partial class Form1 : Form
    {
        private DataTable foodTable;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadCategory();
        }

        public void LoadCategory()
        {
            string connectionString = "server = DESKTOP-EH06V9H; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT ID, Name FROM Category";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();

            sqlConnection.Open();

            //Lấy dữ liệu từ csdl đưa vào database
            adapter.Fill(dt);

            sqlConnection.Close();
            sqlConnection.Dispose();

            //Đưa dữ liệu vào combobox
            cbbCategory.DataSource = dt;

            //Hiển thị tên nhóm sản phẩm
            cbbCategory.DisplayMember = "Name";

            //Nhưng khi lấy giá trị thì lấy ID của nhóm
            cbbCategory.ValueMember = "ID";
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedIndex == -1)
                return;

            string connectionString = "server = DESKTOP-EH06V9H; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = @categoryId";

            //Truyền tham số
            sqlCommand.Parameters.Add("@categoryId", SqlDbType.Int);

            if (cbbCategory.SelectedValue is DataRowView)
            {
                DataRowView rowView = cbbCategory.SelectedValue as DataRowView;
                sqlCommand.Parameters["@categoryId"].Value = rowView["ID"];
            }    
            else
            {
                sqlCommand.Parameters["@categoryId"].Value = cbbCategory.SelectedValue;
            }

            //Tạo bộ điều khiển dữ liệu
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            foodTable = new DataTable();

            //Mở kết nối
            sqlConnection.Open();

            //Lấy dữ liệu từ CSDL đưa vào DataTable
            adapter.Fill(foodTable);

            //Đóng kết nối và giải phóng bộ nhớ
            sqlConnection.Close();
            sqlConnection.Dispose();

            //Đưa dữ liệu vào data GridView
            SetColumnsHeaderText(foodTable);

            //Tính số lượng mẫu tin
            lblQuantity.Text = foodTable.Rows.Count.ToString();
            lblCatName.Text = cbbCategory.Text.ToLower();
        }

        private void tsmCalculateQuantity_Click(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-EH06V9H; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT @numSaleFood = sum(Quantity) FROM BillDetails WHERE FoodID = @foodId";

            //Lấy thông tin sản phẩm được chọn
            if (dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow seletedRow = dgvFoodList.SelectedRows[0];

                DataRowView rowView = seletedRow.DataBoundItem as DataRowView;

                //Truyền tham số
                sqlCommand.Parameters.Add("@foodId", SqlDbType.Int);
                sqlCommand.Parameters["@foodId"].Value = rowView["ID"];

                sqlCommand.Parameters.Add("@numSaleFood", SqlDbType.Int);
                sqlCommand.Parameters["@numSaleFood"].Direction = ParameterDirection.Output;

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                string result = sqlCommand.Parameters["@numSaleFood"].Value.ToString();
                MessageBox.Show("Tổng số lượng món " + rowView["Name"] + " đã bán là: " + result + " " + rowView["Unit"]);

                //Đóng kết nối CSDL
                sqlConnection.Close();
            }
            sqlCommand.Dispose();
            sqlConnection.Dispose();
        }

        

        private void FoodForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbCategory.SelectedIndex;
            cbbCategory.SelectedIndex = -1;
            cbbCategory.SelectedIndex = index;
        }
        private void tsmAddFood_Click(object sender, EventArgs e)
        {
            FoodInfoForm foodForm = new FoodInfoForm();
            foodForm.FormClosed += new FormClosedEventHandler(FoodForm_FormClosed1);

            foodForm.Show(this);
        }

        private void FoodForm_FormClosed1(object sender, FormClosedEventArgs e)
        {
            int index = cbbCategory.SelectedIndex;
            cbbCategory.SelectedIndex = -1;
            cbbCategory.SelectedIndex = index;
            this.LoadCategory();
        }

        private void tsmUpdateFood_Click(object sender, EventArgs e)
        {
            //Lấy thông tin sản phẩm được chọn
            if (dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                FoodInfoForm foodForm = new FoodInfoForm();
                foodForm.FormClosed += new FormClosedEventHandler(FoodForm_FormClosed);

                foodForm.Show(this);
                foodForm.DisplayFoodInfo(rowView);
                this.LoadCategory();
            }    
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (foodTable == null)
            {
                return;
            }

            //tạo bộ lọc và phân loại
            string filterExpresstion = "Name like '%" + txtSearchByName.Text + "%'";
            string sortExpresstion = "Price DESC";
            DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;

            DataView foodView = new DataView(foodTable, filterExpresstion, sortExpresstion, rowStateFilter);

            dgvFoodList.DataSource = foodView;
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm();
            ordersForm.Show(this);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            AccountForm account = new AccountForm();
            account.Show(this);
        }

        private void SetColumnsHeaderText(DataTable dt)
        {
            dgvFoodList.DataSource = dt;
            dgvFoodList.Columns[0].HeaderText = "Mã món ăn";
            dgvFoodList.Columns[1].HeaderText = "Tên món ăn";
            dgvFoodList.Columns[2].HeaderText = "Đơn vị tính";
            dgvFoodList.Columns[3].HeaderText = "Mã nhóm";
            dgvFoodList.Columns[4].HeaderText = "Giá";
            dgvFoodList.Columns[5].HeaderText = "Ghi chú";

            int count = dgvFoodList.Columns.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                dgvFoodList.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
