using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crm_back_test.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(30)")]
        public string Title { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(MAX)")]
        public string Details { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(20)")]
        public string Category { get; set; } = string.Empty;
    }
}
