using FluentValidation.AspNetCore;
using MealPlanner.Business.Component;
using MealPlanner.Mappings;
using Business = MealPlanner.Mappings;
using MealPlanner.DataAccess.Repository;
using MealPlanner.Database.Context;
using MealPlanner.Web.Api.CustomExceptionMiddleware;
using MealPlanner.Web.Api.Extensions;
using MealPlanner.Web.Api.Helpers;
using Web = MealPlanner.Web.Mappings;
using MealPlanner.Web.Validation;
using MealPlanner.Web.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Utils = Utilities.Logging;

namespace MealPlanner.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var validationAssemblyFullname = Configuration.GetValue<string>("ValidationAssembly");
            services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssembly(Assembly.Load(new AssemblyName(validationAssemblyFullname))));

            //options =>
            //{
            //    options.Filters.Add(typeof(ValidationActionFilter));
            //})

            string dbConnString = Configuration.GetConnectionString("meals");
            services.AddDbContext<MealPlannerDbContext>(options => options.UseSqlServer(dbConnString, b => b.MigrationsAssembly("MealPlanner.Database.Migrations")));
            services.AddTransient<IMealPlannerRepository, MealPlannerRepository>();
            services.AddTransient<IMealPlannerHelper, MealPlannerHelper>();
            services.AddTransient<IMealPlannerComponent, MealPlannerComponent>();
            
            services.AddTransient<IMealPlannerDbContext, MealPlannerDbContext>();
            
            
            ConfigureMappers(services);
            //ConfigureLogger(services,loggerFactory);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.ConfigureCustomExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        public void ConfigureMappers(IServiceCollection services)
        {
            var mealPlannerDomainMapper = new MealPlannerDomainMapper(new MealPlannerDomainMappingConfigurationProvider());
            services.AddSingleton<MealPlannerDomainMapper>(mealPlannerDomainMapper);

            var mealPlannerModelMapper = new MealPlannerModelMapper(new MealPlannerModelMappingConfigurationProvider());
            services.AddSingleton<MealPlannerModelMapper>(mealPlannerModelMapper);
        }

        public void ConfigureLogger(IServiceCollection services,ILoggerFactory loggerFactory)
        {
            //
            //services.AddSingleton<Utils.LoggerFactory>(new Utils.LoggerFactory(loggerFactory));
        }
    }
}
