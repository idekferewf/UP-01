using AptekaEuLib.products;
using System.Collections.Generic;
using System.ComponentModel;

namespace AptekaEuLib
{
    public class ProductService
    {
        private BindingList<Product> products_ = new BindingList<Product>();
        private IProductsRepository productsRepository_;

        public ProductService(IProductsRepository productsRepository)
        {
            productsRepository_ = productsRepository;
        }

        public string AddProduct(Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
            {
                return "Наименование товара не может быть пустым.";
            }

            if (product.Category.Id <= 0)
            {
                return "Категория не найдена.";
            }

            if (product.PurchasePrice <= 0)
            {
                return "Цена закупки не может быть отрицательной.";
            }

            if (product.SalePrice <= 0)
            {
                return "Цена продажи не может быть отрицательной.";
            }

            bool is_added = productsRepository_.AddProduct(product);
            if (is_added)
            {
                products_.Add(product);
            }
            else
            {
                return "Не удалось добавить товар в базу данных.";
            }

            return string.Empty;
        }

        public BindingList<Product> GetAllProducts()
        {
            products_ = new BindingList<Product>(productsRepository_.ReadProducts());
            return products_;
        }

        public List<Category> GetAllCategories()
        {
            return productsRepository_.ReadCategories();
        }
    }
}
