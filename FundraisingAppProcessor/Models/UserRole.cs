namespace FundraisingAppProcessor.Models;

/// <summary>
/// Enumeration representing the roles of users in the fundraising application.
/// </summary>
public enum UserRole
{
    /// <summary>
    /// Role is not specified.
    /// </summary>
    Unspecified = 0,

    /// <summary>
    /// Administrator role.
    /// </summary>
    Admin = 1,

    /// <summary>
    /// Collector role (Kwestujący).
    /// </summary>
    Collector = 2,

    /// <summary>
    /// Counter role (Liczący).
    /// </summary>
    Counter = 3
}
