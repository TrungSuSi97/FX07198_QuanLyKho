using System.Collections.Generic;
using TPH.HIS.Model;
using TPH.HIS.Repositories;
namespace TPH.HIS.Services
{
    public class OrderedServices : IOrderedServices
    {
        private readonly IOrderedRepositories _ordered = new OrderedRepositories();
        public List<SeviceOrderedInformation> orderedServices(string condit)
        {
            return _ordered.orderedServices(condit);
        }
    }
}
