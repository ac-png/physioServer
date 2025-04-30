namespace FlexiCareAPITest;

using FlexiCareAPI.ApiModels;
using FlexiCareManager.Models;

[TestClass]
public sealed class ProgrammeAPITests
{
    [TestMethod]
    public void ProgrammeApiProgramme_ProperlyOrganises_ExercisesIntoCategories()
    {
        // ARRANGE
        
        // Create the exercise categories
        var exerciseCategory1 = new ExerciseCategory() 
        {
            Id = 1,
            Name = "Category 1"
        };
        var exerciseCategory2 = new ExerciseCategory()
        {
            Id = 1,
            Name = "Category 2"
        };

        // Add 2 exercises to each category
        var exercise1 = new Exercise()
        {
            Id=1,
            ExerciseCategory = exerciseCategory1,
            Name = "Exercise 1"
        };
        var exercise2 = new Exercise()
        {
            Id=1,
            ExerciseCategory = exerciseCategory2,
            Name = "Exercise 2"
        };
        var exercise3 = new Exercise()
        {
            Id=1,
            ExerciseCategory = exerciseCategory1,
            Name = "Exercise 3"
        };
        var exercise4 = new Exercise()
        {
            Id=1,
            ExerciseCategory = exerciseCategory2,
            Name = "Exercise 4"
        };

        // Now create a one-day programme where all exercises must be done
        var programme = new Programme()
        {
            Id = 1,
            Name = "just a test one-day programme",
            Duration = 1,
            Author = "Mary",
            Exercises = [
                new ProgrammeExercise() {Day = 1, Exercise = exercise1},
                new ProgrammeExercise() {Day = 1, Exercise = exercise2},
                new ProgrammeExercise() {Day = 1, Exercise = exercise3},
                new ProgrammeExercise() {Day = 1, Exercise =  exercise4}
                ]
        };

        // ACT

        // Create the API model
        var apiProgramme = new ProgrammeApiProgramme(programme);

        // ASSERT 
        
        // The API should re-arrange things programme -> with 2 categories -> each with 2 exercise
        Assert.AreEqual(2, apiProgramme.ExerciseCategories.Count);
        Assert.AreEqual(1, apiProgramme.ExerciseCategories.Where(ec => ec.Name == "Category 1").Count());
        Assert.AreEqual(1, apiProgramme.ExerciseCategories.Where(ec => ec.Name == "Category 2").Count());

        // Now check each category has 2 items
        var cat1 = apiProgramme.ExerciseCategories.Where(ec => ec.Name == "Category 1").Single();
        Assert.AreEqual(2, cat1.Exercises.Count);
        Assert.AreEqual(1, cat1.Exercises.Where(ec => ec.Name == "Exercise 1").Count());
        Assert.AreEqual(1, cat1.Exercises.Where(ec => ec.Name == "Exercise 3").Count());

        var cat2 = apiProgramme.ExerciseCategories.Where(ec => ec.Name == "Category 2").Single();
        Assert.AreEqual(2, cat2.Exercises.Count);
        Assert.AreEqual(1, cat2.Exercises.Where(ec => ec.Name == "Exercise 2").Count());
        Assert.AreEqual(1, cat2.Exercises.Where(ec => ec.Name == "Exercise 4").Count());
    }
}
