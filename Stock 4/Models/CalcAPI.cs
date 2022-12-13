using System.ComponentModel.DataAnnotations;

namespace Stock_4.Models
{
    public class CalcAPI
    {
        [Key]
        public int Id { get; set; }
        public int Qty { get; set; }
        public float Stockprice { get; set; }
        public int StampDuty { get; set; }
        public float Brokerage { get; set; }
        public float TotalPrice { get; set; }
    }
}
