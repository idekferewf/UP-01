using System.ComponentModel;

namespace AptekaEuLib
{
    public class Product
    {
        private int? id_;
        private int? categoryId_;

        [DisplayName("Название товара")]
        public string Name { get; set; }

        [DisplayName("Название категории")]
        public string CategoryName { get; set; }

        [DisplayName("Цена закупки")]
        public double PurchasePrice { get; set; }

        [DisplayName("Цена продажи")]
        public double SalePrice { get; set; }

        [DisplayName("Актуальное количество")]
        public int ActualQuantity { get; set; }

        public Product(int? id = null, int? categoryId = null)
        {
            id_ = id;
            categoryId_ = categoryId;
        }

        public int? GetCategoryId()
        {
            return categoryId_;
        }
    }
}
