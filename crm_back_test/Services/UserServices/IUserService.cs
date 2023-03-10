using crm_back_test.Models;

namespace crm_back_test.Services.UserServices
{
    public interface IUserService
    {
        public Task<User?> getUser(int userId);
        public Task<List<User>?> getUsers();
        public Task<User?> postUser(User newUser);
        public Task<User?> putUser(int userId, User newUser);
        public Task<User?> deleteUser(int userId);
    }
}
