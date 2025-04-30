using FlexiCareManager.Data;
using FlexiCareManager.Models;

namespace FlexiCareManager.Seeds
{
    public static class PhysioSeed
    {
        public static void Seed(FlexiCareManagerContext context)
        {
            if (context.Physio.Any())
            {
                return;
            }

            var physios = new List<Physio>
            {
                new Physio { Name = "Dr. Sarah Thompson", Phone = "087 123-4567", Address = "12 Elm Street, Navan" },
                new Physio { Name = "Dr. Alice Legg", Phone = "086 234-5678", Address = "45 Oak Avenue, Trim" },
                new Physio { Name = "Dr. Emily Chen", Phone = "083 345-6789", Address = "78 Maple Drive, Ballsbridge" },
                new Physio { Name = "Dr. Michael Johnson", Phone = "081 456-7890", Address = "11 Pine Street, Stillorgan" },
                new Physio { Name = "Dr. Anna Garcia", Phone = "087 567-8901", Address = "22 Cedar Lane, Malahide" },
                new Physio { Name = "Dr. David Kim", Phone = "085 678-9012", Address = "33 Birch Blvd, Swords" },
                new Physio { Name = "Dr. Lisa Nguyen", Phone = "01 789-0123", Address = "44 Willow Way, Howth" },
                new Physio { Name = "Dr. Robert O'Neil", Phone = " 041 890-1234", Address = "55 Chestnut Circle, Bayside" },
                new Physio { Name = "Dr. Monica Diaz", Phone = "045 901-2345", Address = "66 Spruce Road, Kilbarrack" },
                new Physio { Name = "Dr. Daniel Ahmed", Phone = "083 012-3456", Address = "77 Aspen Court, Blackrock" },
            };
            foreach (var physio in physios)
            {
                var noTitle = physio.Name!.Replace("Dr. ", "");
                physio.Email = noTitle.Replace(' ', '.').ToLower() + "@flexicare.ie";
            }
            context.Physio.AddRange(physios);
            context.SaveChanges();
        }
    }
}
