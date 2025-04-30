using System.ComponentModel.DataAnnotations;

namespace FlexiCareManager.Models;

public class ProgrammeExercise
{
    public int Id { get; set; }
    [Display(Name = "Exercise")]
    [Required]
    public int ExerciseId {get; set; }
    public virtual Exercise Exercise  { get; set; } = new Exercise();
    [Required]
    [Display(Name = "Programme")]
    public int ProgrammeId {get; set;}
    public virtual Programme Programme  { get; set; } = new Programme();
    [Required]
    public int Day {get; set;}
    public string? Notes {get; set;}
}
