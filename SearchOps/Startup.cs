using Elasticsearch.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Nest;
using Octokit;
using SearchOps.Application.Interface;
using SearchOps.Business.Service;
using SearchOps.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchOps
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var url = configuration["elasticsearch:url"];
            var defaultIndex = configuration["elasticsearch:index"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddElasticsearch(Configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SearchOps", Version = "v1" });
            });
            var settings = new ConnectionSettings(new Uri("http://localhost:9200/")).DefaultMappingFor<Mgmt>(x => x.IndexName("newmgmts"));
            ////var connection = Substitute.For<IApiConnection>();
            //var client = new RepositoriesClient();
            services.AddSingleton<IElasticClient>(new ElasticClient(settings));
            //services.AddTransient<ISearchClient, SearchClient>();
            services.AddHttpContextAccessor();
            services.AddScoped<ISearch, SearchService>();
            //services.AddMediatR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SearchOps v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
