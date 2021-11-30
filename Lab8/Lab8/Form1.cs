using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace Lab8
{
    public partial class frmFood : Form
    {
        List<Category> listCategory = new List<Category>();
        List<Food> listFood = new List<Food>();

        Food foodCurrent = new Food();
        public frmFood()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmFood_Load(object sender, EventArgs e)
        {
            //Đổ dữ liệu vào ComboBox
            LoadCategory();
            //Đổ dữ liệu vào ListView
            LoadFoodDataToListView();
        }

        private void LoadCategory()
        {
            //Gọi đối tượng CategoryBL từ tầng BusinessLogic
            CategoryBL categoryBL = new CategoryBL();
            //Lấy dữ liệu gán cho biến toàn cục listCategory
            listCategory = categoryBL.GetAll();
            //Chuyển vào Combobox với dữ liệu là ID, hiển thị là Name
            cbbCategory.DataSource = listCategory;
            cbbCategory.ValueMember = "ID";
            cbbCategory.DisplayMember = "Name";
        }

        public void LoadFoodDataToListView()
        {
            //Gọi đối tượng FoodBL từ tầng BusinessLogic
            FoodBL foodBL = new FoodBL();
            // Lấy dữ liệu
            listFood = foodBL.GetAll();
            int count = 1; // Biến số thứ tự
                           // Xoá dữ liệu trong ListView
            lvFood.Items.Clear();
            // Duyệt mảng dữ liệu để đưa vào ListView
            foreach (var food in listFood)
            {
                // Số thứ tự
                ListViewItem item = lvFood.Items.Add(count.ToString());
                // Đưa dữ liệu Name, Unit, price vào cột tiếp theo
                item.SubItems.Add(food.Name);
                item.SubItems.Add(food.Unit);
                item.SubItems.Add(food.Price.ToString());
                // Theo dữ liệu của bảng Category ID, lấy Name để hiển thị
                string foodName = listCategory
                .Find(x => x.ID == food.FoodCategoryID).Name;
                item.SubItems.Add(foodName);
                // Đưa dữ liệu Notes vào cột cuối
                item.SubItems.Add(food.Notes);
                count++;
            }
        }

        private void lvFood_Click(object sender, EventArgs e)
        {
            // Duyệt toàn bộ dữ liệu trong ListView
            for (int i = 0; i < lvFood.Items.Count; i++)
            {
                // Nếu có dòng được chọn thì lấy dòng đó
                if (lvFood.Items[i].Selected)
                {
                    // Lấy các tham số và gán dữ liệu vào các ô
                    foodCurrent = listFood[i];
                    txtName.Text = foodCurrent.Name;
                    txtUnit.Text = foodCurrent.Unit;
                    txtPrice.Text = foodCurrent.Price.ToString();
                    txtNotes.Text = foodCurrent.Notes;
                    // Lấy index của Combobox theo FoodCategoryID
                    cbbCategory.SelectedIndex = listCategory.FindIndex(x => x.ID == foodCurrent.FoodCategoryID);
                }
            }
        }

        public int InsertFood()
        {
            Food food = new Food();
            food.ID = 0;

            if (txtName.Text == "" || txtUnit.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Chưa nhập đầy đủ dữ liệu. Vui lòng kiểm tra lại!");
            }
            else
            {
                food.Name = txtName.Text;
                food.Unit = txtUnit.Text;
                food.Notes = txtNotes.Text;
                //Giá trị price là giá trị số nên cần bắt lỗi khi người dùng nhập sai
                int price = 0;
                try
                {
                    price = int.Parse(txtPrice.Text);
                }
                catch
                {
                    price = 0;
                }
                food.Price = price;
                food.FoodCategoryID = int.Parse(cbbCategory.SelectedValue.ToString());
                //Khao báo đối tượng FoodBL từ tầng Business
                FoodBL foodBL = new FoodBL();
                return foodBL.Insert(food);
            }
            return -1;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            int result = InsertFood();
            if (result > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công");
                LoadFoodDataToListView();
            }
            else MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại.");
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPrice.Text = "0";
            txtUnit.Text = "";
            txtNotes.Text = "";
            // Thiết lập index = 0 cho ComboBox
            if (cbbCategory.Items.Count > 0)
            {
                cbbCategory.SelectedIndex = 0;
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá mẫu tin này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                FoodBL foodBL = new FoodBL();
                if (foodBL.Delete(foodCurrent) > 0)
                {
                    MessageBox.Show("Xoá thực phẩm thành công");
                    LoadFoodDataToListView();
                }
                else MessageBox.Show("Xoá không thành công");
            }
        }

        public int UpdateFood()
        {
            Food food = foodCurrent;
            if (txtName.Text == "" || txtUnit.Text == "" || txtPrice.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
            else
            {
                food.Name = txtName.Text;
                food.Unit = txtUnit.Text;
                food.Notes = txtNotes.Text;
                //Giá trị price là giá trị số nên cần bắt lỗi khi người dùng nhập sai
                int price = 0;
                try
                {
                    price = int.Parse(txtPrice.Text);
                }
                catch
                {
                    price = 0;
                }
                food.Price = price;
                //Giá trị FoodCategoryID được lấy từ ComboBox
                food.FoodCategoryID = int.Parse(cbbCategory.SelectedValue.ToString());
                //Khao báo đối tượng FoodBL từ tầng Business
                FoodBL foodBL = new FoodBL();
                //Cập nhật dữ liệu trong bảng
                return foodBL.Update(food);
            }
            return -1;
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            int result = UpdateFood();
            if (result > 0)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công");
                LoadFoodDataToListView();
            }
            else MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }
    }
}
