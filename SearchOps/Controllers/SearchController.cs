using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nest;
using Octokit;
using SearchOps.Application.Interface;
using SearchOps.Business.Service;
using SearchOps.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchOps.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        //private readonly IMediator _mediator;
        private readonly ILogger<SearchController> _logger;
        private readonly IElasticClient _client;
        private readonly ISearch _serch;

        public SearchController(ILogger<SearchController> logger, IElasticClient client, ISearch searchClient)
        {
            _logger = logger;
            _client = client;
           // _mediator = mediator;
            _serch = searchClient;
        }

        [HttpGet]
        public async Task<ActionResult> SearchMgmts(string searchText)
        {
            var read = await _serch.SearchMgmt(searchText);
            //await _mediator.Send(read);
            return Ok(read);
            
            //return _client.SearchAsync<Mgmt>(s => s
            //    .From(0)
            //    .Size(25)
            //    .Query(q => q
            //        .Match(m => m
            //            .Field(f => f.name)
            //            .Field(d => d.market)
            //            .Field(d => d.state)
            //            .Query(searchText)
            //        )
            //    )).Result.Documents.FirstOrDefault();
        }

        [HttpGet("{searchText}")]
        public async Task<ActionResult> SearchProperties(string searchText)
        {
            var read = _serch.SearchProperty(searchText);
            // _mediator.Send(read);
            return Ok(read);
            //return _client.SearchAsync<Property>(s => s
            //    .From(0)
            //    .Size(25)
            //    .Query(q => q
            //        .Match(m => m
            //            .Field(f => f.name)
            //            .Field(f => f.state)
            //            .Field(f => f.streetAddress)
            //            .Field(f => f.city)
            //            .Field(f => f.formerName)
            //            .Query(searchText)
            //        )
            //    )).Result.Documents.FirstOrDefault();
        }

        [HttpGet("{market}")]
        public async Task<ActionResult> SearchPropertiesByMarket(string market)
        {
            var read = _serch.SearchProprtyByMarket(market);
           //await _mediator.Send(read);
            return Ok(read);
            
        //    return _client.SearchAsync<Property>(s => s
        //        .From(0)
        //        .Size(25)
        //        .Query(q => q
        //            .Match(m => m
        //                .Field(f => f.Mgmt.market.ToList())
        //                .Query(market)
        //            )
        //        )).Result.Documents.FirstOrDefault();
        }
    }
}
