namespace Bookkeeping.Model
{
    /// <summary>
    /// 收支分类实体类
    /// </summary>
    public class Category
    {
        /// <summary>
        /// 分类ID (主键)
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// 分类名称 (例如: 餐饮美食, 工资收入)
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 类型 ("收入" 或 "支出")
        /// </summary>
        public string Type { get; set; }
    }
}