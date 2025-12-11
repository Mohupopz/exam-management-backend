using DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentExamManagement.Controllers
{

    [ApiController]
    [Route("api/subjects")]
    public class SubjectsController : ControllerBase
    {
        private readonly DataContext _context;

        public SubjectsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _context.Subjects
                .AsNoTracking()
                .Select(s => new
                {
                    subjectID = s.SubjectID,
                    subjectName = s.SubjectName
                })
                .ToListAsync();

            return Ok(data);
        }


    }
}
