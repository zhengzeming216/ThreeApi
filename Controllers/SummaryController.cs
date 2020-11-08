using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeApi.Models;
using ThreeApi.Repositories;

namespace ThreeApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly ISummaryRepository summaryRepository;

        public SummaryController(ISummaryRepository summaryRepository)
        {
            this.summaryRepository = summaryRepository;
        }

        public async Task<IActionResult> Get()
        {
            var result = await summaryRepository.GetCompanySummary();
            return Ok(result);
        }
    }
}
