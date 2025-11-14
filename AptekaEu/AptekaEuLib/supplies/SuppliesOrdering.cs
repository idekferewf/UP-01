using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AptekaEuLib.supplies
{
    public class SuppliesOrdering
    {
        private BindingList<Supply> sortedSupplies_;
        private string currentSortProperty_;
        private bool isAscending_;

        public SuppliesOrdering(BindingList<Supply> sortedSupplies)
        {
            sortedSupplies_ = sortedSupplies;
            currentSortProperty_ = "DeliveryDate";
            isAscending_ = false;
        }

        public BindingList<Supply> SortedSupplies => sortedSupplies_;

        public void SortBy(string propertyName)
        {
            if (sortedSupplies_ == null || !sortedSupplies_.Any())
            {
                return;
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
                supplies = sortedSupplies_.OrderBy(s => propertyInfo.GetValue(s)).ToList();
            }
            else
            {
                supplies = sortedSupplies_.OrderByDescending(s => propertyInfo.GetValue(s)).ToList();
            }

            sortedSupplies_ = new BindingList<Supply>(supplies);
        }
    }
}
