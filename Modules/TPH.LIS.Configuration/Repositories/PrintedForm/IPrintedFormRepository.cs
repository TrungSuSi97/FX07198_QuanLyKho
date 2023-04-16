using TPH.LIS.Configuration.Models;

namespace TPH.LIS.Configuration.Repositories.PrintedForm
{
    public interface IPrintedFormRepository
    {
        
        PrintedHeader GetPrintedHeaderByDepartement(string departement);
        PrintedHeader GetPrintedHeaderByDepartementWithUserPrint(string userId, string departement);
    }
}
