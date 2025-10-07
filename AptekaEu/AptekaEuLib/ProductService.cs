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
            return string.Empty;
        }
    }
}
