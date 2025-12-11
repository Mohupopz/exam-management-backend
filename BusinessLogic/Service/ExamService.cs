using DataAccess.Context;
using DataAccess.Dto;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{

    public class ExamService : IExamService
    {
        private readonly DataContext _context;

        public ExamService(DataContext context)
        {
            _context = context;
        }

        public async Task<ExamResponseDto> CreateExamAsync(ExamCreateDto dto)
        {
            if (await _context.ExamMasters
                .AnyAsync(e => e.StudentID == dto.StudentID && e.ExamYear == dto.ExamYear))
                throw new Exception("Student already has exam for this year.");

            int total = dto.Details.Sum(d => d.Marks);
            bool pass = dto.Details.All(d => d.Marks >= 25);

            var master = new ExamMaster
            {
                StudentID = dto.StudentID,
                ExamYear = dto.ExamYear,
                TotalMark = total,
                PassOrFail = pass ? "PASS" : "FAIL",
                CreateTime = DateTime.Now,
                Details = dto.Details.Select(d => new ExamDtls
                {
                    SubjectID = d.SubjectID,
                    Marks = d.Marks
                }).ToList()
            };

            _context.ExamMasters.Add(master);
            await _context.SaveChangesAsync();

            var student = await _context.Students.FindAsync(dto.StudentID);

            return new ExamResponseDto
            {
                MasterID = master.MasterID,
                StudentName = student!.StudentName,
                ExamYear = master.ExamYear,
                TotalMark = master.TotalMark,
                PassOrFail = master.PassOrFail
            };
        }

        public async Task<List<ExamResponseDto>> GetAllAsync()
        {
            return await _context.ExamMasters
                .AsNoTracking()
                .Select(e => new ExamResponseDto
                {
                    MasterID = e.MasterID,
                    StudentName = _context.Students
                        .Where(s => s.StudentID == e.StudentID)
                        .Select(s => s.StudentName)
                        .First(),
                    ExamYear = e.ExamYear,
                    TotalMark = e.TotalMark,
                    PassOrFail = e.PassOrFail
                }).ToListAsync();
        }
    }
}
