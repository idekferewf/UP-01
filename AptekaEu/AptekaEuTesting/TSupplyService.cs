using AptekaEuLib;
using AptekaEuLib.products;
using AptekaEuLib.supplies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace AptekaEuTesting
{
    [TestClass]
    public class TSupplyService
    {
        public void TestGetAllSupplies()
        {
            var mockRepo = new Mock<ISuppliesRepository>();

            var existingProducts = new List<Product>
            {
                new Product(1) { Name = "Парацетамол 500 мг", Category = new Category(1), PurchasePrice = 299.00, SalePrice = 399.00, ActualQuantity = 100 },
                new Product(2) { Name = "Парацетамол 250 мг", Category = new Category(1), PurchasePrice = 159.00, SalePrice = 279.00, ActualQuantity = 13 },
            };

            var expectedSupplies = new List<Supply>
            {
                new Supply(1)
                {
                    Product = existingProducts[0],
                    SupplierTin = 1001,
                    Quantity = 50,
                    ProductionDate = new DateTime(2024, 1, 15),
                    ExpiryDate = new DateTime(2026, 1, 15)
                },
                new Supply(2)
                {
                    Product = existingProducts[1],
                    SupplierTin = 1002,
                    Quantity = 30,
                    ProductionDate = new DateTime(2024, 2, 10),
                    ExpiryDate = new DateTime(2025, 8, 10)
                },
                new Supply(3)
                {
                    Product = existingProducts[1],
                    SupplierTin = 1003,
                    Quantity = 25,
                    ProductionDate = new DateTime(2024, 1, 20),
                    ExpiryDate = new DateTime(2025, 7, 20)
                }
            };

            mockRepo.Setup(repo => repo.ReadSupplies()).Returns(expectedSupplies);

            var supplyService = new SupplyService(mockRepo.Object);

            var actualSupplies = supplyService.GetAllSupplies();

            Assert.IsNotNull(actualSupplies);
            Assert.AreEqual(expectedSupplies.Count, actualSupplies.Count);

            mockRepo.Verify(repo => repo.ReadSupplies(), Times.Once);

            for (int i = 0; i < expectedSupplies.Count; i++)
            {
                Assert.AreEqual(expectedSupplies[i].Id, actualSupplies[i].Id, $"Id поставки {i} не совпадает");
                Assert.AreEqual(expectedSupplies[i].Product.Name, actualSupplies[i].Product.Name, $"Название продукта поставки {i} не совпадает");
                Assert.AreEqual(expectedSupplies[i].SupplierTin, actualSupplies[i].SupplierTin, $"ИНН поставщика поставки {i} не совпадает");
                Assert.AreEqual(expectedSupplies[i].Quantity, actualSupplies[i].Quantity, $"Количество поставки {i} не совпадает");
                Assert.AreEqual(expectedSupplies[i].ProductionDate, actualSupplies[i].ProductionDate, $"Дата производства поставки {i} не совпадает");
                Assert.AreEqual(expectedSupplies[i].ExpiryDate, actualSupplies[i].ExpiryDate, $"Срок годности поставки {i} не совпадает");
            }
        }
    }
}
