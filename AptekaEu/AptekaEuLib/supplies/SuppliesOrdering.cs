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
    }
}
