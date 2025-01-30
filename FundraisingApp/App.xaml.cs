using FundraisingAppProcessor.Data;
using FundraisingAppProcessor.Repositories;
using FundraisingAppProcessor.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace FundraisingApp
{
    public partial class App : Application
    {
        public static ServiceProvider? Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Services = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            var connectionString = @"Data Source=LAPTOP-N5VPC8I0;Initial Catalog=Fundraising;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            // DbContext
            services.AddDbContext<FundraisingContext>(options =>
                options.UseSqlServer(connectionString));

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMoneyBoxRepository, MoneyBoxRepository>();

            // Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMoneyBoxService, MoneyBoxService>();
        }
    }
}
