using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crm_back_test.Models
{
    public class Customer
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        public User? User { get; set; }

        [Required, Column(TypeName = "nvarchar(50)")]
        public string Company { get; set; } = string.Empty;
    }
}
