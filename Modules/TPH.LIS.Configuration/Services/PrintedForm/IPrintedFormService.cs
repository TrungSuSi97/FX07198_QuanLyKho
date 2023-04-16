using TPH.LIS.Configuration.Models;

namespace TPH.LIS.Configuration.Services.PrintedForm
{
    public interface IPrintedFormService
    {
        PrintedHeader GetPrintedHeaderByDepartement(string departement);
        PrintedHeader GetPrintedHeaderByDepartementWithUserPrint(string userID, string departement);
    }
}
