using System.ComponentModel.DataAnnotations;

namespace FlexiCareManager.Models;

public class ProgrammeTreatment
{
    public int Id { get; set; }
    [Display(Name = "Treatment")]
    public int TreatmentId {get; set;}
    public virtual Treatment Treatment  { get; set; } = new Treatment();
    [Display(Name = "Programme")]
    public int ProgrammeId {get; set;}
    public virtual Programme Programme  { get; set; } = new Programme();
}
