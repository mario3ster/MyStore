namespace MyStore.Backend
{
    using Microsoft.AspNetCore.Hosting;    
    using Microsoft.Extensions.Hosting;    

    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = new WebHostBuilder()
                .UseKestrel()
                // .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                // .UseUrls("https://localhost:5050")
                .Build();

            host.Run();
        }

        // public static IHostBuilder CreateHostBuilder(string[] args) =>
        //     Host.CreateDefaultBuilder(args)
        //         .ConfigureWebHostDefaults(webBuilder =>
        //         {
        //             webBuilder.UseStartup<Startup>();
        //         });
    }
}
