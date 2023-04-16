using System.Collections.Generic;
using TPH.HIS.Model;
namespace TPH.HIS.Services
{
    public interface IOrderedServices
    {
        List<SeviceOrderedInformation> orderedServices(string condit);
    }
}
