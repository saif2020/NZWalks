using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class TokenHandler : ITokenHandler
    {
        public Task<string> CreateTokenAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
