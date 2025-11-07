namespace AptekaEuLib.supplies
{
    public class SupplyService
    {
        private ISuppliesRepository suppliesRepository_;

        public SupplyService(ISuppliesRepository suppliesRepository)
        {
            suppliesRepository_ = suppliesRepository;
        }
    }
}
