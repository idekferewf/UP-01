using System.Collections.Generic;

namespace AptekaEuLib
{
    public interface IProductsRepository
    {
        bool AddProduct(Product product);

        List<Product> ReadProducts();
    }
}
