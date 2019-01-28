using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpendsDemo.Areas.Identity.Data;

[assembly: HostingStartup(typeof(SpendsDemo.Areas.Identity.IdentityHostingStartup))]
namespace SpendsDemo.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SpendsDemoIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("SpendsDemoIdentityDbContext")));

                services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<SpendsDemoIdentityDbContext>();
            });
        }
    }
}