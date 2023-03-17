using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crm_back_test.Models
{
    public class Enduser
    {
        [Key]
        public int EnduserId { get; set; }

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Company { get; set; } = string.Empty;
    }
}
