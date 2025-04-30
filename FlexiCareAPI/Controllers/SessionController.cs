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
    public class SessionController : ControllerBase
    {
        private readonly FlexiCareManagerContext _context;

        public SessionController(FlexiCareManagerContext context)
        {
            _context = context;
        }

        // POST: api/Session/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMe(int id, ApiUpdateSession updateSession)
        {
            if(updateSession == null)
            {
                return BadRequest("");
            }
            if(updateSession.Id != id)
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
            var session = await _context.Session
                .FirstOrDefaultAsync(s => s.Id == id);

            if (patient == null || session == null || patient.Id != session.PatientId)
            {
                return NotFound();
            }

            session.Done = updateSession.Done;
            session.Feedback = updateSession.Feedback;
            session.PainLevel = updateSession.PainLevel;

            _context.Entry(session).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
