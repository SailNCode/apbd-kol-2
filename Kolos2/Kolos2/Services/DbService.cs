using Kolos2.Data;
using Kolos2.DTOs.Request;
using Kolos2.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    private readonly IPatientRepository _patientRepository;
    public DbService(DatabaseContext context, IPatientRepository patientRepository)
    {
        _context = context;
        _patientRepository = patientRepository;
    }
    
    public async Task AddPrescription(PrescriptionRequestDTO prescriptionRequestDto)
    {
        if (await _context.Patients.Where(p => p.IdPatient == prescriptionRequestDto.Patient.IdPatient).CountAsync() == 0)
        {
            await _patientRepository.AddPatient(prescriptionRequestDto.Patient);
        }
        /**/
    }
    
}