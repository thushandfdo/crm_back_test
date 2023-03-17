using crm_back_test.DTOs;
using crm_back_test.Models;

namespace crm_back_test.Services.LoginUserServices
{
    public interface ILoginUserService
    {
        Task<LoginUser?> getLoginUser(int userId);
        Task<LoginUser?> postLoginUser(DTOUser newLoginUser);
        Task<LoginUser?> putLoginUser(int userId, DTOUser newLoginUser);
        Task<LoginUser?> deleteLoginUser(int userId);
        Task<string?> login(DTOUser user);
        Task<DTOLoginUser?> getTokenData();
    }
}
