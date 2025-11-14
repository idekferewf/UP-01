using System.ComponentModel;
using System.Linq;

namespace AptekaEuLib.supplies
{
    public class SupplyService
    {
        private BindingList<Supply> supplies_;
        private BindingList<Supply> filteredSupplies_;
        private ISuppliesRepository suppliesRepository_;

        public SupplyService(ISuppliesRepository suppliesRepository)
        {
            suppliesRepository_ = suppliesRepository;
        }

        public BindingList<Supply> FilteredSupplies => filteredSupplies_;

        public BindingList<Supply> GetAllSupplies()
        {
            supplies_ = new BindingList<Supply>(suppliesRepository_.ReadSupplies());
            filteredSupplies_ = supplies_;
            return filteredSupplies_;
        }

        public BindingList<Supply> FilterBySuppliesTin(string supplierTin)
        {
            if (string.IsNullOrEmpty(supplierTin))
            {
                filteredSupplies_ = supplies_;
                return filteredSupplies_;
            }

            filteredSupplies_ = new BindingList<Supply>(supplies_.Where(s => s.SupplierTin == supplierTin).ToList());
            return filteredSupplies_;
        }
    }
}
