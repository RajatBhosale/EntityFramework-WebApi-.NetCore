﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.Api.Context;
using CityInfo.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace CityInfo.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o =>
               {
                   o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());   //output formatter to support application/xml
               });
            // For changing serializer setting
            //.AddJsonOptions(o =>
            //    {
            //    if (o.SerializerSettings.ContractResolver != null)
            //        {
            //            var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
            //            castedResolver.NamingStrategy = null;
            //        }
            //    }
            //);
            var connectionString = _configuration["connectionStrings:cityInfoDBConnectionString"];

            services.AddDbContext<CityInfoContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });
            services.AddScoped<ICityInfoRepository, CityInfoRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

        }
    }
}
