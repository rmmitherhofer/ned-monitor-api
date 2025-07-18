namespace NedMonitor.Application.Responses;

public class UserResponse
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Account { get; set; }
    public string? AccountCode { get; set; }
    public string? Document { get; set; }
    public string? Email { get; set; }
    public string? TenantId { get; set; }
    public bool IsAuthenticated { get; set; }
    public string? AuthenticationType { get; set; }
    public IEnumerable<string>? Roles { get; set; }
    public IDictionary<string, string>? Claims { get; set; }


}
