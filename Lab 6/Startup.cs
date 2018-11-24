using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lab_5.Repositories;
using System.IO;

namespace Lab_5
{
    public class Startup
    {
        public IConfiguration _Configuration;
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            IConfigurationBuilder builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("TreaterSettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            services.Configure<TreaterSettings>(configuration);
            services.AddTransient<ITreaterRepository, TreaterJsonRepository>();
            services.AddTransient<ICandyRepository, CandyJsonRepository>();
            services.AddTransient<ICostumeRepository, CostumeJsonRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            string baseDir = env.ContentRootPath;
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(baseDir, "App_Data"));
        }
    }
}
