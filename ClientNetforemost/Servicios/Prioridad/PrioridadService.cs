using Newtonsoft.Json;

namespace ClientNetforemost.Servicios.Prioridad
{
    public class PrioridadService : IPrioridadService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public PrioridadService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            _httpClient.BaseAddress = new Uri("http://localhost:5043/api/");
        }

        public async Task<List<Entidad.Prioridad>> GetPrioridades()
        {

            var apiKey = _config
                ["ApiSettings:ApiKey"];

            if (!_httpClient.DefaultRequestHeaders.Contains("x-api-key"))
            {
                _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey
                );

            }

            var response = await _httpClient.GetAsync("Prioridad");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Entidad.Prioridad>>(content) ?? new List<Entidad.Prioridad>();
        }
    }
}



