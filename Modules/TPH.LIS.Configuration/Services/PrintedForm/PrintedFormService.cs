using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Repositories.PrintedForm;

namespace TPH.LIS.Configuration.Services.PrintedForm
{
    public class PrintedFormService : IPrintedFormService
    {
        private readonly IPrintedFormRepository _printedForm;

        public PrintedFormService() : this(null)
        {

        }

        public PrintedFormService(PrintedFormRepository printedForm)
        {
            _printedForm = printedForm ?? new PrintedFormRepository();
        }

        public PrintedHeader GetPrintedHeaderByDepartement(string departement)
        {
            var result = _printedForm.GetPrintedHeaderByDepartement(departement);

            return result;
        }
        public PrintedHeader GetPrintedHeaderByDepartementWithUserPrint(string userID, string departement)
        {
            var result = _printedForm.GetPrintedHeaderByDepartementWithUserPrint(userID, departement);
            return result;
        }
    }
}
