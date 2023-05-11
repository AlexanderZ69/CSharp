using WebApp.BL.Interfaces;
using WebApp.DL.Interfaces;
using WebApp.MODELS.Data.Users;

namespace WebApp.BL.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public async Task Add(string email, string password)
        {

            await _userInfoRepository.Add(new UserInfo()
            {
                Id = Guid.NewGuid(),
                Password = password,
                Email = email
            });
        }

        public async Task<UserInfo?> GetUserInfo(string email, string password)
        {
            return await _userInfoRepository.GetUserInfo(email, password);
        }
    }
}
