namespace NedMonitor.Application.Requests;

/// <summary>
/// Represents the configuration settings for sensitive data masking in HTTP requests.
/// </summary>
public class SensitiveDataMaskerSettingsInfo
{
    /// <summary>
    /// Indicates whether sensitive data masking is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// A list of sensitive keys that should be masked in logs or outputs.
    /// </summary>
    public List<string>? SensitiveKeys { get; set; }

    /// <summary>
    /// The value used to replace the sensitive data (e.g., "***").
    /// </summary>
    public string? MaskValue { get; set; }
}