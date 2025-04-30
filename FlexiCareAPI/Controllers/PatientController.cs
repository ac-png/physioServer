using Microsoft.AspNetCore.Mvc;
using FlexiCareManager.Data;
using FlexiCareAPI.ApiModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FlexiCareAPI.ApiControllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private readonly FlexiCareManagerContext _context;

        public PatientController(FlexiCareManagerContext context)
        {
            _context = context;
        }

        // // GET: api/Patient/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<ApiPatient>> GetPatient(int id)
        // {
        //     var user = User.Identity;
        //     if (user == null)
        //     {
        //         return Unauthorized();
        //     }
        //     var patient = await _context.Patient
        //         .Include(p => p.Programmes)
        //         .Include(p => p.Appointments)
        //         .FirstOrDefaultAsync(p => p.Id == id);

        //     if (patient == null)
        //     {
        //         return NotFound();
        //     }

        //     return new ApiPatient(patient);
        // }

        // GET: api/Patient/me
        [HttpGet("me")]
        public async Task<ActionResult<ApiPatient>> GetMe()
        {
            var user = User.Identity;
            if (user == null)
            {
                return Unauthorized();
            }
            var patient = await _context.Patient
                .Include(p => p.Programmes)
                    .ThenInclude(pp => pp.Programme)
                        .ThenInclude(programme => programme!.Treatments)
                            .ThenInclude(pt => pt.Treatment)
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.Physio)
                .Include(p => p.Sessions)
                    .ThenInclude(s => s.Exercise)
                        .ThenInclude(e => e.ExerciseCategory)
                .FirstOrDefaultAsync(p => p.Email == user.Name);

            if (patient == null)
            {
                return NotFound();
            }

            return new ApiPatient(patient);
        }


        // POST: api/Patient/me
        [HttpPut("me")]
        public async Task<ActionResult> UpdateMe(ApiUpdatePatient updatePatient)
        {
            if(updatePatient == null)
            {
                return BadRequest("");
            }

            var user = User.Identity;
            if (user == null)
            {
                return Unauthorized();
            }

            var patient = await _context.Patient
                .FirstOrDefaultAsync(p => p.Email == user.Name);

            if (patient == null || patient.Id != updatePatient.Id)
            {
                return NotFound();
            }

            patient.Address = updatePatient.Address;
            patient.Phone = updatePatient.Phone;
            patient.AllowNotifications = updatePatient.AllowNotifications;

            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
