using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Test.Api.GraphQL;
using GraphQL.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;
using Microsoft.Extensions.Configuration;

namespace Test.Api
{

    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            
            services.AddSingleton<DatastreamType>();
            services.AddSingleton<TestSchema>();

            services.AddGraphQLHttpTransport<TestSchema>();            
            services.AddGraphQLWebSocketsTransport<TestSchema>();
            services.AddGraphQL();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder =>
                builder
                    .WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseWebSockets();
            app.UseGraphQLEndPoint<TestSchema>("/api/graphql");
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
