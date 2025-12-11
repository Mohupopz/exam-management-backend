using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ExamMaster")]
public class ExamMaster
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MasterID { get; set; }

    public int StudentID { get; set; }
    public int ExamYear { get; set; }
    public int TotalMark { get; set; }
    public string PassOrFail { get; set; } = "";
    public DateTime CreateTime { get; set; }

    public ICollection<ExamDtls> Details { get; set; } = new List<ExamDtls>();
}
