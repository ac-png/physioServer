using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlexiCareManager.Data;
namespace FlexiCareManager.Seeds
{
    public static class ClearData
    {
        public static async Task Clear(FlexiCareManagerContext context)
        {
            // These should be in the reverse order to the seeding to ensure that all dependencies are deleted 
            await context.Session.ExecuteDeleteAsync();
            await context.PatientProgramme.ExecuteDeleteAsync();
            await context.Appointment.ExecuteDeleteAsync();
            await context.Patient.ExecuteDeleteAsync();
            await context.Physio.ExecuteDeleteAsync();
            await context.ProgrammeTreatment.ExecuteDeleteAsync();
            await context.ProgrammeExercise.ExecuteDeleteAsync();
            await context.Programme.ExecuteDeleteAsync();
            await context.Treatment.ExecuteDeleteAsync();
            await context.Exercise.ExecuteDeleteAsync();
            await context.ExerciseCategory.ExecuteDeleteAsync();
            context.SaveChanges();
        }
    }
}