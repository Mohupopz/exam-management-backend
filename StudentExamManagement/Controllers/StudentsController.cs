using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    private readonly DataContext _context;

    public StudentsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string search = "")
    {
        return Ok(await _context.Students
            .AsNoTracking()
            .Where(s => s.StudentName.Contains(search))
            .Take(10)
            .ToListAsync());
    }
}
