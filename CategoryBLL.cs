using Bookkeeping.DAL;
using Bookkeeping.Model;
using System.Collections.Generic;

namespace Bookkeeping.BLL
{
    /// <summary>
    /// 收支分类业务逻辑类
    /// </summary>
    public class CategoryBLL
    {
        private readonly CategoryDAL _categoryDAL = new CategoryDAL();

        /// <summary>
        /// 获取所有分类
        /// </summary>
        public List<Category> GetAllCategories()
        {
            return _categoryDAL.GetAllCategories();
        }

        /// <summary>
        /// 添加新分类
        /// </summary>
        public bool AddCategory(Category category)
        {
            // 业务逻辑检查：分类名和类型不能为空
            if (string.IsNullOrWhiteSpace(category.CategoryName) || string.IsNullOrWhiteSpace(category.Type))
            {
                return false;
            }
            return _categoryDAL.AddCategory(category) > 0;
        }

        /// <summary>
        /// 更新分类信息
        /// </summary>
        public bool UpdateCategory(Category category)
        {
            // 业务逻辑检查：分类名和类型不能为空
            if (string.IsNullOrWhiteSpace(category.CategoryName) || string.IsNullOrWhiteSpace(category.Type))
            {
                return false;
            }
            return _categoryDAL.UpdateCategory(category) > 0;
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        public bool DeleteCategory(int categoryId)
        {
            // 可以在此添加业务逻辑，例如检查该分类下是否有交易记录
            return _categoryDAL.DeleteCategory(categoryId) > 0;
        }
    }
}