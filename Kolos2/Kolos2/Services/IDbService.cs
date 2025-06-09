


using Kolos2.DTOs.Request;

namespace Kolos2.Services;
public interface IDbService
{
    Task AddPrescription(PrescriptionRequestDTO prescriptionRequestDto);
}