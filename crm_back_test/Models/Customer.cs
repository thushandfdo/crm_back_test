using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crm_back_test.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(30)")]
        public string Company { get; set; } = string.Empty;

        [Required, Column(TypeName = "nvarchar(30)")]
        public string ContactPerson { get; set; } = string.Empty;

        [Required, Column(TypeName = "nvarchar(15)")]
        public string ContactNo { get; set; } = string.Empty;

        [Required, Column(TypeName = "nvarchar(30)")]
        public string Email { get; set; } = string.Empty; 
    }
}
