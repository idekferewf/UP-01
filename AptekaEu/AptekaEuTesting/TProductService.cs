using AptekaEuLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AptekaEuTesting
{
    [TestClass]
    public class TProductService
    {
        [TestMethod]
        public void TAddProduct_ValidData()
        {
            var mockRepo = new Mock<IProductsRepository>();

            var product = new Product()
            {
                Name = "Парацетамол 500 мг",
                CategoryId = 1,
                PurchasePrice = 299.00M,
                SalePrice = 399.00M,
                ActualQuantity = 100
            };

            var productService = new ProductService(mockRepo.Object);

            string error = productService.AddProduct(product);

            Assert.AreEqual(string.Empty, error);

            mockRepo.Verify(r => r.AddProduct(product), Times.Once);
        }
    }
}
