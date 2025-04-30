using System.ComponentModel.DataAnnotations;

namespace FlexiCareManager.Models;

public class Session
{
    public int Id { get; set; }
    [Display(Name = "Patient")]
    [Required]
    public int PatientId {get; set;}
    public virtual Patient? Patient  { get; set; }
    [Required]
    [Display(Name = "Programme")]
    public int ProgrammeId {get; set;}
    public virtual Programme? Programme  { get; set; }
    [Required]
    [Display(Name = "Patient Programme")]
    public int PatientProgrammeId {get; set;}
    [Display(Name = "Patient Programme")]
    public virtual PatientProgramme? PatientProgramme  { get; set; }
    [Required]
    [Display(Name = "Exercise")]
    public int ExerciseId {get; set;}
    public virtual Exercise Exercise  { get; set; } = new ();
    [Display(Name = "Exercise Category")]
    [Required]
    public int ExerciseCategoryId {get; set;}
    [Display(Name = "Exercise Category")]
    public virtual ExerciseCategory ExerciseCategory  { get; set; } = new ();
    [DataType(DataType.Date)]
    [Display(Name = "Exercise Date")]
    [Required]
    public DateTime? ExerciseDate {get; set;}
    public String Notes {get; set;} = string.Empty;
    public bool Done {get; set;} = false;
    public string Feedback {get; set;} = string.Empty;
    [Display(Name = "Pain Level")]
    public int PainLevel {get; set;} = 0;
}
