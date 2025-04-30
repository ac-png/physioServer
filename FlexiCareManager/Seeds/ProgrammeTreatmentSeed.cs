using FlexiCareManager.Data;
using FlexiCareManager.Models;

namespace FlexiCareManager.Seeds
{
    public static class ProgrammeTreatmentSeed
    {
        public static void Seed(FlexiCareManagerContext context)
        {
            if (context.ProgrammeTreatment.Any())
            {
                return;
            }

            var coreStrengthProgram = context.Programme.FirstOrDefault(p => p.Name == "Core Strength Builder - 7 Days");
            var kneeRecoveryProgram = context.Programme.FirstOrDefault(p => p.Name == "Knee Recovery Phase 1 - 7 Days");
            var cervicalSpineTreatment = context.Treatment.FirstOrDefault(t => t.Name == "Cervical Spine Mobilization");
            var kneeRehabTreatment = context.Treatment.FirstOrDefault(t => t.Name == "Post-op Knee Rehabilitation");
            if (coreStrengthProgram == null || kneeRecoveryProgram == null || cervicalSpineTreatment == null || kneeRehabTreatment == null)
            {
                return;
            }

            context.ProgrammeTreatment.AddRange(
                new ProgrammeTreatment
                {
                    Programme = coreStrengthProgram,
                    Treatment = cervicalSpineTreatment
                },
                new ProgrammeTreatment
                {
                    Programme = kneeRecoveryProgram,
                    Treatment = kneeRehabTreatment
                }
            );
            context.SaveChanges();
        }
    }
}
