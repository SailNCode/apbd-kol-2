
using Kolos2.Data;
using Kolos2.DTOs.Request;
using Kolos2.Models;

namespace Kolos2.Repositories;

public class PatientRepository: IPatientRepository
{
    private DatabaseContext _dbContext;

    public PatientRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddPatient(PatientRequestDTO patientDto)
    {
        await _dbContext.Patients.AddAsync(new Patient()
        {
            FirstName = patientDto.FirstName,
            LastName = patientDto.LastName,
            Birthdate = patientDto.BirthDate
        });
    }
}