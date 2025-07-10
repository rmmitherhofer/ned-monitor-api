using Common.Core.DomainObjects;
using Common.Exceptions;
using System.Data;
using UAParser;

namespace NedMonitor.Domain.Entities;

public class UserPlatform
{
    public string UserAgent { get; private set; }
    public string BrowserName { get; private set; }
    public string BrowserVersion { get; private set; }
    public string OSName { get; private set; }
    public string OSVersion { get; private set; }
    public string DeviceType { get; private set; }

    private UserPlatform(string userAgent)
    {

        UserAgent = userAgent;

        var uaParser = Parser.GetDefault();
        var result = uaParser.Parse(userAgent);

        BrowserName = result.UA.Family;
        BrowserVersion = FormatVersion(result.UA.Major, result.UA.Minor, result.UA.Patch);

        OSName = result.OS.Family;
        OSVersion = FormatVersion(result.OS.Major, result.OS.Minor, result.OS.Patch);

        DeviceType = result.Device.Family;
    }

    private static string FormatVersion(string? major, string? minor, string? patch)
    {
        var parts = new[] { major, minor, patch }
            .Where(part => !string.IsNullOrWhiteSpace(part))
            .ToArray();

        return string.Join(".", parts);
    }

    public static UserPlatformInfoBuilder Create(string userAgent) => new(userAgent);

    public class UserPlatformInfoBuilder
    {
        private readonly UserPlatform _userPlatform;

        public UserPlatformInfoBuilder(string userAgent)
        {
            if (string.IsNullOrWhiteSpace(userAgent))
                throw new DomainException("UserAgent cannot be null or empty.");

            _userPlatform = new UserPlatform(userAgent);
        }
        public UserPlatform Build() => _userPlatform;
    }

    public override string ToString()
    {
        return $"{BrowserName} {BrowserVersion} on {OSName} {OSVersion} ({DeviceType})";
    }
}