using Autofac;
using Autofac.Extensions.DependencyInjection;
using Buisness.DependencyResolvers.AutoFac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory()) // servis saðlayýcýsý olarak kullan
                 .ConfigureContainer<ContainerBuilder>(builder =>
                 {
                     builder.RegisterModule(new AutoFacBuisnessModule());
                 }) // .net core yerine baþka bir ýoc container kullanmak istersem diye
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
