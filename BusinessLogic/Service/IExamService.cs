using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IExamService
    {
        Task<ExamResponseDto> CreateExamAsync(ExamCreateDto dto);
        Task<List<ExamResponseDto>> GetAllAsync();
    }

}
