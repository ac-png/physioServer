using System.ComponentModel.DataAnnotations;
using FlexiCareManager.Models;

namespace FlexiCareAPI.ApiModels;

public class ApiUpdateSession
{
    public int Id { get; set; }
    public bool Done { get; set;}
    public string Feedback  { get; set; } = string.Empty;
    public int PainLevel  { get; set; }
    public ApiUpdateSession()
    {}
}
