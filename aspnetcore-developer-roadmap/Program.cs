namespace aspnetcore_developer_roadmap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) 
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration(builder =>
               {
                   var configuration = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json", false, true)
                       .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
                       .AddCommandLine(args)
                       .AddEnvironmentVariables()
                       .Build();

                   builder.Sources.Clear();
                   builder.AddConfiguration(configuration);
               })
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
        }
    }
}