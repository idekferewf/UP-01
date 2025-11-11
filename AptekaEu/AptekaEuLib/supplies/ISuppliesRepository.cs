using System.Collections.Generic;

namespace AptekaEuLib.supplies
{
    public interface ISuppliesRepository
    {
        List<Supply> ReadSupplies();
    }
}
