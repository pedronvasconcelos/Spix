using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Spix.Application.Core;
using Spix.Application.Interfaces;
using Spix.Application.Users.RegisterUser;
 
using System.Net.Http.Headers;
using System.Text;

namespace Spix.Infra.Keycloak;

public class KeycloakClient : IUserService
{

    private readonly KeycloakConfig _keycloakConfig;

    public KeycloakClient( IOptions<AppSettings> appSettings)
    {
        _keycloakConfig = appSettings.Value.Keycloak;
    }

    private async Task<string> GetAdminAccessToken()
    {
        using var _httpClient = new HttpClient();
        var requestContent = new FormUrlEncodedContent(new[]
         {
            new KeyValuePair<string, string>("client_id", _keycloakConfig.ClientId),
            new KeyValuePair<string, string>("client_secret", _keycloakConfig.ClientSecret),
            new KeyValuePair<string, string>("grant_type", "client_credentials")
        });

        var response = await _httpClient.PostAsync(_keycloakConfig.Authority + "/protocol/openid-connect/token", requestContent);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
        if (tokenResponse is null || !tokenResponse.ContainsKey("access_token"))
        {
            throw new HttpRequestException("Keycloak did not return an access token");
        }
        return tokenResponse["access_token"];
    }

    public async Task<bool> CreateUserAsync(CreateUserCommand command)
    {
        using var _httpClient = new HttpClient();
        var accessToken = await GetAdminAccessToken();
        var user = UserRepresentation.FromCommand(command); 
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(_keycloakConfig.Authority + $"/admin/realms/{_keycloakConfig.Realm}/users", content);    
        response.EnsureSuccessStatusCode();
        return true;
    }


}
