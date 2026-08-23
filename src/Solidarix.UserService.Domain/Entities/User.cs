namespace Solidarix.UserService.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public User(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
        }

        public bool VerifyPassword(string hashToCompare)
        {
            return PasswordHash == hashToCompare;
        }
    }
}
