using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AptekaEuLib.supplies
{
    public class SupplyService
    {
        private BindingList<Supply> supplies_;
        private BindingList<Supply> filteredSupplies_;
        private ISuppliesRepository suppliesRepository_;

        private string currentSortProperty_ = "DeliveryDate";
        private bool isAscending_ = false;
        private string currentSupplierFilter_ = "";

        public SupplyService(ISuppliesRepository suppliesRepository)
        {
            suppliesRepository_ = suppliesRepository;
        }

        public BindingList<Supply> FilteredSupplies => filteredSupplies_;

        public BindingList<Supply> GetAllSupplies()
        {
            supplies_ = new BindingList<Supply>(suppliesRepository_.ReadSupplies());
            ApplyFilterAndSort();
            return filteredSupplies_;
        }

        public void FilterBySupplierTin(string supplierTin)
        {
            currentSupplierFilter_ = supplierTin;
            ApplyFilterAndSort();
        }

        public void SortBy(string propertyName)
        {
            if (propertyName == "TotalCostDisplay")
            {
                propertyName = "TotalCost";
            }

            if (currentSortProperty_ == propertyName)
            {
                isAscending_ = !isAscending_;
            }
            else
            {
                currentSortProperty_ = propertyName;
            }

            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            if (supplies_ == null)
            {
                return;
            }

            IEnumerable<Supply> result = supplies_;

            if (!string.IsNullOrEmpty(currentSupplierFilter_))
            {
                result = result.Where(s => s.SupplierTin == currentSupplierFilter_);
            }

            PropertyInfo propertyInfo = typeof(Supply).GetProperty(currentSortProperty_);
            if (propertyInfo != null)
            {
                result = isAscending_
                    ? result.OrderBy(s => propertyInfo.GetValue(s))
                    : result.OrderByDescending(s => propertyInfo.GetValue(s));
            }

            filteredSupplies_ = new BindingList<Supply>(result.ToList());
        }
    }
}
