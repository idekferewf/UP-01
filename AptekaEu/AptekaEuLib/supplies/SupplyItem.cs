using System;

namespace AptekaEuLib.supplies
{
    public class SupplyItem
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public DateTime ProductionDate { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
