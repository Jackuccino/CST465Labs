using System;
using System.Data.SqlClient;
using FinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FinalProject.Areas.Identity.IdentityHostingStartup))]
namespace FinalProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LoginContext>(options =>
                    options.UseSqlServer(
                        context.Configuration["LoginContextConnection"]));

                services.AddIdentity<CustomIdentityUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = false;
                })
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<LoginContext>();

                //services.AddDefaultIdentity<CustomIdentityUser>(options =>
                //{
                //    options.Password.RequireDigit = false;
                //    options.Password.RequiredLength = 5;
                //    options.Password.RequireLowercase = true;
                //    options.Password.RequireNonAlphanumeric = true;
                //    options.Password.RequireUppercase = false;
                //})
                //.AddRoles<IdentityRole>()
                //.AddEntityFrameworkStores<LoginContext>();
            });
        }
    }
}