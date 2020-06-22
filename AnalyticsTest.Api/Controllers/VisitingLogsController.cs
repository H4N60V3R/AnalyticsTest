using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalyticsTest.Api.Models;
using System.Net;

namespace AnalyticsTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitingLogsController : ControllerBase
    {
        private readonly StartDone_AnalyticsContext _context;

        public VisitingLogsController(StartDone_AnalyticsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostVisitingLog(object analiseData)
        {
            

            return StatusCode(201);
        }
    }
}
