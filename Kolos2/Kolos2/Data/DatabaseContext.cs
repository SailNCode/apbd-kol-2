using Kolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Race> Races { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Racer> Racers { get; set; }
    public DbSet<TrackRace> TrackRaces { get; set; }
    public DbSet<RaceParticipation> RaceParticipations { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Racer>().HasData(new List<Racer>()
        {
            new Racer() {RacerId = 1, FirstName = "Max", LastName = "Verstappen"}
        });
        modelBuilder.Entity<Track>().HasData(new List<Track>()
        {
            new Track() {TrackId = 1, Name = "Track1", LengthInKm = 50},
            new Track() {TrackId = 2, Name = "SomeOtherTrack", LengthInKm = 75},
        });
        modelBuilder.Entity<Race>().HasData(new List<Race>()
        {
            new Race() {RaceId = 1, Name = "MAgnificicent race", Location = "Lisbon", Date = new DateTime(2025, 6, 4)},
            new Race() {RaceId = 2, Name = "Even better race", Location = "Grochow", Date = new DateTime(2025, 6, 5)}
        });
        modelBuilder.Entity<TrackRace>().HasData(new List<TrackRace>()
        {
            new TrackRace() {TrackRaceId = 1, TrackId = 1, RaceId = 1, Laps = 10, BestTimeInSeconds = 200},
            new TrackRace() {TrackRaceId = 2, TrackId = 2, RaceId = 2, Laps = 8, BestTimeInSeconds = 50}
        });
        modelBuilder.Entity<RaceParticipation>().HasData(new List<RaceParticipation>()
        {
            new RaceParticipation(){TrackRaceId = 1, RacerId = 1, FinishTimeInSeconds = 200, Position = 1},
            new RaceParticipation(){TrackRaceId = 2, RacerId = 1, FinishTimeInSeconds = 50, Position = 1},
        });
    }
}