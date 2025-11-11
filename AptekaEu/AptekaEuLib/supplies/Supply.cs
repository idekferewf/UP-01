using System;
using System.Collections.Generic;

namespace AptekaEuLib.supplies
{
    public class Supply
    {
        private int id_;

        public int Id { get { return id_; } }

        public string SerialNumber { get; set; }

        public string SupplierTin { get; set; }

        public List<SupplyItem> Items { get; set; }

        public DateTime DeliveryDate { get; set; }

        public Supply(int id)
        {
            id_ = id;
        }
    }
}
