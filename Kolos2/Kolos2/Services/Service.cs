using Kolos2.Repositories;

namespace Kolos2.Services;

public class Service : IService
{
    private TransactionHandler _transactionHandler;
    private readonly IRepository _repository;
    public Service(IRepository repository, TransactionHandler transactionHandler)
    {
        _repository = repository;
        _transactionHandler = transactionHandler;
    }
    
    // public async Task AddPrescription(PrescriptionRequestDTO prescriptionRequestDto)
    // {
    //     if (await _context.Patients.Where(p => p.IdPatient == prescriptionRequestDto.Patient.IdPatient).CountAsync() == 0)
    //     {
    //         await _patientRepository.AddPatient(prescriptionRequestDto.Patient);
    //     }
    //     /**/
    // }
    
}