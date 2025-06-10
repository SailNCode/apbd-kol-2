using Kolos2.DTOs.Request;
using Kolos2.DTOs.Response;

namespace Kolos2.Services;
public interface IService
{
    Task<RacerParticipationResponseDTO> GetRacerParticipationInfo(int id);
    Task AddRacersToRaces(AssignRacerRequestDTO assignRacerRequestDto);
}