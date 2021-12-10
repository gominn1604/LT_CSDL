using Lab09_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab09_Entity_Framework
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowCategories();
        }

        private void btnReloadCategory_Click(object sender, EventArgs e)
        {
            ShowCategories();
        }

        private List<Category> GetCategories()
        {
            //Khởi tạo đối tượng Context
            var dbContext = new RestaurantContext();

            //Lấy ds tất cả nhóm thức ăn, sắp xếp theo tên
            return dbContext.Categories.OrderBy(x => x.Name).ToList();
        }

        private void ShowCategories()
        {
            tvCategory.Nodes.Clear();
            var cateMap = new Dictionary<CategoryType, string>()
            {
                [CategoryType.Food] = "Đồ ăn",
                [CategoryType.Drink] = "Thức uống"
            };
            var rootNode = tvCategory.Nodes.Add("Tất cả");
            var categories = GetCategories();
            foreach (var cateType in cateMap)
            {
                var childNode = rootNode.Nodes.Add(cateType.Key.ToString(), cateType.Value);
                childNode.Tag = cateType.Key;
                foreach (var category in categories)
                {
                    if (category.Type != cateType.Key) continue;
                    var grantChildNode = childNode.Nodes.Add(category.ID.ToString(), category.Name);
                    grantChildNode.Tag = category;
                }
            }
            tvCategory.ExpandAll();
            tvCategory.SelectedNode = rootNode;
        }

        private List<FoodModel> GetFoodByCategory(int? categoryId)
        {
            //Khởi tạo đối tượng Context
            var dbContext = new RestaurantContext();

            //Tạo truy vấn lấy danh sách món ăn
            var foods = dbContext.Foods.AsQueryable();

            //Nếu mã nhóm món ăn khác null và hợp lệ
            if (categoryId != null && categoryId > 0)
            {
                foods = foods.Where(x => x.FoodCategoryID == categoryId);
            }

            //Sắp xếp đồ ăn, thức uống theo tên và trả về
            //danh sách chứa đầy đủ thông tin về món ăn.
            return foods
                .OrderBy(x => x.Name)
                .Select(x => new FoodModel()
                {
                    ID = x.ID,
                    Name = x.Name,
                    Unit = x.Unit,
                    Price = x.Price,
                    Notes = x.Notes,
                    CategoryName = x.Category.Name
                })
                .ToList();
        }



        private List<FoodModel> GetFoodByCategoryType(CategoryType cateType)
        {
            var dbContext = new RestaurantContext();

            //tìm kiếm các món ăn theo loại nhóm thức ăn (CategoryType).
            //Sắp xếp đồ ăn, thức uống theo tên và trả về danh sách chứa đầy đủ thông tin của món ăn    
            return dbContext.Foods
                .Where(x => x.Category.Type == cateType)
                .OrderBy(x => x.Name)
                .Select(x => new FoodModel()
                {
                    ID = x.ID,
                    Name = x.Name,
                    Unit = x.Unit,
                    Price = x.Price,
                    Notes = x.Notes,
                    CategoryName = x.Category.Name
                })
                .ToList();
        }

        private void ShowFoodsForNode(TreeNode node)
        {
            lvFood.Items.Clear();
            if (node == null) return;
            List<FoodModel> foods = null;
            if (node.Level == 1)
            {
                var categoryType = (CategoryType)node.Tag;
                foods = GetFoodByCategoryType(categoryType);
            }
            else
            {
                var category = node.Tag as Category;
                foods = GetFoodByCategory(category?.ID);
            }
            ShowFoodsOnListView(foods);
        }

        private void ShowFoodsOnListView(List<FoodModel> foods)
        {
            // Duyệt qua từng phần tử của danh sách food
            foreach (var foodItem in foods)
            {
                // Tạo item tương ứng trên ListView
                var item = lvFood.Items.Add(foodItem.ID.ToString());

                // Và hiến thị các thông tin của món ăn
                item.SubItems.Add(foodItem.Name);
                item.SubItems.Add(foodItem.Unit);
                item.SubItems.Add(foodItem.Price.ToString("##,###"));
                item.SubItems.Add(foodItem.CategoryName);
                item.SubItems.Add(foodItem.Notes);
            }
        }

        private void tvCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowFoodsForNode(e.Node);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var dialog = new UpdateCategoryForm();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowCategories();
            }    
        }

        private void tvCategory_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null || e.Node.Level < 2 || e.Node.Tag == null) return;

            var category = e.Node.Tag as Category;
            var dialog = new UpdateCategoryForm(category?.ID);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowCategories();
            }
        }

        private void btnReloadFood_Click(object sender, EventArgs e)
        {
            ShowFoodsForNode(tvCategory.SelectedNode);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvFood.SelectedItems.Count == 0)
                return;

            var dbConText = new RestaurantContext();
            var selectedFoodId = int.Parse(lvFood.SelectedItems[0].Text);

            var selectedFood = dbConText.Foods.Find(selectedFoodId);

            if (selectedFoodId != null)
            {
                dbConText.Foods.Remove(selectedFood);
                dbConText.SaveChanges();

                lvFood.Items.Remove(lvFood.SelectedItems[0]);
            }    
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            var dialog = new UpdateFoodForm();
            if(dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowFoodsForNode(tvCategory.SelectedNode); 
            }    
        }

        private void lvFood_DoubleClick(object sender, EventArgs e)
        {
            if (lvFood.SelectedItems.Count == 0)
                return;

            var foodID = int.Parse(lvFood.SelectedItems[0].Text);
            var dialog = new UpdateFoodForm(foodID);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowFoodsForNode(tvCategory.SelectedNode);
            }    
        }
    }
}
