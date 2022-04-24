using EVDFKG_HFT_2021221.Data;
using EVDFKG_HFT_2021221.Endpoint.Services;
using EVDFKG_HFT_2021221.Logic;
using EVDFKG_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVDFKG_HFT_2021221.Endpoint
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

            services.AddControllers();
            services.AddTransient<ICpuLogic, CpuLogic>();
            services.AddTransient<IMotherboardLogic, MotherboardLogic>();
            services.AddTransient<IRamLogic, RamLogic>();
            services.AddTransient<IComboLogic, ComboLogic>();
            services.AddSignalR();
            services.AddTransient<ICpuRepository, CpuRepository>();
            services.AddTransient<IMotherboardRepository, MotherboardRepository>();
            services.AddTransient<IRamRepository, RamRepository>();
            services.AddTransient<IComboRepository, ComboRepository>();

            services.AddTransient<ComponentDbContext, ComponentDbContext>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:27079"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
