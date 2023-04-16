using System.Collections.Generic;
using TPH.HIS.Model;
namespace TPH.HIS.Repositories
{
    public interface IOrderedRepositories
    {
        List<SeviceOrderedInformation> orderedServices(string condit);
    }
}
