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
    public class ErrorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ErrorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Errors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Error>>> GetError([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var error = new Error()
            {
                ErrorCategory = "E1C",
                ErrorText = "Error",
                ErrorExtension = "E1E",
                DeviceAddress = "D1",
                DateTime = DateTime.Now,
                ErrorKey ="E1K",
            };
            await _context.Error.AddAsync(error);
            await _context.SaveChangesAsync();
            return await _context.Error.Where(e=>e.DateTime >= start && e.DateTime <= end).ToListAsync();
        }

        // GET: api/Errors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Error>> GetError(int id)
        {
            var error = await _context.Error.FindAsync(id);

            if (error == null)
            {
                return NotFound();
            }

            return error;
        }

        
        private bool ErrorExists(int id)
        {
            return _context.Error.Any(e => e.Id == id);
        }
    }
}
