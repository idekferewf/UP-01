namespace AptekaEuLib
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public int ActualQuantity { get; set; }
    }
}
