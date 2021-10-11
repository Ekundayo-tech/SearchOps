using Nest;
using SearchOps.Application.Interface;
using SearchOps.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchOps.Business.Service
{
    public class SearchService : ISearch
    {
        private readonly IElasticClient _client;
        public SearchService(IElasticClient client)
        {
            _client = client;
        }
        public async Task<Mgmt> SearchMgmt(string searchText)
        {
            return _client.SearchAsync<Mgmt>(s => s
                           .From(0)
                           .Size(25)
                           .Query(q => q
                               .Match(m => m
                                   .Field(f => f.name)
                                   .Field(d => d.market)
                                   .Field(d => d.state)
                                   .Query(searchText)
                               )
                           )).Result.Documents.FirstOrDefault();
        }

        public async Task<Property> SearchProperty(string searchText)
        {
            return _client.SearchAsync<Property>(s => s
                .From(0)
                .Size(25)
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.name)
                        .Field(f => f.state)
                        .Field(f => f.streetAddress)
                        .Field(f => f.city)
                        .Field(f => f.formerName)
                        .Query(searchText)
                    )
                )).Result.Documents.FirstOrDefault();
        }

        public async Task<Property> SearchProprtyByMarket(string market)
        {
            return _client.SearchAsync<Property>(s => s
                .From(0)
                .Size(25)
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Mgmt.market.ToList())
                        .Query(market)
                    )
                )).Result.Documents.FirstOrDefault(); ;
        }
    }
}
