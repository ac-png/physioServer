using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FlexiCareManager.Data;
namespace FlexiCareManager.Seeds
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var reSeed = false;
            UserManager<IdentityUser> userManager = serviceProvider.GetService<UserManager<IdentityUser>>()!;

            using (var context = new FlexiCareManagerContext(
                serviceProvider.GetRequiredService<DbContextOptions<FlexiCareManagerContext>>()))
            {
                if (reSeed)
                {
                    await ClearData.Clear(context);
                }

                // Call the Seed methods for each entity
                ExerciseCategorySeed.Seed(context);
                ExerciseSeed.Seed(context);
                TreatmentSeed.Seed(context);
                ProgrammeSeed.Seed(context);
                ProgrammeExerciseSeed.Seed(context);
                ProgrammeTreatmentSeed.Seed(context);
                PhysioSeed.Seed(context);
                PatientSeed.Seed(context);
                AppointmentSeed.Seed(context);
                await PatientProgrammeSeed.Seed(context);
                await IdentitySeed.Seed(userManager, context);
            }
        }
    }
}