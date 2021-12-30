using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Logger.Data;
using Logger.Model;

namespace Logger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementDatasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MeasurementDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MeasurementDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeasurementData>>> GetMeasurementDatum([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var measurementData = new MeasurementData() { 
                DateTimeStamp = DateTime.Now,
                DeviceAddress = "D1",
                Job = "J1",
                Measurement = 1.0,
                MeasureType = "CH",
                Result = true,
                TerminalKey = "T1",
                WireKey = "W1",
            };

            await _context.MeasurementDatum.AddRangeAsync(measurementData);

            await _context.SaveChangesAsync();

            return await _context.MeasurementDatum.Where(e => e.DateTimeStamp >= start && e.DateTimeStamp <= end).ToListAsync();
        }

        // GET: api/MeasurementDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeasurementData>> GetMeasurementData(int id)
        {
            var measurementData = await _context.MeasurementDatum.FindAsync(id);

            if (measurementData == null)
            {
                return NotFound();
            }

            return measurementData;
        }

        //// PUT: api/MeasurementDatas/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMeasurementData(int id, MeasurementData measurementData)
        //{
        //    if (id != measurementData.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(measurementData).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MeasurementDataExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/MeasurementDatas
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<MeasurementData>> PostMeasurementData(MeasurementData measurementData)
        //{
        //    _context.MeasurementDatum.Add(measurementData);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMeasurementData", new { id = measurementData.Id }, measurementData);
        //}

        //// DELETE: api/MeasurementDatas/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMeasurementData(int id)
        //{
        //    var measurementData = await _context.MeasurementDatum.FindAsync(id);
        //    if (measurementData == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.MeasurementDatum.Remove(measurementData);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool MeasurementDataExists(int id)
        {
            return _context.MeasurementDatum.Any(e => e.Id == id);
        }
    }
}
