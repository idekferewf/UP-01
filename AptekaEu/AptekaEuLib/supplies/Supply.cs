using System;

namespace AptekaEuLib.supplies
{
    public class Supply
    {
        private int id_;

        public int Id { get { return id_; } }

        public Product Product { get; set; }

        public int SupplierTin { get; set; }

        public int Quantity { get; set; }

        public DateTime ProductionDate { get; set; }
        
        public DateTime ExpiryDate { get; set; }

        public Supply(int id)
        {
            id_ = id;
        }
    }
}
