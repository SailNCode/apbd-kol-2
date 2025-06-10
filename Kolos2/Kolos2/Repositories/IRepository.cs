
using Kolos2.Models;

namespace Kolos2.Repositories;

public interface IRepository
{
    Task<bool> HasRacer(int id);
    Task<Racer?> GetRacer(int id);
    Task<bool> HasRaceByName(string raceName);
    Task<bool> HasTrackByName(string trackName);
    Task<Track?> GetTrack(string trackName);
    Task<Race?> GetRace(string raceName);
    Task<TrackRace?> FindTrackRace(int trackTrackId, int raceRaceId);
    Task<RaceParticipation> AssignRacerToTrackRace(int trackRaceId, int racerId, int finishTimeInSeconds, int position);
}