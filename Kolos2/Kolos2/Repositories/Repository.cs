
using Kolos2.Data;
using Kolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Repositories;

public class Repository: IRepository
{
    private DatabaseContext _dbContext;

    public Repository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> HasRacer(int id)
    {
        return await _dbContext.Racers.AnyAsync(r => r.RacerId == id);
    }

    public async Task<Racer?> GetRacer(int id)
    {
        return await _dbContext.Racers
            .Include(r => r.RaceParticipations)
                .ThenInclude(rp => rp.TrackRace)
                    .ThenInclude(tr => tr.Track)
            .Include(r => r.RaceParticipations)
                .ThenInclude(rp => rp.TrackRace)
                    .ThenInclude(tr => tr.Race)
            .FirstOrDefaultAsync(r => r.RacerId == id);
    }

    public async Task<bool> HasRaceByName(string raceName)
    {
        return await _dbContext.Races.AnyAsync(r => r.Name == raceName);
    }

    public async Task<bool> HasTrackByName(string trackName)
    {
        return await _dbContext.Tracks.AnyAsync(t => t.Name == trackName);
    }

    public async Task<Track?> GetTrack(string trackName)
    {
       return await _dbContext.Tracks.FirstOrDefaultAsync(t => t.Name == trackName);
    }

    public async Task<Race?> GetRace(string raceName)
    {
        return await _dbContext.Races.FirstOrDefaultAsync(r => r.Name == raceName);
    }

    public async Task<TrackRace?> FindTrackRace(int trackTrackId, int raceRaceId)
    {
        return await _dbContext.TrackRaces.FirstOrDefaultAsync(rt => rt.TrackId == trackTrackId && rt.RaceId == raceRaceId);
    }

    public async Task<RaceParticipation> AssignRacerToTrackRace(int trackRaceId, int racerId, int finishTimeInSeconds, int position)
    {
        RaceParticipation raceParticipation = new RaceParticipation()
        {
            TrackRaceId = trackRaceId,
            RacerId = racerId,
            FinishTimeInSeconds = finishTimeInSeconds,
            Position = position
        };
        await _dbContext.RaceParticipations.AddAsync(raceParticipation);
        return raceParticipation;
    }
}