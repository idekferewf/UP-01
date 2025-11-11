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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Supply other = (Supply)obj;

            if (Id != other.Id || SerialNumber != other.SerialNumber || SupplierTin != other.SupplierTin || DeliveryDate != other.DeliveryDate)
            {
                return false;
            }

            if (Items == null && other.Items == null)
            {
                return true;
            }
            else if (Items == null || other.Items == null)
            {
                return false;
            }
            else if (Items.Count != other.Items.Count)
            {
                return false;
            }

            for (int i = 0; i < Items.Count; i++)
            {
                var item1 = Items[i];
                var item2 = other.Items[i];

                if (
                    item1.Quantity != item2.Quantity ||
                    item1.UnitPrice != item2.UnitPrice ||
                    item1.ProductionDate != item2.ProductionDate ||
                    item1.ExpiryDate != item2.ExpiryDate ||
                    item1.Product?.Id != item2.Product?.Id
                )
                {
                    return false;
                }
            }

            return true;
        }
    }
}
