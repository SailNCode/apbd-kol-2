
using Kolos2.DTOs.Request;

namespace Kolos2.Repositories;

public interface IPatientRepository
{
    Task AddPatient(PatientRequestDTO patientDto);
}