namespace AptekaEuLib
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int ActualQuantity { get; set; }
    }
}
