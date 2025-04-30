using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlexiCareManager.Data;
using FlexiCareManager.Models;

namespace FlexiCareManager.Seeds
{
    public static class PatientProgrammeSeed
    {
        public static async Task Seed(FlexiCareManagerContext context)
        {
            if (context.PatientProgramme.Any())
            {
                return;
            }
            var coreStrengthProgram = context.Programme
                .Include(p => p.Exercises)
                    .ThenInclude(pe => pe.Exercise)
                        .ThenInclude(e => e.ExerciseCategory)
                .FirstOrDefault(p => p.Name == "Core Strength Builder - 7 Days");
            if (coreStrengthProgram == null)
            {
                return;
            }

            var alice = context.Patient.FirstOrDefault(p => p.Name == "Alice Walker");
            if (alice == null)
            {
                return;
            }

            var aliceCoreStrengthProgramme = new PatientProgramme
            {
                PatientId = alice.Id,
                Patient = alice,
                ProgrammeId = coreStrengthProgram.Id,
                Programme = coreStrengthProgram,
                StartDate = DateTime.Today
            };

            await aliceCoreStrengthProgramme.CreateProgramme(context);
        }
    }
}
