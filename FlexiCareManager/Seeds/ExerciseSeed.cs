using FlexiCareManager.Data;
using FlexiCareManager.Models;

namespace FlexiCareManager.Seeds
{
    public static class ExerciseSeed
    {
        public static void Seed(FlexiCareManagerContext context)
        {
            if (context.Exercise.Any())
            {
                return;
            }
            var upperBodyCategory = context.ExerciseCategory.FirstOrDefault(e => e.Name == "Upper Body Mobility");
            var lowerBodyCategory = context.ExerciseCategory.FirstOrDefault(e => e.Name == "Lower Body Strength");
            var coreCategory = context.ExerciseCategory.FirstOrDefault(e => e.Name == "Core Stability");

            var shoulderMobility = new Exercise { 
                Name = "Wall Angels", 
                ExerciseCategory = upperBodyCategory,
                Reps = "1 full Wall Angels per leg",
                Sets = "2-3 sets",
                Frequency = "3-4 times per week",
                Rest = "30 seconds between sets",
                Equipment = "None. Ensure adequate room is available.",
                MusclesWorked = "Ankle stabilisers, calves, foct muscles",
                Benefits =$"Increases ankle mobility, strengthens stabilising muscles, Increases ankle mobility, strengthens stabilising muscles, improves balance and joint control.",
                HowToPerform = $"1. Sit with your legs extended or in a chair, keeping your back straight.{Environment.NewLine} 2. Lift one foot and 'write' the alphabet in the air with your big toe, moving through full ankle motion (up, down, in, out).{Environment.NewLine} 3. Repeat with the other foot. {Environment.NewLine} 4. Complete 2-3 sets with 30 seconds rest between sets.",
                Tips = $"Try closing your eyes for added challenge.{Environment.NewLine} Focus on controlled, precise movements.",
                ThumbnailUrl = "https://www.bodylogics.co.uk/wp-content/uploads/2020/07/wall-angel-exercise.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=1UU4VvklQ44"
            };
            var hamstringStretch = new Exercise { 
                Name = "Standing Hamstring Stretch", 
                ExerciseCategory = lowerBodyCategory,
                Reps = "1 full Standing Hamstring Stretch",
                Sets = "2-3 sets",
                Frequency = "3-4 times per week",
                Rest = "30 seconds between sets",
                Equipment = "None. Ensure adequate room is available.",
                MusclesWorked = "Ankle stabilisers, calves, foct muscles",
                Benefits =$"Increases ankle mobility, strengthens stabilising muscles, Increases ankle mobility, strengthens stabilising muscles, improves balance and joint control.",
                HowToPerform = $"1. Sit with your legs extended or in a chair, keeping your back straight.{Environment.NewLine} 2. Lift one foot and 'write' the alphabet in the air with your big toe, moving through full ankle motion (up, down, in, out).{Environment.NewLine} 3. Repeat with the other foot. {Environment.NewLine} 4. Complete 2-3 sets with 30 seconds rest between sets.",
                Tips = $"Try closing your eyes for added challenge.{Environment.NewLine} Focus on controlled, precise movements.",
                ThumbnailUrl = "https://hips.hearstapps.com/hmg-prod/images/hamstring-stretches-min-1671014774.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=LVY692zJK0A"

            };
            var gluteBridge = new Exercise { 
                Name = "Glute Bridge", 
                ExerciseCategory = coreCategory,
                                Reps = "1 full Glute Bridge",
                Sets = "2-3 sets",
                Frequency = "3-4 times per week",
                Rest = "30 seconds between sets",
                Equipment = "None. Ensure adequate room is available.",
                MusclesWorked = "Ankle stabilisers, calves, foct muscles",
                Benefits ="Increases ankle mobility, strengthens stabilising muscles, Increases ankle mobility, strengthens stabilising muscles, improves balance and joint control.",
                HowToPerform = $"1. Sit with your legs extended or in a chair, keeping your back straight.{Environment.NewLine} 2. Lift one foot and 'write' the alphabet in the air with your big toe, moving through full ankle motion (up, down, in, out).{Environment.NewLine} 3. Repeat with the other foot. {Environment.NewLine} 4. Complete 2-3 sets with 30 seconds rest between sets.",
                Tips = $"Try closing your eyes for added challenge.{Environment.NewLine} Focus on controlled, precise movements.",
                ThumbnailUrl = "https://media1.popsugar-assets.com/files/thumbor/Cdg_9oBw0JygpcbUKMTjYneKF5U=/fit-in/1584x1584/filters:format_auto():upscale()/2024/06/03/047/n/1922729/6c941ba7665e5af32f7f02.07243797_PS23_Fitness.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=WtilA9IJX1c"
            };
            var birdDog = new Exercise { 
                Name = "Bird Dog", 
                ExerciseCategory = coreCategory,
                                Reps = "1 full Bird Dog",
                Sets = "2-3 sets",
                Frequency = "3-4 times per week",
                Rest = "30 seconds between sets",
                Equipment = "None. Ensure adequate room is available.",
                MusclesWorked = "Ankle stabilisers, calves, foct muscles",
                Benefits ="Increases ankle mobility, strengthens stabilising muscles, Increases ankle mobility, strengthens stabilising muscles, improves balance and joint control.",
                HowToPerform = $"1. Sit with your legs extended or in a chair, keeping your back straight.{Environment.NewLine} 2. Lift one foot and 'write' the alphabet in the air with your big toe, moving through full ankle motion (up, down, in, out).{Environment.NewLine} 3. Repeat with the other foot. {Environment.NewLine} 4. Complete 2-3 sets with 30 seconds rest between sets.",
                Tips = $"Try closing your eyes for added challenge.{Environment.NewLine} Focus on controlled, precise movements.",
                ThumbnailUrl = "https://hips.hearstapps.com/hmg-prod/images/bird-dog-exercise-1674234348.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=k2azbhhuKuM"
            };

            context.Exercise.AddRange(shoulderMobility, hamstringStretch, gluteBridge, birdDog);
            context.SaveChanges();
        }
    }
}
