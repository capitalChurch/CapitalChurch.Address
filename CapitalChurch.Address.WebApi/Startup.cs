using System;
using AutoMapper;
using CapitalChurch.Address.Data;
using CapitalChurch.Address.Shared;
using CapitalChurch.Address.WebApi.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CapitalChurch.Address.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private const string corsPolicy = "AllowAnythingForGet";

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(opts => opts.EnableEndpointRouting = true)
                .AddJsonOptions(opts => opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddDbContext<AddressContext>(opts =>
                opts.UseNpgsql(_configuration["ConnectionString"], builder =>
                    builder.UseNetTopologySuite()));

            services
                .AddCors(opts =>
                    opts.AddPolicy(corsPolicy, builder => builder
                        .AllowAnyHeader()
                        .AllowAnyOrigin()));

            services.AddApiVersioning(opts => opts.ReportApiVersions = true);
            services.AddVersionedApiExplorer(opts =>
            {
                opts.GroupNameFormat = "'v'VVV";
                opts.SubstituteApiVersionInUrl = true;
            });

            services.AddAutoMapper(typeof(Startup));

            services.Add(AllProviders.All);
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
        {
            if(env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors(corsPolicy);
            app.UseSwagger();
            app.UseSwaggerUI(opts =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                    opts.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
            });

            app.UseMvc();
        }
    }
}