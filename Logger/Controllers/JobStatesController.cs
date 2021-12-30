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
    public class JobStatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobStatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobStates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobState>>> GetJobStates([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var jobState = new JobState()
            {
              ArticleKey = "A1",
              DateTime = DateTime.Now,
              DeviceAddress = "D1",
              JobKey = "J1",
              RejectReason = "Undefined",
              Text = "Inwork",
            };

            await _context.JobStates.AddRangeAsync(jobState);
            await _context.SaveChangesAsync();
            return await _context.JobStates.Where(e => e.DateTime >= start && e.DateTime <= end).ToListAsync();
        }

        // GET: api/JobStates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobState>> GetJobState(int id)
        {
            var jobState = await _context.JobStates.FindAsync(id);

            if (jobState == null)
            {
                return NotFound();
            }

            return jobState;
        }

        //// PUT: api/JobStates/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutJobState(int id, JobState jobState)
        //{
        //    if (id != jobState.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(jobState).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!JobStateExists(id))
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

        //// POST: api/JobStates
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<JobState>> PostJobState(JobState jobState)
        //{
        //    _context.JobStates.Add(jobState);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetJobState", new { id = jobState.Id }, jobState);
        //}

        //// DELETE: api/JobStates/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteJobState(int id)
        //{
        //    var jobState = await _context.JobStates.FindAsync(id);
        //    if (jobState == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.JobStates.Remove(jobState);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool JobStateExists(int id)
        {
            return _context.JobStates.Any(e => e.Id == id);
        }
    }
}
