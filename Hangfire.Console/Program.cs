using System;
using Hangfire.Shared;
using Hangfire.SqlServer;
using Ninject;

namespace Hangfire.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Starting hangfire server...");
            
            var standardKernel = new StandardKernel();

            standardKernel.Bind<IPageLoadEventHandler>().To<PageLoadEventHandler>();

            var backgroundJobServerOptions = new BackgroundJobServerOptions();
            backgroundJobServerOptions.Activator = new NinjectJobActivator(standardKernel);

            var sqlServerStorageOptions = new SqlServerStorageOptions();
            sqlServerStorageOptions.QueuePollInterval = TimeSpan.FromSeconds(3);

            var sqlServerStorage = new SqlServerStorage("Hangfire", sqlServerStorageOptions);
            
            using (new BackgroundJobServer(backgroundJobServerOptions, sqlServerStorage))
            {
                System.Console.WriteLine("Press any key to exit...");
                System.Console.ReadKey();
            }
        }
    }
}
