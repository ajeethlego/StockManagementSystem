using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalcApiLocal.Data;
using CalcApiLocal.Models;
using CalcApiLocal.Interface;

namespace CalcApiLocal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly ICalc _context;

        public CalcController(ICalc context)
        {
            _context = context;
        }

        // GET: api/Calc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalcRes>>> GetcalcRes()
        {
            return _context.GetCalc();
        }

        //GET: api/Calc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalcRes>> GetCalcRes(int id)
        {
            var calcRes = _context.GetCalcId(id);


            //var calcRes = await _context.calcRes.FindAsync(id);

            //if (calcRes == null)
            //{
            //    return NotFound();
            //}

            return calcRes;
        }

        // PUT: api/Calc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutCalcRes(int id, CalcRes calcRes)
        {
            if (id != calcRes.Id)
            {
                return BadRequest();
            }

            _context.Entry(calcRes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalcResExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/Calc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CalcRes>> PostCalcRes(CalcRes calcRes)
        {


            //var calc = new CalcRes();
            //{
            //    calc.Qty = calcRes.Qty;
            //    calc.Stockprice = calcRes.Stockprice;
            //    calc.StampDuty = 1;
            //    calc.Brokerage = (calcRes.Stockprice * calcRes.Qty) * 0.02f;
            //    calc.TotalPrice = ((calcRes.Stockprice * calcRes.Qty) - calc.Brokerage) - calc.StampDuty;
            //}
            _context.Create(calcRes);

            return CreatedAtAction("GetCalcRes", new { id = calcRes.Id }, calcRes);
        }

        // DELETE: api/Calc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalcRes(int id)
        {
            //var calcRes = await _context.calcRes.FindAsync(id);
            //if (calcRes == null)
            //{
            //    return NotFound();
            //}

            //_context.calcRes.Remove(calcRes);
            //await _context.SaveChangesAsync();
            var delcal = _context.GetCalcId(id);
            _context.Delete(delcal);

            return NoContent();
        }

        //private bool CalcResExists(int id)
        //{
        //    return _context..Any(e => e.Id == id);
        //}
    }
}
