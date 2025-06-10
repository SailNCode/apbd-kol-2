using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Models;
[Table("Race_Participation")]
[PrimaryKey(nameof(TrackRaceId), nameof(RacerId))]
public class RaceParticipation
{
    [ForeignKey(nameof(TrackRace))]
    public int TrackRaceId { get; set; }
    [ForeignKey(nameof(Race))]
    public int RacerId { get; set; }
    
    public Racer Racer { get; set; }
    public TrackRace TrackRace { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
    
    
     
}