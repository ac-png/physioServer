using FlexiCareManager.Data;
using FlexiCareManager.Models;

namespace FlexiCareManager.Seeds
{
    public static class ProgrammeSeed
    {
        public static void Seed(FlexiCareManagerContext context)
        {
            if (context.Programme.Any())
            {
                return;
            }
            
            var coreStrengthProgram = new Programme
            {
                Name = "Core Strength Builder - 7 Days",
                Duration = 7,
                Author = "Dr. Emily Clark"
            };

            var kneeRecoveryProgram = new Programme
            {
                Name = "Knee Recovery Phase 1 - 7 Days",
                Duration = 7,
                Author = "Dr. Alex Johnson"
            };

            context.Programme.AddRange(coreStrengthProgram, kneeRecoveryProgram);
            context.SaveChanges();
        }
    }
}
