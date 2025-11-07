using System.ComponentModel;

namespace AptekaEuLib.supplies
{
    public class SupplyService
    {
        private ISuppliesRepository suppliesRepository_;

        public SupplyService(ISuppliesRepository suppliesRepository)
        {
            suppliesRepository_ = suppliesRepository;
        }

        public BindingList<Supply> GetAllSupplies()
        {
            return null;
        }
    }
}
