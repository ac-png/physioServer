using System.ComponentModel.DataAnnotations;
using FlexiCareManager.Models;

namespace FlexiCareAPI.ApiModels;

public class ApiUpdatePatient
{
    public int Id { get; set; }
    public string? Phone  { get; set; }
    public string? Address  { get; set; }
    public bool AllowNotifications  { get; set; }
    public ApiUpdatePatient()
    {}
}
