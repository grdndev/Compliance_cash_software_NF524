using CLICore.Data;
using CLISyncService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


string appSettingsFile = environment == "Production" ?
    "appsettings.Production.json" : environment == "Staging" ?
    "appsettings.Staging.json" : environment == "Development" ? "appsettings.Development.json": "appsettings.Local.json";

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile(appSettingsFile, false, true)
    .Build();


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostcontext,services) =>
    {
        

   
    var conn=configuration.GetConnectionString("ConnectionStringCLI");


        services.AddDbContext<CLIContext>(options =>
                options.UseSqlServer(conn, o => o.UseCompatibilityLevel(100)));

        services.AddHostedService<Worker>();
        services.AddHostedService<TransfertExpeditor>();
        services.AddHostedService<TransfertDPD>();

    })
    .Build();


host.Run();



