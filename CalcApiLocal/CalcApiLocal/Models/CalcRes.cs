using System.ComponentModel.DataAnnotations;

namespace CalcApiLocal.Models
{
    public class CalcRes
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
