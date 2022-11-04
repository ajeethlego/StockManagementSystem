using System.ComponentModel.DataAnnotations;

namespace Stock_4.Models
{
    public class AdminDetails
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        [Required]
        public string AdminPassword { get; set; }

    }
}

