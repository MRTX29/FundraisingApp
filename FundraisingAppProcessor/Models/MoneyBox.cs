namespace FundraisingAppProcessor.Models;

/// <summary>
/// Represents a money box in the fundraising application.
/// </summary>
public class MoneyBox
{
    /// <summary>
    /// Gets or sets the unique identifier for the money box.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the date the money box was returned.
    /// </summary>
    public DateTime? DateReturned { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the money box was approved by an admin.
    /// </summary>
    public bool ApprovedByAdmin { get; set; }

    /// <summary>
    /// Gets or sets the denominations contained in the money box.
    /// </summary>
    public Denominations Denominations { get; set; } = new();
}

