using WebApp.MODELS.Data.Users;
using WebApp.MODELS.Request;

namespace WebApp.BL.Interfaces
{
    public interface IUserInfoService
    {
        Task Add(string email, string password); 
        Task<UserInfo?> GetUserInfo(string email, string password);
    }
}
