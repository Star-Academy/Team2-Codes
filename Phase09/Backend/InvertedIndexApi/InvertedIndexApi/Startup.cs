using System;
using InvertedIndex.QueryProcessor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IElasticClient>(provider => new ElasticClient(GetElasticSetting()));
            services.AddTransient<IQueryProcessor>(provider =>
                new ElasticQueryProcessor(provider.GetService<IElasticClient>(), IndexName));
            services.AddControllers();
        }

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