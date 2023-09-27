using Report.Domain.Enums;

namespace Report.Domain.Entities;

public class Output
{
    public Guid Id { get; set; }
    public double Summa { get; set; }
    public OutputCategory Category { get; set; }
    public string? Comment { get; set; }
    public DateTime AddedTime { get; set; } 
    public Guid UserId { get; set; }
}
