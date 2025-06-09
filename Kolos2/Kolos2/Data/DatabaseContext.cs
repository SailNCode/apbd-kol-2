using Microsoft.EntityFrameworkCore;

namespace Kolos2.Data;

public class DatabaseContext : DbContext
{
    //public DbSet<Patient> Patients { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        // {
        //     new Patient(){IdPatient = 1, FirstName = "Maciej", LastName = "Maciak", Birthdate = new DateTime(1985, 12,25)},
        //     new Patient(){IdPatient = 2, FirstName = "Jarosław", LastName = "Sykson", Birthdate = new DateTime(1955, 2,12)}
        //
        // });
    }
}