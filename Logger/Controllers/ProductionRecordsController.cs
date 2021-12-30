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
    public class ProductionRecordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductionRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductionRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionRecord>>> GetProductionRecords([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var record = new ProductionRecord() { 
                ArticleKey = "A1",
                CrimpToolSide1 = "T1",
                CrimpToolSide2 = "T2",
                DateTimeEnd = DateTime.Now,
                DateTimeInWork = DateTime.Now.AddMinutes(-10),
                JobKey = "J1",
                NoGoodSealSide1 = 10,
                NoGoodSealSide2 = 10,
                NoGoodTerminalSide1 = 10,
                NoGoodTerminalSide2 = 10,
                NoGoodWireLength = 10,
                SealSide1 = "S1",
                SealSide2 = "S2",
                State = "Done",
                TerminalSide1 = "T1",
                TerminalSide2 = "T2",
                TotalGood = 100,
                WireKey = "W1"
            };

            await _context.ProductionRecords.AddAsync(record);

            await _context.SaveChangesAsync();

            return await _context.ProductionRecords.Where(e=>e.DateTimeInWork >= start && e.DateTimeEnd <= end).ToListAsync();
        }

        // GET: api/ProductionRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionRecord>> GetProductionRecord(Guid id)
        {
            var productionRecord = await _context.ProductionRecords.FindAsync(id);

            if (productionRecord == null)
            {
                return NotFound();
            }

            return productionRecord;
        }

        //// PUT: api/ProductionRecords/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProductionRecord(Guid id, ProductionRecord productionRecord)
        //{
        //    if (id != productionRecord.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(productionRecord).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductionRecordExists(id))
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

        //// POST: api/ProductionRecords
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ProductionRecord>> PostProductionRecord(ProductionRecord productionRecord)
        //{
        //    _context.ProductionRecords.Add(productionRecord);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProductionRecord", new { id = productionRecord.Id }, productionRecord);
        //}

        //// DELETE: api/ProductionRecords/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProductionRecord(Guid id)
        //{
        //    var productionRecord = await _context.ProductionRecords.FindAsync(id);
        //    if (productionRecord == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.ProductionRecords.Remove(productionRecord);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool ProductionRecordExists(Guid id)
        {
            return _context.ProductionRecords.Any(e => e.Id == id);
        }
    }
}
