namespace FundraisingAppProcessor.Models;

public class MoneyBox
{
    public int Id { get; set; }
    public DateTime? DateReturned { get; set; }
    public bool ApprovedByAdmin { get; set; }
    public Denominations Denominations { get; set; } = new();
}