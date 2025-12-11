using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class ExamCreateDto
    {
        public int StudentID { get; set; }
        public int ExamYear { get; set; }
        public List<ExamDetailDto> Details { get; set; } = new();
    }

}
