using TPH.LabelingMachine.BCRobo.Models;

namespace TPH.LabelingMachine.BCRobo.Services
{
    public interface IClientService
    {
        string SavePatientInfo(PatientInfo patientInfo);
    }
}
