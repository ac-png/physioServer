using System.ComponentModel.DataAnnotations;

namespace FlexiCareManager.Models;

public class Physio
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Phone  { get; set; }
    [Required]
    public string? Address  { get; set; }
    [Display(Name = "Email address")]
    [Required(ErrorMessage = "The email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? Email { get; set; }
}
