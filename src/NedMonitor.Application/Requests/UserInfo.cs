using System.Text.Json.Serialization;

namespace NedMonitor.Application.Requests;

/// <summary>
/// Represents the context information of the current user.
/// </summary>
public class UserInfo
{
    /// <summary>
    /// The unique identifier of the user.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// The user's full name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The user's document.
    /// </summary>
    public string? Document { get; set; }

    /// <summary>
    /// The user's account code.
    /// </summary>
    public string? AccountCode { get; set; }

    /// <summary>
    /// The user's account.
    /// </summary>
    public string? Account { get; set; }

    /// <summary>
    /// The user's e-mail.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// The tenant or user code.
    /// </summary>
    public string? TenantId { get; set; }

    /// <summary>
    /// Indicates whether the user is authenticated.
    /// </summary>
    public bool IsAuthenticated { get; set; }

    /// <summary>
    /// The type of authentication used.
    /// </summary>
    public string? AuthenticationType { get; set; }

    /// <summary>
    /// The roles assigned to the user.
    /// </summary>
    public IEnumerable<string>? Roles { get; set; }

    /// <summary>
    /// The claims associated with the user.
    /// </summary>
    public IDictionary<string, string>? Claims { get; set; }
}
