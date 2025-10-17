﻿using AptekaEuLib.products;
using System.ComponentModel;

namespace AptekaEuLib
{
    public class Product
    {
        private int? id_;

        [DisplayName("Название товара")]
        public string Name { get; set; }

        [DisplayName("Категория")]
        public Category Category { get; set; }

        [DisplayName("Цена закупки")]
        public double PurchasePrice { get; set; }

        [DisplayName("Цена продажи")]
        public double SalePrice { get; set; }

        [DisplayName("Актуальное количество")]
        public int ActualQuantity { get; set; }

        public Product(int? id = null)
        {
            id_ = id;
        }
    }
}
