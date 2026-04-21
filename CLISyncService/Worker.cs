namespace CLISyncService;

using System.Net.Http.Json;
using CLICore.Data;
using CLICore.Models;
using CLIPrestashopConnector.Dtos;
using System.Text.Json;
using System.Text.Json.Serialization;

using System.Text;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private Boolean isProcessing;
    private readonly IConfiguration _configuration;
    private Int32 _CliMinimalApiCallDelay;
    private string _CliMinimalApiXApiKey;
    private string _CliMinimalApiUrl;
    private ToCliDto _toCliDto;

    private readonly string _ConnectionStringCLI;

    private CLIContext _cliContext;
    private HttpClient _client;
    private IServiceProvider _serviceProvider;

    public Worker(ILogger<Worker> logger, IConfiguration configuration, IServiceProvider serviceProvider, CLIContext clicontext)
    {
        _logger = logger;
        // _configuration = configuration;
        // _ConnectionStringCLI = _configuration.GetValue<string>("App:ConnectionStringCLI");
        _cliContext = clicontext;
        // _serviceProvider=serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (!isProcessing)
            {
                isProcessing = true;



                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //récuperation du delai
                _CliMinimalApiCallDelay = Convert.ToInt32(_cliContext.TParams.Where(c => c.Paramname == "CliMinimalApiCallDelay").First().Paramvalue);
                _CliMinimalApiXApiKey = _cliContext.TParams.Where(c => c.Paramname == "CliMinimalApiXApiKey").First().Paramvalue;
                _CliMinimalApiUrl = _cliContext.TParams.Where(c => c.Paramname == "CliMinimalApiUrl").First().Paramvalue;
                _client = new HttpClient();
                _client.BaseAddress = new Uri(_CliMinimalApiUrl);
                _client.DefaultRequestHeaders.Add("XApiKey", _CliMinimalApiXApiKey);

                //On récupère l'appel non traité le plus ancien
                var appel = _cliContext.TApiCalls.Where(c => c.CallDate == null).OrderBy(c => c.CallDate).FirstOrDefault();
                if (appel != null)
                {
                    try
                    {
                        _toCliDto = JsonSerializer.Deserialize<ToCliDto>(appel.Params);
                        HttpResponseMessage response = await _client.PostAsJsonAsync(
                 appel.Url, _toCliDto);
                        response.EnsureSuccessStatusCode();
                    }
                    catch (Exception ex)
                    {

                    }

                    appel.CallDate = DateTime.Now;
                    _cliContext.Update(appel);
                    _cliContext.SaveChanges();

                }


                isProcessing = false;
                await Task.Delay(_CliMinimalApiCallDelay, stoppingToken);
            }

        }
    }
}

