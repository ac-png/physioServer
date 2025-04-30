using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using FlexiCareManager.Data;

namespace FlexiCareManager.Models;

public class PatientProgramme
{
    public int Id { get; set; }
    public int PatientId {get; set;}
    public virtual Patient? Patient  { get; set; }
    [Display(Name = "Programme")]
    [Required]
    public int ProgrammeId {get; set;}
    [Display(Name = "Programme")]
    public virtual Programme? Programme  { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Start Date")]
    [Required]
    public DateTime? StartDate {get; set; }
    [DataType(DataType.Date)]
    public DateTime? EndDate {get; set; }
    public virtual List<Session> Sessions { get; set; } = new List<Session>(); 

    public async Task<bool> CreateProgramme(FlexiCareManagerContext context)
    {
        var programme = await context.Programme
            .Include(p => p.Exercises)
                .ThenInclude(e => e.Exercise)
                    .ThenInclude(e => e.ExerciseCategory)
            .SingleOrDefaultAsync(p => p.Id == ProgrammeId);
        if(programme == null)
        {
            return false;
        }

        EndDate = StartDate!.Value.AddDays(programme.Duration -1);
        context.Add(this);
        await context.SaveChangesAsync();

        foreach(var programmeExercise in programme.Exercises)
        {
            var session = new Session()
            {
                   PatientId = PatientId,
                   Patient = Patient,
                   ProgrammeId = ProgrammeId,
                   Programme = Programme,
                   PatientProgrammeId = Id,
                   PatientProgramme = this,
                   ExerciseId = programmeExercise.ExerciseId,
                   Exercise = programmeExercise.Exercise,
                   ExerciseCategoryId = programmeExercise.Exercise.ExerciseCategoryId,
                   ExerciseCategory= programmeExercise.Exercise.ExerciseCategory!,
                   ExerciseDate = StartDate!.Value.AddDays(programmeExercise.Day -1),
                   Notes = programmeExercise.Notes ?? string.Empty,
                   Done = false
            };
            context.Add(session);
        }
        await context.SaveChangesAsync();
        return true;
    }
}
