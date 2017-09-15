﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mlpp.ApplicationService.Product;
using Mlpp.Domain.Product;
using Mlpp.Infrastructure.Storage;
using Mlpp.Infrastructure.Storage.Mlpp;
using Mlpp.Infrastructure.Storage.Mlpp.Repository;
using Mlpp.QueryService.Product;
using System.Net;
using Mlpp.Toolkit;

namespace Mlpp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IAggregateFactory, AggregateFactory>();
            services.AddTransient<IReadOnlyMlppContext, ReadOnlyMlppContext>();
            services.AddTransient<IUnitOfWork<MlppContext>, UnitOfWork<MlppContext>>();
            
            services.AddTransient<IProductQueryService, ProductQueryService>();

            // db
            var connectionString = Configuration["Database:ConnectionString"];
            services.AddDbContext<MlppContext>(options => options.UseSqlServer(connectionString));

            // automapper
            services.AddAutoMapper(x => x.AddProfiles("Mlpp.QueryService"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseExceptionHandler(
                options => {
                    options.Run(
                        async context =>
                        {
                            var ex = context.Features.Get<IExceptionHandlerFeature>();
                            if (ex.Error is ValidationException)
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            }
                            else
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            }

                            await context.Response.WriteAsync(ex.Error.Message).ConfigureAwait(false);
                        });
                }
            );

            app.UseMvc();
        }
    }
}
