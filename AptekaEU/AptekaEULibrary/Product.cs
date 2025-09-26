using System.ComponentModel;

namespace AptekaEULibrary
{
    public class Product
    {
        [DisplayName("ID товара")]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("ID категории")]
        public int CategoryId { get; set; }

        [DisplayName("Цена продажи")]
        public decimal PurchasePrice { get; set; }

        [DisplayName("Цена продажи")]
        public decimal SalePrice { get; set; }

        [DisplayName("Актуальное количество")]
        public int ActualQuantity { get; set; }
    }
}
