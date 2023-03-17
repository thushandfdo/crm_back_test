using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crm_back_test.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        public DateTime SoldDate { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project? Project { get; set; }

        [ForeignKey("Enduser")]
        public int EnduserId { get; set; }

        public Enduser? Enduser { get; set; }
    }
}
