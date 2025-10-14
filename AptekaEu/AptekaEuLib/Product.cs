using System.ComponentModel;

namespace AptekaEuLib
{
    public class Product
    {
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("Название товара")]
        public string Name { get; set; }

        [DisplayName("ID категории")]
        public int CategoryId { get; set; }

        [DisplayName("Цена закупки")]
        public double PurchasePrice { get; set; }

        [DisplayName("Цена продажи")]
        public double SalePrice { get; set; }

        [DisplayName("Актуальное количество")]
        public int ActualQuantity { get; set; }
    }
}
