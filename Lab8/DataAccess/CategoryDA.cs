using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccess
{
    public class CategoryDA
    {
        public List<Category> GetAll()
        {
            //Khai báo đối tượng SQLConn và mở kết nối
            //Đối tượng SQLConn truyền vào chuỗi kết nối trong App.Config
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            //Khai báo đối tượng SQLCommand có kiểu xử lý là StoredProcedure
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Category_GetAll;

            //Đọc dữ liệu, trả về danh sách các đối tượng Category
            SqlDataReader dr = cmd.ExecuteReader();
            List<Category> list = new List<Category>();
            while (dr.Read())
            {
                Category category = new Category();
                category.ID = Convert.ToInt32(dr["ID"]);
                category.Name = dr["Name"].ToString();
                category.Type = Convert.ToInt32(dr["Type"]);
                list.Add(category);
            }
            //Đóng kết nối và trả về danh sách
            conn.Close();
            return list;
        }

        public int Insert_Update_Delete(Category category, int action)
        {
            //Khai báo đối tượng SQLConn và mở kết nối
            //Đối tượng SQLConn truyền vào chuỗi kết nối trong App.Config
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            //Khai báo đối tượng SQLCommand có kiểu xử lý là StoredProcedure
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Category_InsertUpdateDelete;

            //Thêm các tham số cho thủ tục; Các tham số này chính là các tham số trong thủ tục
            //ID là tham số có giá trị lấy ra khi thêm và truyền vào khi xóa, sửa
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput; //vừa vào vừa ra =))
            cmd.Parameters.Add(IDPara).Value = category.ID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 200).Value = category.Name;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = category.Type;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            //Thực thi lệnh
            int result = cmd.ExecuteNonQuery();
            if (result > 0) //Nếu thành công thì trả về ID đã thực thi
            {
                return (int)cmd.Parameters["@ID"].Value;
            }
            return 0;
        }
    }
}
