using Xunit;
using Solidarix.UserService.Domain.Entities;

namespace Solidarix.UserService.Tests.Domain.Entities
{
    public class UserTests
    {
        [Fact]
        public void User_Should_Store_Email_And_PasswordHash()
        {
            var user = new User("test@example.com", "hashed123");

            Assert.Equal("test@example.com", user.Email);
            Assert.Equal("hashed123", user.PasswordHash);
        }

        [Fact]
        public void VerifyPassword_Should_Return_True_When_HashMatches()
        {
            var user = new User("test@example.com", "hashed123");

            var result = user.VerifyPassword("hashed123");

            Assert.True(result);
        }

        [Fact]
        public void VerifyPassword_Should_Return_False_When_HashDoesNotMatch()
        {
            var user = new User("test@example.com", "hashed123");

            var result = user.VerifyPassword("wronghash");

            Assert.False(result);
        }
    }
}
