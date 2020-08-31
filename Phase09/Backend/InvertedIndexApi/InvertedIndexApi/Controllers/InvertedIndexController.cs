using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Elasticsearch.Net;
using InvertedIndex.QueryProcessor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Validator.Exceptions;

namespace InvertedIndexApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvertedIndexController : ControllerBase
    {
        private readonly ILogger<InvertedIndexController> _logger;
        private readonly IQueryProcessor queryProcessor;

        public InvertedIndexController(IQueryProcessor queryProcessor, ILogger<InvertedIndexController> logger)
        {
            this.queryProcessor = queryProcessor;
            _logger = logger;
        }


        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get(string query = "Hello", int numberToTake = 10)
        {
            try
            {
                var result = await Task.FromResult(queryProcessor.PerformSearch(query, numberToTake));
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}