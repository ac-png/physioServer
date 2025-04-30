using System.ComponentModel.DataAnnotations;

namespace FlexiCareManager.Models;

public class Treatment
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Subtitle {get; set; }
}
