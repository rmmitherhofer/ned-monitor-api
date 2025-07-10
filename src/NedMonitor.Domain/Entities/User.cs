using Common.Exceptions;

namespace NedMonitor.Domain.Entities;

public class User
{
    public string? Id { get; private set; }
    public string? Name { get; private set; }
    public string? Account { get; private set; }
    public string? AccountCode { get; private set; }
    public string? Document { get; private set; }
    public string? Email { get; private set; }
    public string? TenantId { get; private set; }
    public bool IsAuthenticated { get; private set; }
    public string? AuthenticationType { get; private set; }
    public IEnumerable<string>? Roles{ get; private set; }
    public IDictionary<string, string>? Claims { get; private set; }

    private User() { }

    private User(string? id) => Id = id;

    public static UserInfoBuilder Create(string userId) => new(userId);

    public class UserInfoBuilder
    {
        private readonly User _user;
        public UserInfoBuilder(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new DomainException("User Id is required.");

            _user = new User(id);
        }
        public UserInfoBuilder WithName(string? name)
        {
            _user.Name = name;
            return this;
        }

        public UserInfoBuilder WithAccountCode(string? account)
        {
            _user.AccountCode = account;
            return this;
        }

        public UserInfoBuilder WithAccount(string? account)
        {
            _user.Account = account;
            return this;
        }

        public UserInfoBuilder WithDocument(string? document)
        {
            _user.Document = document;
            return this;
        }
        public UserInfoBuilder WithEmail(string? email)
        {
            _user.Email = email;
            return this;
        }
        public UserInfoBuilder WithRole(IEnumerable<string>? roles)
        {
            _user.Roles = roles;
            return this;
        }
        public UserInfoBuilder WithClaims(IDictionary<string, string>? claims)
        {
            _user.Claims = claims;
            return this;
        }
        public UserInfoBuilder WithTenant(string? tenantId)
        {
            _user.TenantId = tenantId;
            return this;
        }
        public UserInfoBuilder Authenticated(string? authType)
        {
            _user.IsAuthenticated = true;
            _user.AuthenticationType = authType;
            return this;
        }
        public User Build() => _user;
    }

    public static User CreateAnonymous()
    {
        return new("anonymous")
        {
            IsAuthenticated = false
        };
    }
    public override string ToString()
    {
        return IsAuthenticated
            ? $"{Name ?? "Unknown"} ({Id})"
            : "Anonymous User";
    }
}
