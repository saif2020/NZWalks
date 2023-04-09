using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> Users = new List<User>()
        {
            new User()
            {
                Id = Guid.NewGuid(),
                UserName = "johndoe",
                EmailAddress = "johndoe@example.com",
                Password = "password123",
                Roles = new List<string>() { "reader" },
                FirstName = "John",
                LastName = "Doe"
            },
            new User()
            {
                Id = Guid.NewGuid(),
                UserName = "janedoe",
                EmailAddress = "janedoe@example.com",
                Password = "password456",
                Roles = new List<string>() { "reader", "writer" },
                FirstName = "Jane",
                LastName = "Doe"
            }
        };
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = Users.Find(x => x.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
            x.Password == password);

            return user;
        }
    }
}
