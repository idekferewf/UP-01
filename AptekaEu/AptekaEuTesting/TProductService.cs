using AptekaEuLib;
using AptekaEuLib.products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace AptekaEuTesting
{
    [TestClass]
    public class TProductService
    {
        [TestMethod]
        [DataRow("Парацетамол 500 мг", 1, 299.00, 399.00, 100, 1, "")]
        [DataRow("", 2, 249.00, 319.00, 22, 0, "Наименование товара не может быть пустым.")]
        [DataRow("Парацетамол 250 мг", 6, 229.00, -129.00, 64, 0, "Цена продажи не может быть отрицательной.")]
        [DataRow("Парацетамол 900 мг", 3, -189.00, 399.00, 8, 0, "Цена закупки не может быть отрицательной.")]
        [DataRow("Парацетамол 500 мг", -1, 299.00, 399.00, 100, 0, "Категория не найдена.")]
        public void TestAddProduct(string name, int categoryId, double purchasePrice, double salePrice, int actualQuantity, int result, string expected)
        {
            Mock<IProductsRepository> mockRepo = new Mock<IProductsRepository>();

            Category category = new Category(categoryId);

            Product product = new Product(null)
            {
                Name = name,
                Category = category,
                PurchasePrice = purchasePrice,
                SalePrice = salePrice,
                ActualQuantity = actualQuantity
            };

            mockRepo.Setup(r => r.AddProduct(product)).Returns(result);

            ProductService productService = new ProductService(mockRepo.Object);

            string error = productService.AddProduct(product);

            Assert.AreEqual(expected, error);

            if (string.IsNullOrEmpty(error))
            {
                mockRepo.Verify(r => r.AddProduct(product), Times.Once);
            }
            else
            {
                mockRepo.Verify(r => r.AddProduct(product), Times.Never);
            }
        }

        [TestMethod]
        [DataRow(new int[] { 2 }, true, "")]
        [DataRow(new int[] { 2, 4 }, true, "")]
        [DataRow(new int[] { 19 }, false, "Данных товаров не существует.")]
        [DataRow(new int[] { 19, 9 }, false, "Данных товаров не существует.")]
        public void TestDeleteProduct(int[] productIds, bool result, string expected)
        {
            Mock<IProductsRepository> mockRepo = new Mock<IProductsRepository>();
            ProductService productService = new ProductService(mockRepo.Object);

            List<Product> existingProducts = new List<Product>
            {
                new Product(1) { Name = "Парацетамол 500 мг", Category = new Category(1), PurchasePrice = 299.00, SalePrice = 399.00, ActualQuantity = 100 },
                new Product(2) { Name = "Парацетамол 250 мг", Category = new Category(1), PurchasePrice = 159.00, SalePrice = 279.00, ActualQuantity = 13 },
                new Product(3) { Name = "Амоксиклав 625мг таб. №14", Category = new Category(2), PurchasePrice = 199.00, SalePrice = 349.00, ActualQuantity = 79 },
                new Product(4) { Name = "Мыло жидкое антибактериальное", Category = new Category(3), PurchasePrice = 249.00, SalePrice = 419.00, ActualQuantity = 54 }
            };

            foreach (Product product in existingProducts)
            {
                mockRepo.Setup(r => r.AddProduct(product)).Returns((int)product.Id);
                productService.AddProduct(product);
            }

            List<int> productsIdsList = productIds.ToList();
            mockRepo.Setup(r => r.DeleteProducts(productsIdsList)).Returns(result);

            string error = productService.DeleteProducts(productsIdsList);

            Assert.AreEqual(expected, error);

            if (string.IsNullOrEmpty(error))
            {
                mockRepo.Verify(r => r.DeleteProducts(productsIdsList), Times.Once);
            }
            else
            {
                mockRepo.Verify(r => r.DeleteProducts(productsIdsList), Times.Never);
            }
        }
    }
}
