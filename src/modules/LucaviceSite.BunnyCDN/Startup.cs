using System;
using Lucavice.BunnyCDN.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Handlers;
using Lucavice.BunnyCDN.Services;
using Microsoft.Extensions.Configuration;
using Lucavice.BunnyCDN.Options;

namespace Lucavice.BunnyCDN
{
    public class Startup : StartupBase
    {
        private IConfiguration config { get; set; }
        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<BunnyCdnOptions>(config.GetSection(BunnyCdnOptions.BunnyCdn));
            services.AddScoped<PurgeService>();
            services.AddHttpClient<PurgeService>();    
            services.AddScoped<IContentHandler, PurgeHandler>();
      
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {

        }
    }
}