using System.Linq;

public class Questions
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public string[] BadAnswers { get; set; }
    public string Category { get; set; }
    public string Difficulty { get; set; }

    public string[] Answers 
    {
        get => (string[])BadAnswers.Append(Answer);
    }
}
