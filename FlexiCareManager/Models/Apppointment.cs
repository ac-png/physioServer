using System.ComponentModel.DataAnnotations;

namespace FlexiCareManager.Models;

public class Appointment
{
    public int Id { get; set; }
    [Display(Name = "Patient")]
    [Required]
    public int? PatientId { get; set; }
    [Display(Name = "Patient")]
    public virtual Patient? Patient { get; set; }
    public DateTime? When  { get; set; }
    [Display(Name = "Physio")]
    [Required]
    public int? PhysioId {get; set;}
    [Display(Name = "Physio")]
    public virtual Physio? Physio  { get; set; }
}