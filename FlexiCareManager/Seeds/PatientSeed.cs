using FlexiCareManager.Data;
using FlexiCareManager.Models;

namespace FlexiCareManager.Seeds
{
    public static class PatientSeed
    {
        public static void Seed(FlexiCareManagerContext context)
        {
            if (context.Patient.Any())
            {
                return;
            }

            var patients = new List<Patient>
            {
                new Patient { Name = "Alice Walker", Phone = "555-100-2001", Address = "12 Garden Lane, Roseville", AllowNotifications=true },
                new Patient { Name = "Ben Carter", Phone = "555-100-2002", Address = "34 Park Ave, Hilltown", AllowNotifications=false },
                new Patient { Name = "Catherine Lee", Phone = "555-100-2003", Address = "56 River Street, Lakeview", AllowNotifications=true },
                new Patient { Name = "Daniel Wright", Phone = "555-100-2004", Address = "78 Sunset Blvd, Westport", AllowNotifications=false },
                new Patient { Name = "Ella Johnson", Phone = "555-100-2005", Address = "90 Ocean Drive, Rivertown", AllowNotifications=false },
                new Patient { Name = "Frank Lin", Phone = "555-100-2006", Address = "21 Birch Road, Northside", AllowNotifications=true },
                new Patient { Name = "Grace Kim", Phone = "555-100-2007", Address = "43 Maple Crescent, Brookfield", AllowNotifications=true },
                new Patient { Name = "Henry Adams", Phone = "555-100-2008", Address = "65 Cedar Street, Springfield", AllowNotifications=false },
                new Patient { Name = "Isabella Nguyen", Phone = "555-100-2009", Address = "87 Elm Avenue, Eastview", AllowNotifications=true },
                new Patient { Name = "Jack Morales", Phone = "555-100-2010", Address = "109 Pine Hill Road, Southwood", AllowNotifications=false },
            };
            foreach (var patient in patients)
            {
                patient.Email = patient.Name!.Replace(' ', '.').ToLower() + "@patient.ie";
            }
            context.Patient.AddRange(patients);
            context.SaveChanges();
        }
    }
}
