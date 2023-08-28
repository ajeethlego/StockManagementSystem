﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolidayAPILocal.Data;
using HolidayAPILocal.Models;

namespace HolidayAPILocal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly HolidayContext _context;

        public HolidaysController(HolidayContext context)
        {
            _context = context;
        }

        // GET: api/Holidays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Holiday>>> Getholidays()
        {
            return await _context.holidays.ToListAsync();
        }

        // GET: api/Holidays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Holiday>> GetHoliday(int id)
        {
            var holiday = await _context.holidays.FindAsync(id);

            if (holiday == null)
            {
                return NotFound();
            }

            return holiday;
        }

        // PUT: api/Holidays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoliday(int id, Holiday holiday)
        {
            if (id != holiday.Id)
            {
                return BadRequest();
            }

            _context.Entry(holiday).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HolidayExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Holidays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Holiday>> PostHoliday(Holiday holiday)
        {
            _context.holidays.Add(holiday);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoliday", new { id = holiday.Id }, holiday);
        }

        //DELETE: api/Holidays/5

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoliday(int id)
        {
            var holiday = await _context.holidays.FindAsync(id);
            if (holiday == null)
            {
                return NotFound();
            }

            _context.holidays.Remove(holiday);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HolidayExists(int id)
        {
            return _context.holidays.Any(e => e.Id == id);
        }
    }
}
