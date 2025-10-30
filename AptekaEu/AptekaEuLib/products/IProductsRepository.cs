using AptekaEuLib.products;
using System.Collections.Generic;

namespace AptekaEuLib
{
    public interface IProductsRepository
    {
        int AddProduct(Product product);

        bool DeleteProducts(List<int> productIds);

        List<Product> ReadProducts();

        List<Category> ReadCategories();
    }
}
