
using Kolos2.Data;
namespace Kolos2.Repositories;

public class Repository: IRepository
{
    private DatabaseContext _dbContext;

    public Repository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    // public async Task AddPatient(PatientRequestDTO patientDto)
    // {
    //     await _dbContext.Patients.AddAsync(new Patient()
    //     {
    //         FirstName = patientDto.FirstName,
    //         LastName = patientDto.LastName,
    //         Birthdate = patientDto.BirthDate
    //     });
    // }
}