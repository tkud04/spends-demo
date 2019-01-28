using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using SpendsDemo.Models;
using SpendsDemo.Helpers;
using SpendsDemo.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace SpendsDemo
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<SpendsContext>(options =>
			   options.UseSqlite(Configuration.GetConnectionString("SpendsContext")
			));
			
			services.AddDbContext<UploadsContext>(options =>
			   options.UseSqlite(Configuration.GetConnectionString("UploadsContext")
			));
			
			//services.AddDefaultIdentity<IdentityUser>()
			  //      .AddEntityFrameworkStores<SpendsDemoIdentityDbContext>();
			
			services.Configure<IdentityOptions>(options =>
			{
				//password settings
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;
				
				//Lockout settings
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = true;
				
				//User settings
				options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = false;
			});
			
			services.ConfigureApplicationCookie(options => 
			{
				//Cookie settings
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
				
				options.LoginPath = "/Identity/Account/Login";
				options.LogoutPath = "/Identity/Account/Logout";
				options.AccessDeniedPath = "/Identity/Account/AccessDenied";
				options.SlidingExpiration = true;
			});
			
			services.AddSingleton<IDemoHelper, DemoHelper>();
			//services.AddScoped<RoleManager<IdentityRole>, RoleManager<IdentityRole>>();
			
            services.AddMvc(config => {
				var policy = new AuthorizationPolicyBuilder()
				                 .RequireAuthenticatedUser()
								 .Build();
				config.Filters.Add(new AuthorizeFilter(policy));
			}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
		{
			//Add custom roles here
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
			
			string[] roles = {"SuperAdmin","Admin","User"};
			IdentityResult roleResult;
			
			foreach(var r in roles)
			{
				var roleExists = await roleManager.RoleExistsAsync(r);
				if(!roleExists)
				{
					roleResult = await roleManager.CreateAsync(new IdentityRole(r));
				}
			}
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
			app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
			CreateRoles(serviceProvider).Wait();
        }
		
		
    }
}
