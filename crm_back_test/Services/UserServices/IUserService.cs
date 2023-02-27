using crm_back_test.Models;

namespace crm_back_test.Services.UserServices
{
    public interface IUserService
    {
        public Task<User?> getUser(int userId);
        public Task<List<User>?> getUsers();
        public Task<List<User>?> postUser(User newUser);
        public Task<List<User>?> putUser(int userId, User newUser);
        public Task<List<User>?> deleteUser(int userId);
    }
}
