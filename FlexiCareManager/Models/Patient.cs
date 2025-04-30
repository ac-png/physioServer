using System.ComponentModel.DataAnnotations;

namespace FlexiCareManager.Models;

public class Patient
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Phone  { get; set; }
    public string? Address  { get; set; }
    [Display(Name = "Email address")]
    [Required(ErrorMessage = "The email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? Email { get; set; }
    public bool AllowNotifications  { get; set; } = true;
    public virtual List<PatientProgramme> Programmes { get; set; } = [];
    public virtual List<Appointment> Appointments { get; set; } = [];
    public virtual List<Session> Sessions { get; set; } = [];
}
