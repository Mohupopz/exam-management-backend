using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class ExamResponseDto
    {
        public int MasterID { get; set; }
        public string StudentName { get; set; } = null!;
        public int ExamYear { get; set; }
        public int TotalMark { get; set; }
        public string PassOrFail { get; set; } = null!;
    }

}
