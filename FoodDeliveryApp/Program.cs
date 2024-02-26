using AutoMapper;
using FoodDeliveryApp;
using FoodDeliveryApp.Util;


public static class Program

{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Initialize configuration
        IConfiguration configuration = builder.Configuration;
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

}