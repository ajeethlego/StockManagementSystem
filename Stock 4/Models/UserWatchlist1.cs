using Stock4.Models;
using System.ComponentModel.DataAnnotations;

namespace Stock4.Models
{
    public class UserWatchlist1
    {
        [Key]
        public int Id { get; set; }
        public int StockId { get; set; }
        public StockList Stock { get; set; }
        public int UserId { get; set; }
        public AuthorizedUser User { get; set; }



    }
}
