using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("StudentMst")]
    public class StudentMst
    {
        [Key]
        public int StudentID { get; set; }

        [Required, StringLength(250, MinimumLength = 5)]
        public string StudentName { get; set; } = null!;

        [Required, EmailAddress]
        public string Mail { get; set; } = null!;
    }
}
