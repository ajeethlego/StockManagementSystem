using Stock_4.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stock4.Models
{
    public class StockList
    {
        [Key]
        public int StockId { get; set; }
        [Required]
        public string StockName { get; set; }
        public float StockPrice { get; set; }
        //public AuthorizedUser User { get; set; }

        public List<UserWatchlist1> UserWatchlist1 { get; set; }

    }
}
