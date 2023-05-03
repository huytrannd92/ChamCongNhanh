using Schedule.Api.Models;

namespace Schedule.Api.Infrastructure.Providers
{
    public interface IUserInfoProvider
    {
        public Task<UserInfoDto> GetUserInfoAsync(string email, string phoneNumber);
    }
}
