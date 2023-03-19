using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace crm_back_test.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        public DateTime SoldDate { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [JsonIgnore]
        public Project? Project { get; set; }

        [ForeignKey("Enduser")]
        public int EnduserId { get; set; }

        [JsonIgnore]
        public Enduser? Enduser { get; set; }
    }
}
