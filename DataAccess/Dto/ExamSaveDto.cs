public class ExamSaveDto
{
    public int StudentID { get; set; }
    public int ExamYear { get; set; }
    public List<ExamDetailDto> Details { get; set; }
}

public class ExamDetailDto
{
    public int SubjectID { get; set; }
    public int Marks { get; set; }
}
