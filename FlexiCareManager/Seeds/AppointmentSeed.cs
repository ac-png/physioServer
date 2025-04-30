using FlexiCareManager.Data;
using FlexiCareManager.Models;

namespace FlexiCareManager.Seeds
{
    public static class AppointmentSeed
    {
        public static void Seed(FlexiCareManagerContext context)
        {
            if (context.Appointment.Any())
            {
                return;
            }

            var patients = context.Patient.ToList();
            if (!patients.Any()) return;

            var physios = context.Physio.ToList();
            if (!physios.Any()) return;

            var random = new Random();
            var appointments = new List<Appointment>();

            foreach (var patient in patients)
            {
                int numberOfAppointments = random.Next(1, 3); // 1 or 2 appointments

                for (int i = 0; i < numberOfAppointments; i++)
                {
                    appointments.Add(new Appointment
                    {
                        PatientId = patient.Id,
                        When = DateTime.Now.AddDays(random.Next(1, 30)).AddHours(random.Next(8, 17)),
                        Physio = physios[random.Next(physios.Count)]
                    });
                }
            }

            context.Appointment.AddRange(appointments);
            context.SaveChanges();
        }
    }
}
