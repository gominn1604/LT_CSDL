using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class FoodBL
    {
        FoodDA foodDA = new FoodDA();

        //Phương thức lấy hết dữ liệu
        public List<Food> GetAll()
        {
            return foodDA.GetAll();
        }

        //Phương thức thêm dữ liệu
        public int Insert(Food food)
        {
            return foodDA.Insert_Update_Delete(food, 0);
        }

        //Phương thức cập nhật dữ liệu
        public int Update(Food food)
        {
            return foodDA.Insert_Update_Delete(food, 1);
        }

        //Phương thức xóa dữ liệu với ID cho trước
        public int Delete(Food food)
        {
            return foodDA.Insert_Update_Delete(food, 2);
        }

        //Lấy về đối tượng Food theo khóa chính
        public Food GetByID(int ID)
        {
            //Lấy hết
            List<Food> list = GetAll();
            //Duyệt để tìm
            foreach (var item in list)
            {
                if (item.ID == ID)
                    return item;
            }
            return null;
        }

        //Tìm kiếm đối tượng theo khóa
        public List<Food> Find(string key)
        {
            //Lấy hết
            List<Food> list = GetAll();
            List<Food> listResult = new List<Food>();
            //Duyệt theo danh sách
            foreach (var item in list)
            {
                //Nếu từng trường có chứa từ khóa
                if (item.ID.ToString().Contains(key)
                    || item.Name.Contains(key)
                    || item.Unit.Contains(key)
                    || item.Price.ToString().Contains(key)
                    || item.Notes.Contains(key))
                {
                    listResult.Add(item); // Nếu có chứa khóa thì thêm vào ds kết quả
                }
            }
            return listResult;
        }
    }
}
