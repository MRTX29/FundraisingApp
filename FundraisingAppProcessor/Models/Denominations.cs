namespace FundraisingAppProcessor.Models;

/// <summary>
/// Represents the denominations of currency contained in a money box.
/// </summary>
public class Denominations
{
    /// <summary>
    /// Gets or sets the count of 500 złoty.
    /// </summary>
    public int Count500 { get; set; }

    /// <summary>
    /// Gets or sets the count of 200 złoty.
    /// </summary>
    public int Count200 { get; set; }

    /// <summary>
    /// Gets or sets the count of 100 złoty.
    /// </summary>
    public int Count100 { get; set; }

    /// <summary>
    /// Gets or sets the count of 50 złoty.
    /// </summary>
    public int Count50 { get; set; }

    /// <summary>
    /// Gets or sets the count of 20 złoty.
    /// </summary>
    public int Count20 { get; set; }

    /// <summary>
    /// Gets or sets the count of 10 złoty.
    /// </summary>
    public int Count10 { get; set; }

    /// <summary>
    /// Gets or sets the count of 5 złoty.
    /// </summary>
    public int Count5 { get; set; }

    /// <summary>
    /// Gets or sets the count of 2 złoty.
    /// </summary>
    public int Count2 { get; set; }

    /// <summary>
    /// Gets or sets the count of 1 złoty.
    /// </summary>
    public int Count1 { get; set; }

    /// <summary>
    /// Gets or sets the count of 50 groszy.
    /// </summary>
    public int Count50gr { get; set; }

    /// <summary>
    /// Gets or sets the count of 20 groszy.
    /// </summary>
    public int Count20gr { get; set; }

    /// <summary>
    /// Gets or sets the count of 10 groszy.
    /// </summary>
    public int Count10gr { get; set; }

    /// <summary>
    /// Gets or sets the count of 5 groszy.
    /// </summary>
    public int Count5gr { get; set; }

    /// <summary>
    /// Gets or sets the count of 2 groszy.
    /// </summary>
    public int Count2gr { get; set; }

    /// <summary>
    /// Gets or sets the count of 1 groszy.
    /// </summary>
    public int Count1gr { get; set; }

    /// <summary>
    /// Gets or sets other currencies contained in the money box.
    /// </summary>
    public string? OtherCurrencies { get; set; }
}

