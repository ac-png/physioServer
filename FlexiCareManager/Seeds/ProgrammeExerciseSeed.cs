using FlexiCareManager.Data;
using FlexiCareManager.Models;

namespace FlexiCareManager.Seeds
{
    public static class ProgrammeExerciseSeed
    {
        public static void Seed(FlexiCareManagerContext context)
        {
            if (context.ProgrammeExercise.Any())
            {
                return;
            }
            var coreStrengthProgram = context.Programme.FirstOrDefault(p => p.Name == "Core Strength Builder - 7 Days");
            var kneeRecoveryProgram = context.Programme.FirstOrDefault(p => p.Name == "Knee Recovery Phase 1 - 7 Days");
            if (coreStrengthProgram == null || kneeRecoveryProgram == null)
            {
                return;
            }

            var gluteBridge = context.Exercise.FirstOrDefault(e => e.Name == "Glute Bridge");
            var birdDog = context.Exercise.FirstOrDefault(e => e.Name == "Bird Dog");
            var hamstringStretch = context.Exercise.FirstOrDefault(e => e.Name == "Standing Hamstring Stretch");
            if (gluteBridge == null || birdDog == null || hamstringStretch == null)
            {
                return;
            }

            context.ProgrammeExercise.AddRange(
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 1, Exercise = gluteBridge },
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 2, Exercise = gluteBridge },
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 3, Exercise = gluteBridge },
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 4, Exercise = gluteBridge },
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 5, Exercise = gluteBridge },
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 6, Exercise = gluteBridge },
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 7, Exercise = gluteBridge },
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 1, Exercise = birdDog },
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 2, Exercise = birdDog },
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 3, Exercise = birdDog },
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 4, Exercise = birdDog },
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 5, Exercise = birdDog },
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 6, Exercise = birdDog },
                new ProgrammeExercise { Programme = coreStrengthProgram, Day = 7, Exercise = birdDog },
                new ProgrammeExercise { Programme = kneeRecoveryProgram, Day = 1, Exercise = hamstringStretch },
                new ProgrammeExercise { Programme = kneeRecoveryProgram, Day = 2, Exercise = hamstringStretch },
                new ProgrammeExercise { Programme = kneeRecoveryProgram, Day = 3, Exercise = hamstringStretch },
                new ProgrammeExercise { Programme = kneeRecoveryProgram, Day = 4, Exercise = hamstringStretch },
                new ProgrammeExercise { Programme = kneeRecoveryProgram, Day = 5, Exercise = hamstringStretch },
                new ProgrammeExercise { Programme = kneeRecoveryProgram, Day = 6, Exercise = hamstringStretch },
                new ProgrammeExercise { Programme = kneeRecoveryProgram, Day = 7, Exercise = hamstringStretch }
            );
            context.SaveChanges();
        }
    }
}
