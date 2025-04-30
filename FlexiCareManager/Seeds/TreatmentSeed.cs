using FlexiCareManager.Data;
using FlexiCareManager.Models;

namespace FlexiCareManager.Seeds
{
    public static class TreatmentSeed
    {
        public static void Seed(FlexiCareManagerContext context)
        {
            if (context.Treatment.Any())
            {
                return;
            }

            var cervicalSpineTreatment = new Treatment { Name = "Cervical Spine Mobilization", Subtitle = "Neck Region" };
            var kneeRehabTreatment = new Treatment { Name = "Post-op Knee Rehabilitation", Subtitle = "ACL Reconstruction Recovery" };

            context.Treatment.AddRange(cervicalSpineTreatment, kneeRehabTreatment);
            context.SaveChanges();
        }
    }
}
