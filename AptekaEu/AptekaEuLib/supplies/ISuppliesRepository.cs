using System.Collections.Generic;

namespace AptekaEuLib.supplies
{
    public interface ISuppliesRepository
    {
        bool AddSupply(Supply supply);

        List<Supply> ReadSupplies();
    }
}
