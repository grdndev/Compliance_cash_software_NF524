using CLICore.Dtos;

namespace CLICore.Services.User;

public interface IUserService
{
    Task<UserProfileDto> GetUserProfileAsync(string login, string password);
    Task<UserProfileDto> GetUserProfileAsync(string codeBar);
}
