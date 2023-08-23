using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CustomerWebAPI.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string customerCode { get; set; }
        [Required]
        [MaxLength(225)]
        public string? customerName { get; set; }
        [MaxLength(1000)]
        [Column("customerAddress")]
        [DefaultValue("")]
        [Required]
        public string customerAddress { get; set; }
        [Required]
        public int createdBy { get; set; }
        [Required]
        public DateTime? createdAt { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime? modifiedAt { get; set; }
    }
}