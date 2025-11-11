using System.ComponentModel;

namespace AptekaEuLib.supplies
{
    public class SupplyService
    {
        private BindingList<Supply> supplies_;
        private ISuppliesRepository suppliesRepository_;

        public SupplyService(ISuppliesRepository suppliesRepository)
        {
            suppliesRepository_ = suppliesRepository;
        }

        public BindingList<Supply> GetAllSupplies()
        {
            supplies_ = new BindingList<Supply>(suppliesRepository_.ReadSupplies());
            return supplies_;
        }
    }
}
