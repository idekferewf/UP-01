using AptekaEuLib;
using AptekaEuLib.products;
using AptekaEuLib.supplies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AptekaEuTesting
{
    [TestClass]
    public class TSupplyService
    {
        [TestMethod]
        public void TestGetAllSupplies()
        {
            Mock<ISuppliesRepository> mockRepo = new Mock<ISuppliesRepository>();

            List<Product> existingProducts = new List<Product>
            {
                new Product(1) { Name = "Парацетамол 500 мг", Category = new Category(1), PurchasePrice = 299.00, SalePrice = 399.00, ActualQuantity = 100 },
                new Product(2) { Name = "Парацетамол 250 мг", Category = new Category(1), PurchasePrice = 159.00, SalePrice = 279.00, ActualQuantity = 13 },
                new Product(3) { Name = "Амоксиклав 625мг таб. №14", Category = new Category(2), PurchasePrice = 199.00, SalePrice = 349.00, ActualQuantity = 79 },
                new Product(4) { Name = "Мыло жидкое антибактериальное", Category = new Category(3), PurchasePrice = 249.00, SalePrice = 419.00, ActualQuantity = 54 }
            };

            List<Supply> expectedSupplies = new List<Supply>
            {
                new Supply("SUP-2024-001")
                {
                    Supplier = new Supplier("1001"),
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
                new Supply("SUP-2024-002")
                {
                    Supplier = new Supplier("1002"),
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
                new Supply("SUP-2024-003")
                {
                    Supplier = new Supplier("1003"),
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

            SupplyService supplyService = new SupplyService(mockRepo.Object);

            BindingList<Supply> actualSupplies = supplyService.GetAllSupplies();
            List<Supply> actualSuppliesList = new List<Supply>(actualSupplies);

            Assert.IsNotNull(actualSupplies);
            Assert.AreEqual(expectedSupplies.Count, actualSuppliesList.Count);

            mockRepo.Verify(repo => repo.ReadSupplies(), Times.Once);

            CollectionAssert.AreEqual(expectedSupplies, actualSuppliesList);
        }

        [TestMethod]
        public void TestAddSupply_WithCorrectData()
        {
            Mock<ISuppliesRepository> mockRepo = new Mock<ISuppliesRepository>();
            SupplyService supplyService = new SupplyService(mockRepo.Object);

            Supplier supplier = new Supplier("1001") { Name = "ЗАО \"Технопром\"" };

            List<Product> existingProducts = new List<Product>
            {
                new Product(1) { Name = "Нурофен 200мг таб. №10", ActualQuantity = 23 },
                new Product(2) { Name = "Парацетамол 250 мг", ActualQuantity = 15 }
            };

            Supply supply = new Supply("SUP-2025-001")
            {
                Supplier = supplier,
                DeliveryDate = new DateTime(2025, 11, 15),
                Items = new List<SupplyItem>
                {
                    new SupplyItem
                    {
                        Product = existingProducts[0],
                        Quantity = 50,
                        UnitPrice = 165.00
                    },
                    new SupplyItem
                    {
                        Product = existingProducts[1],
                        Quantity = 25,
                        UnitPrice = 159.00
                    }
                }
            };

            mockRepo.Setup(repo => repo.AddSupply(supply)).Returns(true);

            string result = supplyService.AddSupply(supply);

            Assert.AreEqual(string.Empty, result);
            mockRepo.Verify(repo => repo.AddSupply(supply), Times.Once);

            // Проверка обновления количества товаров
            Assert.AreEqual(73, existingProducts[0].ActualQuantity);
            Assert.AreEqual(40, existingProducts[1].ActualQuantity);

            // Проверка общей суммы поставки
            double expectedTotalCost = (50 * 165.00) + (25 * 159.00);
            Assert.AreEqual(expectedTotalCost, supply.TotalCost);
        }

        [TestMethod]
        public void TestAddSupply_WithEmptySerialNumber()
        {
            Mock<ISuppliesRepository> mockRepo = new Mock<ISuppliesRepository>();
            SupplyService supplyService = new SupplyService(mockRepo.Object);

            Supplier supplier = new Supplier("1001") { Name = "ЗАО \"Технопром\"" };

            Product existingProduct = new Product(1) { Name = "Нурофен 500мг таб. №12", ActualQuantity = 10 };

            Supply supply = new Supply("")
            {
                Supplier = supplier,
                DeliveryDate = new DateTime(2025, 11, 10),
                Items = new List<SupplyItem>
                {
                    new SupplyItem
                    {
                        Product = existingProduct,
                        Quantity = 10,
                        UnitPrice = 200.00
                    }
                }
            };

            string result = supplyService.AddSupply(supply);

            Assert.AreEqual("Серийный номер не может быть пустым.", result);
            mockRepo.Verify(repo => repo.AddSupply(supply), Times.Never);
        }

        [TestMethod]
        public void TestAddSupply_WithNullSupplier()
        {
            Mock<ISuppliesRepository> mockRepo = new Mock<ISuppliesRepository>();
            SupplyService supplyService = new SupplyService(mockRepo.Object);

            Product existingProduct = new Product(1) { Name = "Парацетамол 500 мг", ActualQuantity = 13 };

            Supply supply = new Supply("SUP-2025-002")
            {
                Supplier = null,
                DeliveryDate = new DateTime(2025, 11, 1),
                Items = new List<SupplyItem>
                {
                    new SupplyItem
                    {
                        Product = existingProduct,
                        Quantity = 20,
                        UnitPrice = 299.00
                    }
                }
            };

            string result = supplyService.AddSupply(supply);

            Assert.AreEqual("Поставщик не указан.", result);
            mockRepo.Verify(repo => repo.AddSupply(supply), Times.Never);
        }

        [TestMethod]
        public void TestAddSupply_WithEmptyItems()
        {
            Mock<ISuppliesRepository> mockRepo = new Mock<ISuppliesRepository>();
            SupplyService supplyService = new SupplyService(mockRepo.Object);

            Supplier supplier = new Supplier("1001") { Name = "ЗАО \"Технопром\"" };

            Supply supply = new Supply("SUP-2025-004")
            {
                Supplier = supplier,
                DeliveryDate = new DateTime(2025, 10, 1),
                Items = new List<SupplyItem>()
            };

            string result = supplyService.AddSupply(supply);

            Assert.AreEqual("Необходимо добавить хотя бы одну позицию для создания поставки.", result);
            mockRepo.Verify(repo => repo.AddSupply(supply), Times.Never);
        }
    }
}
