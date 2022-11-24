using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Stock4.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock_4.Models
{
    public class UserPortfolio
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StockId { get; set; }
        public string StockName { get; set; }
        public int Qty { get; set; }
        public float BoughtAt { get; set; }
        public float BoughtAtTotal { get; set; }
        public float CurrentPrice { get; set; }
        public float CurrentPriceTotal { get; set; }
        public float ProfOrLoss { get; set; }
        public StockList Stock { get; set; }
        public AuthorizedUser User { get; set; }
    }
}
