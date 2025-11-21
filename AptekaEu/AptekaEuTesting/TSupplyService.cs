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
            Mock<ISuppliesRepository> suppliesMockRepo = new Mock<ISuppliesRepository>();
            SupplyService supplyService = new SupplyService(suppliesMockRepo.Object);

            Mock<IProductsRepository> productsMockRepo = new Mock<IProductsRepository>();
            ProductService productService = new ProductService(productsMockRepo.Object);

            List<Product> existingProducts = new List<Product>
            {
                new Product(1) { Name = "Нурофен 200мг таб. №10", ActualQuantity = 23 },
                new Product(2) { Name = "Парацетамол 250 мг", ActualQuantity = 15 }
            };

            productsMockRepo.Setup(repo => repo.ReadProducts()).Returns(existingProducts);

            Supply supply = new Supply("SUP-2025-001")
            {
                Supplier = new Supplier("1001"),
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

            suppliesMockRepo.Setup(repo => repo.AddSupply(supply)).Returns(true);

            string result = supplyService.AddSupply(supply);

            Assert.AreEqual(string.Empty, result);
            suppliesMockRepo.Verify(repo => repo.AddSupply(supply), Times.Once);

            BindingList<Product> resultProducts = productService.GetAllProducts();
            Assert.AreEqual(2, resultProducts.Count);
            Assert.AreEqual(73, resultProducts[0].ActualQuantity);
            Assert.AreEqual(40, resultProducts[1].ActualQuantity);

            double expectedTotalCost = (50 * 165.00) + (25 * 159.00);
            Assert.AreEqual(expectedTotalCost, supply.TotalCost);
        }

        [TestMethod]
        [DataRow("", "1001", true, "Серийный номер не может быть пустым.")]
        [DataRow("SUP-2025-002", null, true, "Поставщик не указан.")]
        [DataRow("SUP-2025-003", "1002", false, "Необходимо добавить хотя бы одну позицию для создания поставки.")]
        public void TestAddSupply_WithIncorrectData(string serialNumber, string supplierTin, bool hasItems, string expected)
        {
            Mock<ISuppliesRepository> mockRepo = new Mock<ISuppliesRepository>();
            SupplyService supplyService = new SupplyService(mockRepo.Object);

            Supplier supplier = string.IsNullOrEmpty(supplierTin) ? null : new Supplier(supplierTin);

            List<SupplyItem> items = new List<SupplyItem>();
            if (hasItems)
            {
                Product existingProduct = new Product(1) { Name = "Нурофен 500мг таб. №12", ActualQuantity = 10 };
                items.Add(new SupplyItem
                {
                    Product = existingProduct,
                    Quantity = 10,
                    UnitPrice = 200.00
                });
            }

            Supply supply = new Supply(serialNumber)
            {
                Supplier = supplier,
                DeliveryDate = new DateTime(2025, 11, 10),
                Items = items
            };

            string result = supplyService.AddSupply(supply);

            Assert.AreEqual(expected, result);
            mockRepo.Verify(repo => repo.AddSupply(supply), Times.Never);
        }
    }
}
