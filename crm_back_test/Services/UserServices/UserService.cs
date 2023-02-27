using crm_back_test.Data;
using crm_back_test.Models;
using Microsoft.EntityFrameworkCore;

namespace crm_back_test.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User?> getUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            return user;
        }

        public async Task<List<User>?> getUsers()
        {
            var notes = await _context.Users.ToListAsync();

            return notes;
        }

        public async Task<List<User>?> postUser(User newUser)
        {
            var user = await _context.Users.Where(user => 
                user.Username.Equals(newUser.Username) || user.Email.Equals(newUser.Email)
            ).FirstOrDefaultAsync();

            if (user != null)
            {
                return null;
            }

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>?> putUser(int userId, User newUser)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return null;
            }

            user.Type = (newUser.Type == "") ? user.Type : newUser.Type;
            user.Username = (newUser.Username == "") ? user.Username : newUser.Username;
            user.Password = (newUser.Password == "") ? user.Password : newUser.Password;
            user.FirstName = (newUser.FirstName == "") ? user.FirstName : newUser.FirstName;
            user.LastName = (newUser.LastName == "") ? user.LastName : newUser.LastName;
            user.ContactNo = (newUser.ContactNo == "") ? user.ContactNo : newUser.ContactNo;
            user.Email = (newUser.Email == "") ? user.Email : newUser.Email;
            user.ProfilePic = (newUser.ProfilePic == "") ? user.ProfilePic : newUser.ProfilePic;

            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>?> deleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }
    }
}
