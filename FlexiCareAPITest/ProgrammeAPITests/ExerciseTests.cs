namespace FlexiCareAPITest;

using FlexiCareAPI.ApiModels;
using FlexiCareManager.Models;

[TestClass]
public sealed class ProgrammeAPIExerciseTests
{
    [TestMethod]
    /// A basic test to check that all fields from FlexiCare Exercise class are properly mapped to the API
    public void ExerciseInfo_IsCorrectlyMapped_ToTheAPI()
    {
        // ARRANGE
        
        // Create a FlexiCare Exercise class
        var exercise1 = new Exercise()
        {
            Id=1,
            Name = null,
            Reps = "5 - 10",
            Sets = "4 or less",
            Frequency = "once or twice"
        };

        // ACT
        var result = new ProgrammeApiExercise(dayNumber: 1, exercise: exercise1);

        // ASSERT 
        Assert.IsNull(result.Name);
        Assert.AreEqual("5 - 10", result.Reps);
        Assert.AreEqual("4 or less", result.Sets);
        Assert.AreEqual("once or twice", result.Frequency);
    }
}
