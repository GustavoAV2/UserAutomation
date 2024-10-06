using System.Net.Http.Json;

public class KeycloakService {
    public HttpClient client { get; set; }

    public KeycloakService()
    {
        client = new();
    }

    public async Task<HttpResponseMessage> PostUser(string uri){
        var content = JsonContent.Create("");
        return await client.PostAsync(uri, content);
    }

    public async Task<HttpResponseMessage> GetUserKcIdByEmail(string uri){
        return await client.GetAsync(uri);
    }
}