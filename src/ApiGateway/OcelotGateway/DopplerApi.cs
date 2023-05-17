using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OcelotGateway;

public class DopplerApi
{
    [JsonPropertyName("ROUTES_FOR_OCELOT")]
    public string RoutesForOcelot { get; set; } = string.Empty;    
    
    [JsonPropertyName("USERDB_CONNECTION_STRING")]
    public string UserDbConnectionString { get; set; } = string.Empty;

    [JsonPropertyName("BOOKDB_CONNECTION_STRING")]
    public string BookDbConnectionString { get; set; } = string.Empty;

    public static async Task<DopplerApi> FetchSecretsAsync()
    {
        var client = new HttpClient();
        var dopplerToken = Environment.GetEnvironmentVariable("DOPPLER_TOKEN");
        var basicAuthHeaderValue = Convert.ToBase64String(Encoding.Default.GetBytes(dopplerToken + ":"));

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicAuthHeaderValue);
        var streamTask = client.GetStreamAsync("https://api.doppler.com/v3/configs/config/secrets/download?format=json");
        var secrets = await JsonSerializer.DeserializeAsync<DopplerApi>(await streamTask);

        return secrets is null
            ? throw new Exception("Woa scheisse")
            : secrets;
    }
}
