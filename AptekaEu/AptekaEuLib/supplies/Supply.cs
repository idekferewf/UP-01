using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AptekaEuLib.supplies
{
    public class Supply
    {
        private string serialNumber_;

        [DisplayName("Серийный номер")]
        public string SerialNumber { get { return serialNumber_; } }

        [DisplayName("ИНН поставщика")]
        public string SupplierTin { get; set; }

        public List<SupplyItem> Items { get; set; }

        [DisplayName("Дата поставки")]
        public DateTime DeliveryDate { get; set; }

        [DisplayName("Количество позиций")]
        public int ItemsCount
        {
            get
            {
                return Items.Count;
            }
        }

        [Browsable(false)]
        public double TotalCost
        {
            get
            {
                if (Items == null || !Items.Any())
                    return 0;
                return Items.Sum(item => item.UnitPrice * item.Quantity);
            }
        }

        [DisplayName("Сумма поставки")]
        public string TotalCostDisplay
        {
            get
            {
                return $"{TotalCost:N2} руб.";
            }
        }

        public Supply(string serialNumber)
        {
            serialNumber_ = serialNumber;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Supply other = (Supply)obj;

            if (SerialNumber != other.SerialNumber || SupplierTin != other.SupplierTin || DeliveryDate != other.DeliveryDate)
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

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + SerialNumber.GetHashCode();
                hash = hash * 23 + SupplierTin.GetHashCode();
                hash = hash * 23 + DeliveryDate.GetHashCode();

                if (Items != null)
                {
                    foreach (var item in Items)
                    {
                        hash = hash * 23 + item.Quantity.GetHashCode();
                        hash = hash * 23 + item.UnitPrice.GetHashCode();
                        hash = hash * 23 + item.ProductionDate.GetHashCode();
                        hash = hash * 23 + item.ExpiryDate.GetHashCode();
                        hash = hash * 23 + (item.Product?.Id.GetHashCode() ?? 0);
                    }
                }

                return hash;
            }
        }
    }
}
