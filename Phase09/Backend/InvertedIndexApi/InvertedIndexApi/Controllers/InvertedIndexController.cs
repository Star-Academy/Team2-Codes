using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvertedIndex.Models;
using InvertedIndex.QueryProcessor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvertedIndexApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvertedIndexController : ControllerBase
    {
        private readonly ILogger<InvertedIndexController> _logger;
        private readonly IQueryProcessor queryProcessor;
        private const string QueryMustNotEmpty = "Query Must not be empty!";

        public InvertedIndexController(IQueryProcessor queryProcessor, ILogger<InvertedIndexController> logger)
        {
            this.queryProcessor = queryProcessor;
            _logger = logger;
        }


        [Route("documents/[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Search( string query = "",
             int size = 10, int page = 1)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest(QueryMustNotEmpty);
            }

            try
            {
                var result = await Task.FromResult(queryProcessor.PerformSearch(query, size, page));
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("documents/get/{id}")]
        [HttpGet]
        public async Task<ActionResult<Document>> GetById([FromRoute] string id)
        {
            try
            {
                var result = await Task.FromResult(queryProcessor.GetDocumentByID(id));
                if (result != Document.Null)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}