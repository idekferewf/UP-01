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

            if (product.CategoryId <= 0)
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

            productsRepository_.AddProduct(product);

            return string.Empty;
        }
    }
}
