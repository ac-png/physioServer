using System.ComponentModel.DataAnnotations;

namespace FlexiCareManager.Models;

public class Exercise
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [Display(Name = "Exercise Category")]
    public virtual ExerciseCategory? ExerciseCategory { get; set; }
    [Required]
    [Display(Name = "Exercise Category")]
    public int ExerciseCategoryId { get; set; }
    public string Reps {get; set;} = string.Empty;
    public string Sets {get; set;} = string.Empty;
    public string Frequency {get; set;} = string.Empty;
    public string Rest {get; set;} = string.Empty;
    public string Equipment {get; set;} = string.Empty;
    [Display(Name = "Muscles Worked")]
    public string MusclesWorked {get; set;} = string.Empty;
    public string Benefits {get; set;} = string.Empty;
    [Display(Name = "How to perform")]
    public string HowToPerform {get; set;} = string.Empty;
    public string Tips {get; set;} = string.Empty;
    [DataType(DataType.ImageUrl)]
    [Display(Name = "Thumbnail Url")]
    public string ThumbnailUrl {get; set;} = string.Empty;
    [DataType(DataType.Url)]
    [Display(Name = "Video Url")]
    public string VideoUrl {get; set;} = string.Empty;
}
