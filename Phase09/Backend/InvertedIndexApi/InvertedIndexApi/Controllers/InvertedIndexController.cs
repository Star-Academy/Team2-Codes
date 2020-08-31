using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvertedIndex.QueryProcessor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvertedIndexApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvertedIndexController : ControllerBase
    {
        private readonly ILogger<InvertedIndexController> _logger;
        private readonly IQueryProcessor queryProcessor;

        public InvertedIndexController(IQueryProcessor queryProcessor , ILogger<InvertedIndexController> logger)
        {
            this.queryProcessor = queryProcessor;
            _logger = logger;
        }


        [Route("[action]")]
        [HttpGet]
        public IEnumerable<string> Get(string query , int numberToTake = 10)
        {

            var result = queryProcessor.PerformSearch(query, numberToTake);
            return result;
        }
    }
}