using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AptekaEuLib.supplies
{
    public class SuppliesOrdering
    {
        private string currentSortProperty_;
        private bool isAscending_ = false;

        public string CurrentSortProperty => currentSortProperty_;

        public BindingList<Supply> SortBy(BindingList<Supply> sortedSupplies, string propertyName)
        {
            if (sortedSupplies == null || !sortedSupplies.Any())
            {
                return null;
            }

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

            PropertyInfo propertyInfo = typeof(Supply).GetProperty(currentSortProperty_);

            List<Supply> supplies;
            if (isAscending_)
            {
                supplies = sortedSupplies.OrderBy(s => propertyInfo.GetValue(s)).ToList();
            }
            else
            {
                supplies = sortedSupplies.OrderByDescending(s => propertyInfo.GetValue(s)).ToList();
            }

            currentSortProperty_ = propertyName;

            return new BindingList<Supply>(supplies);
        }
    }
}
