using AptekaEuLib.products;
using System;
using System.ComponentModel;

namespace AptekaEuLib.supplies
{
    public class SupplyItem
    {
        [DisplayName("Наименование товара")]
        public Product Product { get; set; }

        [DisplayName("Категория")]
        public Category Category
        {
            get
            {
                return Product.Category;
            }
        }

        [DisplayName("Стоимость товара")]
        public double UnitPrice { get; set; }

        [DisplayName("Стоимость товара")]
        public string UnitPriceDisplay 
        {
            get
            {
                return $"{UnitPrice:N2} руб.";
            }
        }

        [DisplayName("Количество")]
        public int Quantity { get; set; }

        [Browsable(false)]
        public double TotalCost
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }

        [DisplayName("Сумма позиции")]
        public string TotalCostDisplay
        {
            get
            {
                return $"{TotalCost:N2} руб.";
            }
        }

        [DisplayName("Дата производства")]
        public DateTime ProductionDate { get; set; }

        [DisplayName("Срок годности")]
        public DateTime ExpiryDate { get; set; }
    }
}
