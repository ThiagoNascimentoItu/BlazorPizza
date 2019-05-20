using BlazorPizza.Server.Controllers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorPizza.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        //    var host = CreateHostBuilder(args).Build();
        //    // INICIALIZA A BASE DE DADOS
        //    var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();
        //    using (var scope = scopeFactory.CreateScope())
        //    {
        //        var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
        //        if (db.Database.EnsureCreated())
        //        {
        //            SeedData.Initialize(db);
        //        }
        //    }
        //    host.Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //    .ConfigureWebHostDefaults(webBuilder =>
        //    {
        //        webBuilder.UseStartup<Startup>();
        //    });


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build())
                .UseStartup<Startup>()
                .Build();
    }
}
