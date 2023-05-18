using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OcelotGateway;

public class DopplerApi
{
    [JsonPropertyName("USERSERVICE_CONFIG_OCELOT")]
    public string UserServiceConfig { get; set; } = string.Empty;     
    
    [JsonPropertyName("BASE_URL_OCELOT")]
    public string BaseUrlOcelot { get; set; } = string.Empty;    
    

    public static async Task<DopplerApi> FetchSecretsAsync()
    {
        var client = new HttpClient();
        var dopplerToken = Environment.GetEnvironmentVariable("DOPPLER_TOKEN");
        var basicAuthHeaderValue = Convert.ToBase64String(Encoding.Default.GetBytes(dopplerToken + ":"));

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicAuthHeaderValue);
        var streamTask = client.GetStreamAsync("https://api.doppler.com/v3/configs/config/secrets/download?format=json");
        var secrets = await JsonSerializer.DeserializeAsync<DopplerApi>(await streamTask);

        return secrets is null
            ? throw new Exception("Could not read secrets from doppler.")
            : secrets;
    }
}
