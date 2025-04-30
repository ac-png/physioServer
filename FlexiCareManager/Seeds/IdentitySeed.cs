using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FlexiCareManager.Data;
using FlexiCareManager.Models;
using FlexiCareManager.Services;

namespace FlexiCareManager.Seeds
{
    public static class IdentitySeed
    {
        public static async Task Seed(UserManager<IdentityUser> userManager, FlexiCareManagerContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }
            var adminRole = "ADMINISTRATOR";
            var physioRole = "PHYSIO";
            var patientRole = "PATIENT";
            string[] roles = [adminRole, physioRole, patientRole];
            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    var identityRole = new IdentityRole(){Name = role, NormalizedName = role};
                    await roleStore.CreateAsync(identityRole);
                }
            }
            var userStore = new UserStore<IdentityUser>(context);

            // Create Administrator
            await IdentityService.CreateUser(userStore, "Alice Governor", "alice.governor@flexicare.ie");

            // Create Patients
            var patients = context.Patient.ToList();
            foreach (var patient in patients)
            {
                await IdentityService.CreateUser(userStore, patient.Name!, patient.Email!);
            }

            // Create Physios
            var physios = context.Physio.ToList();
            foreach (var physio in physios)
            {
                await IdentityService.CreateUser(userStore, physio.Name!, physio.Email!);
            }

            context.SaveChanges();

            // Add Administrator Roles
            await IdentityService.AddRoles(userManager, "alice.governor@flexicare.ie", [adminRole]);
            
            // Add Patient roles
            foreach (var patient in patients)
            {
                var email = patient.Name!.Replace(' ', '.') + "@patient.ie";
                await IdentityService.AddRoles(userManager, email, [patientRole]);
            }

            // Add Physios roles
            foreach (var physio in physios)
            {
                var noTitle = physio.Name!.Replace("Dr. ", "");
                var email = noTitle.Replace(' ', '.') + "@flexicare.ie";
                await IdentityService.AddRoles(userManager, email.ToLower(), [physioRole]);
            }

        }

    }
}
