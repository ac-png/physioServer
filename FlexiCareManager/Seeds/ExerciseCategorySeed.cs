using FlexiCareManager.Data;
using FlexiCareManager.Models;

namespace FlexiCareManager.Seeds
{
    public static class ExerciseCategorySeed
    {
        public static void Seed(FlexiCareManagerContext context)
        {
            if (context.ExerciseCategory.Any())
            {
                return;
            }
            var upperBodyCategory = new ExerciseCategory { Name = "Upper Body Mobility" };
            var lowerBodyCategory = new ExerciseCategory { Name = "Lower Body Strength" };
            var coreCategory = new ExerciseCategory { Name = "Core Stability" };

            context.ExerciseCategory.AddRange(upperBodyCategory, lowerBodyCategory, coreCategory);
            context.SaveChanges();
        }
    }
}
