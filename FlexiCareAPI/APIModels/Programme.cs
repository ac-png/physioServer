using System.ComponentModel.DataAnnotations;
using FlexiCareManager.Models;

namespace FlexiCareAPI.ApiModels;

public class ProgrammeApiProgramme
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Duration { get; set; }
    public String? Author { get; set; }
    public List<ProgrammeApiExerciseCategory> ExerciseCategories { get; set; } = []; 
    public ProgrammeApiProgramme()
    {}

    public ProgrammeApiProgramme(Programme programme)
    {
        Id = programme.Id;
        Name = programme.Name;
        Duration = programme.Duration;
        Author = programme.Author;
        var exerciseCategories = programme.Exercises
            .GroupBy(pe => pe.Exercise.ExerciseCategory, (key, value) => new {exerciseCategory = key, programmeExercises = value});
        foreach(var exerciseCategory in exerciseCategories){
            ExerciseCategories.Add(new ProgrammeApiExerciseCategory(exerciseCategory.exerciseCategory!, exerciseCategory.programmeExercises));
       }
    }
}
public class ProgrammeApiExerciseCategory
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<ProgrammeApiExercise> Exercises { get; set; } = [];
    public ProgrammeApiExerciseCategory()
    {}

    public ProgrammeApiExerciseCategory(ExerciseCategory exerciseCategory, IEnumerable<ProgrammeExercise> programmeExercises)
    {
        Id = exerciseCategory.Id;
        Name = exerciseCategory.Name;
        // Name = exerciseCategory.Name;
        foreach(var pe in programmeExercises.OrderBy(pe => pe.Day))
        {
            Exercises.Add(new ProgrammeApiExercise(pe.Day, pe.Exercise));
        }
    }
}

public class ProgrammeApiExercise
{
    public int Id { get; set; }
    public int DayNumber { get; set; }
    public string? Name { get; set; }
    public string Reps {get; set;} = string.Empty;
    public string Sets {get; set;} = string.Empty;
    public string Frequency {get; set;} = string.Empty;
    public string Rest {get; set;} = string.Empty;
    public string Equipment {get; set;} = string.Empty;
    public string MusclesWorked {get; set;} = string.Empty;
    public string Benefits {get; set;} = string.Empty;
    public string HowToPerform {get; set;} = string.Empty;
    public string Tips {get; set;} = string.Empty;
    [DataType(DataType.ImageUrl)]
    public string ThumbnailUrl {get; set;} = string.Empty;
    [DataType(DataType.Url)]
    public string VideoUrl {get; set;} = string.Empty;

    public ProgrammeApiExercise()
    {}

    public ProgrammeApiExercise(int dayNumber, Exercise exercise)
    {
        Id = exercise.Id;
        DayNumber = dayNumber;
        Name = exercise.Name;
        Reps = exercise.Reps;
        Sets = exercise.Sets;
        Frequency  = exercise.Frequency;
        Rest  = exercise.Rest;
        Equipment= exercise.Equipment;
        MusclesWorked= exercise.MusclesWorked;
        Benefits= exercise.Benefits;
        HowToPerform= exercise.HowToPerform;
        Tips= exercise.Tips;
        ThumbnailUrl= exercise.ThumbnailUrl;
        VideoUrl= exercise.VideoUrl;
    }
}

