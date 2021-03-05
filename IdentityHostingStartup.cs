
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CRM.Models;
using CRM.Services;
using CRM.Data;
using System;

[assembly: HostingStartup(typeof(CRM.IdentityHostingStartup))]
namespace CRM
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DbConnection")));
                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();
                services.Configure<DataProtectionTokenProviderOptions>(o =>
                    o.TokenLifespan = TimeSpan.FromHours(3));
                services.AddTransient<IEmailSender,EmailSender>();
                services.Configure<AuthMessageSenderOptions>(context.Configuration);
            });
        }
    }
}