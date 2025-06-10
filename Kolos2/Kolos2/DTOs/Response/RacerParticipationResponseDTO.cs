namespace Kolos2.DTOs.Response;

public class RacerParticipationResponseDTO
{
    public int RacerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<ParticipationResponseDTO> Participations { get; set; }
}

public class ParticipationResponseDTO
{
    public RaceResponseDTO Race { get; set; }
    public TrackResponseDTO Track { get; set; }
    public int Laps { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
}


public class RaceResponseDTO
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
}
public class TrackResponseDTO
{
    public string Name { get; set; }
    public decimal LengthInKm { get; set; }
}