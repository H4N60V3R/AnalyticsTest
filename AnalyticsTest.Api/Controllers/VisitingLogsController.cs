using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalyticsTest.Api.Models;

namespace AnalyticsTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitingLogsController : ControllerBase
    {
        private readonly AnalyticsTestContext _context;

        public VisitingLogsController(AnalyticsTestContext context)
        {
            _context = context;
        }

        // GET: api/VisitingLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitingLog>>> GetVisitingLogs()
        {
            return await _context.VisitingLogs.ToListAsync();
        }

        // GET: api/VisitingLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitingLog>> GetVisitingLog(int id)
        {
            var visitingLog = await _context.VisitingLogs.FindAsync(id);

            if (visitingLog == null)
            {
                return NotFound();
            }

            return visitingLog;
        }

        // PUT: api/VisitingLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitingLog(int id, VisitingLog visitingLog)
        {
            if (id != visitingLog.VisitLogId)
            {
                return BadRequest();
            }

            _context.Entry(visitingLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitingLogExists(id))
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

        // POST: api/VisitingLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VisitingLog>> PostVisitingLog(VisitingLog visitingLog)
        {
            _context.VisitingLogs.Add(visitingLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisitingLog", new { id = visitingLog.VisitLogId }, visitingLog);
        }

        // DELETE: api/VisitingLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VisitingLog>> DeleteVisitingLog(int id)
        {
            var visitingLog = await _context.VisitingLogs.FindAsync(id);
            if (visitingLog == null)
            {
                return NotFound();
            }

            _context.VisitingLogs.Remove(visitingLog);
            await _context.SaveChangesAsync();

            return visitingLog;
        }

        private bool VisitingLogExists(int id)
        {
            return _context.VisitingLogs.Any(e => e.VisitLogId == id);
        }
    }
}
