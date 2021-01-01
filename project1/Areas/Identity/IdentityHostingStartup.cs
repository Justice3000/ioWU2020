using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


[assembly: HostingStartup(typeof(project1.Areas.Identity.IdentityHostingStartup))]
namespace project1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseInMemoryDatabase(
                        context.Configuration.GetConnectionString("ApplicationDbContextConnection")));

                services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

                services.AddAuthorization(opt => {
                    opt.AddPolicy("user",
                    builder => builder.RequireRole("admin", "manager", "user"));

                    opt.AddPolicy("manager",
                    builder => builder.RequireRole("admin", "manager"));

                    opt.AddPolicy("admin",
                    builder => builder.RequireRole("admin"));
                });

        
                    
            });
        }
    }
}