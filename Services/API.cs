using ProyectoG3.Models;
namespace ProyectoG3.Services
{
    public class API
    {
        private readonly HttpClient _httpClient;

        public API(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("ApiService");
        }

        public async Task<List<Emisor>> GetEmisores()
        {
            var response = await _httpClient.GetAsync("Varios/GetEmisor");
            response.EnsureSuccessStatusCode();

            var emisores = await response.Content.ReadFromJsonAsync<List<Emisor>>();

            if (emisores == null)
            {
                throw new InvalidOperationException("No se recibieron datos");
            }

            return emisores;
        }
    }
}
