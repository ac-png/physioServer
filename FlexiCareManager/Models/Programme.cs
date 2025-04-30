using System.ComponentModel.DataAnnotations;

namespace FlexiCareManager.Models;

public class Programme
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Duration { get; set; }
    public String? Author { get; set; }

    public virtual List<ProgrammeExercise> Exercises { get; set; } = [];
    public virtual List<ProgrammeTreatment> Treatments { get; set; } = [];
}
