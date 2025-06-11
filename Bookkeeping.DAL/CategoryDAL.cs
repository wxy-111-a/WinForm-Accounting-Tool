using Bookkeeping.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Bookkeeping.DAL
{
    /// <summary>
    /// 收支分类数据访问类
    /// </summary>
    public class CategoryDAL
    {
        /// <summary>
        /// 获取所有分类信息
        /// </summary>
        public List<Category> GetAllCategories()
        {
            List<Category> list = new List<Category>();
            string sql = "SELECT CategoryID, CategoryName, Type FROM Categories ORDER BY Type, CategoryID";

            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Category()
                        {
                            CategoryID = (int)reader["CategoryID"],
                            CategoryName = reader["CategoryName"].ToString(),
                            Type = reader["Type"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 添加一个新的分类
        /// </summary>
        public int AddCategory(Category category)
        {
            string sql = "INSERT INTO Categories (CategoryName, Type) VALUES (@CategoryName, @Type)";
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("@Type", category.Type);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 更新一个已有的分类
        /// </summary>
        public int UpdateCategory(Category category)
        {
            string sql = "UPDATE Categories SET CategoryName = @CategoryName, Type = @Type WHERE CategoryID = @CategoryID";
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("@Type", category.Type);
                cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 根据ID删除一个分类
        /// </summary>
        public int DeleteCategory(int categoryId)
        {
            // 注意：实际项目中需要检查该分类是否已被交易记录使用
            string sql = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}