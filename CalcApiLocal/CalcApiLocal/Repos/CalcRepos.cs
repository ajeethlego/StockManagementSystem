using CalcApiLocal.Data;
using CalcApiLocal.Interface;
using CalcApiLocal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalcApiLocal.Repos
{
    public class CalcRepos : ICalc
    {
        private readonly CalcContext _context;

        public CalcRepos(CalcContext context)
        {
            _context = context;
        }

        public CalcRepos()
        { }
        public List<CalcRes> GetCalc()
        {
            return _context.calcRes.ToList();
        }

        CalcRes ICalc.GetCalcId(int id)
        {
            return _context.calcRes.FirstOrDefault(w => w.Id == id);
        }

        public void Create(CalcRes calcRes)
        {
            var calc = new CalcRes();
            {
                calc.Qty = calcRes.Qty;
                calc.Stockprice = calcRes.Stockprice;
                calc.StampDuty = 1;
                calc.Brokerage = (calcRes.Stockprice * calcRes.Qty) * 0.02f;
                calc.TotalPrice = ((calcRes.Stockprice * calcRes.Qty) - calc.Brokerage) - calc.StampDuty;
            }
            _context.calcRes.Add(calc);
            _context.SaveChanges();
           // return (IActionResult)calc;
        }

        public void Delete(CalcRes calcRes)
        {
            _context.calcRes.Remove(calcRes);
            _context.SaveChanges();
        }

        
    }
}
