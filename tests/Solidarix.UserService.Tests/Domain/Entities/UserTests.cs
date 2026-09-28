using Xunit;
using Solidarix.UserService.Domain.Entities;

namespace Solidarix.UserService.Tests.Domain.Entities
{
    public class UserTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            var user = new User("test@example.com", "hashed123", "Test User");

            Assert.Equal("test@example.com", user.Email);
            Assert.Equal("hashed123", user.PasswordHash);
            Assert.Equal("Test User", user.FullName);
            Assert.NotEqual(Guid.Empty, user.Id);
        }

        [Fact]
        public void UpdatePassword_ShouldChangePasswordHash()
        {
            var user = new User("test@example.com", "oldHash", "Test User");

            user.UpdatePassword("newHash");

            Assert.Equal("newHash", user.PasswordHash);
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenEmailEmpty()
        {
            Assert.Throws<DomainException>(() => new User("", "hash", "Test User"));
        }

        [Fact]
        public void UpdatePassword_ShouldThrow_WhenEmpty()
        {
            var user = new User("test@example.com", "oldHash", "Test User");

            Assert.Throws<DomainException>(() => user.UpdatePassword(""));
        }
    }
}
