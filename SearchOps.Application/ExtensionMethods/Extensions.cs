//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Nest;
//using Octokit;
//using SearchOps.Application.Interface; 
//using SearchOps.Domain.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SearchOps.Business.ExtensionMethods
//{
//    public static class ElasticsearchExtensions
//    {
//        public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
//        {
//            var url = configuration["elasticsearch:url"];
//            var defaultIndex = configuration["elasticsearch:index"];

//            var settings = new ConnectionSettings(new Uri(url))
//                .DefaultIndex(defaultIndex);

//            AddDefaultMappings(settings);

//            var client = new ElasticClient(settings);

//            services.AddSingleton(client);
//            //services.AddHttpContextAccessor();
//            //services.AddScoped<ISearch, SearchService>();

//            CreateIndex(client, defaultIndex);
//        }

//        private static void AddDefaultMappings(ConnectionSettings settings)
//        {
//            settings.
//                DefaultMappingFor<Mgmt>(m => m
//                .Ignore(p => p.name)
//                .Ignore(p => p.state)
//                .Ignore(p => p.market)
//            );
//            settings.
//               DefaultMappingFor<Property>(m => m
//               .Ignore(p => p.name)
//               .Ignore(p => p.state)
//               .Ignore(p => p.market)
//            );
//        }

//        private static void CreateIndex(IElasticClient client, string indexName)
//        {

//            var createIndexResponse = client.Indices.Create(indexName,
//                index => index.Map<Mgmt>(x => x.AutoMap())
//            );

//            var createIndexResponses = client.Indices.Create(indexName,
//                index => index.Map<Property>(x => x.AutoMap())
//            );
//        }
//    }
//}
