using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("SubjectMst")]
    public class SubjectMst
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; } = null!;
    }
}
