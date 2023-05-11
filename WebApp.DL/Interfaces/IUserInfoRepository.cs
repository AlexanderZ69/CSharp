using WebApp.MODELS.Data.Users;

namespace WebApp.DL.Interfaces
{
    public interface IUserInfoRepository
    {
        Task Add(UserInfo userInfo);
        Task<UserInfo?> GetUserInfo(string email, string password);
    }
}
