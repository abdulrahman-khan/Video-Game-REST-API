using Azure.Core;
using VideoGamesAPI.Entities;
using VideoGamesAPI.Models;

namespace VideoGamesAPI.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<string?> LoginAsync(UserDto request);
    }
}
