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
    public class ProgrammeController : ControllerBase
    {
        private readonly FlexiCareManagerContext _context;

        public ProgrammeController(FlexiCareManagerContext context)
        {
            _context = context;
        }

        // GET: api/Programme
        [HttpGet()]
        public async Task<ActionResult<List<ProgrammeApiProgramme>>> GetProgrammes()
        {
            var user = User.Identity;
            if (user == null)
            {
                return Unauthorized();
            }
            var programmeList = await _context.Programme
                .Include(p => p.Exercises)
                    .ThenInclude(pe => pe.Exercise)
                        .ThenInclude(ex => ex.ExerciseCategory)
                .ToListAsync();


            if (programmeList == null || programmeList.Count == 0)
            {
                return NotFound();
            }
            var response = new List<ProgrammeApiProgramme>();
            programmeList.ForEach(programme => response.Add(new ProgrammeApiProgramme(programme)));

            return response;
        }

    }
}
