using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace crm_back_test.Models
{
    public class LoginUser
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        public User? User { get; set; }

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }
    }
}
