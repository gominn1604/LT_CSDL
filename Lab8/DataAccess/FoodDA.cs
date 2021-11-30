using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FoodDA
    {
        public List<Food> GetAll()
        {
            //Khai báo đối tượng SQLConn và mở kết nối
            //Đối tượng SQLConn truyền vào chuỗi kết nối trong App.Config
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            //Khai báo đối tượng SQLCommand có kiểu xử lý là StoredProcedure
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Food_GetAll;

            //Đọc dữ liệu, trả về danh sách các đối tượng Food
            SqlDataReader dr = cmd.ExecuteReader();
            List<Food> list = new List<Food>();
            while (dr.Read())
            {
                Food food = new Food();
                food.ID = Convert.ToInt32(dr["ID"]);
                food.Name = dr["Name"].ToString();
                food.Unit = dr["Unit"].ToString();
                food.FoodCategoryID = Convert.ToInt32(dr[3]);
                food.Price = Convert.ToInt32(dr["Price"]);
                food.Notes = dr["Notes"].ToString();
                list.Add(food);
            }

            //Đóng kết nối và trả về danh sách
            conn.Close();
            return list;
        }

        public int Insert_Update_Delete(Food food, int action)
        {
            //Khai báo đối tượng SQLConn và mở kết nối
            //Đối tượng SQLConn truyền vào chuỗi trong App.Config
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            //Khai báo đối tượng SQLCommand có kiểu xử lý là StoredProcedure
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Food_InsertUpdateDelete;

            //Thêm các tham số cho thủ tục
            //ID là tham số lấy ra khi thêm và truyền vào khi xóa, sửa
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = food.Name;
            cmd.Parameters.Add("@Unit", SqlDbType.NVarChar, 100).Value = food.Unit;
            cmd.Parameters.Add("@FoodCategoryID", SqlDbType.Int).Value = food.FoodCategoryID;
            cmd.Parameters.Add("@Price", SqlDbType.Int).Value = food.Price;
            cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 3000).Value = food.Notes;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = cmd.ExecuteNonQuery();
            //Thực thi lệnh
            if (result > 0)
            {
                return (int)cmd.Parameters["@ID"].Value;
            }
            return 0;
        }
    }
}
