using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgency.Data;

public class Qna
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public string Question { get; init; }
    public string Answer { get; init; }

    public Qna(int id, string question, string answer)
    {
        Id = id;
        Question = question;
        Answer = answer;
    }
}