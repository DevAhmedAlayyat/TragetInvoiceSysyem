using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TargetInvoiceSystem.Core.ServicesInterfaces;
using TargetInvoiceSystem.Infrastructure.Data;
using TargetInvoiceSystem.Infrastructure.Services;

namespace TargetInvoiceSystem.WepApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddMvcOptions(opt =>
            {
                opt.EnableEndpointRouting = false;
            }
            ).AddNewtonsoftJson();
            services.ConfigureCors();
            services.ConfigureDatabase(_configuration["ConnectionStrings:AppDbContext"]);
            services.ConfigureIdentity(_configuration);

            services.AddScoped<DbContext, AppDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuthLogin, AuthLogin>();
            services.AddScoped<IAuthRegister, AuthRegister>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseMvc();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
