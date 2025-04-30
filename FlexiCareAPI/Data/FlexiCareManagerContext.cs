using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FlexiCareManager.Models;

namespace FlexiCareManager.Data
{
    public class FlexiCareManagerContext   : IdentityDbContext<IdentityUser>
    {
        public FlexiCareManagerContext (DbContextOptions<FlexiCareManagerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Exercise> Exercise { get; set; } = default!;
        public DbSet<ExerciseCategory> ExerciseCategory { get; set; } = default!;
        public DbSet<Patient> Patient { get; set; } = default!;
        public DbSet<PatientProgramme> PatientProgramme { get; set; } = default!;
        public DbSet<Programme> Programme { get; set; } = default!;
        public DbSet<ProgrammeExercise> ProgrammeExercise { get; set; } = default!;
        public DbSet<ProgrammeTreatment> ProgrammeTreatment { get; set; } = default!;
        public DbSet<Treatment> Treatment { get; set; } = default!;
        public DbSet<Appointment> Appointment { get; set; } = default!;
        public DbSet<Physio> Physio { get; set; } = default!;
        public DbSet<Session> Session { get; set; } = default!;
    }
}
