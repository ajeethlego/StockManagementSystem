
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock4.Models
{
    public class AuthorizedUser
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        [Column(TypeName ="Date")]
        public DateTime DateOfBirth { get; set; }
        public string PanNumber { get; set; }
        public int IncomePerAnum { get; set; }
        public string EmploymentType { get; set; }
        public string CityName { get; set; }
        public int Pincode { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        //public List<StockList> stockLists { get; set; }
        public float AvailableFund { get; set; }
        public List<UserWatchlist1> UserWatchlist1 { get; set; }

    }
}
