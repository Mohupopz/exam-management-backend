using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/exams")]
public class ExamController : ControllerBase
{
    private readonly DataContext _context;

    public ExamController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> SaveExam([FromBody] ExamSaveDto dto)
    {
        if (dto == null || dto.Details == null || !dto.Details.Any())
            return BadRequest("Invalid exam data");

        int totalMarks = dto.Details.Sum(d => d.Marks);
        bool isPass = dto.Details.All(d => d.Marks >= 25);

        var master = new ExamMaster
        {
            StudentID = dto.StudentID,
            ExamYear = dto.ExamYear,
            TotalMark = totalMarks,
            PassOrFail = isPass ? "PASS" : "FAIL",
            CreateTime = DateTime.Now
        };

        _context.ExamMasters.Add(master);
        await _context.SaveChangesAsync();

        foreach (var d in dto.Details)
        {
            _context.ExamDetails.Add(new ExamDtls
            {
                MasterID = master.MasterID,
                SubjectID = d.SubjectID,
                Marks = d.Marks
            });
        }

        await _context.SaveChangesAsync();

        return Ok(new { message = "Exam saved successfully", masterId = master.MasterID });
    }
}
