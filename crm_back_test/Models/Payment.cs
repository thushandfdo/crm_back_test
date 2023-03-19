﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace crm_back_test.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        //[Required, ForeignKey("Project")]
        //public int ProjectId { get; set; }

        //[JsonIgnore]
        //public Project Project { get; set; }

        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }

        [Required]
        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public string StripeId { get; set; } = string.Empty;
    }
}
