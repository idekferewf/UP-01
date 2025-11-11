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
        [TestMethod]
        public void TestGetAllSupplies()
        {
            var mockRepo = new Mock<ISuppliesRepository>();

            var existingProducts = new List<Product>
            {
                new Product(1) { Name = "Парацетамол 500 мг", Category = new Category(1), PurchasePrice = 299.00, SalePrice = 399.00, ActualQuantity = 100 },
                new Product(2) { Name = "Парацетамол 250 мг", Category = new Category(1), PurchasePrice = 159.00, SalePrice = 279.00, ActualQuantity = 13 },
                new Product(3) { Name = "Амоксиклав 625мг таб. №14", Category = new Category(2), PurchasePrice = 199.00, SalePrice = 349.00, ActualQuantity = 79 },
                new Product(4) { Name = "Мыло жидкое антибактериальное", Category = new Category(3), PurchasePrice = 249.00, SalePrice = 419.00, ActualQuantity = 54 }
            };

            var expectedSupplies = new List<Supply>
            {
                new Supply(1)
                {
                    SerialNumber = "SUP-2024-001",
                    SupplierTin = "1001",
                    DeliveryDate = new DateTime(2024, 1, 10),
                    Items = new List<SupplyItem>
                    {
                        new SupplyItem
                        {
                            Product = existingProducts[0],
                            Quantity = 50,
                            UnitPrice = existingProducts[0].PurchasePrice,
                            ProductionDate = new DateTime(2024, 1, 15),
                            ExpiryDate = new DateTime(2026, 1, 15)
                        },
                        new SupplyItem
                        {
                            Product = existingProducts[1],
                            Quantity = 30,
                            UnitPrice = existingProducts[1].PurchasePrice,
                            ProductionDate = new DateTime(2024, 2, 10),
                            ExpiryDate = new DateTime(2025, 8, 10)
                        }
                    }
                },
                new Supply(2)
                {
                    SerialNumber = "SUP-2024-002",
                    SupplierTin = "1002",
                    DeliveryDate = new DateTime(2024, 1, 12),
                    Items = new List<SupplyItem>
                    {
                        new SupplyItem
                        {
                            Product = existingProducts[3],
                            Quantity = 100,
                            UnitPrice = existingProducts[3].PurchasePrice,
                            ProductionDate = new DateTime(2024, 3, 5),
                            ExpiryDate = new DateTime(2026, 3, 5)
                        }
                    }
                },
                new Supply(3)
                {
                    SerialNumber = "SUP-2024-003",
                    SupplierTin = "1003",
                    DeliveryDate = new DateTime(2024, 1, 15),
                    Items = new List<SupplyItem>
                    {
                        new SupplyItem
                        {
                            Product = existingProducts[0],
                            Quantity = 40,
                            UnitPrice = existingProducts[0].PurchasePrice,
                            ProductionDate = new DateTime(2024, 1, 25),
                            ExpiryDate = new DateTime(2025, 7, 25)
                        },
                        new SupplyItem
                        {
                            Product = existingProducts[2],
                            Quantity = 80,
                            UnitPrice = existingProducts[2].PurchasePrice,
                            ProductionDate = new DateTime(2024, 3, 1),
                            ExpiryDate = new DateTime(2026, 3, 1)
                        },
                        new SupplyItem
                        {
                            Product = existingProducts[3],
                            Quantity = 15,
                            UnitPrice = existingProducts[3].PurchasePrice,
                            ProductionDate = new DateTime(2024, 2, 20),
                            ExpiryDate = new DateTime(2025, 11, 20)
                        }
                    }
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
                Assert.AreEqual(expectedSupplies[i].SerialNumber, actualSupplies[i].SerialNumber, $"Серийный номер поставки {i} не совпадает");
                Assert.AreEqual(expectedSupplies[i].SupplierTin, actualSupplies[i].SupplierTin, $"ИНН поставщика поставки {i} не совпадает");
                Assert.AreEqual(expectedSupplies[i].DeliveryDate, actualSupplies[i].DeliveryDate, $"Дата поставки {i} не совпадает");
                Assert.AreEqual(expectedSupplies[i].Items.Count, actualSupplies[i].Items.Count, $"Количество позиций в поставке {i} не совпадает");
            }
        }
    }
}
