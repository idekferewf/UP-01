using AptekaEuLib.products;
using System.ComponentModel;

namespace AptekaEuLib
{
    public class Product
    {
        private int? id_;

        [Browsable(false)]
        public int? Id { get { return id_; } set { id_ = value; } }

        [DisplayName("Название товара")]
        public string Name { get; set; }

        [DisplayName("Категория")]
        public Category Category { get; set; }

        [Browsable(false)]
        public double PurchasePrice { get; set; }

        [DisplayName("Цена закупки")]
        public string PurchasePriceDisplay
        {
            get
            {
                return $"{PurchasePrice:N2} руб.";
            }
        }

        [Browsable(false)]
        public double SalePrice { get; set; }

        [DisplayName("Цена закупки")]
        public string SalePriceDisplay
        {
            get
            {
                return $"{SalePrice:N2} руб.";
            }
        }

        [DisplayName("Актуальное количество")]
        public int ActualQuantity { get; set; }

        public Product(int? id = null)
        {
            id_ = id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
