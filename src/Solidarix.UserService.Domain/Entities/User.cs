namespace Solidarix.UserService.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string FullName { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        // Constructor protegido para EF Core
        protected User() { }

        public User(string email, string passwordHash, string fullName)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException("Error_EmailEmpty");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new DomainException("Error_PasswordEmpty");

            Email = email;
            PasswordHash = passwordHash;
            FullName = fullName;
        }

        public void UpdatePassword(string newHash)
        {
            if (string.IsNullOrWhiteSpace(newHash))
                throw new DomainException("Error_PasswordEmpty");

            PasswordHash = newHash;
        }
    }

    // Excepción de dominio que encapsula un código de error
    public class DomainException : Exception
    {
        public string ErrorCode { get; }

        public DomainException(string errorCode) : base(errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}
