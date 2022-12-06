using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock_4.Models
{
    public class API_HolidayLocal
    {
        [Key]
        public int Id { get; set; }
        public string Occasion { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; } 
    }

}
