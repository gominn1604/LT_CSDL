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
    public partial class UpdateCategoryForm : Form
    {
        private RestaurantContext _dbContext;
        private int _categoryId;

        public UpdateCategoryForm(int? categoryId = null)
        {
            InitializeComponent();

            _dbContext = new RestaurantContext();
            _categoryId = categoryId ?? 0;
        }

        private Category GetCategoryById(int categoryId)
        {
            // Nếu ID được truyền vào là hợp lệ, ta tìm thông tin theo ID
            // Ngược lại, chỉ đơn giản trả về null, cho biết không thấy.
            return categoryId > 0 ? _dbContext.Categories.Find(categoryId) : null;
        }
        private void ShowCategory()
        {
            // Lấy thông tin của nhóm thức ăn
            var category = GetCategoryById(_categoryId);

            // Nếu không tìm thấy thông tin, không cần làm gì cả
            if (category == null) return;

            // Ngược lại, nếu tìm thấy, hiển thị lên form
            txtCategoryId.Text = category.ID.ToString();
            txtCategoryName.Text = category.Name;
            cbbCategoryType.SelectedIndex = (int)category.Type;
        }

        private void UpdateCategoryForm_Load(object sender, EventArgs e)
        {
            ShowCategory();
        }

        private Category GetUpdatedCategory()
        {
            var category = new Category()
            {
                Name = txtCategoryName.Text.Trim(),
                Type = (CategoryType)cbbCategoryType.SelectedIndex
            };
            if (_categoryId > 0)
            {
                category.ID = _categoryId;
            }
            return category;
        }
        private bool ValidateUserInput()
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên nhóm thức ăn không được để trống", "Thông báo");
                return false;
            }
            if (cbbCategoryType.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn loại nhóm thức ăn", "Thông báo");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUserInput())
            {
                var newCategory = GetUpdatedCategory();

                var oldCategory = GetCategoryById(_categoryId);

                if (oldCategory == null)
                {
                    _dbContext.Categories.Add(newCategory);
                }
                else
                {
                    oldCategory.Name = newCategory.Name;
                    oldCategory.Type = newCategory.Type;
                }

                _dbContext.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }
    }
}
