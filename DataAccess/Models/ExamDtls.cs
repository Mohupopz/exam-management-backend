using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ExamDtls")]
public class ExamDtls
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DtlsID { get; set; }

    public int MasterID { get; set; }
    public int SubjectID { get; set; }

    [Range(0, 100)]
    public int Marks { get; set; }

    [ForeignKey("MasterID")]
    public ExamMaster Master { get; set; }
}
