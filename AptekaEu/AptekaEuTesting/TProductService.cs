using AptekaEuLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AptekaEuTesting
{
    [TestClass]
    public class TProductService
    {
        [TestMethod]
        [DataRow("Парацетамол 500 мг", 1, 299.00, 399.00, 100, true, "")]
        [DataRow("", 2, 249.00, 319.00, 22, false, "Наименование товара не может быть пустым.")]
        [DataRow("Парацетамол 250 мг", 6, 229.00, -129.00, 64, false, "Цена продажи не может быть отрицательной.")]
        [DataRow("Парацетамол 900 мг", 3, -189.00, 399.00, 8, false, "Цена закупки не может быть отрицательной.")]
        [DataRow("Парацетамол 500 мг", -1, 299.00, 399.00, 100, false, "Категория не найдена.")]
        public void TAddProduct(string name, int categoryId, double purchasePrice, double salePrice, int actualQuantity, bool result, string expected)
        {
            var mockRepo = new Mock<IProductsRepository>();

            var product = new Product()
            {
                Name = name,
                CategoryId = categoryId,
                PurchasePrice = purchasePrice,
                SalePrice = salePrice,
                ActualQuantity = actualQuantity
            };

            mockRepo.Setup(r => r.AddProduct(product)).Returns(result);

            var productService = new ProductService(mockRepo.Object);

            string error = productService.AddProduct(product);

            Assert.AreEqual(expected, error);

            if (string.IsNullOrEmpty(error))
            {
                mockRepo.Verify(r => r.AddProduct(product), Times.Once);
            } else
            {
                mockRepo.Verify(r => r.AddProduct(product), Times.Never);
            }
        }
    }
}
