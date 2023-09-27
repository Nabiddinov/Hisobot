using Report.Domain.Enums;

namespace Report.Domain.Entities;

public class Input
{
    public Guid Id { get; set; }
    public double Summa { get; set; }
    public InputCategory Category { get; set; }
    public string? Comment { get; set; }
    public DateTime AddedTime { get; set; } 
    public Guid UserId { get; set; }     
}

