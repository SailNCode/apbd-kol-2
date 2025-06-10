using Kolos2.DTOs.Request;
using Kolos2.DTOs.Response;
using Kolos2.Exceptions;
using Kolos2.Models;
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

    public async Task<RacerParticipationResponseDTO> GetRacerParticipationInfo(int id)
    {
        if (!await _repository.HasRacer(id))
        {
            throw new NotFoundException("Racer not found");
        }

        Racer? racer = await _repository.GetRacer(id);
        if (racer == null)
        {
            throw new NotFoundException("Racer not found");
        }

        return new RacerParticipationResponseDTO()
        {
            RacerId = racer.RacerId,
            FirstName = racer.FirstName,
            LastName = racer.LastName,
            Participations = racer.RaceParticipations.Select(rp => new ParticipationResponseDTO()
            {
                Race = new RaceResponseDTO()
                {
                    Name = rp.TrackRace.Race.Name,
                    Location = rp.TrackRace.Race.Location,
                    Date = rp.TrackRace.Race.Date,
                },
                Track = new TrackResponseDTO()
                {
                    Name = rp.TrackRace.Track.Name,
                    LengthInKm = rp.TrackRace.Track.LengthInKm, 
                },
                Laps = rp.TrackRace.Laps,
                FinishTimeInSeconds = rp.FinishTimeInSeconds,
                Position = rp.Position
            }).ToList()
        };
    }

    public async Task AddRacersToRaces(AssignRacerRequestDTO assignRacerRequestDto)
    {
        if (!await _repository.HasRaceByName(assignRacerRequestDto.RaceName))
        {
            throw new NotFoundException("Race with name does not exist");
        }

        if (!await _repository.HasTrackByName(assignRacerRequestDto.TrackName))
        {
            throw new NotFoundException("Track with name does not exist");
        }

        foreach (var participation in assignRacerRequestDto.Participations)
        {
            if (!await _repository.HasRacer(participation.RacerId))
            {
                throw new NotFoundException("Racer with id=" + participation.RacerId + " not found" );
            }
        }
        //Begin transaction here to enforce data integrity - no race or track or trackrace is deleted
        try
        {
            await _transactionHandler.BeginTransactionAsync();
            
            Track? track = await _repository.GetTrack(assignRacerRequestDto.TrackName);
            Race? race = await _repository.GetRace(assignRacerRequestDto.RaceName);
            if (track == null || race == null)
            {
                throw new NotFoundException("Track or Race not found");
            }
            
            TrackRace? trackRace = await _repository.FindTrackRace(track.TrackId, race.RaceId);

            if (trackRace == null)
            {
                throw new BadRequestException("Race is not assigned to this track");
            }
            foreach (var participation in assignRacerRequestDto.Participations)
            {
                Racer? racer = await _repository.GetRacer(participation.RacerId);
                if (racer == null)
                {
                    throw new NotFoundException("Racer with id=" + participation.RacerId + " not found" );
                }

                RaceParticipation raceParticipation = 
                    await _repository.AssignRacerToTrackRace(trackRace.TrackRaceId, racer.RacerId, participation.FinishTimeInSeconds, participation.Position);
                await _transactionHandler.SaveChangesAsync();
                
                //Handling best time:
                if (raceParticipation.FinishTimeInSeconds < trackRace.BestTimeInSeconds)
                {
                    trackRace.BestTimeInSeconds = raceParticipation.FinishTimeInSeconds;
                    await _transactionHandler.SaveChangesAsync();
                }
            }
            
            await _transactionHandler.CommitTransactionAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            await _transactionHandler.RollbackTransactionAsync();
            throw new InternalServerException("Error while registering racers for races");
        }
         
    }
}