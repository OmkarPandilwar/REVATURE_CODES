namespace Ormconsole;

public class Subject
{
    public int Id { get; set; }
    public string SubjectName { get; set; } = "";

    // FK (many subjects belong to one student)
    public int StudentId { get; set; }
}