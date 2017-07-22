using System;
using Hangfire.SqlServer;
using Hangfire.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Hangfire.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var sqlServerStorageOptions = new SqlServerStorageOptions();
            //sqlServerStorageOptions.QueuePollInterval = TimeSpan.FromSeconds(5);
            
            GlobalConfiguration.Configuration.UseSqlServerStorage("Hangfire");

            //var dashboardOptions = new DashboardOptions();
            //dashboardOptions.StatsPollingInterval = 5;

            app.UseHangfireDashboard();
            //app.UseHangfireServer();
        }
    }
}