namespace Kolos2.DTOs.Request;

public class PrescriptionRequestDTO
{
    public PatientRequestDTO Patient { get; set; }
    public int IdDoctor { get; set; }
    public ICollection<MedicamentRequestDTO> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}