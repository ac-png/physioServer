using System.ComponentModel.DataAnnotations;
using FlexiCareManager.Models;

namespace FlexiCareAPI.ApiModels;

public class ApiPatient
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Phone  { get; set; }
    public string? Address  { get; set; }
    public string? Email  { get; set; }
    public bool AllowNotifications  { get; set; }
    public List<ApiPatientProgramme> Programmes { get; set; } = [];
    public List<ApiAppointment> Appointments { get; set; } = [];
    public List<ApiSession> Sessions { get; set; } = [];

    public ApiPatient()
    {}

    public ApiPatient(Patient patient)
    {
        Id = patient.Id;
        Name = patient.Name;
        Phone = patient.Phone;
        Address = patient.Address;
        Email = patient.Email;
        AllowNotifications = patient.AllowNotifications;
        Programmes = [];
        Appointments = [];
        patient.Programmes.ForEach(pp => Programmes.Add(new ApiPatientProgramme(pp)));
        patient.Appointments.ForEach(a => Appointments.Add(new ApiAppointment(a)));
        patient.Sessions.ForEach(s => Sessions.Add(new ApiSession(s)));
    }

}

public class ApiPatientProgramme
{
    public int PatientId {get; set;}
    public int ProgrammeId {get; set;}
    // public virtual Programme? Programme  { get; set; }
    public DateTime? StartDate {get; set; }
    public DateTime? EndDate {get; set; }
    public List<Treatment> Treatments { get; set; } = []; 

    public ApiPatientProgramme()
    {}

    public ApiPatientProgramme(PatientProgramme patientProgramme)
    {
        PatientId = patientProgramme.PatientId;
        ProgrammeId = patientProgramme.ProgrammeId;
        StartDate = patientProgramme.StartDate;
        EndDate = patientProgramme.EndDate;
        Treatments = [];
        patientProgramme.Programme!.Treatments.ForEach(t => Treatments.Add(t.Treatment));
    }
}

public class ApiAppointment
{
    public int Id { get; set; }
    public int? PatientId { get; set; }
    public DateTime? When  { get; set; }
    public int? PhysioId {get; set;}
    public Physio? Physio  { get; set; }
    public ApiAppointment()
    {}

    public ApiAppointment(Appointment appointment)
    {
        Id = appointment.Id;
        PatientId = appointment.PatientId;
        When = appointment.When;
        PhysioId = appointment.PhysioId;
        Physio = appointment.Physio;
    }

}
public class ApiSession
{
    public int Id { get; set; }
    public int PatientId {get; set;}
    public int ExerciseId {get; set;}
    public ApiExercise Exercise  { get; set; } = new ();
    public int ExerciseCategoryId {get; set;}
    public ApiExerciseCategory ExerciseCategory  { get; set; } = new ();
    public DateTime? ExerciseDate {get; set;}
    public String Notes {get; set;} = string.Empty;
    public bool Done {get; set;}
    public int PainLevel {get; set;}
    public string Feedback {get; set;} = string.Empty;
    public ApiSession()
    {}

    public ApiSession(Session session)
    {
        Id = session.Id;
        PatientId = session.PatientId;
        ExerciseId = session.ExerciseId;
        Exercise = new ApiExercise(session.Exercise);
        ExerciseCategoryId = session.ExerciseCategoryId;
        ExerciseCategory = new ApiExerciseCategory(session.ExerciseCategory);
        ExerciseDate = session.ExerciseDate;
        Notes = session.Notes;
        Done = session.Done;
        PainLevel = session.PainLevel;
        Feedback = session.Feedback;
    }

}
public class ApiExercise
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Reps {get; set;} = string.Empty;
    public string Sets {get; set;} = string.Empty;
    public string Frequency {get; set;} = string.Empty;
    public string Rest {get; set;} = string.Empty;
    public string Equipment {get; set;} = string.Empty;
    public string MusclesWorked {get; set;} = string.Empty;
    public string Benefits {get; set;} = string.Empty;
    public string HowToPerform {get; set;} = string.Empty;
    public string Tips {get; set;} = string.Empty;
    [DataType(DataType.ImageUrl)]
    public string ThumbnailUrl {get; set;} = string.Empty;
    [DataType(DataType.Url)]
    public string VideoUrl {get; set;} = string.Empty;

    public ApiExercise()
    {}

    public ApiExercise(Exercise exercise)
    {
        Id = exercise.Id;
        Name = exercise.Name;
        Reps = exercise.Reps;
        Sets = exercise.Sets;
        Frequency  = exercise.Frequency;
        Rest  = exercise.Rest;
        Equipment= exercise.Equipment;
        MusclesWorked= exercise.MusclesWorked;
        Benefits= exercise.Benefits;
        HowToPerform= exercise.HowToPerform;
        Tips= exercise.Tips;
        ThumbnailUrl= exercise.ThumbnailUrl;
        VideoUrl= exercise.VideoUrl;
    }
}

public class ApiExerciseCategory
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ApiExerciseCategory()
    {}

    public ApiExerciseCategory(ExerciseCategory exerciseCategory)
    {
        Id = exerciseCategory.Id;
        Name = exerciseCategory.Name;
    }
}

public class ApiTreatment
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ApiTreatment()
    {}

    public ApiTreatment(Treatment treatment)
    {
        Id = treatment.Id;
        Name = treatment.Name;
    }
}