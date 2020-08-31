using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvertedIndex.QueryProcessor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nest;

namespace InvertedIndexApi
{
    public class Startup
    {
        private const string ElasticAddress = "http://localhost:9200/";
        private const string IndexName = "document_test";
        public ConnectionSettings GetElasticSetting()
        {
            var uri = new Uri(ElasticAddress);
            var settings = new ConnectionSettings(uri);
            settings.EnableDebugMode();
            return settings;
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IElasticClient>(provider => new ElasticClient(GetElasticSetting()));
            services.AddTransient<IQueryProcessor>(provider =>
                new ElasticQueryProcessor(provider.GetService<IElasticClient>(), IndexName));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}