using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaEuLib
{
    public class ProductService
    {
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

            if (product.PurchasePrice <= 0 || product.SalePrice <= 0)
            {
                return "Цена не может быть отрицательной.";
            }

            productsRepository_.AddProduct(product);

            return string.Empty;
        }
    }
}
