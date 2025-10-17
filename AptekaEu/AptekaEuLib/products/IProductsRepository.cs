using AptekaEuLib.products;
using System.Collections.Generic;

namespace AptekaEuLib
{
    public interface IProductsRepository
    {
        bool AddProduct(Product product);

        List<Product> ReadProducts();

        List<Category> ReadCategories();
    }
}
